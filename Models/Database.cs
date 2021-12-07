using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mastermind.Models
{
    public class Database:DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options)
        {


        }

        public DbSet<Highscores> Table { get; set; }
        public DbSet<Game_info> Game_info { get; set; }
        
    }
}
