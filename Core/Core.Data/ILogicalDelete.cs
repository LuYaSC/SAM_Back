using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Core.Data
{
    public interface ILogicalDelete
    {
        bool IsDeleted { get; set; }
    }
}
