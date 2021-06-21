using Microsoft.EntityFrameworkCore;
using SAM.Databases.DbSam.Core.Data;
using SAM.Databases.DbSam.Core.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Functions.ResolveCasesSiver.Business
{
    public class ResolveCasesSiverContext : SAMContext
    {
        public ResolveCasesSiverContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<MinistryActiveContribution> MinistryActiveContributions { get; set; }

        public DbSet<MumanalActiveContribution> MumanalActiveContributions { get; set; }

        public DbSet<SeveranceBonusContribution> SeveranceBonusContributions { get; set; }

        public DbSet<MumanalPartialActiveBeneficiary> MumanalPartialActiveBeneficiaries { get; set; }

        public DbSet<MumanalFullActiveBeneficiary> MumanalFullActiveBeneficiaries { get; set; }

        public DbSet<MinistryPassiveContribution> MinistryPassiveContributions { get; set; }

        public DbSet<MumanalPassiveContribution> MumanalPassiveContributions { get; set; }

        public DbSet<MumanalPassiveBeneficiary> MumanalPassiveBeneficiaries { get; set; }
    }
}

