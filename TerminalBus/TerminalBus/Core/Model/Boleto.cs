using System;
using System.ComponentModel.DataAnnotations;
using TerminalBus.Core.Authentication;

namespace TerminalBus.Core.Model
{
    public class Boleto
    {
        [Key]
        public int IdBoleto { get; set; }
        public decimal Costo { get; set; }        
        public DateTime FechaCompra { get; set; }
        public int Asiento { get; set; }
        public int IdViaje { get; set; }
        public string IdPasajero { get; set; }
        public virtual Viaje Viaje { get; set; }
        public virtual ApplicationUser Pasajero { get; set; }
    }
}
