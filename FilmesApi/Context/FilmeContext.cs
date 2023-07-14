using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Context
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opts)
        {
                
        }

        public DbSet<Filme> Filmes { get; set; }
    }
}
