using System.IO;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Tabela
            builder.ToTable("User");

            //Chave primaria
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

            builder.Property(x => x.Bio);
            builder.Property(x => x.Email);
            builder.Property(x => x.Image);
            builder.Property(x => x.PasswordHash);

            builder.Property(x => x.Slug)
            .IsRequired()
            .HasColumnName("Slug")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);


            // indices
            builder.HasIndex(x => x.Slug, "IX_USER_SLUG")
            .IsUnique();

            // N:N

            builder.HasMany(x => x.Roles)
            .WithMany(x => x.Users)
            .UsingEntity<Directory<string, object>>(
            "UserRole",
            role => role
            .HasOne<Role>()
            .WithMany()
            .HasForeignKey("RoleId")
            .HasConstraintName("FK_USER_ROLE_ROLE")
            .OnDelete(DeleteBehavior.Cascade),

            user => user
            .HasOne<User>()
            .WithMany()
            .HasForeignKey("UserId")
            .HasConstraintName("FK_USER_ROLE_USER")
            .OnDelete(DeleteBehavior.Cascade));
        }

    }

    internal class Directory<T1, T2>
    {
    }

}
