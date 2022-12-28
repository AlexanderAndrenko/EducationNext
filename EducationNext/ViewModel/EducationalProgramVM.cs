using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationNext
{
    public class EducationalProgramVM : BaseVM
    {
        private static EducationalProgramVM instance;

        public static EducationalProgramVM GetInstance()
        {
            if (instance == null)
                instance = new EducationalProgramVM();
            return instance;
        }
        private EducationalProgramVM()
        {

        }
    }
}
