using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Databases.DbSam.Core.Data
{
    public class Session : Base, IDateCreation
    {
        public string Name { get; set; }

        public string Password { get; set; }

        [MaxLength(50)]
        public string Action { get; set; }

        public DateTime DateCreation { get; set; }
    }
}
