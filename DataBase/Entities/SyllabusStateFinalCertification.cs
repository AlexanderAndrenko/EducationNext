using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    internal class SyllabusStateFinalCertification
    {
        public int Id { get; set; }
        public int SyllabusID { get; set; }
        public int StateFinalCertificationID { get; set; }
    }
}
