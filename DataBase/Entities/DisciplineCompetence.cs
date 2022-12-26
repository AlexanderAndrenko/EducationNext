using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    internal class DisciplineCompetence
    {
        public int Id { get; set; }
        public int DisciplineID { get; set; }
        public int CompetenceID { get; set; }
    }
}
