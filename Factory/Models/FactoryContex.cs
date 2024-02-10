using Microsoft.EntityFrameworkCore;

namespace Factory.Models
{
  public class FactoryContext : DbContext
  {
  public FactoryContext(DbContextOptions<FactoryContext> options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.Entity<EngineerMachine>()
    .HasKey(em => new { em.EngineerId, em.MachineId });

    builder.Entity<EngineerMachine>()
    .HasOne(em => em.Engineer)
    .WithMany(e => e.Machines)
    .HasForeignKey(em => em.EngineerId);

    builder.Entity<EngineerMachine>()
    .HasOne(em => em.Machine)
    .WithMany(m => m.Engineers)
    .HasForeignKey(em => em.MachineId);
  }

  public DbSet<Engineer> Engineers { get; set; }
  public DbSet<Machine> Machines { get; set; }
  public DbSet<EngineerMachine> EngineerMachines { get; set; }
  }
}