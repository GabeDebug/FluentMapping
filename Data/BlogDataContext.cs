using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Blog.Data
{
    public class BlogDataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlServer(
                "Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$"
            );


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        // definindo tabelas
        {
            modelBuilder.ApplyConfiguration(new Category());
            modelBuilder.ApplyConfiguration(new User());
            modelBuilder.ApplyConfiguration(new Post());
            // aplicando configurações separadas para cada entidade
        }
    }
}
