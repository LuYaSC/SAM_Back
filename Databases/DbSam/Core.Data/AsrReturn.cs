using SAM.Core.DataDb;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Databases.DbSam.Core.Data
{
    public class AsrReturn : BaseTrace
    {
        public int AsrNumber { get; set; }

        public int ReportNumber { get; set; }

        public int BeneficiaryId { get; set; }

        [ForeignKey("BeneficiaryId")]
        public virtual Beneficiary Beneficiary { get; set; }

        public decimal Amount { get; set; }

        [MaxLength(50)]
        public string DisbursementVoucher { get; set; }
    }
}
