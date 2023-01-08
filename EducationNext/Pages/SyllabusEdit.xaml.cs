using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using static EducationNext.SyllabusVM;

namespace EducationNext.Pages
{
    /// <summary>
    /// Interaction logic for SyllabusEdit.xaml
    /// </summary>
    public partial class SyllabusEdit : Window
    {
        public SyllabusEdit()
        {
            InitializeComponent();
        }

        private void ListView_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (e.OriginalSource is System.Windows.Shapes.Rectangle || e.OriginalSource is System.Windows.Controls.Primitives.Thumb)
                    return;

                DataObject data = new DataObject(typeof(DragAndDropElement), new DragAndDropElement()
                {
                    MovementElement = (Element)(sender as ListView).SelectedItem,
                    SourceCollection = (sender as ListView).ItemsSource as ObservableCollection<Element>
                });
                
                DragDrop.DoDragDrop((ListView)sender, data, DragDropEffects.Copy | DragDropEffects.Move);
                GetInstance().RecalculateSemester();
            }
        }

        private void ListView_Drop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(DragAndDropElement)))
                return;


            var data = (DragAndDropElement)e.Data.GetData(typeof(DragAndDropElement));
            var collectionView = (sender as ListView).ItemsSource as ObservableCollection<Element>;

            collectionView.Add(data.MovementElement);

            data.SourceCollection.Remove(data.MovementElement);
            GetInstance().RecalculateSemester();
        }

        private void ListView_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (sender is ListView)
            {
                ((sender as ListView).Tag as Border).BorderBrush = new SolidColorBrush(Color.FromRgb(188, 188, 188));
            }           
        }

        private void ListView_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is ListView)
            {
                ((sender as ListView).Tag as Border).BorderBrush = new SolidColorBrush(Color.FromRgb(244, 245, 247));
            }
        }

        private void ListView_DragOver(object sender, DragEventArgs e)
        {
            if (sender is ListView)
            {
                ((sender as ListView).Tag as Border).BorderBrush = new SolidColorBrush(Color.FromRgb(188, 188, 188));
            }
        }

        private void ListView_DragLeave(object sender, DragEventArgs e)
        {
            if (sender is ListView)
            {
                ((sender as ListView).Tag as Border).BorderBrush = new SolidColorBrush(Color.FromRgb(244, 245, 247));
            }
        }

        
    }
}
