using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace EducationNext
{
    public class CompetenceVM : BaseVM
    {
        private static CompetenceVM instance;

        public static CompetenceVM GetInstance()
        {
            if (instance == null)
                instance = new CompetenceVM();
            return instance;
        }
        private CompetenceVM()
        {

        }
    }
}
