using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Core.Data
{
    public class MinistryPassiveContribution : Base
    {
        [MaxLength(60)]
        public string T_MATRICULA_AP { get; set; }

        [MaxLength(60)]
        public string B_MATRICULA_AP { get; set; }

        [MaxLength(60)]
        public string PATERNO_AP { get; set; }

        [MaxLength(60)]
        public string MATERNO_AP { get; set; }

        [MaxLength(60)]
        public string NOMBRES_AP { get; set; }

        [MaxLength(60)]
        public string DECASADA_AP { get; set; }

        [MaxLength(20)]
        public string CARNET_AP { get; set; }

        public decimal DESCUENTO_AP { get; set; }

        [MaxLength(60)]
        public string DISTRITO_AP { get; set; }

        public string DEPTO_AP { get; set; }

        public DateTime FECHA_AP { get; set; }

        [MaxLength(60)]
        public string SUELDO_AP { get; set; }
    }
}
