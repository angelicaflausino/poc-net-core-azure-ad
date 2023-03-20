using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.Resource;
using NetCorePocAzureAd.Authorization;
using NetCorePocAzureAd.Extensions;

namespace NetCorePocAzureAd.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Get Authenticated User from Azure AD with App Permission = User
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [RequiredScopeOrAppPermission(AcceptedAppPermission = new[] { AppRoles.User })]
        public IActionResult Get()
        {
            var user = GetUser();

            return Ok(user);
        }

        private dynamic GetUser() =>
            new
            {
                Id = User.GetObjectId(),
                Name = User.GetName(),
                Email = User.GetDisplayName(),
                Roles = User.GetRoles()
            };
    }
}
