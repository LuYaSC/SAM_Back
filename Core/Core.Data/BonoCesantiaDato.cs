﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Core.Data
{
    public class BonoCesantiaDato
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(15)]
        public string CodigoBase { get; set; }

        [MaxLength(15)]
        public string CedulaIdentidad { get; set; }

        public decimal Descuento { get; set; }

        public DateTime Fecha { get; set; }

        public int Mes { get; set; }

        public decimal Sueldo { get; set; }
    }
}
