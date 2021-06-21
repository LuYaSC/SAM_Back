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
        public ResolveCasesSiverContext(DbContextOptions<SAMContext> options) : base(options)
        {

        }
        public DbSet<MinistryActiveContribution> MinistryActiveContributions { get; set; }

        public DbSet<MumanalActiveContribution> MumanalDatos { get; set; }

        public DbSet<SeveranceBonusContribution> BonoCesantiaDatos { get; set; }

        public DbSet<MumanalPartialActiveBeneficiary> Beneficiarios { get; set; }

        public DbSet<MumanalPartialActiveBeneficiary> beneficiarioBdAportes { get; set; }

        public DbSet<MinistryPassiveContribution> MinistryPassiveContributions { get; set; }

        public DbSet<MumanalPassiveContribution> MumanalAportesPasivos { get; set; }

        public DbSet<MumanalPassiveBeneficiary> BeneficiariosPasivos { get; set; }

        public DbSet<MumanalActiveContribution> MumanalAportesActivos { get; set; }

    }
}

