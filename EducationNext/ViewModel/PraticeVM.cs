using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationNext
{
    public class PraticeVM : BaseVM
    {
        private static PraticeVM instance;

        public static PraticeVM GetInstance()
        {
            if (instance == null)
                instance = new PraticeVM();
            return instance;
        }
        private PraticeVM()
        {

        }
    }
}
