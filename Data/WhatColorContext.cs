using Microsoft.EntityFrameworkCore;
using WhatColor.Areas.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatColor.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WhatColor.Data
{
    public class WhatColorContext : IdentityDbContext<User>
    {
        public WhatColorContext(DbContextOptions<WhatColorContext> options) : base(options)
        {

        }

        public DbSet<Color> Colors { get; set; }
        public DbSet<ColorCategory> ColorCategories { get; set; }
        public DbSet<ColorHistory> ColorHistories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ImageLibrary> ImageLibraries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Color>().ToTable("Color");
            modelBuilder.Entity<ColorCategory>().ToTable("ColorCategory");
            modelBuilder.Entity<Image>().ToTable("Image");
            modelBuilder.Entity<ColorHistory>().ToTable("ColorHistory");
            modelBuilder.Entity<ImageLibrary>().ToTable("ImageLibrary");

            //Meer op meer ColorHistory
            modelBuilder.Entity<ColorHistory>()
                .HasOne<Color>(il => il.Color)
                .WithMany(c => c.ColorHistories)
                .HasForeignKey(il => il.ColorID);
            modelBuilder.Entity<ColorHistory>()
                .HasOne<User>(il => il.User)
                .WithMany(u => u.ColorHistories)
                .HasForeignKey(il => il.Id);

            //Meer op meer ImageLibrary
            modelBuilder.Entity<ImageLibrary>()
                .HasOne<Image>(il => il.Image)
                .WithMany(i => i.ImageLibraries)
                .HasForeignKey(il => il.ImageID);
            modelBuilder.Entity<ImageLibrary>()
                .HasOne<User>(il => il.User)
                .WithMany(u => u.ImageLibraries)
                .HasForeignKey(il => il.Id);
        }
    }
}
