using SAM.Core.DataDb;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Databases.DbSam.Core.Data
{
    public class MumanalPassiveContribution : Base
    {
        [MaxLength(20)]
        public string cod_base { get; set; }


        [MaxLength(20)]
        public string cedula_identidad { get; set; }


        [MaxLength(50)]
        public string concatenado { get; set; }

        public string aporte { get; set; }

        [MaxLength(15)]
        public string fecha { get; set; }

        [MaxLength(50)]
        public string mes { get; set; }
    }
}
