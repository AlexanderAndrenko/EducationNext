using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    [Index("SyllabusID", "StateFinalCertificationID", IsUnique = true)]
    public class SyllabusStateFinalCertification
    {
        [Key]
        public int Id { get; set; }
        public int SyllabusID { get; set; }
        public Syllabus? Syllabus { get; set; }
        public int StateFinalCertificationID { get; set; }
        public StateFinalCertification? StateFinalCertification { get; set; }
        public int Semester { get; set; } = 0;
    }
}
