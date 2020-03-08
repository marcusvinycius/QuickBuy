using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Repositorio.Config
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            //throw new NotImplementedException();
            //Qual propriedade de Pedido será mapeada como chave primaria
            builder.HasKey(p => p.Id);

            /*
             *Builder utiliza o padrao Fluent
             * Determina como será criado o campo no banco de dados
             */
            builder
                .Property(p => p.DataPedido)
                .IsRequired()
                .HasColumnType("datetime");

            //builder.Property(p => p.UsuarioId);
            /*
             * Nao precisa pq esta feito o relacionamento na classe "PAI" UsuarioConfiguration.cs 
            builder
                .HasOne(p => p.Usuario); //Pedido só pode ter um unico usuario
            */

            //builder.Property(p => p.ItensPedido);

            builder
                .Property(p => p.DataPrevisaoEntrega)
                .HasColumnType("datetime");

            builder
                .Property(p => p.CEP)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder
                .Property(p => p.Estado)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder
               .Property(p => p.Cidade)
               .IsRequired()
               .HasMaxLength(50)
               .HasColumnType("varchar(50)");

            builder
                .Property(p => p.EnderecoCompleto)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("varchar(200)");

            builder
                .Property(p => p.NumeroEndereco)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            //builder.Property(p => p.FormaPagamentoId);
            builder.HasOne(p => p.FormaPagamento);

        }
    }
}
