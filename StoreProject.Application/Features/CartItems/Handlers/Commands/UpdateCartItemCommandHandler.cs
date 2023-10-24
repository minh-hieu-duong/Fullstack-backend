﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using StoreProject.Application.Constants;
using StoreProject.Application.Contracts.Infrastructure.IReposiotry;
using StoreProject.Application.DTOs.CartItem.Validators;
using StoreProject.Application.Exceptions;
using StoreProject.Application.Features.CartItems.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.Application.Features.CartItems.Handlers.Commands
{
    public class UpdateCartItemCommandHandler : IRequestHandler<UpdateCartItemCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateCartItemCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Unit> Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid).Value;

            if (!(await _unitOfWork.CartItemRepository.IsItemOwnedByUser(request.CartItemDto.Id, userId)))
            {
                throw new BadRequestException("Something went wrong");
            }

            var validator = new UpdateCartItemDtoValidator();
            var validatorResult = await validator.ValidateAsync(request.CartItemDto);

            if (validatorResult.IsValid == false)
            {
                throw new ValidationException(validatorResult);
            }

            var cartItem = await _unitOfWork.CartItemRepository.Get(request.CartItemDto.Id);


            if(request.IsMinus == true && cartItem.Quantity > 0)
            {
                cartItem.Quantity--;
            }
            else if(request.IsMinus == false && cartItem.Quantity > 0) 
            {
                cartItem.Quantity++;
            }


            await _unitOfWork.CartItemRepository.Update(cartItem);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
