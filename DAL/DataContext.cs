using DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DataContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public new virtual DbSet<User> Users { get; set; }
        public new virtual DbSet<Role> Roles { get; set; }
        public new virtual DbSet<RoleClaim> RoleClaims { get; set; }
        public new virtual DbSet<UserClaim> UserClaims { get; set; }
        public new virtual DbSet<UserLogin> UserLogins { get; set; }
        public new virtual DbSet<UserRole> UserRoles { get; set; }
        public new virtual DbSet<UserToken> UserTokens { get; set; }

        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // identity tables
            builder.Entity<User>(e => e.ToTable($"{nameof(User)}s"));
            builder.Entity<Role>(e => e.ToTable($"{nameof(Role)}s"));
            builder.Entity<UserClaim>(e => e.ToTable($"{nameof(UserClaim)}s"));
            builder.Entity<UserRole>(e => e.ToTable($"{nameof(UserRole)}s"));
            builder.Entity<UserLogin>(e => e.ToTable($"{nameof(UserLogin)}s"));
            builder.Entity<RoleClaim>(e => e.ToTable($"{nameof(RoleClaim)}s"));
            builder.Entity<UserToken>(e => e.ToTable($"{nameof(UserToken)}s"));
        }
    }
}
