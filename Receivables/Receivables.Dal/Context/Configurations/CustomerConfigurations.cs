using System.Data.Entity.ModelConfiguration;
using Receivables.Dal.Models;

namespace Receivables.Dal.Context.Configurations
{
    public class CustomerConfigurations : EntityTypeConfiguration<Customer>
    {
        public CustomerConfigurations()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(100);
            Property(x => x.FullName).HasMaxLength(256);
            Property(x => x.Address).HasMaxLength(256);
            Property(x => x.INN).IsRequired();

            Property(x => x.UserId).IsRequired();
            HasRequired(x => x.User)
                .WithMany(g => g.Customers)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}