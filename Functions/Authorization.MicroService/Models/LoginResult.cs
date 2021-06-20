using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAM.Functions.Authorization.MicroService.Models
{
    public class LoginResult
    {
        public string Token { get; set; }

        public DateTime Expirate { get; set; }
    }
}
