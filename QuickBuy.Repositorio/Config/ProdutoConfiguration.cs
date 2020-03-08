using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Repositorio.Config
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            //throw new NotImplementedException();
            //Qual propriedade de Produto será mapeada como chave primaria
            builder.HasKey(p => p.Id);

            /*
             *Builder utiliza o padrao Fluent
             * Determina como será criado o campo no banco de dados
             */
            builder
                .Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder
                .Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnType("varchar(500)");

            builder
                .Property(p => p.Preco)
                .HasColumnType("decimal(18,4)");
        }
    }
}
