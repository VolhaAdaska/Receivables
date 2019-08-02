using System.Data.Entity.ModelConfiguration;
using Receivables.DAL.Models;

namespace Receivables.DAL.Core.Context.Configurations
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
