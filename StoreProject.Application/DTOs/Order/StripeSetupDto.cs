﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.Application.DTOs.Order
{
    public class StripeSetupDto
    {
        public string ApprovedUrl { get; set; }
        public string CancelUrl { get; set; }
    }
}
