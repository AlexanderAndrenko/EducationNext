using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
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
            var window = new Pages.EducationalStandartNew();
            window.DataContext = this;
            window.ShowDialog();
        }
        private void OpenWindowNewEducationalStandart()
        {
            SelectedItem = new();
            var window = new Pages.EducationalStandartNew();
            window.DataContext = this;
            window.ShowDialog();
        }
        private void SaveNewEducationalStandart()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            cdb.SetEducationalStandart(SelectedItem);
            GetEducationalStandart();
        }
        private void DeleteSelectedEducationalStandart()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            cdb.DeleteEducationalStandart(SelectedItem);
            GetEducationalStandart();
        }

        #endregion //Methods

    }
}
