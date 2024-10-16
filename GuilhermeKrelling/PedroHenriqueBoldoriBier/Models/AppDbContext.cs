namespace PedroHenriqueBoldoriBier.Models;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Folha> Folhas { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Guilherme_Pedro.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Folha>()
            .HasOne(f => f.funcionario)
            .WithMany( f => f.Folhas)
            .HasForeignKey(f => f.FuncionarioId); 
    }
}
