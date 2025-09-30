using Microsoft.EntityFrameworkCore;
using P1_Ap1_LohammyVasquez.Models;

namespace P1_Ap1_LohammyVasquez.DAL;

public class Contexto : DbContext
{
    public DbSet<EntradaHuacales> EntradaHuacales { get; set; }
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

}
