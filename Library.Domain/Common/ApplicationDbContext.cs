﻿using Library.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Domain.Common
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<NewsMessage> NewsMessages { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}