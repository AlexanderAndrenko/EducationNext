using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class Practic
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string MainType { get; set; } = "";
        public string Type { get; set; } = "";
        public float QuantityCreditUnit { get; set; }

        public List<PracticCompetence>? PracticCompetences { get; set; }
        public List<SyllabusPractic>? SyllabusPractics { get; set; }
        public List<EducationalStandartPractice>? EducationalStandartPractices { get; set; }
    }
}
