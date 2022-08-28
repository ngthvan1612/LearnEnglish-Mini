using LearnEnglish.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEnglish.Infrastructure.DataAccess
{
    public class EnglishDbContext : DbContext
    {
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Vocab> Vocabs { get; set; }

        private static bool isCreated = false;

        public EnglishDbContext()
        {
            if (!isCreated)
            {
                this.Database.EnsureCreated();
                isCreated = true;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=HocTiengAnh_02;Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
