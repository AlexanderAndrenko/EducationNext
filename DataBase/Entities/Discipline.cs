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
    public class Discipline
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public float QuantityCreditUnit { get; set; }
        public float QuantityAcademicHour { get; set; }
        public string? FormIntermediateCertification { get; set; }
        public string? Place { get; set; }
        public bool IsIncludeToEducatiopnalProgram { get; set; } = true;
        public bool IsHaveCourseWork { get; set; } = false;

        [NotMapped]
        public string CourseWork { get; set; } = string.Empty;

        public List<EducationalStandartDiscipline>? EducationalStandartDisciplines { get; set; }
        public List<SyllabusDiscipline>? SyllabusDisciplines { get; set; }
        public List<DisciplineCompetence>? DisciplineCompetences { get; set; }
        
    }
}
