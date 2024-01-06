﻿using StockApp.Application.Common.Interfaces;
using StockApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.Features.StockService
{
    public class StockService : IStockService
    {

        private readonly IUnitOfWork _unitOfWork;

        public StockService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IReadOnlyCollection<Stock>> GetAll()
        {
            return await _unitOfWork.StockRepo.GetAllAsync();
        }

        public async Task<Stock> GetStockById(int Id)
        {
            return await _unitOfWork.StockRepo.GetByIdAsync(Id);
        }
    }
}