using DataBase;
using System.Buffers.Text;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using DataBase.Entities;

namespace EducationNext
{
    public class MainWindowVM : BaseVM
    {
        #region Constructor
        private static MainWindowVM instance;
        public static MainWindowVM GetInstance()
        {
            if (instance == null)
                instance = new MainWindowVM();
            return instance;
        }
        private MainWindowVM()
        {
            ApplicationContext db = new ApplicationContext();
            db.Database.EnsureCreated();
            ConnectorDatabase cdb = new ConnectorDatabase();
            if (cdb.GetEducationalStandarts().Count() == 0)
            {
                cdb.InitializeDatabaseEntities();
            }

            #region CreateListOfPages
            MenuItemsData = new ObservableCollection<MenuItemDataVM>()
            {
                new MenuItemDataVM("Образовательный стандарт", EducationalStandartVM.GetInstance()),
                new MenuItemDataVM("Образовательная программа", EducationalProgramVM.GetInstance()),
                new MenuItemDataVM("Учебный план", SyllabusVM.GetInstance()),
                new MenuItemDataVM("Дисциплина", DisciplineVM.GetInstance()),
                new MenuItemDataVM("Практика", PracticeVM.GetInstance()),
                new MenuItemDataVM("ГИА", StateFinalCertificationVM.GetInstance()),
                new MenuItemDataVM("Компетенция", CompetenceVM.GetInstance())
                //new MenuItemDataVM("Настройки", SettingVM.GetInstance())
            };
            #endregion //CreateListOfPages

            #region CreateEventClickButton

            //backspaceButton = () => { };
            //BackspaceButtonClick = new MenuItemDataCommand(Backspace_btn_click);

            #endregion //CreateEventClickButton
        }
        #endregion //Constructor

        #region backspace button

        //public delegate void BackspaceButtonDelegate();
        //public event BackspaceButtonDelegate backspaceButton;
        //public MenuItemDataCommand BackspaceButtonClick { get; set; }

        //private void Backspace_btn_click()
        //{
        //    backspaceButton();
        //}

        #endregion //backspace button

        #region ListBoxItem
        public ObservableCollection<MenuItemDataVM> MenuItemsData { get; set; }

        private BaseVM currentContent;
        public BaseVM CurrentContent
        {
            get => currentContent;
            set
            {
                currentContent = value;
                RaisePropertyChanged();
            }
        }

        private MenuItemDataVM selectedMenu;
        public MenuItemDataVM SelectedMenu
        {
            get => selectedMenu;
            set
            {
                selectedMenu = value;
                CurrentContent = value.ViewModel;
                RaisePropertyChanged();
            }
        }
        #endregion //ListBoxItem

        private string _userNameSurname;
        public string UserNameSurname
        {
            get => _userNameSurname;
            set
            {
                _userNameSurname = value;
                RaisePropertyChanged();
            }
        }
    }
}