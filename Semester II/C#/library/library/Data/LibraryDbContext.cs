using library.Models;
using Microsoft.EntityFrameworkCore;

namespace library.Data;

public class LibraryDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Loan> Loans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=library;User=sa;Password=NewStrongPassword123;TrustServerCertificate=true;");

        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.author_id);
            entity.Property(e => e.name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.nationality).HasMaxLength(50);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.book_id);
            entity.Property(e => e.title).IsRequired().HasMaxLength(150);
            entity.Property(e => e.genre).HasMaxLength(50);
            entity.HasOne(d => d.Author)
                .WithMany(p => p.Books)
                .HasForeignKey(d => d.author_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_Authors");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.member_id);
            entity.Property(e => e.first_name).IsRequired().HasMaxLength(50);
            entity.Property(e => e.last_name).IsRequired().HasMaxLength(50);
            entity.Property(e => e.email).HasMaxLength(100);
            entity.Property(e => e.phone).HasMaxLength(15);
        });

        modelBuilder.Entity<Loan>(entity =>
        {
            entity.HasKey(e => e.loan_id);
            entity.HasOne(d => d.Book)
                .WithMany(p => p.Loans)
                .HasForeignKey(d => d.book_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Loans_Books");
            entity.HasOne(d => d.Member)
                .WithMany(p => p.Loans)
                .HasForeignKey(d => d.member_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Loans_Members");
        });
    }
}