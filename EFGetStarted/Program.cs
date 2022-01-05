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
                // Note: This sample requires the database to be created before running.
                Console.WriteLine($"Database path: {db.DbPath}.");
                
                // Create
                Console.WriteLine("Inserting a new blog");
                db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                db.SaveChanges();

                // Read
                Console.WriteLine("Querying for a blog");
                var blog = db.Blogs
                    .OrderBy(b => b.BlogId)
                    .First();

                var query = db.Blogs.Where(x => x.Url.Contains("http"));
                var sql = query.ToQueryString();

                // Update
                Console.WriteLine("Updating the blog and adding a post");
                blog.Url = "https://devblogs.microsoft.com/dotnet";
                blog.Posts.Add(
                    new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
                db.SaveChanges();

                var post = db.Posts.ToList();

                // Delete
                Console.WriteLine("Delete the blog");
                db.Remove(blog);
                db.SaveChanges();

                // Adding new Tags to db
                Console.WriteLine("Adding Tags");
                db.Add(new Tag { TagName = "Nuevo" });
                db.SaveChanges();
                Console.WriteLine("Tags added successfully");

                // Tags Query
                var tags = db.Tags.ToList();

                var fTag = db.Tags.OrderBy(b => b.TagId).First();

                fTag.posts = post;

            }
        }
    }
}