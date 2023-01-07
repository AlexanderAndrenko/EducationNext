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
    [Index("PracticID", "CompetenceID", IsUnique = true)]
    public class PracticCompetence
    {
        [Key]
        public int Id { get; set; }
        public int PracticID { get; set; }
        public Practic? Practic { get; set; }
        public int CompetenceID { get; set; }
        public Competence? Competence { get; set; }
    }
}
