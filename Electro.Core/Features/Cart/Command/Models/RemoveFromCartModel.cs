﻿using Electro.Core.ResponseHelper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Cart.Command.Models
{
    public class RemoveFromCartModel:IRequest<Response<string>>
    {
        public int UserId { get; set; }
        public int ProductId {  get; set; }
    }
}