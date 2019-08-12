using System.Data.Entity.ModelConfiguration;
using Receivables.Dal.Models;

namespace Receivables.Dal.Context.Configurations
{
    public class ContractConfigurations : EntityTypeConfiguration<Contract>
    {
        public ContractConfigurations()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(256);
            Property(x => x.Number).IsRequired();
            Property(x => x.Date).IsRequired();

            Property(x => x.CustomerId).IsRequired();
            HasRequired(x => x.Customer)
                .WithMany(g => g.Contracts)
                .HasForeignKey(x => x.CustomerId)
                .WillCascadeOnDelete(false);
        }
    }
}