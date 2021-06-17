﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Core.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public interface IBase<TypeKey>
    {
        TypeKey Id { get; set; }
    }

    public class Base : Base<int> { }

    public class Base<TypeKey> : IBase<TypeKey>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual TypeKey Id { get; set; }
    }

    public class BaseLogicalDelete : BaseLogicalDelete<int> { }

    public class BaseLogicalDelete<TypeKey> : Base<TypeKey>, ILogicalDelete
    {
        public bool IsDeleted { get; set; }
    }

    public class BaseTrace : BaseTrace<int> { }

    public class BaseTrace<TypeId> : BaseLogicalDelete<TypeId>, IAuditable<int, int>
    {
        [Required]
        public int UserCreation { get; set; }

        [ForeignKey("UserCreation")]
        public virtual ApplicationUser UserCreated { get; set; }

        public int UserModification { get; set; }

        [ForeignKey("UserModification")]
        public virtual ApplicationUser UserModificated { get; set; }

        [Required]
        public DateTime DateCreation { get; set; }

        public DateTime? DateModification { get; set; }
    }

    public class BaseBackOfficeTrace : BaseBackOfficeTrace<int> { }

    public class BaseBackOfficeTrace<Typekey> : BaseLogicalDelete<Typekey>, IBackOfficeAuditable
    {
        [Required]
        [MaxLength(6)]
        public string UserCreation { get; set; }

        [MaxLength(6)]
        public string UserModification { get; set; }

        [Required]
        public DateTime DateCreation { get; set; }

        public DateTime? DateModification { get; set; }
    }

    public class BaseOnlyTrace : BaseOnlyTrace<int> { }

    public class BaseOnlyTrace<TypeKey> : Base<TypeKey>, IAuditable<int, int>
    {
        [Required]
        public int UserCreation { get; set; }

        [ForeignKey("UserCreation")]
        public virtual ApplicationUser UserCreated { get; set; }

        public int UserModification { get; set; }

        [ForeignKey("UserModification")]
        public virtual ApplicationUser UserModificated { get; set; }

        [Required]
        public DateTime DateCreation { get; set; }

        public DateTime? DateModification { get; set; }
    }

}
