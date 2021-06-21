using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Core.Data
{
    public class BeneficiariosPasivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        public string cod_base { get; set; }
        [MaxLength(100)]
        public string concatenado { get; set; }
        [MaxLength(20)]
        public string cedula_identidad { get; set; }
        [MaxLength(50)]
        public string mat_titular { get; set; }
        [MaxLength(50)]
        public string mat_beneficiario { get; set; }
        [MaxLength(50)]
        public string primer_apellido { get; set; }
        [MaxLength(50)]
        public string segundo_apellido { get; set; }
        [MaxLength(50)]
        public string apellido_casada { get; set; }
        [MaxLength(50)]
        public string primer_nombre { get; set; }
        [MaxLength(50)]
        public string segundo_nombre { get; set; }
        [MaxLength(50)]
        public string regional { get; set; }
        [MaxLength(50)]
        public string distrital { get; set; }
        [MaxLength(250)]
        public string obs { get; set; }

    }
}
