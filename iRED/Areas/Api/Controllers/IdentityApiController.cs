using iRED.ViewModel.JsonResult;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Mvc;

namespace iRED.Areas.Api.Controllers
{
    [Area("Api")]
    [ActionDescription("授权")]
    [ApiController]
    [Route("api/Identity")]
    public class IdentityApiController : BaseApiController
    {
        private readonly IHttpClientFactory _clientFactory;
        private string _appID { get; set; }
        private string _appSecret { get; set; }

        public IdentityApiController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _appID = GetAppSettingValue("AppID");
            _appSecret = GetAppSettingValue("AppSecret");
        }

        private string GetAppSettingValue(string key)
        {
            var kV = GlobalServices.GetService<Configs>().AppSettings.FirstOrDefault(x => x.Key == key);
            if (kV == null)
            {
                DoLog($"key[{key}]不存在", ActionLogTypesEnum.Exception);
                return string.Empty;
            }
            return kV.Value;
        }

        [ActionDescription("登录")]
        [HttpGet("SignIn")]
        public async Task<IActionResult> SignIn(string code)
        {
            string urlFormat = "/sns/jscode2session?appid={0}&secret={1}&js_code={2}&grant_type={3}";
            var url = string.Format(urlFormat, _appID, _appSecret, code, "authorization_code");
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
                return Ok(res.openid);
            }
            return BadRequest(res.errcodeName);
        }
    }
}