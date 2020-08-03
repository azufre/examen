using System.ComponentModel.DataAnnotations;

namespace TerminalBus.Core.ViewModel
{
    public class BusViewModel
    {
        [Required]
        public string Placa { get; set; }
        [Required]        
        public int CantidadAsientos { get; set; }
    }
}
