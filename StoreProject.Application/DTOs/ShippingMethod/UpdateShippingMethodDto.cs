﻿using StoreProject.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.Application.DTOs.ShippingMethod
{
    public class UpdateShippingMethodDto : BaseDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
