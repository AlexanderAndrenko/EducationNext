using DataBase.Entities;
using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationNext
{
    public class SyllabusVM : BaseVM
    {
        private static SyllabusVM instance;

        public static SyllabusVM GetInstance()
        {
            if (instance == null)
                instance = new SyllabusVM();
            return instance;
        }
        private SyllabusVM()
        {
            GetSyllabus();
            EditSyllabus = new(OpenWindowEditSyllabus);
            NewSyllabus = new(OpenWindowNewSyllabus);
            SaveSyllabus = new(SaveNewSyllabus);
            DeleteSyllabus = new(DeleteSelectedSyllabus);
        }

        #region Properties

        private List<Syllabus> dataGridSyllabus;
        public List<Syllabus> DataGridSyllabus
        {
            get => dataGridSyllabus;
            set
            {
                dataGridSyllabus = value;
                RaisePropertyChanged();
            }
        }

        private List<EducationalProgram> comboBoxEducationalProgram;

        public List<EducationalProgram> ComboBoxEducationalProgram
        {
            get => comboBoxEducationalProgram;
            set
            {
                comboBoxEducationalProgram = value;
                RaisePropertyChanged();
            }
        }


        public Syllabus SelectedItem { get; set; }

        public OwnCommand EditSyllabus { get; set; }
        public OwnCommand NewSyllabus { get; set; }
        public OwnCommand SaveSyllabus { get; set; }
        public OwnCommand DeleteSyllabus { get; set; }

        #endregion //Properties

        #region Methods

        public void GetSyllabus()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            DataGridSyllabus = cdb.GetSyllabuses();
        }
        private void OpenWindowEditSyllabus()
        {
            if (SelectedItem == null)
                SelectedItem = new();
            var window = new Pages.SyllabusEdit();
            window.DataContext = this;
            window.ShowDialog();
        }
        private void OpenWindowNewSyllabus()
        {
            SelectedItem = new();
            var window = new Pages.SyllabusEdit();
            window.DataContext = this;
            window.ShowDialog();
        }
        private void SaveNewSyllabus()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            cdb.SetSyllabus(SelectedItem);
            GetSyllabus();
        }
        private void DeleteSelectedSyllabus()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            cdb.DeleteSyllabus(SelectedItem);
            GetSyllabus();
        }

        #endregion //Methods
    }
}
