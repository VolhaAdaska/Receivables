using System.Data.Entity.ModelConfiguration;
using Receivables.Dal.Models;

namespace Receivables.Dal.Context.Configurations
{
    public class AccountConfigurations : EntityTypeConfiguration<Account>
    {
        public AccountConfigurations()
        {
            HasKey(x => x.Id);
            Property(x => x.Sum).IsRequired();
            Property(x => x.Date).IsRequired();
        }
    }
}
