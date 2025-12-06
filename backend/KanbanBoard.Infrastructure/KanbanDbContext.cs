using KanbanBoard.Application.Abstractions;
using KanbanBoard.Domain;
using Microsoft.EntityFrameworkCore;

namespace KanbanBoard.Infrastructure;

public class KanbanDbContext : DbContext, IKanbanDbContext
{
    public KanbanDbContext(DbContextOptions<KanbanDbContext> options)
        : base(options)
    {
    }

    public DbSet<Board> Boards { get; set; }
    public DbSet<Column> Columns { get; set; }
    public DbSet<Card> Cards { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Board>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasMany(b => b.Columns)
                .WithOne(c => c.Board)
                .HasForeignKey("BoardId")
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Column>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasMany(c => c.Cards)
                .WithOne(card => card.Column)
                .HasForeignKey("ColumnId")
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex("BoardId", "Position")
                .IsUnique();
        });

        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).HasMaxLength(128);
            entity.Property(e => e.Description).HasMaxLength(1024);

            entity.HasIndex("ColumnId", "Position").IsUnique();
        });
    }
}