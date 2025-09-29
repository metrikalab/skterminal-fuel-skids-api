using Microsoft.EntityFrameworkCore;

namespace skterminal_fuel_skids_api.Configurations.Databases
{
  public class DataContextEntityFramework : DbContext
  {
    public DataContextEntityFramework(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasDefaultSchema("public");
    }
  }
}
