using Microsoft.EntityFrameworkCore;
using ProEventos.API.Models;

namespace ProEventos.API.Data
{
    //Contexto ultilizado para a criaçao de eventos do nosso banco de dados.

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){}


        //Apos adicionar a referencia eventos, tenho que adicionar aos services.
        public DbSet<Evento> Eventos { get; set; }
    }
}