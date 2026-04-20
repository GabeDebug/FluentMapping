using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Mappings
{
    //                                                     passando o tipo
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Tabela
            builder.ToTable("Category");

            // Chave primária
            builder.HashKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            // Propriedades
            builder
                .Property(x => x.Name)
                .Property(x => x.Name)
                .IsRequired()
                .hasColumnType("NVARCHAR")
                .hasColumnName("Name")
                .HasMaxLength(80);
            // Fluent API mappings

            builder
                .Property(x => x.Slug)
                .IsRequired()
                .hasColumnType("VARCHAR")
                .hasColumnName("Slug")
                .HasMaxLength(80);
        }
    }
}
