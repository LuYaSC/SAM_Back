using Microsoft.EntityFrameworkCore;
using SAM.Databases.DbSam.Core.Data;
using SAM.Databases.DbSam.Core.Data.Context;
using System;

namespace SAM.Functions.ReturnsASR.Business
{
    public class ReturnsASRContext : SAMContext
    {
        public ReturnsASRContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AsrReturn> AsrReturns { get; set; }

        public DbSet<Beneficiary> Beneficiaries { get; set; }
    }
}
