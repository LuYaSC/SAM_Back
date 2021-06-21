using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Databases.DbSam.Core.Data
{
    public class MumanalPartialActiveBeneficiary : Base
    {
        [MaxLength(15)]
        public string CARNET_AA { get; set; }

        [MaxLength(15)]
        public string COD_BASE { get; set; }

        [MaxLength(100)]
        public string NOMBRE1_AA { get; set; }

        [MaxLength(100)]
        public string NOMBRE2_AA { get; set; }

        [MaxLength(100)]
        public string PATERNO_AA { get; set; }

        [MaxLength(100)]
        public string MATERNO_AA { get; set; }

        public string SECTOR { get; set; }
    }
}
