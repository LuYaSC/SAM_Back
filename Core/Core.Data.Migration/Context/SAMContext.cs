using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace SAM.Core.Data.Migration
{
    public class SAMContext : IdentityDbContext<ApplicationUser, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public SAMContext(DbContextOptions<SAMContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys()).Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"SAMContext");
        }

        public DbSet<Beneficiary> Beneficiaries { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<ControlGift> ControlGifts { get; set; }

        public DbSet<MinistryActiveContribution> MinistryActiveContributions { get; set; }

        public DbSet<MinistryPassiveContribution> MinistryPassiveContributions { get; set; }

        public DbSet<AfpPassiveContribution> AfpPassiveContributions { get; set; }

        public DbSet<OfficePlace> OfficePlaces { get; set; }


    }

    public class UserLogin : IdentityUserLogin<int>
    { }

    public class UserClaim : IdentityUserClaim<int>
    { }

    public class UserToken : IdentityUserToken<int>
    { }

    public class RoleClaim : IdentityRoleClaim<int>
    { }
}