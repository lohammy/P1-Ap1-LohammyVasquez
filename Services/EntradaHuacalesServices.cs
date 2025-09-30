using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using P1_Ap1_LohammyVasquez.DAL;
using P1_Ap1_LohammyVasquez.Models;

namespace P1_Ap1_LohammyVasquez.Services;

public class EntradaHuacalesServices(IDbContextFactory<Contexto> DbFactory)
{

    public async Task<bool> Guardar(EntradaHuacales entradaHuacales)
    {
        if (!await Existe(entradaHuacales.IdEntrada))
        {
            return await Insertar(entradaHuacales);
        }
        else
        {
            return await Modificar(entradaHuacales);
        }
    }

    private async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradaHuacales.AnyAsync(p => p.IdEntrada == id);
    }

    private async Task<bool> Insertar(EntradaHuacales entradaHuacales)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.EntradaHuacales.Add(entradaHuacales);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(EntradaHuacales entradaHuacales)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.EntradaHuacales.Update(entradaHuacales);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<EntradaHuacales?> Buscar(int entradaHuacalesID)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradaHuacales.FirstOrDefaultAsync(p => p.IdEntrada == entradaHuacalesID);

    }
    public async Task<bool> Eliminar(int entradaHuacalesID)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradaHuacales.AsNoTracking()
            .Where(p => p.IdEntrada == entradaHuacalesID)
            .ExecuteDeleteAsync() > 0;
    }


    public async Task<List<EntradaHuacales>> Listar(Expression<Func<EntradaHuacales, bool>> criterio)
    {

        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradaHuacales
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}

