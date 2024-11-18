using MarianelaVentura_AP1_P2.Models;
using System.Linq.Expressions;
using System;
using MarianelaVentura_AP1_P2.DAL;
using Microsoft.EntityFrameworkCore;

namespace MarianelaVentura_AP1_P2.Services
{
    public class CombosDetalleService (Contexto contexto)
    {
        
            // Listar detalles de combos con sus artículos
            public async Task<List<CombosDetalle>> Listar(Expression<Func<CombosDetalle, bool>> criterio)
            {
                return await contexto.CombosDetalle.Include(cd => cd.Articulo)
                    .Where(criterio)
                    .AsNoTracking()
                    .ToListAsync();
            }

            // Obtener un detalle de Combo por su ID
            public async Task<CombosDetalle?> ObtenerPorId(int detalleId)
            {
                return await contexto.CombosDetalle.Include(cd => cd.Articulo)
                    .FirstOrDefaultAsync(cd => cd.DetalleId == detalleId);
            }

            // Crear un nuevo detalle de Combo
            public async Task<CombosDetalle> Crear(CombosDetalle comboDetalle)
            {
                contexto.CombosDetalle.Add(comboDetalle);
                await contexto.SaveChangesAsync();
                return comboDetalle;
            }

            // Modificar un detalle de Combo
            public async Task<CombosDetalle> Modificar(CombosDetalle comboDetalle)
            {
                contexto.CombosDetalle.Update(comboDetalle);
                await contexto.SaveChangesAsync();
                return comboDetalle;
            }

            // Eliminar un detalle de Combo por ID
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
        }
    }
}
}
