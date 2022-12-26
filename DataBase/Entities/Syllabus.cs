using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    [Index("EducationalProgramID")]
    public class Syllabus
    {
        [Key]
        public int Id { get; set; }
        public int EducationalProgramID { get; set; }
        public EducationalProgram? EducationalProgram { get; set; }

        public List<SyllabusDiscipline>? SyllabusDisciplines { get; set; }
        public List<SyllabusPractic>? SyllabusPractics { get; set; }
        public List<SyllabusStateFinalCertification>? SyllabusStateFinalCertifications { get; set; }
    }
}
