using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    [Index("Id")]
    [Index("EducationalStandartID")]
    public class EducationalProgram
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Profile { get; set; } = "";
        public int EducationalStandartID { get; set; }
        [NotMapped]
        public string CodePlusNamePlusProfile { get; set; }
        public EducationalStandart? EducationalStandart { get; set; }
        public List<Syllabus>? Syllabuses { get; set; }
    }
}
