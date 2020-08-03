
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using TerminalBus.Core.Model;

namespace TerminalBus.Core.Authentication
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            BoletoPasajero = new HashSet<Boleto>();
        }
        public IEnumerable<Boleto> BoletoPasajero { get; set; }
    }
}
