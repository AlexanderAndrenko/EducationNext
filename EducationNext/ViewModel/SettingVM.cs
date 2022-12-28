using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationNext
{
    public class SettingVM : BaseVM
    {
        private static SettingVM instance;

        public static SettingVM GetInstance()
        {
            if (instance == null)
                instance = new SettingVM();
            return instance;
        }
        private SettingVM()
        {

        }
    }
}
