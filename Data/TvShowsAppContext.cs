using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TvShowsApp.Models;

namespace TvShowsApp.Data
{
    public class TvShowsAppContext : DbContext
    {
        public TvShowsAppContext (DbContextOptions<TvShowsAppContext> options)
            : base(options)
        {
        }

        public DbSet<TvShowsApp.Models.TvShowModel> TvShowModel { get; set; }
    }
}
