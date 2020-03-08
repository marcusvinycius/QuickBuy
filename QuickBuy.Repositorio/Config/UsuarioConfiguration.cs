using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Repositorio.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            //throw new NotImplementedException();
            //Qual propriedade de usuario será mapeada como chave primaria
            builder.HasKey(u => u.Id);
            
            /*
             *Builder utiliza o padrao Fluent
             * Determina como será criado o campo no banco de dados
             */
            builder
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder
                .Property(u => u.Senha)
                .IsRequired()
                .HasMaxLength(1000)
                .HasColumnType("varchar(1000)");

            builder
                .Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder
                .Property(u => u.SobreNome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder
                .HasMany(u => u.Pedidos) //Usuario tem muitos pedidos
                .WithOne(p => p.Usuario) //Pedido só pode está ligado a um unico usuario
                ;
        }
    }
}
