﻿using AutoMapper;
using MediatR;
using StoreProject.Application.Contracts.Infrastructure.IReposiotry;
using StoreProject.Application.Features.ShippingMethods.Requests.Commands;
using StoreProject.Application.Features.Coupons.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.Application.Features.ShippingMethods.Handlers.Commands
{
    public class DeleteShippingMethodCommandHandler : IRequestHandler<DeleteShippingMethodCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteShippingMethodCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteShippingMethodCommand request, CancellationToken cancellationToken)
        {

            var shippingMethod = await _unitOfWork.ShippingMethodRepository.Get(request.Id);



            await _unitOfWork.ShippingMethodRepository.Delete(shippingMethod);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
