using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project1.Models
{
    public partial class DBPRUEBASContext : DbContext
    {
        public DBPRUEBASContext()
        {
        }

        public DBPRUEBASContext(DbContextOptions<DBPRUEBASContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tarea> Tareas { get; set; } = null!;
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               // optionsBuilder.UseSqlServer("Server=DESKTOP-A8VSFF7; DataBase=DBPRUEBAS;Integrated Security=true");
                //local    
                optionsBuilder.UseSqlServer("Data Source=SQL8003.site4now.net;Initial Catalog=db_a8ee55_jirazabal001;User Id=db_a8ee55_jirazabal001_admin;Password=44427210Joa");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.HasKey(e => e.IdTarea)
                    .HasName("PK__Tarea__756A5402B519C624");

                entity.ToTable("Tarea");

                entity.Property(e => e.IdTarea).HasColumnName("idTarea");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
