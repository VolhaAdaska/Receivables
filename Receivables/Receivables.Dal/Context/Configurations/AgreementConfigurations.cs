using Receivables.Dal.Models;
using System.Data.Entity.ModelConfiguration;

namespace Receivables.Dal.Context.Configurations
{
    public class AgreementConfigurations : EntityTypeConfiguration<Agreement>
    {
        public AgreementConfigurations()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(256);
            Property(x => x.Number).IsRequired();
            Property(x => x.StartDate).IsRequired();
            
            Property(x => x.CustomerId).IsRequired();
            HasRequired(x => x.Customer)
                .WithMany(g => g.Agreements)
                .HasForeignKey(x => x.CustomerId)
                .WillCascadeOnDelete(true);
        }
    }
}
