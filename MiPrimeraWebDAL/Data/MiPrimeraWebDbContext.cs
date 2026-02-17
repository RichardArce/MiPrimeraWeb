using System;
using System.Collections.Generic;
using MiPrimeraWebDAL.Entidades;
using Microsoft.EntityFrameworkCore;

namespace MiPrimeraWebDAL.Data;

public partial class MiPrimeraWebDbContext : DbContext
{
    public MiPrimeraWebDbContext()
    {
    }

    public MiPrimeraWebDbContext(DbContextOptions<MiPrimeraWebDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carro> Carros { get; set; }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\richa\\Downloads\\DB.Browser.for.SQLite-v3.13.1-win64 (2)\\CarroDB.db");
    */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carro>(entity =>
        {
            entity.ToTable("Carro");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
