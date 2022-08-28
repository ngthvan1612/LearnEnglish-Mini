using LearnEnglish.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEnglish.App.Services
{
    public abstract class BaseRepository
    {
        private EnglishDbContext _context;
        protected EnglishDbContext Context => this._context;

        public BaseRepository()
        {
            this._context = new EnglishDbContext();
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
            this._context = new EnglishDbContext();
        }
    }
}
