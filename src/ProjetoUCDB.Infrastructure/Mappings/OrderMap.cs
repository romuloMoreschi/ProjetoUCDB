using ProjetoUCDB.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoUCDB.Infrastructure.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(x => x.nome_produto)
                .IsRequired()
                .HasColumnName("nome_produto")
                .HasColumnType("VARCHAR(100)");

            builder.Property(x => x.valor)
                .IsRequired()
                .HasColumnName("valor")
                .HasColumnType("DECIMAL(9,2)")
                .HasDefaultValue(0);

            builder.Property(x => x.desconto)
                .HasColumnName("desconto")
                .HasColumnType("DECIMAL(9,2)")
                .HasDefaultValue(0);

            builder.Property(x => x.data_vencimento)
                .IsRequired()
                .HasColumnName("data_vencimento")
                .HasColumnType("DATE");

            builder.Property(x => x.situacao)
               .IsRequired()
               .HasColumnName("situacao")
               .HasColumnType("VARCHAR(100)");
        }
    }
}
