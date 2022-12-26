using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    [Index("EducationalStandartID")]
    public class EducationalProgram
    {
        [Key]
        public int Id { get; set; }
        public int EducationalStandartID { get; set; }
        public EducationalStandart? EducationalStandart { get; set; }
        public List<Syllabus>? Syllabuses { get; set; }
    }
}
