using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.ApplicationUser
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }
    public class UserContext : IUserContext
    {
        IHttpContextAccessor httpContextAccessor;
        public UserContext(IHttpContextAccessor _httpContextAccessor) 
        {
            httpContextAccessor = _httpContextAccessor;
        }
        public CurrentUser? GetCurrentUser()
        {
            var user = httpContextAccessor?.HttpContext?.User;
            if (user == null)
            {
                throw new InvalidOperationException("Context User is not present");
            }
            if (user.Identity == null || !user.Identity.IsAuthenticated) 
            {
                return null;
            }
            var id = user.FindFirst(u => u.Type == ClaimTypes.NameIdentifier)!.Value;
            var email = user.FindFirst(u => u.Type == ClaimTypes.Email)!.Value;
            var roles = user.Claims.Where(r => r.Type == ClaimTypes.Role).Select(r => r.Value);

            return new CurrentUser(id, email, roles);
        }
    }
}
