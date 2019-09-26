using System.Data.Entity.ModelConfiguration;
using Receivables.Dal.Models;

namespace Receivables.Dal.Context.Configurations
{
    public class StoreConfigurations : EntityTypeConfiguration<Store>
    {
        public StoreConfigurations()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(256);
            Property(x => x.Number).IsRequired();

            Property(x => x.AgreementId).IsRequired();
            HasRequired(x => x.Agreement)
                .WithMany(g => g.Stores)
                .HasForeignKey(x => x.AgreementId)
                .WillCascadeOnDelete(true);
        }
    }
}