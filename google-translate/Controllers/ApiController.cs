using Microsoft.AspNetCore.Mvc;
using google_translate.RequestHandler;
using google_translate.Requests;
using google_translate.Responses;

namespace google_translate.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly TranslateRequestHandler _requestHandler;

        public ApiController(TranslateRequestHandler requestHandler)
        {
            _requestHandler = requestHandler;
        }

        [HttpGet("[action]")]
        public Task<TranslateResponse> translate([FromQuery] TranslateRequest request)
        {
            return _requestHandler.Translate(request);
        }
    }
}