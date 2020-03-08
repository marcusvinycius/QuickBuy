using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Dominio.ObjetoDeValor;
using System;

namespace QuickBuy.Repositorio.Config
{
    public class FormaPagamentoConfiguration : IEntityTypeConfiguration<FormaPagamento>
    {
        public void Configure(EntityTypeBuilder<FormaPagamento> builder)
        {
            //throw new NotImplementedException();
            //Qual propriedade de FormaPagamento será mapeada como chave primaria
            builder.HasKey(FP => FP.Id);

            /*
             *Builder utiliza o padrao Fluent
             * Determina como será criado o campo no banco de dados
             */
            //builder.Property((FP => FP.EhBoleto);

            builder
                .Property(FP => FP.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder
                .Property(FP => FP.Descricao)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");
        }
    }
}
