using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Dominio.Entidades;
using System;

namespace QuickBuy.Repositorio.Config
{
    public class ItemPedidoConfiguration : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            //throw new NotImplementedException();
            //Qual propriedade de ItemPedido será mapeada como chave primaria
            builder.HasKey(IP => IP.Id);

            /*
             *Builder utiliza o padrao Fluent
             * Determina como será criado o campo no banco de dados
             */
            builder
                .Property(IP => IP.ProdutoId)
                .IsRequired();

            builder
                .Property(IP => IP.Quantidade)
                .IsRequired()
                .HasColumnType("decimal(18,4)"); ;

        }
    }
}
