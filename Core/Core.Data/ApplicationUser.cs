using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Core.DataDb
{
    public class ApplicationUser : IdentityUser<int>
    {
        public int AvailableDays { get; set; } = 0;

        public bool IsActive { get; set; }

        [Required]
        public DateTime DateCreation { get; set; }

        public DateTime? DateModification { get; set; }

        [MaxLength(1)]
        public string State { get; set; }

        //[MaxLength(100)]
        //public string Name { get; set; }

        //[MaxLength(100)]
        //public string FirstLastName { get; set; }

        //[MaxLength(100)]
        //public string SecondLastName { get; set; }
    }
}
