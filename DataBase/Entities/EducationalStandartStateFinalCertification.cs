using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    internal class EducationalStandartStateFinalCertification
    {
        public int Id { get; set; }
        public int EducationalStandartID { get; set; }
        public int StateFinalCertificationID { get; set; }
    }
}
