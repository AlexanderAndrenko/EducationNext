using DataBase.Entities;
using DataBase;
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
            GetDiscipline();
            EditDiscipline = new(OpenWindowEditDiscipline);
            NewDiscipline = new(OpenWindowNewDiscipline);
            SaveDiscipline = new(SaveNewDiscipline);
            DeleteDiscipline = new(DeleteSelectedDiscipline);
        }

        #region Properties

        private List<Discipline> dataGridDiscipline;
        public List<Discipline> DataGridDiscipline
        {
            get => dataGridDiscipline;
            set
            {
                dataGridDiscipline = value;
                RaisePropertyChanged();
            }
        }

        public Discipline SelectedItem { get; set; }

        public OwnCommand EditDiscipline { get; set; }
        public OwnCommand NewDiscipline { get; set; }
        public OwnCommand SaveDiscipline { get; set; }
        public OwnCommand DeleteDiscipline { get; set; }

        #endregion //Properties

        #region Methods

        public void GetDiscipline()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            DataGridDiscipline = cdb.GetDisciplines();
        }
        private void OpenWindowEditDiscipline()
        {
            if (SelectedItem == null)
                SelectedItem = new();
            var window = new Pages.DisciplineEdit();
            window.DataContext = this;
            window.ShowDialog();
        }
        private void OpenWindowNewDiscipline()
        {
            SelectedItem = new();
            var window = new Pages.DisciplineEdit();
            window.DataContext = this;
            window.ShowDialog();
        }
        private void SaveNewDiscipline()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            cdb.SetDiscipline(SelectedItem);
            GetDiscipline();
        }
        private void DeleteSelectedDiscipline()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            cdb.DeleteDiscipline(SelectedItem);
            GetDiscipline();
        }

        #endregion //Methods
    }
}
