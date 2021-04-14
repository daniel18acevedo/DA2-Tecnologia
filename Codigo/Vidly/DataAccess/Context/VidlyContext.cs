using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DataAccess
{
    public class VidlyContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public VidlyContext() { }
        public VidlyContext(DbContextOptions options) : base(options) { }
    }
}
