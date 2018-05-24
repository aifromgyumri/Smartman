using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Smartman.Models
{
    public class SmartmanDbContext : DbContext {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Datasource=.\\Database\\Smartestman.db");
        }

        public DbSet<UserModel> User { get; set; }

        public DbSet<QuestionModel> Question { get; set; }

        public DbSet<HistoryModel> History { get; set; }
    }
}