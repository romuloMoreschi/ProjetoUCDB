using ProjetoUCDB.Services.Services;
using ProjetoUCDB.Services.Interfaces;
using ProjetoUCDB.Infrastructure.Interfaces;
using ProjetoUCDB.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ProjetoUCDB.CrossCutting
{
    public class ProjetoUCDBInjection
    {
        public static void Main(IServiceCollection services)
        {
            #region Repositories
            
            services.AddScoped<IOrderRepository, OrderRepository>();

            #endregion

            #region Services

            services.AddScoped<IOrderService, OrderService>();

            #endregion
        }
    }
}
