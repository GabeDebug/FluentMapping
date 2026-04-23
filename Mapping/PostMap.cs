using System;
using System.Collections.Generic;
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
            // estou configurando a propriedade LastUpdateDate da minha entidade Post
            .IsRequired()
            // estou colocando obrigatoriamente (not null)
            .HasColumnName("LastUpdateDate") // DATETIME NOT NULL DEFAULT(GETDATE())
            // nome da coluna no banco
            .HasColumnType("SMALLDATETIME")
            // menos preciso
            .HasDefaultValueSql("GETDATE()") //  se eu deixa como getDate vai gerar como default
            // mais preciso | o valor que vem padrão no sql serve
            .HasDefaultValue(DateTime.Now.ToUniversalTime()); // não vai ter o sql
            /*
                para usar o sql do o datetime do dotnet
           */
            // Relacionamento
            builder.HasOne(x => x.Author)
            .WithMany(x => x.Posts)
            .HasConstraintName("FK_POST_AUTHOR")
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Category)
            .WithMany(x => x.Posts)
            .HasConstraintName("FK_POST_CATEGORY")
            .OnDelete(DeleteBehavior.Cascade);


            // Relacionamentos muitos para muitos
            builder.HasMany(x => x.Tags) // Um Post tem várias Tags
            .WithMany(x => x.Posts) // Uma Tag tem vários Posts
            .UsingEntity<Dictionary<string, object>>(
                "PostTag",
            post => post.HasOne<Tag>()
            .WithMany()
            .HasForeignKey("PostId")
            .HasConstraintName("FK_POST_TAG")
            .OnDelete(DeleteBehavior.Cascade),

            tag => tag.HasOne<Post>()
            .WithMany()
            .HasForeignKey("TagId")
            .HasConstraintName("FK_TAG_POST")
            .OnDelete(DeleteBehavior.Cascade)
            );
        }
    }
}
