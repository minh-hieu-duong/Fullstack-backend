﻿using Microsoft.EntityFrameworkCore;
using StoreProject.Application.Contracts.Infrastructure.IReposiotry;
using StoreProject.Domain.Entities;
using StoreProject.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.Infrastructure.Repositories
{
    public class ProductTagRepository : GenericRepository<ProductTag>, IProductTagRepository
    {
         private readonly ApplicationDbContext _dbContext;
        public ProductTagRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductTag> GetProductTag(int productId, int tagId)
        {
            var productTag = await _dbContext.ProductTags
                .FirstOrDefaultAsync(p => p.TagId == tagId && p.ProductId == productId);

            return productTag;
        }
    }
}
