using System.Data.Entity.ModelConfiguration;
using Receivables.Dal.Models;

namespace Receivables.Dal.Context.Configurations
{
    public class DebtClaimConfigurations : EntityTypeConfiguration<DebtClaim>
    {
        public DebtClaimConfigurations()
        {
            HasKey(x => x.Id);
            Property(x => x.DebtId).IsRequired();
        }
    }
}
