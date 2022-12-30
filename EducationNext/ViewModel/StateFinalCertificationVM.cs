using DataBase.Entities;
using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationNext
{
    public class StateFinalCertificationVM : BaseVM
    {
        private static StateFinalCertificationVM instance;

        public static StateFinalCertificationVM GetInstance()
        {
            if (instance == null)
                instance = new StateFinalCertificationVM();
            return instance;
        }
        private StateFinalCertificationVM()
        {
            GetStateFinalCertification();
            EditStateFinalCertification = new(OpenWindowEditStateFinalCertification);
            NewStateFinalCertification = new(OpenWindowNewStateFinalCertification);
            SaveStateFinalCertification = new(SaveNewStateFinalCertification);
            DeleteStateFinalCertification = new(DeleteSelectedStateFinalCertification);
        }

        #region Properties

        private List<StateFinalCertification> dataGridStateFinalCertification;
        public List<StateFinalCertification> DataGridStateFinalCertification
        {
            get => dataGridStateFinalCertification;
            set
            {
                dataGridStateFinalCertification = value;
                RaisePropertyChanged();
            }
        }

        public StateFinalCertification SelectedItem { get; set; }

        public OwnCommand EditStateFinalCertification { get; set; }
        public OwnCommand NewStateFinalCertification { get; set; }
        public OwnCommand SaveStateFinalCertification { get; set; }
        public OwnCommand DeleteStateFinalCertification { get; set; }

        #endregion //Properties

        #region Methods

        public void GetStateFinalCertification()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            DataGridStateFinalCertification = cdb.GetStateFinalCertifications();
        }
        private void OpenWindowEditStateFinalCertification()
        {
            if (SelectedItem == null)
                SelectedItem = new();
            var window = new Pages.StateFinalCertificationEdit();
            window.DataContext = this;
            window.ShowDialog();
        }
        private void OpenWindowNewStateFinalCertification()
        {
            SelectedItem = new();
            var window = new Pages.StateFinalCertificationEdit();
            window.DataContext = this;
            window.ShowDialog();
        }
        private void SaveNewStateFinalCertification()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            cdb.SetStateFinalCertification(SelectedItem);
            GetStateFinalCertification();
        }
        private void DeleteSelectedStateFinalCertification()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            cdb.DeleteStateFinalCertification(SelectedItem);
            GetStateFinalCertification();
        }

        #endregion //Methods
    }
}
