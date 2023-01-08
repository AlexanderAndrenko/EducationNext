using DataBase.Entities;
using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static EducationNext.EducationalStandartVM;

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

        private List<CompetenceListItem> listCompetenceListItem;
        public List<CompetenceListItem> ListCompetenceListItem
        {
            get => listCompetenceListItem;
            set
            {
                listCompetenceListItem = value;
                RaisePropertyChanged();
            }
        }


        public Discipline SelectedItem { get; set; }
        public OwnCommand EditDiscipline { get; set; }
        public OwnCommand NewDiscipline { get; set; }
        public OwnCommand SaveDiscipline { get; set; }
        public OwnCommand DeleteDiscipline { get; set; }
        public Window WindowEdit { get; set; }

        #endregion //Properties

        #region Methods

        public void GetDiscipline()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            DataGridDiscipline = cdb.GetDisciplines();
            DataGridDiscipline.Where(x => x.IsHaveCourseWork == true).ToList().ForEach(x=>x.CourseWork = "Курсовая работа");
        }
        private void OpenWindowEditDiscipline()
        {
            if (SelectedItem == null)
                SelectedItem = new();
            OpenWindow();
        }
        private void OpenWindowNewDiscipline()
        {
            SelectedItem = new();
            OpenWindow();
        }
        private void SaveNewDiscipline()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();

            List<DisciplineCompetence> discilineCompetences = ListCompetenceListItem.Where(x => x.IsChecked == true).Select(x => new DisciplineCompetence() { DisciplineID = x.ParentId, CompetenceID = x.Id }).ToList();
            SelectedItem.DisciplineCompetences = discilineCompetences;
            cdb.SetDiscipline(SelectedItem);

            GetDiscipline();
            WindowEdit.DialogResult = true;
        }
        private void DeleteSelectedDiscipline()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            cdb.DeleteDiscipline(SelectedItem);
            GetDiscipline();
        }

        public void OpenWindow()
        {
            UpdateListCompetence();
            WindowEdit = new Pages.DisciplineEdit();
            WindowEdit.DataContext = this;
            WindowEdit.ShowDialog();
        }

        private void UpdateListCompetence()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            List<Competence> listCompetence = cdb.GetCompetences();

            ListCompetenceListItem = listCompetence.Select(
                x => new CompetenceListItem()
                {
                    Id = x.Id,
                    Name = x.Name
                }
            ).ToList();

            if (SelectedItem.DisciplineCompetences != null)
            {
                foreach (var item in ListCompetenceListItem)
                {
                    foreach (var itemSI in SelectedItem.DisciplineCompetences)
                    {
                        if (item.Id == itemSI.CompetenceID)
                        {
                            item.IsChecked = true;
                        }
                    }
                }
            }
        }

        #endregion //Methods

        public class CompetenceListItem
        {
            public int Id { get; set; } = 0;
            public int ParentId { get; set; } = 0;
            public string Name { get; set; } = string.Empty;
            public bool IsChecked { get; set; } = false;

        }
    }
}
