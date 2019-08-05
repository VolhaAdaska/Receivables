using Receivables.Dal.Models;
using System.Data.Entity.ModelConfiguration;

namespace Receivables.Dal.Context.Configurations
{
    public class StoreTypeConfigurations : EntityTypeConfiguration<StoreType>
    {
        public StoreTypeConfigurations()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(100);
            HasIndex(x => x.Name).IsUnique();
        }
    }
}
