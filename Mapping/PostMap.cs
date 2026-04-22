using System;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mapping
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(x => x.LastUpdateDate) // data padrão 01/01/1900
            .IsRequired()
            .HasColumnName("LasUpdateDate") // DATETIME NOT NULL DEFAULT(GETDATE())
            .HasColumnType("SMALLDATETIME")
            .HasDefaultValueSql("GETDATE()") //  se eu deixa como getDate vai gerar como default
            .HasDefaultValue(DateTime.Now.ToUniversalTime()); // não vai ter o sql
            /*
                para usar o sql do o datetime do dotnet
           */
        }
    }
}
