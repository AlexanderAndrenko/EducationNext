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
    [Index("DisciplineID", "CompetenceID", IsUnique = true)]
    public class DisciplineCompetence
    {
        [Key]
        public int Id { get; set; }
        public int DisciplineID { get; set; }
        public Discipline? Discipline { get; set; }
        public int CompetenceID { get; set; }
        public Competence? Competence { get; set; }

    }
}
