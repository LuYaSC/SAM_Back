using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SAM.Databases.DbSam.Core.Data;
using SAM.Databases.DbSam.Core.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace SAM.Functions.Authorization.MicroService
{
    public class AuthContext : SAMContext
    {
        public AuthContext(DbContextOptions<SAMContext> options) : base(options)
        {

        }

        public DbSet<Session> Sessions { get; set; }
    }

}