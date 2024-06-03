using Ap1_P1_CristopherMarte.Models;
using Microsoft.EntityFrameworkCore;

namespace Ap1_P1_CristopherMarte.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Articulos> Articulos { get; set; }
}
