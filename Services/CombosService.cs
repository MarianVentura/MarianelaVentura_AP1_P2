using MarianelaVentura_AP1_P2.DAL;
using MarianelaVentura_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MarianelaVentura_AP1_P2.Services;

public class CombosService
{
    private readonly IDbContextFactory<Contexto> _dbFactory;

    public CombosService(IDbContextFactory<Contexto> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task<List<Combos>> Listar(Expression<Func<Combos, bool>> criterio)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Combos
            .Include(c => c.CombosDetalles)
            .ThenInclude(cd => cd.Articulo)
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Combos?> ObtenerPorId(int comboId)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Combos
            .Include(c => c.CombosDetalles)
            .ThenInclude(cd => cd.Articulo)
            .FirstOrDefaultAsync(c => c.ComboId == comboId);
    }

    public async Task<Combos> Crear(Combos combo)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        contexto.Combos.Add(combo);
        await contexto.SaveChangesAsync();
        return combo;
    }

    public async Task<Combos> Modificar(Combos combo)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        contexto.Combos.Update(combo);
        await contexto.SaveChangesAsync();
        return combo;
    }

    public async Task<bool> Eliminar(int comboId)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
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
