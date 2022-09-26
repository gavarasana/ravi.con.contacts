// See https://aka.ms/new-console-template for more information
using ravi.con.contacts;

Console.WriteLine("Hello, World!");


using var db = new BloggingContext();

 

Console.WriteLine("Inserting a new blog");
db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
db.SaveChanges();

// Read
Console.WriteLine("Querying for a blog");
var blog = db.Blogs
    .OrderBy(b => b.BlogId)
    .First();

// Update
Console.WriteLine("Updating the blog and adding a post");
blog.Url = "https://devblogs.microsoft.com/dotnet";
blog.Posts.Add(
    new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });


var blogs = new List<Blog>();
var secondBlog = new Blog { Url = "http://blogs.msdn.com/functions" };
secondBlog.Posts.Add(new Post { Title = "Hello, Azure functions", Content = "My first content" });
secondBlog.Posts.Add(new Post { Title = "Awesome, Azure functions", Content = "I love az functions" });

blogs.Add(secondBlog);

var thirdBlog = new Blog { Url = "http://blogs.msdn.com/storage" };
thirdBlog.Posts.Add(new Post { Title = "Hello, Azure storage", Content = "Learning about storage content" });

blogs.Add(thirdBlog);


db.AddRange(blogs);

db.SaveChanges();

Console.WriteLine("Adding authors as a collection");

var authors = new List<Author>();
//authors.Add(new Author { FirstName = "Jon", LastName = "Denver" });
//authors.Add(new Author { FirstName = "Lisa", LastName = "May" });
//authors.Add(new Author { FirstName = "Tina", LastName = "Fay" });
//authors.Add(new Author { FirstName = "Elton", LastName = "John" });

//db.AddRange(authors);
//db.SaveChanges();


var authorLisa = db.Authors.FirstOrDefault(a => a.FirstName == "Lisa" && a.LastName == "May");
// Change Lisa's last name
if (authorLisa != null)
{
    authorLisa.LastName = "June";
}

var authorElton = db.Authors.FirstOrDefault(a => a.FirstName == "Lisa" && a.LastName == "May");
// Change Elton's first name
if (authorElton != null)
{
    authorElton.FirstName = "Almond";
}
authors.Add(new Author { FirstName = "Eric", LastName = "Clapton" });
authors.Add(new Author { FirstName = "Raj", LastName = "Muthu" });

db.AddRange(authors);

Console.WriteLine("Done adding authors as a collection");

// Delete
Console.WriteLine("Delete the blog");
db.Remove(blog);
db.SaveChanges();


