﻿using StockApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.Features.TokenService
{
    public interface ITokenService
    {
        Task<string> GenerateTokenAsync(ApplicationUser User);
    }
}
