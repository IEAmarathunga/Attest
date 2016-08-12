using Attest.Web.Models.Application;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Attest.Web
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("AtstContext")
        {

        }

        public DbSet<Application> Applications { get; set; }
    }
}