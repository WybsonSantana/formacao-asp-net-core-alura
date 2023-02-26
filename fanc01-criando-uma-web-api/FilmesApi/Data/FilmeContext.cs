using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data;

public class FilmeContext : DbContext
{
    public DbSet<Filme> Filmes { get; set; }

    public FilmeContext(DbContextOptions<FilmeContext> options) : base(options)
    {

    }
}
