using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Core.Data
{
    public class BeneficiarioBdAporte
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(15)]
        public string cod_base { get; set; }

        [MaxLength(15)]
        public string cedula_identidad { get; set; }

        [MaxLength(100)]
        public string primer_apellido { get; set; }

        [MaxLength(100)]
        public string segundo_apellido { get; set; }

        [MaxLength(100)]
        public string apellido_casada { get; set; }

        [MaxLength(100)]
        public string primer_nombre { get; set; }

        [MaxLength(100)]
        public string segundo_nombre { get; set; }

        public string sector { get; set; }

        public string regional { get; set; }

        public string distrital { get; set; }

        public string obs { get; set; }
    }
}
