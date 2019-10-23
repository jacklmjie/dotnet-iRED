using iRED.Helpers;
using iRED.Model;
using iRED.Settings;
using iRED.ViewModel.JsonResult;
using iRED.ViewModel.JsonResult.Request;
using iRED.ViewModel.Mp.WxUserVMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Mvc;

namespace iRED.Areas.Api.Controllers
{
    [Area("Api")]
    [ActionDescription("微信开放平台")]
    [ApiController]
    [Route("api/WxOpen")]
    public class WxOpenApiController : BaseApiController
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly JwtSettings _jwtSettings;
        private readonly WxSettings _wxSettings;
        public WxOpenApiController(IHttpClientFactory clientFactory,
            IOptions<JwtSettings> jwtSettings,
            IOptions<WxSettings> wxSettings)
        {
            _clientFactory = clientFactory;
            _jwtSettings = jwtSettings.Value;
            _wxSettings = wxSettings.Value;
        }

        [ActionDescription("登录")]
        [HttpPost("OnLogin")]
        public async Task<IActionResult> OnLogin(WxLoginRequest req)
        {
            var appId = _wxSettings.AppID;
            var appSecret = _wxSettings.AppSecret;
            string urlFormat = "/sns/jscode2session?appid={0}&secret={1}&js_code={2}&grant_type={3}";
            var url = string.Format(urlFormat, appId, appSecret, req.code, "authorization_code");
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _clientFactory.CreateClient("wx");
            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                DoLog($"{url}未响应", ActionLogTypesEnum.Exception);
                return BadRequest("系统繁忙");
            }

            var json = response.Content.ReadAsStringAsync().Result;
            var res = JsonConvert.DeserializeObject<JsCode2JsonResult>(json);
            if (res.errcode != 0)
            {
                return BadRequest(res.errcodeName);
            }

            var sessionKey = res.session_key;
            if (!EncryptHelper.CheckSignature(sessionKey, req.rawData, req.signature))
            {
                return BadRequest("签名校验失败");
            }

            var openId = res.openid;
            var user = CreateVM<LoginVM>().DoLogin(openId);
            if (user != null)
            {
                var token = CreateJwtToken(user);
                return Ok(token);
            }

            var decodedUser = EncryptHelper.DecodeUserInfoBySessionKey(sessionKey, req.encryptedData, req.iv);
            if (decodedUser != null && decodedUser.CheckWatermark(appId))
            {
                var wxUser = CreateVM<LoginVM>().DoAdd(decodedUser);
                var token = CreateJwtToken(wxUser);
                return Ok(token);
            }
            return BadRequest("水印验证不通过");
        }

        /// <summary>
        /// 生成Jwt的Token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string CreateJwtToken(WxUser user)
        {
            Claim[] claims =
            {
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                new Claim(ClaimTypes.Name, user.NickName),
                new Claim(ClaimTypes.PrimarySid, user.OpenId),
            };

            var token = JwtHelper.CreateToken(claims, _jwtSettings);
            return token;
        }
    }
}