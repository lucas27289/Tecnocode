using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted
{
    internal class Program
    {
        private static void Main()
        {
            using (var db = new BloggingContext())
            {
                // Para controlar que estan vacias
                var blogs = db.Blogs.ToList();
                var posts = db.Posts.ToList();
                var tags = db.Tags.ToList();

                // Agregamos un blog
                db.Blogs.Add(new Blog {Url = "https://miweb.com"});
                db.Blogs.Add(new Blog {Url = "https://www.miweb2.com.ar"});
                db.SaveChanges();

                // Vemos que se agrego correctamente
                var blogsList = db.Blogs.ToList();



                // Agregamos un par de posts
                db.Posts.Add(new Post {Title = "Post 1", Content = "Contenido post 1", Blog =db.Blogs.OrderBy(b => b.BlogId).First()});
                db.Posts.Add(new Post {Title = "Post 2", Content = "Contenido post 2", Blog =db.Blogs.OrderBy(b => b.BlogId).First()});
                db.SaveChanges();

                blogs = db.Blogs.ToList();


                db.Tags.Add(new Tag{ TagName = "Informatica", Posts= db.Posts.ToList() });
                db.Tags.Add(new Tag{ TagName = "Generico"});
                db.SaveChanges();

                
                tags = db.Tags.ToList();
                posts = db.Posts.ToList();




                // Vaciamos todo nuevamente
                foreach( var entity in db.Posts ){
                    db.Posts.Remove(entity);
                }
                db.SaveChanges();
                foreach( var entity in db.Tags ){
                    db.Tags.Remove(entity);
                }
                db.SaveChanges();
                foreach( var entity in db.Blogs ){
                    db.Blogs.Remove(entity);
                }
                db.SaveChanges();

            }
        }
    }
}