using DataBase.Entities;
using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EducationNext
{
    public class EducationalProgramVM : BaseVM
    {
        private static EducationalProgramVM instance;

        public static EducationalProgramVM GetInstance()
        {
            if (instance == null)
                instance = new EducationalProgramVM();
            return instance;
        }
        private EducationalProgramVM()
        {
            GetEducationalProgram();
            EditEducationalProgram = new(OpenWindowEditEducationalProgram);
            NewEducationalProgram = new(OpenWindowNewEducationalProgram);
            SaveEducationalProgram = new(SaveNewEducationalProgram);
            DeleteEducationalProgram = new(DeleteSelectedEducationalProgram);
        }

        #region Properties

        private List<EducationalProgram> dataGridEducationalProgram;
        public List<EducationalProgram> DataGridEducationalProgram
        {
            get => dataGridEducationalProgram;
            set
            {
                dataGridEducationalProgram = value;
                RaisePropertyChanged();
            }
        }

        public List<EducationalStandart> comboBoxListES;
        public List<EducationalStandart> ComboBoxListES 
        { 
            get => comboBoxListES; 
            set
            {
                comboBoxListES = value;
                RaisePropertyChanged();
            }
        }
        public EducationalProgram SelectedItem { get; set; }

        public OwnCommand EditEducationalProgram { get; set; }
        public OwnCommand NewEducationalProgram { get; set; }
        public OwnCommand SaveEducationalProgram { get; set; }
        public OwnCommand DeleteEducationalProgram { get; set; }
        public Window WindowEdit { get; set; }

        #endregion //Properties

        #region Methods

        public void GetEducationalProgram()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            DataGridEducationalProgram = cdb.GetEducationalPrograms();
        }

        public void GetEducationalStandart()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            ComboBoxListES = cdb.GetEducationalStandarts();
            ComboBoxListES.ToList().ForEach(e => { e.CodePlusName = e.SpecializationCode + " " + e.Name; });
        }
        private void OpenWindowEditEducationalProgram()
        {
            if (SelectedItem == null)
                SelectedItem = new();
            OpenWindow();
        }
        private void OpenWindowNewEducationalProgram()
        {
            SelectedItem = new();
            GetEducationalStandart();
            OpenWindow();
        }
        private void SaveNewEducationalProgram()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            cdb.SetEducationalProgram(SelectedItem);
            GetEducationalProgram();
            WindowEdit.DialogResult = true;
        }
        private void DeleteSelectedEducationalProgram()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            cdb.DeleteEducationalProgram(SelectedItem);
            GetEducationalProgram();
        }

        public void OpenWindow()
        {
            GetEducationalStandart();
            WindowEdit = new Pages.EducationalProgramEdit();
            WindowEdit.DataContext = this;
            WindowEdit.ShowDialog();
        }

        #endregion //Methods
    }
}
