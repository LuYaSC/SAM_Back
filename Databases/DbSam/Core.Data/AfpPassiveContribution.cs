using SAM.Core.DataDb;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Databases.DbSam.Core.Data
{
    public class AfpPassiveContribution : Base
    {
        [MaxLength(100)]
        public string CodeBase { get; set; }

        [MaxLength(100)]
        public string DocumentNumber { get; set; }

        [MaxLength(80)]
        public string Name { get; set; }

        [MaxLength(80)]
        public string FirstLastName { get; set; }

        [MaxLength(80)]
        public string SecondLastName { get; set; }

        [MaxLength(80)]
        public string Sector { get; set; }

        [MaxLength(110)]
        public string Salary { get; set; }

        [MaxLength(100)]
        public string Contribution { get; set; }

        [MaxLength(30)]
        public string DateUp { get; set; }

        [MaxLength(80)]
        public string DepositNumber { get; set; }

        [MaxLength(25)]
        public string DateDeposit { get; set; }

        [MaxLength(25)]
        public string DateSiverOld { get; set; }

        [MaxLength(100)]
        public string Bank { get; set; }

        [MaxLength(30)]
        public string AmountDeposit { get; set; }

        [MaxLength(200)]
        public string MonthExplicit { get; set; }

        [MaxLength(200)]
        public string YearExplicit { get; set; }

        [MaxLength(100)]
        public string Regional { get; set; }

        [MaxLength(500)]
        public string Observations { get; set; }

        [MaxLength(100)]
        public string TypeDeposit { get; set; }

        [MaxLength(30)]
        public string QuantityAports { get; set; }
    }
}
