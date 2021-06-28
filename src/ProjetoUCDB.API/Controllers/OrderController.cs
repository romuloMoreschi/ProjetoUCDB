using System;
using AutoMapper;
using ProjetoUCDB.API.Util;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoUCDB.Services.DTO;
using ProjetoUCDB.API.ViewModels;
using ProjetoUCDB.Core.Exceptions;
using ProjetoUCDB.Services.Interfaces;

namespace ProjetoUCDB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public OrderController(IMapper mapper, IOrderService orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
        }
        [HttpPost]
        [Route("/api/orders/create")]
        public async Task<IActionResult> Create([FromBody] CreateOrderViewModel orderViewModel)
        {
            try
            {
                var orderDTO = _mapper.Map<OrderDTO>(orderViewModel);

                var orderCreated = await _orderService.Create(orderDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Venda cadastrada com sucesso!",
                    Success = true,
                    Data = orderCreated
                });
            }
            catch (CoreException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
        [HttpPut]
        [Route("/api/orders/update")]
        public async Task<IActionResult> Update([FromBody] UpdateOrderViewModel orderViewModel)
        {
            try
            {
                var orderDTO = _mapper.Map<OrderDTO>(orderViewModel);

                var orderUpdated = await _orderService.Update(orderDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Venda atualizada com sucesso!",
                    Success = true,
                    Data = orderUpdated
                });
            }
            catch (CoreException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
        [HttpDelete]
        [Route("/api/orders/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                await _orderService.Remove(id);

                return Ok(new ResultViewModel
                {
                    Message = "Venda removida com sucesso!",
                    Success = true,
                    Data = null
                });
            }
            catch (CoreException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
        [HttpGet]
        [Route("/api/orders/get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var order = await _orderService.Get(id);

                if (order == null)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhuma venda foi encontrada com o ID informado.",
                        Success = true,
                        Data = order
                    });

                return Ok(new ResultViewModel
                {
                    Message = "Venda encontrada com sucesso!",
                    Success = true,
                    Data = order
                });
            }
            catch (CoreException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
        [HttpGet]
        [Route("/api/orders/get-all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var allOrders = await _orderService.Get();

                return Ok(new ResultViewModel
                {
                    Message = "Vendas encontradas com sucesso!",
                    Success = true,
                    Data = allOrders
                });
            }
            catch (CoreException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}
