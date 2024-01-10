using StockApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Domain.Entities
{
    public class Order :BaseAuditableEntity
    {
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public int StockId { get; private set; }
        public Stock Stock {  get; private set; }

        public string UserId { get ; private set; }
        public ApplicationUser User { get; private set; }

        private Order() { }

        public Order(Stock stock, int quantity, decimal price,ApplicationUser user)
        {
            Stock = stock;
            StockId = stock.Id;
            Quantity = quantity;
            Price = price *quantity;
            UserId =user.Id;
            User = user;
        }

       
    }
}
