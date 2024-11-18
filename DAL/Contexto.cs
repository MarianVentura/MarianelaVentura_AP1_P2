using Microsoft.EntityFrameworkCore;
using MarianelaVentura_AP1_P2.Models;

namespace MarianelaVentura_AP1_P2.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Articulos> Articulos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Articulos>().HasData(
            new Articulos { ArticuloId = 1, Descripcion = "Procesador Intel Core i7", Costo = 250m, Precio = 400m, Existencia = 15 },
            new Articulos { ArticuloId = 2, Descripcion = "Memoria RAM 16GB DDR4", Costo = 80m, Precio = 150m, Existencia = 20 },
            new Articulos { ArticuloId = 3, Descripcion = "Disco Duro SSD 500GB", Costo = 60m, Precio = 120m, Existencia = 25 },
            new Articulos { ArticuloId = 4, Descripcion = "Tarjeta Gráfica NVIDIA RTX 3060", Costo = 300m, Precio = 600m, Existencia = 10 },
            new Articulos { ArticuloId = 5, Descripcion = "Fuente de Poder 650W", Costo = 70m, Precio = 120m, Existencia = 18 },
            new Articulos { ArticuloId = 6, Descripcion = "Placa Base ASUS ROG", Costo = 200m, Precio = 350m, Existencia = 12 },
            new Articulos { ArticuloId = 7, Descripcion = "Monitor Full HD 24 pulgadas", Costo = 150m, Precio = 300m, Existencia = 8 },
            new Articulos { ArticuloId = 8, Descripcion = "Teclado Mecánico RGB", Costo = 50m, Precio = 100m, Existencia = 30 },
            new Articulos { ArticuloId = 9, Descripcion = "Mouse Gaming", Costo = 30m, Precio = 70m, Existencia = 25 },
            new Articulos { ArticuloId = 10, Descripcion = "Gabinete ATX con Ventilación", Costo = 90m, Precio = 150m, Existencia = 10 }
        );
    }

}