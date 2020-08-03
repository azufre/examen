using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TerminalBus.Core.Model
{
    public class Viaje
    {
        public Viaje()
        {
            BoletoViaje = new HashSet<Boleto>();
        }

        [Key]
        public int IdViaje { get; set; }
        public string Ciudad { get; set; }
        public int HoraSalida { get; set; }
        public int HoraEntrada { get; set; }
        public decimal Costo { get; set; }
        public int IdBus { get; set; }
        public virtual Bus Bus { get; set; }

        public IEnumerable<Boleto> BoletoViaje { get; set; }

    }
}
