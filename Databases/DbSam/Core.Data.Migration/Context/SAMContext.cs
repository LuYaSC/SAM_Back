using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SAM.Core.DataDb;
using System.Linq;

namespace SAM.Databases.DbSam.Core.Data.MigrationsDb.Context
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

        //tabla global de beneficiarios siver, afp, ministerio
        public DbSet<Beneficiary> Beneficiaries { get; set; }

        //tabla parametrica de tipo de beneficiarios
        public DbSet<BeneficiaryType> BeneficiaryTypes { get; set; }

        public DbSet<Session> Sessions { get; set; }

        //tabla de registro para el control de presentes por regional
        public DbSet<ControlGift> ControlGifts { get; set; }

        //tabla de aportes activos ministerio senasir
        public DbSet<MinistryActiveContribution> MinistryActiveContributions { get; set; }

        //tabla de aportes pasivos senasir
        public DbSet<MinistryPassiveContribution> MinistryPassiveContributions { get; set; }

        //tabla de aportes pasivos afp siver
        public DbSet<AfpPassiveContribution> AfpPassiveContributions { get; set; }

        //tabla de regionales mumnala
        public DbSet<OfficePlace> OfficePlaces { get; set; }

        //tabla de apoetes activos mumanal siver
        public DbSet<MumanalActiveContribution> MumanalActiveContributions { get; set; }

        //tabla de aportes pasivos mumanal siver
        public DbSet<MumanalPassiveContribution> MumanalPassiveContributions { get; set; }

        //tabla de beneficiarios 97000 siver
        public DbSet<MumanalFullActiveBeneficiary> MumanalFullActiveBeneficiaries { get; set; }

        //tabla de beneficiarios 67000 siver
        public DbSet<MumanalPartialActiveBeneficiary> MumanalPartialActiveBeneficiaries { get; set; }

        //tabla de beneficiarios pasivos siver
        public DbSet<MumanalPassiveBeneficiary> MumanalPassiveBeneficiaries { get; set; }

        //tabla de aportes Bono de cesantia sistema mutual
        public DbSet<SeveranceBonusContribution> SeveranceBonusContributions { get; set; }

        //tabla devoluciones ASR
        public DbSet<AsrReturn> AsrReturns { get; set; }

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