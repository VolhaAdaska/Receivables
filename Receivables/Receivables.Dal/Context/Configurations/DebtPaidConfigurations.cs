using System.Data.Entity.ModelConfiguration;
using Receivables.Dal.Models;

namespace Receivables.Dal.Context.Configurations
{
    public class DebtPaidConfigurations : EntityTypeConfiguration<DebtPaid>
    {
        public DebtPaidConfigurations()
        {
            HasKey(x => x.Id);
            Property(x => x.DebtId).IsRequired();
        }
    }
}
