using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Notechest.Models
{
    public class NotechestDBContext : DbContext
    {
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>().HasRequired(t => t.Project)
                .WithMany(t => t.Notes)
                .HasForeignKey(t => t.SourceKey)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Note>().HasRequired(t => t.Organization)
                .WithMany(t => t.Notes)
                .HasForeignKey(t => t.SourceKey)
                .WillCascadeOnDelete(false);
        }

        public override int SaveChanges()
        {
            foreach (var auditableEntity in ChangeTracker.Entries<IAuditable>())
            {
                if (auditableEntity.State == EntityState.Added || auditableEntity.State == EntityState.Modified)
                {
                    // Populate created date column for newly added record.
                    if (auditableEntity.State == EntityState.Added)
                    {
                        auditableEntity.Entity.CreatedOn = DateTime.Now;
                    }
                    else
                    {
                        // Modify updated date.
                        auditableEntity.Entity.LastModified = DateTime.Now;

                        // Make sure that code is not inadvertly modifying created date column. 
                        auditableEntity.Property(p => p.CreatedOn).IsModified = false;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}