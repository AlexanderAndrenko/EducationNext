using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    internal class Discipline
    {
        public int Id { get; set; }
        public float QuantityCreditUnit { get; set; }
        public float QuantityAcademicHour { get; set; }
        public string? FormIntermediateCertification { get; set; }
        public string? Place { get; set; }
    }
}
