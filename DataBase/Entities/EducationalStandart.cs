using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    [Index("Id")]
    public class EducationalStandart
    {
        [Key]
        public int Id { get; set; }
        public string SpecializationCode { get; set; } = "";
        public string? Name { get; set; }
        public float QuantityCreditUnit { get; set; }
        public int QuantityTerm { get; set; } = 0;
        public float MaxQuantityCreditUnitPerYear { get; set; }
        [NotMapped]
        public string CodePlusName { get; set; } = string.Empty;

        public List<EducationalStandartCompetence>? EducationalStandartCompetences { get; set; }
        public List<EducationalStandartDiscipline>? EducationalStandartDisciplines { get; set; }
        public List<EducationalStandartPractice>? EducationalStandartPractices { get; set; }
        public List<EducationalStandartStateFinalCertification>? EducationalStandartStateFinalCertifications { get; set; }
        public List<EducationalProgram>? EducationalProgram { get; set; }
    }
}