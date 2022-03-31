using System;
using CoreUI.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace CoreUI.Models
{
    public class CoreIdentityContext : IdentityDbContext<User>
    {
        public CoreIdentityContext(DbContextOptions<CoreIdentityContext> options)
            : base(options)
        {
        }
        
    }
}