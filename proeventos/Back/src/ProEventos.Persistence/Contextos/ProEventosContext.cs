using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contextos
{
    //Contexto ultilizado para a criaçao de eventos do nosso banco de dados.

    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options)
         : base (options){}


        //Apos adicionar a referencia eventos, tenho que adicionar aos services.
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }
        public DbSet<RedeSocial> RedeSociais { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Determinando que quando a classe PalestranteEvento for criada, sera relizada a junção entre EventoId e PalestranteId
            modelBuilder.Entity<PalestranteEvento>()
                                        .HasKey(PE => new {PE.EventoId , PE.PalestranteId});

            modelBuilder.Entity<Evento>()   
                                    .HasMany(e => e.RedeSociais)                  
                                    .WithOne(rs => rs.Evento) //Ao deletear evento que possui rede social, faça um cascade
                                    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Palestrante>()   
                        .HasMany(e => e.RedeSociais)                  
                        .WithOne(rs => rs.Palestrante) //Ao deletear um palestrante que possui rede social, faça um cascade e deleta as redes sociais tbm
                        .OnDelete(DeleteBehavior.Cascade);                        
        }
    }
}