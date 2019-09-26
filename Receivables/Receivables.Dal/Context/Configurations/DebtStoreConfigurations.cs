using System.Data.Entity.ModelConfiguration;
using Receivables.Dal.Models;

namespace Receivables.Dal.Context.Configurations
{
    public class DebtStoreConfigurations : EntityTypeConfiguration<DebtStore>
    {
        public DebtStoreConfigurations()
        {
            HasKey(x => x.Id);
            Property(x => x.DebtId).IsRequired();
        }
    }
}
