﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectAPI.Data;

namespace ProjectAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221031221857_Id_Revert")]
    partial class Id_Revert
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AlunoDisciplina", b =>
                {
                    b.Property<int>("AlunosId")
                        .HasColumnType("int");

                    b.Property<int>("DisciplinasId")
                        .HasColumnType("int");

                    b.HasKey("AlunosId", "DisciplinasId");

                    b.HasIndex("DisciplinasId");

                    b.ToTable("AlunoDisciplina");
                });

            modelBuilder.Entity("ProjectAPI.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data_Nascimento")
                        .HasColumnType("datetime2");

                    b.Property<int>("Matricula")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("ProjectAPI.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("ProjectAPI.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CursoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProfessorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("ProjectAPI.Notas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int?>("DisciplinaId")
                        .HasColumnType("int");

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("Notas");
                });

            modelBuilder.Entity("ProjectAPI.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("data_nascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("salario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("AlunoDisciplina", b =>
                {
                    b.HasOne("ProjectAPI.Aluno", null)
                        .WithMany()
                        .HasForeignKey("AlunosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectAPI.Disciplina", null)
                        .WithMany()
                        .HasForeignKey("DisciplinasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectAPI.Disciplina", b =>
                {
                    b.HasOne("ProjectAPI.Curso", "Curso")
                        .WithMany("Disciplinas")
                        .HasForeignKey("CursoId");

                    b.HasOne("ProjectAPI.Professor", "Professor")
                        .WithMany()
                        .HasForeignKey("ProfessorId");

                    b.Navigation("Curso");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("ProjectAPI.Notas", b =>
                {
                    b.HasOne("ProjectAPI.Aluno", "Aluno")
                        .WithMany("Notas")
                        .HasForeignKey("AlunoId");

                    b.HasOne("ProjectAPI.Disciplina", "Disciplina")
                        .WithMany("Notas")
                        .HasForeignKey("DisciplinaId");

                    b.Navigation("Aluno");

                    b.Navigation("Disciplina");
                });

            modelBuilder.Entity("ProjectAPI.Aluno", b =>
                {
                    b.Navigation("Notas");
                });

            modelBuilder.Entity("ProjectAPI.Curso", b =>
                {
                    b.Navigation("Disciplinas");
                });

            modelBuilder.Entity("ProjectAPI.Disciplina", b =>
                {
                    b.Navigation("Notas");
                });
#pragma warning restore 612, 618
        }
    }
}
