using iRED.Model;
using iRED.ViewModel.Helpers;
using iRED.ViewModel.JsonResult;
using iRED.ViewModel.JsonResult.Request;
using Microsoft.AspNetCore.Mvc;
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
        private readonly Configs _configInfo;
        public WxOpenApiController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _configInfo = GlobalServices.GetService<Configs>();
        }

        [ActionDescription("登录")]
        [HttpPost("OnLogin")]
        public async Task<IActionResult> OnLogin(WxLoginRequest req)
        {
            var appId = _configInfo.Wx.AppID;
            var appSecret = _configInfo.Wx.AppSecret;
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
            if (res.errcode == 0)
            {
                var sessionKey = res.session_key;
                var openId = res.openid;
                if (!EncryptHelper.CheckSignature(sessionKey, req.rawData, req.signature))
                {
                    return BadRequest("签名校验失败");
                }

                var decodedEntity = EncryptHelper.DecodeUserInfoBySessionKey(sessionKey, req.encryptedData, req.iv);
                if (decodedEntity != null && decodedEntity.CheckWatermark(appId))
                {
                    return Ok(openId);
                }
                return BadRequest("水印验证不通过");
            }
            return BadRequest(res.errcodeName);
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
                new Claim(ClaimTypes.Name, user.NickName)
            };

            var token = JwtHelper.CreateToken(claims, _configInfo.Jwt);
            return token;
        }
    }
}