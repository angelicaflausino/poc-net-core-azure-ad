using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Microsoft.Identity.Web;

namespace NetCorePocAzureAd.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MeController : ControllerBase
    {
        private readonly GraphServiceClient _graphServiceClient;

        public MeController(GraphServiceClient graphServiceClient)
        {
            _graphServiceClient = graphServiceClient;
        }

        /// <summary>
        /// Call MS Graph /me
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AuthorizeForScopes(ScopeKeySection = "DownstreamApi:Scopes")]
        public async Task<IActionResult> Get()
        {              
            var user = await _graphServiceClient.Me.Request().GetAsync();

            return Ok(user);
        }
    }
}
