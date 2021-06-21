using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Core.Data
{
    public class MumanalAportesActivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(25)]
        public string cod_base { get; set; }

        [MaxLength(15)]
        public string cedula_identidad { get; set; }

        [MaxLength(5)]
        public string numbol { get; set; }

        [MaxLength(50)]
        public string aporte { get; set; }

        [MaxLength(15)]
        public string fecha { get; set; }

        [MaxLength(50)]
        public string mes { get; set; }

        [MaxLength(50)]
        public string ctacte { get; set; }
    }
}
