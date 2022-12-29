using DataBase.Entities;
using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationNext.ViewModel
{
    public class PracticeVM : BaseVM
    {
        private static PracticeVM instance;

        public static PracticeVM GetInstance()
        {
            if (instance == null)
                instance = new PracticeVM();
            return instance;
        }
        private PracticeVM()
        {
            GetPractice();
            EditPractice = new(OpenWindowEditPractice);
            NewPractice = new(OpenWindowNewPractice);
            SavePractice = new(SaveNewPractice);
            DeletePractice = new(DeleteSelectedPractice);
        }

        #region Properties

        private List<Practic> dataGridPractice;
        public List<Practic> DataGridPractice
        {
            get => dataGridPractice;
            set
            {
                dataGridPractice = value;
                RaisePropertyChanged();
            }
        }

        public Practic SelectedItem { get; set; }

        public OwnCommand EditPractice { get; set; }
        public OwnCommand NewPractice { get; set; }
        public OwnCommand SavePractice { get; set; }
        public OwnCommand DeletePractice { get; set; }

        #endregion //Properties

        #region Methods

        public void GetPractice()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            DataGridPractice = cdb.GetPractices();
        }
        private void OpenWindowEditPractice()
        {
            if (SelectedItem == null)
                SelectedItem = new();
            var window = new Pages.PracticeEdit();
            window.DataContext = this;
            window.ShowDialog();
        }
        private void OpenWindowNewPractice()
        {
            SelectedItem = new();
            var window = new Pages.PracticeEdit();
            window.DataContext = this;
            window.ShowDialog();
        }
        private void SaveNewPractice()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            cdb.SetPractice(SelectedItem);
            GetPractice();
        }
        private void DeleteSelectedPractice()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            cdb.DeletePractice(SelectedItem);
            GetPractice();
        }

        #endregion //Methods
    }
}
