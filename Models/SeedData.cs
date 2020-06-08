using Kennisbank.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kennisbank.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new KennisbankContext(serviceProvider.GetRequiredService<DbContextOptions<KennisbankContext>>());

            if (context.Document.Any())
            {
                return;
            }

            context.Document.AddRange(
                new Document
                {
                    Name = "dynamics 365 handleiding",
                    Tag = "handleiding",
                    FileSize = 2,
                    AddedOn = DateTime.Now,
                    AddedBy = "mike",
                },

                new Document
                {
                    Name = "outlook handleiding",
                    Tag = "handleiding",
                    FileSize = 4,
                    AddedOn = DateTime.Now,
                    AddedBy = "ronald",
                },

                new Document
                {
                    Name = "scrum oefenexamen",
                    Tag = "examen",
                    FileSize = 8,
                    AddedOn = DateTime.Now,
                    AddedBy = "daan",
                },

                new Document
                {
                    Name = "leaseauto aanvraagformulier",
                    Tag = "aanvraagformulier",
                    FileSize = 1,
                    AddedOn = DateTime.Now,
                    AddedBy = "dirk",
                }
            );
            context.SaveChanges();
        }
    }
}
