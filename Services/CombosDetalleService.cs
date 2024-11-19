using MarianelaVentura_AP1_P2.Models;
using System.Linq.Expressions;
using System;
using MarianelaVentura_AP1_P2.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace MarianelaVentura_AP1_P2.Services
{
    public class CombosDetalleService (Contexto contexto)
    {
        
            public async Task<List<CombosDetalle>> Listar(Expression<Func<CombosDetalle, bool>> criterio)
            {
                return await contexto.CombosDetalle.Include(cd => cd.Articulo)
                    .Where(criterio)
                    .AsNoTracking()
                    .ToListAsync();
            }

            public async Task<CombosDetalle?> ObtenerPorId(int detalleId)
            {
                return await contexto.CombosDetalle.Include(cd => cd.Articulo)
                    .FirstOrDefaultAsync(cd => cd.DetalleId == detalleId);
            }

            public async Task<CombosDetalle> Crear(CombosDetalle comboDetalle)
            {
                contexto.CombosDetalle.Add(comboDetalle);
                await contexto.SaveChangesAsync();
                return comboDetalle;
            }

            public async Task<CombosDetalle> Modificar(CombosDetalle comboDetalle)
            {
                contexto.CombosDetalle.Update(comboDetalle);
                await contexto.SaveChangesAsync();
                return comboDetalle;
            }

            public async Task<bool> Eliminar(int detalleId)
            {
                var comboDetalle = await contexto.CombosDetalle.FindAsync(detalleId);
                if (comboDetalle != null)
                {
                    contexto.CombosDetalle.Remove(comboDetalle);
                    await contexto.SaveChangesAsync();
                    return true;
                }
                return false;
            }

        public async Task<List<Articulos>> ListaArticulos(Expression<Func<Articulos, bool>>? criterio = null)
        {
            if (criterio == null)
                return await contexto.Articulos.AsNoTracking().ToListAsync();
            else
                return await contexto.Articulos.Where(criterio).AsNoTracking().ToListAsync();
        }

    }
}

