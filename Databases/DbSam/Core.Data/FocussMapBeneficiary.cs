using SAM.Core.DataDb;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Databases.DbSam.Core.Data
{
    public class FocussMapBeneficiary : Base
    {
        public int Page { get; set; }

        [MaxLength(20)]
        public string DocumentNumber { get; set; }

        [MaxLength(100)]
        public string FirstLastName { get; set; }

        [MaxLength(100)]
        public string SecondLastName { get; set; }

        public decimal Amount { get; set; }

        [MaxLength(100)]
        public string FirstLastNameCor { get; set; }

        [MaxLength(100)]
        public string SecondLastNameCor { get; set; }

        [MaxLength(100)]
        public string NameCor { get; set; }

        [MaxLength(50)]
        public string Status { get; set; }
    }
}
