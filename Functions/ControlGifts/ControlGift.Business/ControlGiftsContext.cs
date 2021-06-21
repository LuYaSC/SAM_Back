using Microsoft.EntityFrameworkCore;
using SAM.Databases.DbSam.Core.Data;
using SAM.Databases.DbSam.Core.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Functions.ControlGift.Business
{
    public class ControlGiftsContext : SAMContext
    {
        public ControlGiftsContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Beneficiary> Beneficiaries { get; set; }

        public DbSet<Databases.DbSam.Core.Data.ControlGift> ControlGifts { get; set; }

        public DbSet<MinistryActiveContribution> MinistryActiveContributions { get; set; }

        public DbSet<MinistryPassiveContribution> MinistryPassiveContributions { get; set; }

        public DbSet<AfpPassiveContribution> AfpPassiveContributions { get; set; }

        public DbSet<OfficePlace> OfficePlaces { get; set; }

    }
}
