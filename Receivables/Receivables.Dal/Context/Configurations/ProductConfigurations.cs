using System.Data.Entity.ModelConfiguration;
using Receivables.Dal.Models;

namespace Receivables.Dal.Context.Configurations
{
    public class ProductConfigurations : EntityTypeConfiguration<Product>
    {
        public ProductConfigurations() 
        {
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(256);

            Property(x => x.StoreId).IsRequired();
            HasRequired(x => x.Store)
                .WithMany(g => g.Products)
                .HasForeignKey(x => x.StoreId)
                .WillCascadeOnDelete(false);
        }
    }
}