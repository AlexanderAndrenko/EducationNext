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
    [Index("SyllabusID", "DisciplineID", IsUnique = true)]

    public class SyllabusDiscipline
    {
        [Key]
        public int Id { get; set; }
        public int SyllabusID { get; set; }
        public Syllabus? Syllabus { get; set; }
        public int DisciplineID { get; set; }
        public Discipline? Discipline { get; set; }
        public int Semester { get; set; } = 0;
    }
}
