using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Repository.Models
{
    public partial class BookcaseContext : DbContext
    {
        public BookcaseContext()
        {
        }

        public BookcaseContext(DbContextOptions<BookcaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TabBook> TabBook { get; set; }
        public virtual DbSet<TabUser> TabUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=Bookcase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TabBook>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__tab_book__490D1AE19A1B2D8B");

                entity.ToTable("tab_book");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.BookAuthor)
                    .HasColumnName("book_author")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BookBrief)
                    .HasColumnName("book_brief")
                    .IsUnicode(false);

                entity.Property(e => e.BookGenre).HasColumnName("book_genre");

                entity.Property(e => e.BookImg64)
                    .HasColumnName("book_img_64")
                    .IsUnicode(false);

                entity.Property(e => e.BookJoinDate)
                    .HasColumnName("book_join_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.BookPages).HasColumnName("book_pages");

                entity.Property(e => e.BookPublished)
                    .HasColumnName("book_published")
                    .HasColumnType("datetime");

                entity.Property(e => e.BookRate).HasColumnName("book_rate");

                entity.Property(e => e.BookTitle)
                    .IsRequired()
                    .HasColumnName("book_title")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<TabUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__tab_user__B9BE370F38E981A3");

                entity.ToTable("tab_user");

                entity.HasIndex(e => e.UserName)
                    .HasName("UQ__tab_user__7C9273C4ABEA8E01")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasColumnName("user_email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserFullName)
                    .IsRequired()
                    .HasColumnName("user_full_name")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.UserJoinDate)
                    .HasColumnName("user_join_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("user_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("user_password")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
