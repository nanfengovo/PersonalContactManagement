﻿using Microsoft.EntityFrameworkCore;
using PersonalContactManagement.EntityFrameCore.EntityModel;

namespace PersonalContactManagement.EntityFrameCore.Config
{
    public class MyDbContext:DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=contacts.db");
        }
    }
}
