using Microsoft.AspNetCore.Mvc;
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

        private string GetAppSettingValue(string key)
        {
            var kV = ConfigInfo.AppSettings.FirstOrDefault(x => x.Key == key);
            return kV.Value;
        }

        public IdentityApiController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _appID = GetAppSettingValue("AppID");
            _appSecret = GetAppSettingValue("AppSecret");
        }

        [ActionDescription("登录")]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(string code)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"/sns/jscode2session?appid={_appID}&secret={_appSecret}&js_code={code}&grant_type=authorization_code");

            var client = _clientFactory.CreateClient("wx");

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content
                    .ReadAsAsync<string>();
            }
            else
            {

            }
            return Ok("");
        }
    }
}