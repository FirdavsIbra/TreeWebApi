using Microsoft.EntityFrameworkCore;

namespace Tree.DatabaseFirst.Models;

public partial class TreeDbFirstContext : DbContext
{
    public TreeDbFirstContext()
    {
    }

    public TreeDbFirstContext(DbContextOptions<TreeDbFirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Plot> Plots { get; set; }

    public virtual DbSet<Tree> Trees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=NBA-088-01-UZ\\SQLEXPRESS;Database=TreeDbFirst; Integrated Security=SSPI;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Plot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Plots__3214EC074EC69D9C");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Tree>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Trees__3214EC0741CCB83D");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Plot).WithMany(p => p.Trees)
                .HasForeignKey(d => d.PlotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Trees__PlotId__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
