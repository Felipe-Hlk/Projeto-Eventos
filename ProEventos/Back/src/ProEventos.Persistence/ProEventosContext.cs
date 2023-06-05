using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence
{
    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options)
        {
        }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestrantesEventos{ get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }

        /* abaixo associação feita de mn entre 'Eventos'e 'Palestrantes' pois empre irá
        receber 'PalestrantesEventos', vinculando as chaves de um para o outro, consolidando
        a classe 'PalestrantesEventos' como a classe de junção entre 'Eventos'e 'Palestrantes' */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new { PE.EventoId, PE.PalestranteId });
        }
    }
}
