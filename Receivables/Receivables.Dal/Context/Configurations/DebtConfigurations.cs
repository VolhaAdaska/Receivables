using System.Data.Entity.ModelConfiguration;
using Receivables.Dal.Models;

namespace Receivables.Dal.Context.Configurations
{
    public class DebtConfigurations : EntityTypeConfiguration<Debt>
    {
        public DebtConfigurations()
        {
            HasKey(x => x.Id);
            Property(x => x.CustomerId).IsRequired();
            Property(x => x.AgreementId).IsRequired();
            Property(x => x.SumDebt).IsRequired();
        }
    }
}