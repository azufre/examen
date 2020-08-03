using System.ComponentModel.DataAnnotations;

namespace TerminalBus.Core.ViewModel
{
    public class ViajeViewModel
    {
        [Required]
        public string Ciudad { get; set; }

        [Required]
        public int HoraSalida { get; set; }

        [Required]
        public int HoraEntrada { get; set; }

        [Required]
        public int IdBus { get; set; }

        [Required]
        public decimal Costo { get; set; }
    }
}
