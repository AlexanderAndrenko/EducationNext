using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    internal class EducationalStandart
    {
        public int Id { get; set; }
        public string? SpecializationCode { get; set; }
        public float QuantityCreditUnit { get; set; }    
        public int QuantityTerm { get; set; }
        public float MaxQuantityCreditUnitPerYear { get; set; }
    }
}
