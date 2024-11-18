using Microsoft.EntityFrameworkCore;
using MarianelaVentura_AP1_P2.Models;

namespace MarianelaVentura_AP1_P2.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Registro> Registros { get; set; }
}