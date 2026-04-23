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

            var post = new Post
            {
                Author = null,
                Body = "Meu artigo",
                Category = null,
                CreateDate = System.DateTime.Now,
                Slug = "meu-artigo",
                Summary = "Nesse artigo vamos se referir",
                Title = "Meu artigo",
            };
        }
    }
}
