using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TerminalBus.Core.Authentication;
using TerminalBus.Core.Model;

namespace TerminalBus.Core.Context
{
    public class TerminalBusContext : IdentityDbContext<ApplicationUser>
    {
        public TerminalBusContext()
        {
        }

        public TerminalBusContext(DbContextOptions<TerminalBusContext> options) : base(options)
        {           
        }
        
        public DbSet<Boleto> Boletos { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Viaje> Viajes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Viaje>().HasOne(m => m.Bus).WithMany(m => m.ViajeBus).HasForeignKey(q => q.IdBus).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Boleto>().HasOne(m => m.Pasajero).WithMany(m => m.BoletoPasajero).HasForeignKey(q => q.IdPasajero).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Boleto>().HasOne(m => m.Viaje).WithMany(m => m.BoletoViaje).HasForeignKey(q => q.IdViaje).OnDelete(DeleteBehavior.Restrict);

        }

    }
}
