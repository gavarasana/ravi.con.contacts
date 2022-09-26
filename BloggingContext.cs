using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ravi.con.contacts
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

 
      
        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlite($"Data Source={DbPath}");

            var builder = new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json", true, true);

            var config = builder.Build();

            var contactsConnection = config.GetConnectionString("Contacts");

            options.UseSqlServer(contactsConnection);
            options.LogTo(message => Console.WriteLine(message));
        }

       
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string? Url { get; set; }

        public List<Post> Posts { get; } = new();
    }

    public class Post
    {
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
