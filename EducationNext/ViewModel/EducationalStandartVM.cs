using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataBase;
using DataBase.Entities;

namespace EducationNext
{
    public class EducationalStandartVM : BaseVM
    {
        #region Constructor
        private static EducationalStandartVM instance;

        public static EducationalStandartVM GetInstance()
        {
            if (instance == null)
                instance = new EducationalStandartVM();
            return instance;
        }

        private EducationalStandartVM()
        {
            GetEducationalStandart();
            EditEducationalStandart = new(OpenWindowEditEducationalStandart);
            NewEducationalStandart = new(OpenWindowNewEducationalStandart);
            SaveEducationalStandart = new(SaveNewEducationalStandart);
            DeleteEducationalStandart = new(DeleteSelectedEducationalStandart);
        }

        #endregion //Constructor

        #region Properties

        private List<EducationalStandart> dataGridEducationalStandart;

        public List<EducationalStandart> DataGridEducationalStandart 
        {
            get => dataGridEducationalStandart;
            set
            {
                dataGridEducationalStandart = value;
                RaisePropertyChanged();
            }
        }


        public EducationalStandart SelectedItem { get; set; }

        public OwnCommand EditEducationalStandart { get; set; }

        public OwnCommand NewEducationalStandart { get; set; }
        public OwnCommand SaveEducationalStandart { get; set; }
        public OwnCommand DeleteEducationalStandart { get; set; }

        private List<ListItemModel> listDiscipline;
        public List<ListItemModel> ListDiscipline 
        { 
            get => listDiscipline; 
            set
            {
                listDiscipline = value;
                RaisePropertyChanged();
            }
        }

        private List<ListItemModel> listPractice;
        public List<ListItemModel> ListPractice
        {
            get => listPractice;
            set
            {
                listPractice = value;
                RaisePropertyChanged();
            }
        }

        private List<ListItemModel> listSFC;
        public List<ListItemModel> ListSFC
        {
            get => listSFC;
            set
            {
                listSFC = value;
                RaisePropertyChanged();
            }
        }

        private List<ListItemModel> listCompetence;
        public List<ListItemModel> ListСompetence
        {
            get => listCompetence;
            set
            {
                listCompetence = value;
                RaisePropertyChanged();
            }
        }
        public Window WindowEdit { get; set; }

        #endregion //Properties

        #region Methods

        public void GetEducationalStandart()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            DataGridEducationalStandart = cdb.GetEducationalStandarts();
        }
        private void OpenWindowEditEducationalStandart()
        {
            if (SelectedItem == null)
                SelectedItem = new();
            OpenWindow();
        }
        private void OpenWindowNewEducationalStandart()
        {
            SelectedItem = new();
            OpenWindow();
        }
        private void SaveNewEducationalStandart()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();

            List<EducationalStandartDiscipline> educationalStandartDiscipline =
                ListDiscipline
                .Where(x => x.IsChecked == true)
                .Select(x => new EducationalStandartDiscipline() { EducationalStandartID = x.ParentId, DisciplineID = x.Id })
                .ToList();

            SelectedItem.EducationalStandartDisciplines = educationalStandartDiscipline;

            List<EducationalStandartPractice> educationalStandartPractice = 
                ListPractice
                .Where(x => x.IsChecked == true)
                .Select(x => new EducationalStandartPractice() { EducationalStandartID = x.ParentId, PracticeID = x.Id })
                .ToList();

            SelectedItem.EducationalStandartPractices = educationalStandartPractice;

            List<EducationalStandartStateFinalCertification> educationalStandartStateFinalCertification =
                ListSFC
                .Where(x => x.IsChecked == true)
                .Select(x => new EducationalStandartStateFinalCertification() { EducationalStandartID = x.ParentId, StateFinalCertificationID = x.Id })
                .ToList();

            SelectedItem.EducationalStandartStateFinalCertifications = educationalStandartStateFinalCertification;

            List<EducationalStandartCompetence> educationalStandartCompetence =
                ListСompetence
                .Where(x => x.IsChecked == true)
                .Select(x => new EducationalStandartCompetence() { EducationalStandartID = x.ParentId, CompetenceID = x.Id })
                .ToList();

            SelectedItem.EducationalStandartCompetences = educationalStandartCompetence;

            cdb.SetEducationalStandart(SelectedItem);
            GetEducationalStandart();
            WindowEdit.DialogResult = true;
        }
        private void DeleteSelectedEducationalStandart()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            cdb.DeleteEducationalStandart(SelectedItem);
            GetEducationalStandart();
        }
        private void OpenWindow()
        {
            UpdateListDiscipline();
            UpdateListPractice();
            UpdateListSFC();
            UpdateListCompetence();
            WindowEdit = new Pages.EducationalStandartNew();
            WindowEdit.DataContext = this;
            WindowEdit.ShowDialog();
        }
        private void UpdateListDiscipline()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            List<Discipline> listDiscipline = cdb.GetDisciplines();
            ListDiscipline = listDiscipline.Select(
                x => new ListItemModel()
                {
                    Id = x.Id,
                    Name = x.Name
                }
            ).ToList();

            if (SelectedItem.EducationalStandartDisciplines != null)
            {
                foreach (var item in ListDiscipline)
                {
                    foreach (var itemSI in SelectedItem.EducationalStandartDisciplines)
                    {
                        if (item.Id == itemSI.DisciplineID)
                        {
                            item.IsChecked = true;
                        }
                    }
                }
            }
        }
        private void UpdateListPractice()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            List<Practic> lstPrc = cdb.GetPractices();
            ListPractice = lstPrc.Select(
                x => new ListItemModel()
                {
                    Id = x.Id,
                    Name = x.Name
                }
            ).ToList();

            if (SelectedItem.EducationalStandartPractices != null)
            {
                foreach (var item in ListPractice)
                {
                    foreach (var itemSI in SelectedItem.EducationalStandartPractices)
                    {
                        if (item.Id == itemSI.PracticeID)
                        {
                            item.IsChecked = true;
                        }
                    }
                }
            }
        }
        private void UpdateListSFC()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            List<StateFinalCertification> lstSFC = cdb.GetStateFinalCertifications();
            ListSFC = lstSFC.Select(
                x => new ListItemModel()
                {
                    Id = x.Id,
                    Name = x.Name
                }
            ).ToList();

            if (SelectedItem.EducationalStandartStateFinalCertifications != null)
            {
                foreach (var item in ListSFC)
                {
                    foreach (var itemSI in SelectedItem.EducationalStandartStateFinalCertifications)
                    {
                        if (item.Id == itemSI.StateFinalCertificationID)
                        {
                            item.IsChecked = true;
                        }
                    }
                }
            }
        }
        private void UpdateListCompetence()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            List<Competence> lstCompetence = cdb.GetCompetences();
            ListСompetence = lstCompetence.Select(
                x => new ListItemModel()
                {
                    Id = x.Id,
                    Name = x.Name
                }
            ).ToList();

            if (SelectedItem.EducationalStandartCompetences != null)
            {
                foreach (var item in ListСompetence)
                {
                    foreach (var itemSI in SelectedItem.EducationalStandartCompetences)
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

        public class ListItemModel
        {
            public int Id { get; set; } = 0;
            public int ParentId { get; set; } = 0;
            public string Name { get; set; } = "";
            public bool IsChecked { get; set; } = false;
        }
    }
}
