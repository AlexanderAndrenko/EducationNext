using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationNext
{
    public class DisciplineVM : BaseVM
    {
        private static DisciplineVM instance;

        public static DisciplineVM GetInstance()
        {
            if (instance == null)
                instance = new DisciplineVM();
            return instance;
        }
        private DisciplineVM()
        {

        }
    }
}
