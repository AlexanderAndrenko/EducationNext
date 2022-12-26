using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class MenuItemDataVM
    {
        public string Name { get; set; }
        public BaseVM ViewModel { get; set; }
        public override string ToString() => Name;

        public MenuItemDataVM(string name, BaseVM viewModel)
        {
            Name = name;
            ViewModel = viewModel;
        }
    }
}
