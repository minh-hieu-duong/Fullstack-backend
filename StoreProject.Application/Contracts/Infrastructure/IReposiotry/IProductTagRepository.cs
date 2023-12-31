﻿using StoreProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.Application.Contracts.Infrastructure.IReposiotry
{
    public interface IProductTagRepository : IGenericRepository<ProductTag>
    {
        public Task<ProductTag> GetProductTag(int productId, int tagId);

    }
}
