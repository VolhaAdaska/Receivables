namespace Receivables.Dal.Models
{
    public class FileModel : BaseEntity
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public int AgreementId { get; set; }

        public virtual Agreement Agreement { get; set; }
    }
}