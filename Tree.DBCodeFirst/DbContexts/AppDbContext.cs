using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Tree.DBCodeFirst.Entities;

namespace Tree.DBCodeFirst.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public AppDbContext()
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

        /// <summary>
        /// Table of tree types.
        /// </summary>
        public virtual DbSet<TreeTypeDb> TreeTypes { get; set; }

        /// <summary>
        /// Table of tree sorts.
        /// </summary>
        public virtual DbSet<TreeSortDb> TreeSorts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=NBA-088-01-UZ\\SQLEXPRESS;Database=TreeDb;Trusted_Connection=True; TrustServerCertificate=True;",
                 builder => builder.EnableRetryOnFailure())
                 .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryPossibleUnintendedUseOfEqualsWarning));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TreeDb>()
                .HasOne(t => t.Plot)
                .WithMany(p => p.Trees)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TreeSortDb>()
                .HasOne(t => t.TreeType)
                .WithMany(s => s.TreeSorts)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
