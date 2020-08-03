using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TerminalBus.Core.Model
{
    public class Bus
    {
        public Bus()
        {
            ViajeBus = new HashSet<Viaje>();
        }

        [Key]
        public int IdBus { get; set; }
        public string Placa { get; set; }
        public int CantidadAsientos { get; set; }

        public virtual IEnumerable<Viaje> ViajeBus { get; set; }

    }
}
