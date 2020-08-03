using System.ComponentModel.DataAnnotations;

namespace TerminalBus.Core.ViewModel
{
    public class BoletoUpdateViewModel : BoletoViewModel
    {
        [Required]
        public int IdBoleto { get; set; }
    }
}
