namespace Receivables.Bll.Models
{
    public static class StatusDebt
    {
        public const string NewStatus = "Новый";
        public const string Received = "Претензия получена контрагентом"; 
        public const string Sued = "Направлен иск";
        public const string Trial = "Судебное";
        public const string EntryDecision = "Вступление в силу решения";
        public const string Delayed = "Отложено";
        public const string PaymentRequirement = "Платежное требование";
        public const string ExecutionOfDecision = "Исполнение решения";
        public const string Closed = "Закрыто";
    }
}