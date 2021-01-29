using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PostgreSQLDatabase_First.Models
{
    public partial class IssueTrackerContext : DbContext
    {
        public IssueTrackerContext()
        {
        }

        public IssueTrackerContext(DbContextOptions<IssueTrackerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Iteration> Iterations { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WorkItem> WorkItems { get; set; }
        public virtual DbSet<WorkItemComment> WorkItemComments { get; set; }
        public virtual DbSet<WorkItemState> WorkItemStates { get; set; }
        public virtual DbSet<WorkItemType> WorkItemTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("User ID =postgres;Password=postgres;Server=localhost;Port=5432;Database=IssueTracker;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_Turkey.1252");

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Iteration>(entity =>
            {
                entity.ToTable("Iteration");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<WorkItem>(entity =>
            {
                entity.ToTable("WorkItem");

                entity.HasIndex(e => e.IterationId, "IX_WorkItem_IterationId");

                entity.HasIndex(e => e.WorkItemStateId, "IX_WorkItem_WorkItemStateId");

                entity.HasIndex(e => e.WorkItemTypeId, "IX_WorkItem_WorkItemTypeId");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("1");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Iteration)
                    .WithMany(p => p.WorkItems)
                    .HasForeignKey(d => d.IterationId);

                entity.HasOne(d => d.WorkItemState)
                    .WithMany(p => p.WorkItems)
                    .HasForeignKey(d => d.WorkItemStateId);

                entity.HasOne(d => d.WorkItemType)
                    .WithMany(p => p.WorkItems)
                    .HasForeignKey(d => d.WorkItemTypeId);
            });

            modelBuilder.Entity<WorkItemComment>(entity =>
            {
                entity.HasIndex(e => e.CommentId, "IX_WorkItemComments_CommentId");

                entity.HasIndex(e => e.WorkItemId, "IX_WorkItemComments_WorkItemId");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.WorkItemComments)
                    .HasForeignKey(d => d.CommentId);

                entity.HasOne(d => d.WorkItem)
                    .WithMany(p => p.WorkItemComments)
                    .HasForeignKey(d => d.WorkItemId);
            });

            modelBuilder.Entity<WorkItemState>(entity =>
            {
                entity.ToTable("WorkItemState");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<WorkItemType>(entity =>
            {
                entity.ToTable("WorkItemType");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
