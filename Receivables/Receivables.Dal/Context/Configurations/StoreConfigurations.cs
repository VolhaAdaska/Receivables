using System.Data.Entity.ModelConfiguration;
using Receivables.Dal.Models;

namespace Receivables.Dal.Context.Configurations
{
    public class StoreConfigurations : EntityTypeConfiguration<Store>
    {
        public StoreConfigurations()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(100);
            HasIndex(x => x.Name).IsUnique();
        }
    }
}