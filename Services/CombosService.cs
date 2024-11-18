using MarianelaVentura_AP1_P2.DAL;
using MarianelaVentura_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace MarianelaVentura_AP1_P2.Services
{
    public class CombosService(Contexto contexto)
    {
       
        public async Task<List<Combos>> Listar(Expression<Func<Combos, bool>> criterio)
        {
            return await contexto.Combos.Include(c => c.CombosDetalles)
                .ThenInclude(cd => cd.Articulo)  // Incluir los detalles de los artículos asociados
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Combos?> ObtenerPorId(int comboId)
        {
            return await contexto.Combos.Include(c => c.CombosDetalles)
                .ThenInclude(cd => cd.Articulo)
                .FirstOrDefaultAsync(c => c.ComboId == comboId);
        }

        public async Task<Combos> Crear(Combos combo)
        {
            contexto.Combos.Add(combo);
            await contexto.SaveChangesAsync();
            return combo;
        }

        public async Task<Combos> Modificar(Combos combo)
        {
            contexto.Combos.Update(combo);
            await contexto.SaveChangesAsync();
            return combo;
        }

        public async Task<bool> Eliminar(int comboId)
        {
            var combo = await contexto.Combos.FindAsync(comboId);
            if (combo != null)
            {
                contexto.Combos.Remove(combo);
                await contexto.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}




      

     



   




