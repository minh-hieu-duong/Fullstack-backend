﻿using AutoMapper;
using MediatR;
using StoreProject.Application.Contracts.Infrastructure.IReposiotry;
using StoreProject.Application.DTOs.ShippingMethod;
using StoreProject.Application.DTOs.Coupon;
using StoreProject.Application.Features.ShippingMethods.Requests.Queries;
using StoreProject.Application.Features.Coupons.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.Application.Features.ShippingMethods.Handlers.Queries
{
    public class GetShippingMethodListRequestHandler : IRequestHandler<GetShippingMethodListRequest, List<ShippingMethodDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetShippingMethodListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ShippingMethodDto>> Handle(GetShippingMethodListRequest request, CancellationToken cancellationToken)
        {
            var shippingMethods = await _unitOfWork.ShippingMethodRepository.GetAll();
            return _mapper.Map<List<ShippingMethodDto>>(shippingMethods);
        }
    }
}
