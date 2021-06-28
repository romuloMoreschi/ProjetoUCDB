using System;
using AutoMapper;
using System.Threading.Tasks;
using ProjetoUCDB.Services.DTO;
using ProjetoUCDB.Core.Entities;
using System.Collections.Generic;
using ProjetoUCDB.Core.Exceptions;
using ProjetoUCDB.Services.Interfaces;
using ProjetoUCDB.Infrastructure.Interfaces;

namespace ProjetoUCDB.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _OrderRepository;
        public OrderService(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _OrderRepository = orderRepository;
        }
        public async Task<OrderDTO> Create(OrderDTO orderDTO)
        {
            var orderExists = await _OrderRepository.Get(orderDTO.Id);

            if (orderExists != null)
                throw new CoreException("Já existe uma venda cadastrada com os dados informados.");

            CalculateMaturity(orderDTO);

            var order = _mapper.Map<Order>(orderDTO);

            order.Validate();
            var orderCreated = await _OrderRepository.Create(order);

            return _mapper.Map<OrderDTO>(orderCreated);
        }
        public async Task<OrderDTO> Update(OrderDTO orderDTO)
        {
            var orderExists = await _OrderRepository.Get(orderDTO.Id);

            if (orderExists == null)
                throw new CoreException("Não existe nenhuma venda com o id informado!");

            CalculateMaturity(orderDTO);

            var order = _mapper.Map<Order>(orderDTO);

            order.Validate();
            var orderUpdated = await _OrderRepository.Update(order);

            return _mapper.Map<OrderDTO>(orderUpdated);
        }
        public async Task Remove(long id)
        {
            await _OrderRepository.Remove(id);
        }
        public async Task<OrderDTO> Get(long id)
        {
            var order = await _OrderRepository.Get(id);

            return _mapper.Map<OrderDTO>(order);
        }
        public async Task<List<OrderDTO>> Get()
        {
            var allOrders = await _OrderRepository.Get();

            return _mapper.Map<List<OrderDTO>>(allOrders);
        }
        public OrderDTO CalculateDiscount(OrderDTO orderDTO)
        {
            if (orderDTO.desconto > 0)
            {
                var desconto = orderDTO.valor * (orderDTO.desconto / 100);
                orderDTO.valor -= desconto;
            }

            return orderDTO;
        }
        public OrderDTO CalculateMaturity(OrderDTO orderDTO)
        {
            var dataAtual = DateTime.Now;
            var dataDTO = DateTime.Parse(orderDTO.data_vencimento);

            if (dataDTO < dataAtual.AddDays(3) && dataDTO > dataAtual)
            {
                orderDTO.situacao = "Quase vencendo";

                CalculateDiscount(orderDTO);
            }
            else if (dataDTO < dataAtual)
            {
                orderDTO.situacao = "Vencido";
            }
            else
            {
                orderDTO.situacao = "Valido";

                CalculateDiscount(orderDTO);
            }

            return orderDTO;
        }
    }
}
