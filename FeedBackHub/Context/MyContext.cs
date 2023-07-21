using FeedBackHub.Models;
using Microsoft.EntityFrameworkCore;

namespace FeedBackHub.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Visitor> Visitors { get; set; }
    }
}