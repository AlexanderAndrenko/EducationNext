using EducationNext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EducationNext.Pages
{
    /// <summary>
    /// Interaction logic for PracticModule.xaml
    /// </summary>
    public partial class PracticModule : UserControl
    {
        public PracticModule()
        {
            InitializeComponent();
            DataContext = PracticeVM.GetInstance();
        }
    }
}
