using Microsoft.AspNetCore.Identity;
using System;

namespace DAL.Entities
{
    public class User : IdentityUser<int>
    {        
        public User() : base()
        {
            base.ConcurrencyStamp = Guid.NewGuid().ToString();
            base.SecurityStamp = Guid.NewGuid().ToString();
        }

        public User(string userName) : base(userName)
        {
            base.ConcurrencyStamp = Guid.NewGuid().ToString();
            base.SecurityStamp = Guid.NewGuid().ToString();
        }
    }
}
