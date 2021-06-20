using Microsoft.EntityFrameworkCore;
using SAM.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlGift.Business
{
    public class ControlGiftsContext : SAMContext
    {
        public ControlGiftsContext(DbContextOptions<SAMContext> options) : base(options)
        {

        }


    }
}
