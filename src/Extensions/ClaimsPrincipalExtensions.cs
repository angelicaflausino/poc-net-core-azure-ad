using System.Security.Claims;

namespace NetCorePocAzureAd.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        private const string ROLE_TYPE = "roles";
        private const string NAME_TYPE = "name";

        public static string GetRoles(this ClaimsPrincipal principal)
        {
            if(principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirstValue(ROLE_TYPE);
        }

        public static string GetName(this ClaimsPrincipal principal)
        {
            if(principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirstValue(NAME_TYPE);
        }
    }
}
