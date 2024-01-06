using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockApp.Application.Common.Exceptions;
using StockApp.Application.DTOS;
using StockApp.Application.Features.OrderService;

namespace StockApp.WebApi.Controllers.Order
{

 
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService,IMapper  mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {

            var response = await _orderService.GetAll();

            return Ok(_mapper.Map<List<OrderDTO>>(response));
        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateOrder(CreateOrderDTO createOrder)
        {
            

            var order = await _orderService.CreateOrder(createOrder);

            return Ok(_mapper.Map<OrderDTO>(order));
        }

    }
}
