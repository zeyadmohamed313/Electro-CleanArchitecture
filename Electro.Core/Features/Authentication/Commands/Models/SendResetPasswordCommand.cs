﻿using Electro.Core.ResponseHelper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Authentication.Commands.Models
{
    public class SendResetPasswordCommand:IRequest<Response<string>>
    {
        public string Email { get; set; }
    }
}