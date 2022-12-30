using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class EducationalStandart
    {
        [Key]
        public int Id { get; set; }
        public string SpecializationCode { get; set; } = "";
        public string? Name { get; set; }
        public float QuantityCreditUnit { get; set; }    
        public int QuantityTerm { get; set; }
        public float MaxQuantityCreditUnitPerYear { get; set; }

        public List<EducationalStandartCompetence>? EducationalStandartCompetences { get; set; }
        public List<EducationalStandartDiscipline>? EducationalStandartDisciplines { get; set; }
        public List<EducationalStandartPractice>? EducationalStandartPractices { get; set; }
        public List<EducationalStandartStateFinalCertification>? EducationalStandartStateFinalCertifications { get; set; }
        public List<EducationalProgram>? EducationalProgram { get; set; }
    }
}