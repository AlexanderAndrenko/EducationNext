using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Competence> Competences { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<DisciplineCompetence> DisciplinesCompetences { get; set; }
        public DbSet<EducationalProgram> EducationalPrograms { get; set;}
        public DbSet<EducationalStandart> EducationalStandarts { get;set; }
        public DbSet<EducationalStandartCompetence> EducationalStandartCompetences { get; set; }
        public DbSet<EducationalStandartDiscipline> EducationalStandartDisciplines { get; set; }
        public DbSet<EducationalStandartPractice> EducationalStandartPractices { get; set; }
        public DbSet<EducationalStandartStateFinalCertification> EducationalStandartStateFinalCertifications { get; set; }
        public DbSet<Practic> Practics { get; set; }
        public DbSet<PracticCompetence> PracticsCompetences { get;set; }
        public DbSet<StateFinalCertification> StateFinalCertifications { get; set; }
        public DbSet<Syllabus> Syllabuses { get; set;}
        public DbSet<SyllabusDiscipline> SyllabusDisciplines { get; set; }
        public DbSet<SyllabusPractic> SyllabusPractics { get; set; }
        public DbSet<SyllabusStateFinalCertification> SyllabusStateFinalCertifications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=EducationNext");
        }
    }
}
