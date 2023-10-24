﻿using AutoMapper;
using MediatR;
using StoreProject.Application.Contracts.Infrastructure.IReposiotry;
using StoreProject.Application.DTOs.Coupon;
using StoreProject.Application.DTOs.Product;
using StoreProject.Application.DTOs.ProductItem;
using StoreProject.Application.Features.Coupons.Requests.Queries;
using StoreProject.Application.Features.Products.Requests.Queries;
using StoreProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.Application.Features.Order.Handlers.Queries
{
    public class GetProductRequestHandler : IRequestHandler<GetProductRequest, ProductDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            var product = _unitOfWork.ProductRepository.GetProductWithProductItem(request.Id);

            return _mapper.Map<ProductDto>(product);
        }
    }
}
