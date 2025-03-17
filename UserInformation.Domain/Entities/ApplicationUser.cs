using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInformation.Domain.Entities
{
    #nullable disable
    public class ApplicationUser : IdentityUser
    {
        public DateTime RegistrationDate { get; set; }
        public string Name { get; set; }
        public string UserType { get; set; }
        public int EntityId { get; set; }
        public bool Active { get; set; }
        public string UserAvatar { get; set; }
    }
}
