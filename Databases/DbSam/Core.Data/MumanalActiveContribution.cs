using SAM.Core.DataDb;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Databases.DbSam.Core.Data
{
    public class MumanalActiveContribution : Base
    {
        public string cod_base { get; set; }

        [MaxLength(15)]
        public string cedula_identidad { get; set; }

        public string numbol { get; set; }

        public string aporte { get; set; }

        public string fecha { get; set; }

        public string mes { get; set; }

        public string ctacte { get; set; }
    }
}
