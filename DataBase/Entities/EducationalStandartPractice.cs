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
    [Index("EducationalStandartID", "PracticeID", IsUnique = true)]
    [Index("EducationalStandartID")]
    public class EducationalStandartPractice
    {
        [Key]
        public int Id { get; set; }
        public int EducationalStandartID { get; set; }
        public EducationalStandart? EducationalStandart { get; set; }
        public int PracticeID { get; set; }
        public Practic? Practic { get; set; }
    }
}
