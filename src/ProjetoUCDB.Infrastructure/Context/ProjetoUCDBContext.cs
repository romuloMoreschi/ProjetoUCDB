using ProjetoUCDB.Core.Entities;
using Microsoft.EntityFrameworkCore;
using ProjetoUCDB.Infrastructure.Mappings;

namespace ProjetoUCDB.Infrastructure.Context
{
    public class ProjetoUCDBContext : DbContext
    {
        public ProjetoUCDBContext()
        {
        }
        public ProjetoUCDBContext(DbContextOptions<ProjetoUCDBContext> options)
             : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //USADO PARA ADICIONAR MIGRATIONS E UPDATE-DATABASE
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ProjetoUCDB;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }
        public virtual DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new OrderMap());
        }
    }

}
