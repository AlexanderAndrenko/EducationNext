using DataBase.Entities;
using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EducationNext.DisciplineVM;
using System.Windows;

namespace EducationNext
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
            SelectionComboBoxChanged = new(GetComboBoxList);
            SelectedItem = new();
            MainTypeNewPractice = new(SelectedItem.MainType);        
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

        private List<string> comboBoxList;
        public List<string> ComboBoxList 
        { 
            get => comboBoxList;
            set
            {
                comboBoxList = value; 
                RaisePropertyChanged();
            }
        }

        private Practic selectedItem;
        public Practic SelectedItem 
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
            }
        }

        private string mainTypeNewPractice;
        public string MainTypeNewPractice
        {
            get => mainTypeNewPractice;
            set
            {
                mainTypeNewPractice = value;
                RaisePropertyChanged();
                SelectedItem.MainType = value;
                GetComboBoxList();                
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

        public OwnCommand EditPractice { get; set; }
        public OwnCommand NewPractice { get; set; }
        public OwnCommand SavePractice { get; set; }
        public OwnCommand DeletePractice { get; set; }
        public OwnCommand SelectionComboBoxChanged { get; set; }
        public Window WindowEdit { get; set; }

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
            OpenWindow();
        }
        private void OpenWindowNewPractice()
        {
            SelectedItem = new();
            OpenWindow();
        }
        private void SaveNewPractice()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();


            List<PracticCompetence> practicCompetences = ListCompetenceListItem.Where(x => x.IsChecked == true).Select(x => new PracticCompetence() { PracticID = x.ParentId, CompetenceID = x.Id }).ToList();

            SelectedItem.PracticCompetences = practicCompetences;

            cdb.SetPractice(SelectedItem);

            GetPractice();
            WindowEdit.DialogResult = true;
        }
        private void DeleteSelectedPractice()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            cdb.DeletePractice(SelectedItem);
            GetPractice();
        }
        private void OpenWindow()
        {
            UpdateListCompetence();

            WindowEdit = new Pages.PracticeEdit();
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

            if (SelectedItem.PracticCompetences != null)
            {
                foreach (var item in ListCompetenceListItem)
                {
                    foreach (var itemSI in SelectedItem.PracticCompetences)
                    {
                        if (item.Id == itemSI.CompetenceID)
                        {
                            item.IsChecked = true;
                        }
                    }
                }
            }            
        }

        private void GetComboBoxList()
        {
            if (SelectedItem.MainType == "Учебная")
            {
                ComboBoxList = new()
                {
                    "Ознакомительная",
                    "Технологическая (проектно-технологическая)",
                    "Эксплуатационная",
                    "Научно-исследовательская работа (получение первичных навыков научно-исследовательской работы)"
                };
            }
            else if (SelectedItem.MainType == "Производственная")
            {
                ComboBoxList = new()
                {
                    "Технологическая (проектно-технологическая)",
                    "Эксплуатационная",
                    "Научно-исследовательская работа",
                    "Педагогическая",
                    "Преддипломная"
                };
            }
            else
            {
                ComboBoxList = new();
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
