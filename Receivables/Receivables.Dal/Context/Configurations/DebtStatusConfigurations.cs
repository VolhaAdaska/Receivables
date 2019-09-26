using System.Data.Entity.ModelConfiguration;
using Receivables.Dal.Models;

namespace Receivables.Dal.Context.Configurations
{
    public class DebtStatusConfigurations: EntityTypeConfiguration<DebtStatus>
    {
        public DebtStatusConfigurations()
        {
            HasKey(x => x.Id);
            Property(x => x.DebtId).IsRequired();
        }
    }
}
