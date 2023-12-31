﻿using MediatR;
using StoreProject.Application.DTOs.Coupon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.Application.Features.Coupons.Requests.Commands
{
    public class DeleteCouponCommand : IRequest
    {
        public int Id { get; set; }
    }
}
