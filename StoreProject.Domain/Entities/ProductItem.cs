﻿using StoreProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.Domain.Entities
{
    public class ProductItem : BaseDomainEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Name { get; set; }
        public int QuantityInStock { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public ICollection<OrderItem> OrderItems { get; }
        public ICollection<CartItem> CartItems { get; }

    }
}
