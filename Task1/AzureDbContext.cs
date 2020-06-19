﻿using Microsoft.EntityFrameworkCore;

namespace Task1
{
    public class AzureDbContext : DbContext
    {
        public AzureDbContext(DbContextOptions<AzureDbContext> options) : base(options)
        {
        }

        protected AzureDbContext()
        {
                
        }

        public DbSet<Person> People { get; set; }
    }
}