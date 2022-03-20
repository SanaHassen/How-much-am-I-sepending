using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Model;

namespace RecordsDB
{
    public class RecordsContext: DbContext
    {
       public DbSet<Record> Records { set; get; }

        public RecordsContext()
        {
            this.Database.EnsureCreated();
        }
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Records.DB");
            
        }
    }
}
