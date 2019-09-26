﻿using System;

namespace Receivables.Models
{
    public class DebtStore
    {
        public int Id { get; set; }

        public int DebtId { get; set; }

        public DateTime Date { get; set; }

        public int DebtStoreType { get; set; }

        public decimal Sum { get; set; }

        public string Number { get; set; }
    }
}