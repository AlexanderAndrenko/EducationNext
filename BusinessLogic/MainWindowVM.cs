using System.Buffers.Text;
using System.Collections.ObjectModel;

namespace BusinessLogic
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

            #region CreateListOfPages
            MenuItemsData = new ObservableCollection<MenuItemDataVM>()
            {
                new MenuItemDataVM("Образовательный стандарт", EducationalStandartVM.GetInstance()),
                new MenuItemDataVM("Образовательная программа", EducationalProgramVM.GetInstance()),
                new MenuItemDataVM("Учебный план", SyllabusVM.GetInstance()),
                new MenuItemDataVM("Дисциплина", DisciplineVM.GetInstance()),
                new MenuItemDataVM("Практика", PraticeVM.GetInstance()),
                new MenuItemDataVM("Компетенция", CompetenceVM.GetInstance()),
                new MenuItemDataVM("Настройки", SettingVM.GetInstance())
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