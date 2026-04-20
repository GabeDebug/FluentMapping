using System.Security.Claims;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Data.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        // Se não fizer o contrato ainda irá fica dando erro
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // antess era [Table()]
            builder.ToTable("Category");

            // Chave Primária
            builder.HasKey(x => x.Id); // significa tem chave

            // Identity
            builder.Property(x => x.Id)
            .ValueGeneratedOnAdd() // Primary Key
            .UseIdentityColumn(); // aqui e como se fosse o identity(1, 1)

            // Propriedades
            builder.Property(x => x.Name)
            .IsRequired() // NOT NULL
            .HasColumnName("Name")
            .HasColumnType("NVACHAR")
            .HasMaxLength(80);
            /*
            uma API fluent
            */

            builder.Property(x => x.Slug)
            .IsRequired() // NOT NULL
            .HasColumnName("Slug")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);

            // Indices
            // Criação dos indices
            builder.HasIndex(x => x.Slug, "IX_Category_Slug")
            .IsUnique(); // vai transforma o slug em um índice único
        }
    }
}
