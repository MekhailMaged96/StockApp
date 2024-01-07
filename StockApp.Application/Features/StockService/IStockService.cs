using StockApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.Features.StockService
{
    public interface IStockService
    {
        Task<IReadOnlyCollection<Stock>> GetAll();

        Task<Stock> GetStockById(int Id);

        Task<IEnumerable<Stock>> UpdateAllStocksPrice();
    }
}
