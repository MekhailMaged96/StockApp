using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StockApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StockApp.Infrastructure.Data
{
    public class ApplicationDbContextInitialiser
    {
        private ILogger<ApplicationDbContextInitialiser> _logger;
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task InitialiseAsync()
        {
            try
            {
                await _context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }
        public async Task SeedAsync()
        {
            try
            {
                await SeedStocks();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        private async Task SeedStocks()
        {


            if (await _context.Stocks.AnyAsync())
                return;

           
            var stockData = await File.ReadAllTextAsync("Data/StockSeedData.json");

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var stocks = JsonSerializer.Deserialize<List<Stock>>(stockData, options);
            Random random = new Random();

            foreach (var stock in stocks)
            {

                 stock.SetRandomPrice();
                _context.Add(stock);
            }

                
             await _context.SaveChangesAsync();


        }



    }
}
