using SAM.Core.DataDb;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Databases.DbSam.Core.Data
{
    public class Beneficiary : BaseLogicalDelete
    {
        public int BeneficiaryTypeId { get; set; }

        [ForeignKey("BeneficiaryTypeId")]
        public virtual BeneficiaryType BeneficiaryType { get; set; }

        [MaxLength(100)]
        public string DocumentNumber { get; set; }

        [MaxLength(15)]
        public string CodeBase { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(80)]
        public string FirstLastName { get; set; }

        [MaxLength(80)]
        public string SecondLastName { get; set; }

        [MaxLength(80)]
        public string MarriedLastName { get; set; }

        [MaxLength(100)]
        public string Sector { get; set; }

        //AFP Benecifiaries
        [MaxLength(15)]
        public string CITE { get; set; }

        [Column(TypeName = "decimal")]
        public decimal Aport { get; set; }

        public DateTime? ApplicationDate { get; set; }

        public DateTime? ActivateDate { get; set; }

        [MaxLength(500)]
        public string Letter { get; set; }

        public DateTime? BirthDate { get; set; }

        [MaxLength(25)]
        public string PhoneNumber { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        //Senasir Pasives

        [MaxLength(50)]
        public string Concatenated { get; set; }

        [MaxLength(25)]
        public string EnrollmentTitular { get; set; }

        [MaxLength(25)]
        public string EnrollmentBeneficiary { get; set; }

        //normal

        /*public int RegionalId { get; set; }

        [ForeignKey("RegionalId")]
        public virtual Regional Regional { get; set; }

        public int DistrictId { get; set; }

        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }*/

        [MaxLength(50)]
        public string Regional { get; set; }

        [MaxLength(100)]
        public string District { get; set; }

        [MaxLength(500)]
        public string Observations { get; set; }
        
    }
}
