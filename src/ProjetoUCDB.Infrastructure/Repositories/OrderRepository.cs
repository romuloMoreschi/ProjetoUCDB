using ProjetoUCDB.Core.Entities;
using ProjetoUCDB.Infrastructure.Context;
using ProjetoUCDB.Infrastructure.Interfaces;

namespace ProjetoUCDB.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly ProjetoUCDBContext _context;

        public OrderRepository(ProjetoUCDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
