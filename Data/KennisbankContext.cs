using Kennisbank.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kennisbank.Data
{
    public class KennisbankContext : DbContext
    {
        public KennisbankContext (DbContextOptions<KennisbankContext> options)
            : base(options)
        {

        }

        public DbSet<Document> Document { get; set; }
    }
}
