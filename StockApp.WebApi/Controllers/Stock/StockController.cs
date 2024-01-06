using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockApp.Application.DTOS;
using StockApp.Application.Features.StockService;

namespace StockApp.WebApi.Controllers.Stock
{

    public class StockController : BaseController
    {
        private readonly IStockService _stockService;
        private readonly IMapper _mapper;

        public StockController(IStockService stockService,IMapper mapper)
        {
            _stockService = stockService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {

            var response =await _stockService.GetAll();

            return Ok(_mapper.Map<List<StockDTO>>(response));
        }
        
        

    }
}
