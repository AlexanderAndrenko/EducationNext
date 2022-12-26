using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    [Index("EducationalStandartID", "CompetenceID", IsUnique = true)]
    public class EducationalStandartCompetence
    {
        [Key]
        public int Id { get; set; }
        public int EducationalStandartID { get; set; }
        public EducationalStandart? EducationalStandart { get; set; }
        public int CompetenceID { get; set; }
        public Competence? Competence { get; set; }
    }
}
