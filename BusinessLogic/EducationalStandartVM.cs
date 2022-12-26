using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using DataBase;

namespace BusinessLogic
{
    public class EducationalStandartVM : BaseVM
    {
        private static EducationalStandartVM instance;

        public static EducationalStandartVM GetInstance()
        {
            if (instance == null)
                instance = new EducationalStandartVM();
            return instance;
        }

        private EducationalStandartVM()
        {

        }

        private List<EducationalStandart> dataGridEducationalStandart;

    }
}
