using System;
using System.ComponentModel.DataAnnotations;

namespace TerminalBus.Core.ViewModel
{
    public class BoletoViewModel
    {
        [Required]
        public DateTime FechaCompra { get; set; }
        [Required]
        public int Asiento { get; set; }
        [Required]
        public int IdViaje { get; set; }
    }
}
