using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Core.Data
{
    public class MinistryActiveContribution : Base
    {
        [MaxLength(15)]
        public string CARNET_AA { get; set; }
        public string PATERNO_AA { get; set; }
        public string MATERNO_AA { get; set; }
        public string NOMBRE1_AA { get; set; }
        public string NOMBRE2_AA { get; set; }
        public string PROGRAMA_AA { get; set; }
        public string SERVICIO_AA { get; set; }
        public string ITEM_AA { get; set; }
        public string DESCUENTO_AA { get; set; }
        public string SUELDO_AA { get; set; }
        public DateTime FECHAAPORTES_AA { get; set; }
        public string CATEGORIA { get; set; }
    }
}
