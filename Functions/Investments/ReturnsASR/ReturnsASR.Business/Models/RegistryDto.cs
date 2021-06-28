using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM.Functions.Investments.ReturnsASR.Business.Models
{
    public class RegistryDto
    {
        public int BeneficiaryId { get; set; }

        public decimal Amount { get; set; }

        public int AsrNumber { get; set; }

        public int ReportNumber { get; set; }

        public string DisbursementVoucher { get; set; }
    }
}
