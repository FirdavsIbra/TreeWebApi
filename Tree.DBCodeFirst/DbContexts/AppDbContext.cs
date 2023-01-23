using Microsoft.EntityFrameworkCore;
using Tree.DBCodeFirst.Entities;

namespace Tree.DBCodeFirst.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Table of trees.
        /// </summary>
        public virtual DbSet<TreeDb> Trees { get; set; }

        /// <summary>
        /// Table of plots.
        /// </summary>
        public virtual DbSet<PlotDb> Plots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TreeDb>()
                .HasOne(t => t.Plot)
                .WithMany(p => p.Trees)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
