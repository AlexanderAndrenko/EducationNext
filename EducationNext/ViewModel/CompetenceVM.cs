using DataBase;
using DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EducationNext
{
    public class CompetenceVM : BaseVM
    {
        private static CompetenceVM instance;

        public static CompetenceVM GetInstance()
        {
            if (instance == null)
                instance = new CompetenceVM();
            return instance;
        }
        private CompetenceVM()
        {
            GetCompetence();
            EditCompetence = new(OpenWindowEditCompetence);
            NewCompetence = new(OpenWindowNewCompetence);
            SaveCompetence = new(SaveNewCompetence);
            DeleteCompetence = new(DeleteSelectedCompetence);
        }

        #region Properties

        private List<Competence> dataGridCompetence;

        public List<Competence> DataGridCompetence
        {
            get => dataGridCompetence;
            set
            {
                dataGridCompetence = value;
                RaisePropertyChanged();
            }
        }

        public string NameNewCompetence { get; set; }

        private string typeNewCompetence;
        public string TypeNewCompetence 
        { 
            get => typeNewCompetence;
            set 
            {
                typeNewCompetence = value.ToString();
            }
        }
        public string DescriptionNewCompetence { get; set; }

        public Competence SelectedItem { get; set; }

        public OwnCommand EditCompetence { get; set; }
        public OwnCommand NewCompetence { get; set; }
        public OwnCommand SaveCompetence { get; set; }
        public OwnCommand DeleteCompetence { get; set; }
        public Window WindowEdit { get; set; }

        #endregion //Properties

        #region Methods

        public void GetCompetence()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            DataGridCompetence = cdb.GetCompetences();
        }
        private void OpenWindowEditCompetence()
        {
            if (SelectedItem == null)
                SelectedItem = new();

            NameNewCompetence = SelectedItem.Name;
            TypeNewCompetence = SelectedItem.TypeCompetence;
            DescriptionNewCompetence = SelectedItem.Description;
            OpenWindow();
        }
        private void OpenWindowNewCompetence()
        {
            SelectedItem = new();
            NameNewCompetence = SelectedItem.Name;
            TypeNewCompetence = SelectedItem.TypeCompetence;
            DescriptionNewCompetence = SelectedItem.Description;
            OpenWindow();
        }
        private void SaveNewCompetence()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            string shortTypeCompetence = TypeNewCompetence
                switch
                {
                    "Универсальная" => "УК",
                    "Общекультурная" => "ОК",
                    "Общепрофессиональная" => "ОПК",
                    "Профессиональная" => "ПО"
                };
            Competence competence =
                new()
                {
                    Name = NameNewCompetence,
                    TypeCompetence = TypeNewCompetence,
                    ShortTypeCompetence = shortTypeCompetence,
                    Description = DescriptionNewCompetence
                };
            cdb.SetCompetence(competence);
            GetCompetence();
            WindowEdit.DialogResult = true;
        }
        private void DeleteSelectedCompetence()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            cdb.DeleteCompetence(SelectedItem);
            GetCompetence();
        }

        private void OpenWindow()
        {
            WindowEdit = new Pages.EditCompetence();
            WindowEdit.DataContext = this;
            WindowEdit.ShowDialog();
        }

        #endregion //Methods
    }
}
