using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using P1_Ap1_LohammyVasquez.DAL;
using P1_Ap1_LohammyVasquez.Models;

namespace P1_Ap1_LohammyVasquez.Services;

public class RegistroServices (IDbContextFactory<Contexto> DbFactory)
{
    public async Task<List<Registro>> Listar(Expression<Func<Registro, bool>> criterio) {

        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Registro
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}
