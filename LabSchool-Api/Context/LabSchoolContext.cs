using System;
using System.Collections.Generic;
using LabSchool_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace LabSchool_Api.Context;

public partial class LabSchoolContext : DbContext
{
    public LabSchoolContext()
    {
    }

    public LabSchoolContext(DbContextOptions<LabSchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aluno> Alunos { get; set; }

    public virtual DbSet<Pedagogo> Pedagogos { get; set; }

    public virtual DbSet<Professor> Professores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LabSchool;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluno>(entity =>
        {
            entity.HasKey(e => e.Codigo);

            entity.ToTable("Aluno");
        });

        modelBuilder.Entity<Pedagogo>(entity =>
        {
            entity.HasKey(e => e.Codigo);
        });

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.HasKey(e => e.Codigo);

            entity.ToTable("Professor");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
