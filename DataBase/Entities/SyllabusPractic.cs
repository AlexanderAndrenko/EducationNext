using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    [Index("SyllabusID", "PracticID", IsUnique = true)]
    public class SyllabusPractic
    {
        [Key]
        public int Id { get; set; }
        public int SyllabusID { get; set; }
        public Syllabus? Syllabus { get; set; }
        public int PracticID { get; set; }
        public Practic? Practic { get;set; }
        public int Semester { get; set; } = 0;
    }
}
