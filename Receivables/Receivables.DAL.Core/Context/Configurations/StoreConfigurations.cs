using System.Data.Entity.ModelConfiguration;
using Receivables.DAL.Models;

namespace Receivables.DAL.Core.Context.Configurations
{
    public class StoreConfigurations : EntityTypeConfiguration<Store>
    {
        public StoreConfigurations()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(100);
            HasIndex(x => x.Name).IsUnique();
            Property(x => x.Promocode).HasMaxLength(20);
        }
    }
}