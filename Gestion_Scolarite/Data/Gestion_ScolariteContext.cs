using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gestion_Scolarite.Models;

namespace Gestion_Scolarite.Data
{
    public class Gestion_ScolariteContext : DbContext
    {
        public Gestion_ScolariteContext (DbContextOptions<Gestion_ScolariteContext> options)
            : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Departement> Departements { get; set; }
        public DbSet<Enseignant> Enseignants { get; set; }
        public DbSet<Niveau> Nivaux { get; set; }
        public DbSet<Etudiant> Etudiants { get; set; }
        public DbSet<Filiere> Filieres { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Matiere> Matieres { get; set; }
        public DbSet<Seance> Seances { get; set; }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<Departement>().ToTable("Departement");
            modelBuilder.Entity<Enseignant>().ToTable("Enseignant");
            modelBuilder.Entity<Niveau>().ToTable("Niveau");
            modelBuilder.Entity<Etudiant>().ToTable("Etudiant");
            modelBuilder.Entity<Filiere>().ToTable("Filiere");
            modelBuilder.Entity<Module>().ToTable("Module");
            modelBuilder.Entity<Matiere>().ToTable("Matiere");
            modelBuilder.Entity<Seance>().ToTable("Seance");
            modelBuilder.Entity<Absence>().ToTable("Absence");
            modelBuilder.Entity<Note>().ToTable("Note");
        }
    }
}
