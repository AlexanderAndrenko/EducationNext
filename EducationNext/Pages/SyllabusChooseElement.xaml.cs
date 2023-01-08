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
using System.Windows.Shapes;

namespace EducationNext.Pages
{
    /// <summary>
    /// Interaction logic for SyllabusChooseElement.xaml
    /// </summary>
    public partial class SyllabusChooseElement : Window
    {
        public SyllabusChooseElement()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SyllabusVM.GetInstance().CBSelectionChanged();
        }
    }
}
