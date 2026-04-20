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
        }
    }
}
