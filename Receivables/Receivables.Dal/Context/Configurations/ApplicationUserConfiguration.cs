using System.Data.Entity.ModelConfiguration;
using Receivables.Dal.Models;

namespace Receivables.Dal.Context.Configurations
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            Property(e => e.FirstName)
           .HasColumnType("NVARCHAR")
           .HasMaxLength(50);

            Property(e => e.LastName)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);

            Property(e => e.Address)
               .HasColumnType("NVARCHAR")
               .HasMaxLength(150);

            Property(e => e.City)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(50);

            Property(e => e.Country)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(50);

            Property(e => e.PostCode)
             .HasColumnType("NVARCHAR")
             .HasMaxLength(20);
        }
    }
}
