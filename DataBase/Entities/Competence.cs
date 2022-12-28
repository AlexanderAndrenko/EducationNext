using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    [Index("Name", IsUnique = true)]
    public class Competence
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string TypeCompetence { get; set; } = "";
        public string ShortTypeCompetence { get; set; } = "";

        public List<DisciplineCompetence> DisciplineCompetences { get; set; } = new();
        public List<PracticCompetence> PracticCompetences { get; set; } = new();
        public List<EducationalStandartCompetence> EducationalStandartCompetences { get; set; } = new();
    }
}
