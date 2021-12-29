using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatColor.Models;

namespace WhatColor.Data
{
    public class WhatColorContext : DbContext
    {
        public WhatColorContext(DbContextOptions<WhatColorContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Color> Colors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Color>().ToTable("Color");
        }
    }
}
