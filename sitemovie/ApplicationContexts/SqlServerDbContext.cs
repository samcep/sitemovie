using Microsoft.EntityFrameworkCore;
using sitemovie.Entities;

namespace sitemovie.ApplicationContexts
{
    public class SqlServerDbContext : DbContext
    {


        public SqlServerDbContext(DbContextOptions options) : base(options) 
        {
        
        }

        public  DbSet<Genre> Genres { get; set; }
        public  DbSet<Actor> Actors { get; set; }

    }
}
