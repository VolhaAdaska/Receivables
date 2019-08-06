using Receivables.Dal.Models;
using System.Data.Entity.ModelConfiguration;

namespace Receivables.Dal.Context.Configurations
{
    public class AgreementConfigurations : EntityTypeConfiguration<Agreement>
    {
        public AgreementConfigurations()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(100);
            Property(x => x.Number).IsRequired();
            Property(x => x.Date).IsRequired();
        }
    }
}
