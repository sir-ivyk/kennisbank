using Kennisbank.Models;
using Microsoft.EntityFrameworkCore;

namespace Kennisbank.Data
{
    public class KennisbankContext : DbContext
    {
        public KennisbankContext (DbContextOptions<KennisbankContext> options)
            : base(options)
        {

        }

        public DbSet<Document> Document { get; set; }
        public DbSet<Tag> Tag { get; set; }
    }
}
