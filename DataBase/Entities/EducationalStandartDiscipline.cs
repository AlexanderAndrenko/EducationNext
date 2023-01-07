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
    [Index("EducationalStandartID", "DisciplineID", IsUnique = true)]
    [Index("EducationalStandartID")]
    public class EducationalStandartDiscipline
    {
        [Key]
        public int Id { get; set; }
        public int EducationalStandartID { get; set; }
        public EducationalStandart? EducationalStandart { get; set; }
        public int DisciplineID { get; set; }
        public Discipline? Discipline { get; set; }
    }
}
