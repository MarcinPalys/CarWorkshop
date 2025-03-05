using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.ApplicationUser
{
    public class CurrentUser
    {
        public CurrentUser(string _Id, string _Email, IEnumerable<string> _Roles)
        {
            Id = _Id;
            Email = _Email;
            Roles = _Roles;
        }
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; } 

        public bool IsInRole(string role) => Roles.Contains(role);
    }
}
