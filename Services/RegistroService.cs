using Microsoft.EntityFrameworkCore;
using MarianelaVentura_AP1_P2.DAL;
using MarianelaVentura_AP1_P2.Models;
using System.Linq.Expressions;

namespace MarianelaVentura_AP1_P2.Service;

public class RegistroServices
{
    private readonly IDbContextFactory<Contexto> _dbFactory;

    public RegistroServices(IDbContextFactory<Contexto> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    // Metodo Existe
    public async Task<bool> Existe(int registroId)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Registros.AnyAsync(r => r.RegistroId == registroId);
    }

    // Metodo Insertar
    private async Task<bool> Insertar(Registro registro)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        contexto.Registros.Add(registro);
        return await contexto.SaveChangesAsync() > 0;
    }

    // Metodo Modificar
    private async Task<bool> Modificar(Registro registro)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        contexto.Update(registro);
        return await contexto.SaveChangesAsync() > 0;
    }

    // Metodo Guardar
    public async Task<bool> Guardar(Registro registro)
    {
        if (!await Existe(registro.RegistroId))
        {
            return await Insertar(registro);
        }
        else
        {
            return await Modificar(registro);
        }
    }

    // Metodo Eliminar
    public async Task<bool> Eliminar(Registro registro)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Registros
            .AsNoTracking()
            .Where(r => r.RegistroId == registro.RegistroId)
            .ExecuteDeleteAsync() > 0;
    }

    // Metodo Buscar
    public async Task<Registro?> Buscar(int registroId)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Registros
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.RegistroId == registroId);
    }

    // Metodo Listar
    public async Task<List<Registro>> Listar(Expression<Func<Registro, bool>> criterio)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Registros
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
