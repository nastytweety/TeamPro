using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;
using System.Security.Principal;

namespace TeamP.Models.Extensions
{
    public static class IdentityExtension
    {
        public static string GetUrlPicture(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("ProfilePic");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetLogin(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Login");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetUserRole(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("UserRole");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}