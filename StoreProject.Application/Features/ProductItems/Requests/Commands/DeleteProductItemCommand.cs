﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.Application.Features.ProductItems.Requests.Commands
{
    public class DeleteProductItemCommand : IRequest
    {
        public int Id { get; set; }
    }
}
