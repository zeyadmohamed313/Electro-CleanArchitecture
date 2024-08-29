﻿using Electro.Core.ResponseHelper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Cart.Command.Models
{
    public class AddToCartModel:IRequest<Response<string>>
    {
        public int UserId {  get; set; }
        public int ProductId {  get; set; }
        public int Quantity { get; set; } = 1;

    }
}