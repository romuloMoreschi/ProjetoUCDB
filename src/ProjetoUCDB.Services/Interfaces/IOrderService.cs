using ProjetoUCDB.Services.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoUCDB.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDTO> Create(OrderDTO orderDTO);
        Task<OrderDTO> Update(OrderDTO orderDTO);
        Task Remove(long id);
        Task<OrderDTO> Get(long id);
        Task<List<OrderDTO>> Get();
        OrderDTO CalculateDiscount(OrderDTO orderDTO);
        OrderDTO CalculateMaturity(OrderDTO orderDTO);
    }
}
