using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class Discipline
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public float QuantityCreditUnit { get; set; }
        public float QuantityAcademicHour { get; set; }
        public string? FormIntermediateCertification { get; set; }
        public string? Place { get; set; }
        public bool IsIncludeToEducatiopnalProgramm { get; set; } = true;

        public List<EducationalStandartDiscipline>? EducationalStandartDisciplines { get; set; }
        public List<SyllabusDiscipline>? SyllabusDisciplines { get; set; }
        public List<DisciplineCompetence>? DisciplineCompetences { get; set; }
        
    }
}
