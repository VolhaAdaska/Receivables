﻿using System.Linq;
using Receivables.Dal.Context;
using Receivables.Dal.Interfaces;
using Receivables.Dal.Models;

namespace Receivables.Dal.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ReceivablesContext context)
          : base(context)
        {
        }

        public Product GetByCode(int codeId)
        {
            return entities.FirstOrDefault(x => x.Code == codeId);
        }
    }
}