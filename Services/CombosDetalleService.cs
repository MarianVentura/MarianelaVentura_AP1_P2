using MarianelaVentura_AP1_P2.DAL;
using MarianelaVentura_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MarianelaVentura_AP1_P2.Services;

public class CombosDetalleService
{
    private readonly IDbContextFactory<Contexto> _dbFactory;

    public CombosDetalleService(IDbContextFactory<Contexto> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task<List<CombosDetalle>> Listar(Expression<Func<CombosDetalle, bool>> criterio)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.CombosDetalle
            .Include(cd => cd.Articulo)
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<CombosDetalle?> ObtenerPorId(int detalleId)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.CombosDetalle
            .Include(cd => cd.Articulo)
            .FirstOrDefaultAsync(cd => cd.DetalleId == detalleId);
    }

    public async Task<CombosDetalle> Crear(CombosDetalle comboDetalle)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        contexto.CombosDetalle.Add(comboDetalle);
        await contexto.SaveChangesAsync();
        return comboDetalle;
    }

    public async Task<CombosDetalle> Modificar(CombosDetalle comboDetalle)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        contexto.CombosDetalle.Update(comboDetalle);
        await contexto.SaveChangesAsync();
        return comboDetalle;
    }

    public async Task<bool> Eliminar(int detalleId)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
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
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        if (criterio == null)
            return await contexto.Articulos
                .AsNoTracking()
                .ToListAsync();
        else
            return await contexto.Articulos
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
    }

    public async Task<List<CombosDetalle>> ObtenerDetallesPorComboId(int comboId)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.CombosDetalle
            .Where(cd => cd.ComboId == comboId)
            .Include(cd => cd.Articulo) // Asegurarse de incluir el artículo
            .AsNoTracking()
            .ToListAsync();
    }

}
