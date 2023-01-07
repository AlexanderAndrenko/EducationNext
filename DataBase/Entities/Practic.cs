using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    [Index("Id")]
    public class Practic
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string MainType { get; set; } = "";
        public string Type { get; set; } = "";
        public string Place { get; set; } = "";
        public float QuantityCreditUnit { get; set; } = 0;
        public float QuantityAcademicHour { get; set; } = 0;
        public List<PracticCompetence>? PracticCompetences { get; set; }
        public List<SyllabusPractic>? SyllabusPractics { get; set; }
        public List<EducationalStandartPractice>? EducationalStandartPractices { get; set; }
    }
}
