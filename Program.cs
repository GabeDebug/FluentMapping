using System;
using System.Linq;
using System.Threading;
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new BlogDataContext();

            context.Users.Add(new User
            {
                Bio = "",
                Email = "",
                Image = "",
                Name = "",
                PasswordHash = "",
                Slug = ""
            });
            context.SaveChanges();

            var user = context.Users.FirstOrDefault();
            var post = new Post
            {
                Author = user,
                Body = "Meu artigo",
                Category = new Category
                {
                    Name = "Back-end",
                    Slug = "Back-end"
                },
                CreateDate = System.DateTime.Now,
                Slug = "meu-artigo",
                Summary = "Nesse artigo vamos se referir",
                Title = "Meu artigo",
            };
            context.Posts.Add(post);
            context.SaveChanges();
        }
    }
}
