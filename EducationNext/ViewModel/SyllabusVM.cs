using DataBase.Entities;
using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static EducationNext.EducationalStandartVM;
using System.Collections.ObjectModel;
using System.Windows.Media;

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
            EditSyllabusElement = new(OpenWindowChooseElement);
            SaveChooseElementSyllabus = new(SaveChooseElement);
            Semesters = new List<Semester>();
            ElementsWithoutSemester = new ObservableCollection<Element>();
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

        #region Command

        public OwnCommand EditSyllabus { get; set; }
        public OwnCommand NewSyllabus { get; set; }
        public OwnCommand SaveSyllabus { get; set; }
        public OwnCommand DeleteSyllabus { get; set; }
        public OwnCommand EditSyllabusElement { get; set; }
        public OwnCommand SaveChooseElementSyllabus { get; set; }

        #endregion //Command

        #region Window
        public Window WindowEdit { get; set; }
        public Window WindowChooseElement { get; set; }

        #endregion //Window

        #region ListProperties

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

        #endregion //ListProperties

        #region BoardProperties

        private List<Semester> semesters;
        public List<Semester> Semesters 
        { 
            get => semesters;
            set
            {
                semesters = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<Element> elementsWithoutSemester;
        public ObservableCollection<Element> ElementsWithoutSemester
        { 
            get => elementsWithoutSemester; 
            set
            {
                elementsWithoutSemester = value;
                RaisePropertyChanged();
            }
        }

        #endregion //BoardProperties


        #endregion //Properties

        #region Methods
        public void GetSyllabus()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            DataGridSyllabus = cdb.GetSyllabuses();
        }

        #region WindowMethods
        private void OpenWindowEditSyllabus()
        {
            if (SelectedItem == null)
                SelectedItem = new();
            OpenWindowEdit();
        }
        private void OpenWindowNewSyllabus()
        {
            SelectedItem = new();
            OpenWindowEdit();
        }
        public void OpenWindowEdit()
        {
            GenerateElementsWithoutSemester();
            GenerateSemester();
            WindowEdit = new Pages.SyllabusEdit();
            WindowEdit.DataContext = this;
            WindowEdit.ShowDialog();
        }
        public void OpenWindowChooseElement()
        {
            UpdateListDiscipline();
            UpdateListPractice();
            UpdateListSFC();
            GenerateSemester();
            WindowChooseElement = new Pages.SyllabusChooseElement();
            WindowChooseElement.DataContext = this;
            WindowChooseElement.ShowDialog();
        }
        #endregion //WindowMethods

        #region EditWindowCommand
        private void SaveNewSyllabus()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();

            cdb.SetSyllabus(SelectedItem);
            GetSyllabus();
            WindowEdit.DialogResult = true;
        }
        private void DeleteSelectedSyllabus()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            cdb.DeleteSyllabus(SelectedItem);
            GetSyllabus();
        }
        #endregion //EditWindowCommand

        #region ChooseElementWindowCommand

        public void SaveChooseElement()
        {
            List<SyllabusDiscipline> SyllabusDiscipline =
                ListDiscipline
                .Where(x => x.IsChecked == true)
                .Select(x => new SyllabusDiscipline() { SyllabusID = x.ParentId, DisciplineID = x.Id })
                .ToList();

            SelectedItem.SyllabusDisciplines = SyllabusDiscipline;

            List<SyllabusPractic> SyllabusPractice =
                ListPractice
                .Where(x => x.IsChecked == true)
                .Select(x => new SyllabusPractic() { SyllabusID = x.ParentId, PracticID = x.Id })
                .ToList();

            SelectedItem.SyllabusPractics = SyllabusPractice;

            List<SyllabusStateFinalCertification> SyllabusStateFinalCertification =
                ListSFC
                .Where(x => x.IsChecked == true)
                .Select(x => new SyllabusStateFinalCertification() { SyllabusID = x.ParentId, StateFinalCertificationID = x.Id })
                .ToList();

            SelectedItem.SyllabusStateFinalCertifications = SyllabusStateFinalCertification;
        }

        #endregion //ChooseElementWindowCommand

        #region ListPropertiesMethods
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

            if (SelectedItem.SyllabusDisciplines != null)
            {
                foreach (var item in ListDiscipline)
                {
                    foreach (var itemSI in SelectedItem.SyllabusDisciplines)
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

            if (SelectedItem.SyllabusPractics != null)
            {
                foreach (var item in ListPractice)
                {
                    foreach (var itemSI in SelectedItem.SyllabusPractics)
                    {
                        if (item.Id == itemSI.PracticID)
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

            if (SelectedItem.SyllabusStateFinalCertifications != null)
            {
                foreach (var item in ListSFC)
                {
                    foreach (var itemSI in SelectedItem.SyllabusStateFinalCertifications)
                    {
                        if (item.Id == itemSI.StateFinalCertificationID)
                        {
                            item.IsChecked = true;
                        }
                    }
                }
            }
        }

        #endregion //ListPropertiesMethods

        #region GenerateSemester

        public void GenerateSemester()
        {
            //Затираем список семестров, если он уже был
            Semesters = new();

            //Инициализируем все семестры
            for (int i = 1; i <= 3; i++) //SelectedItem.EducationalProgram.EducationalStandart.QuantityTerm
            {
                Semesters.Add(
                    new Semester()
                    {
                        SemesterNumber = i,
                        SemesterQuantityCreditUnit = 0,
                        SemesterQuantityAcademicHour = 0
                    });
            }

            Semesters.ForEach(
                x =>
                {
                    x.Elements.Add(
                        new Element()
                        {
                            Id = 1,
                            Name = "TEST",
                            FormIntermediateCertification = "Экзамен",
                            Place = "Б1",
                            IsCourseWork = false,
                            QuantityCreditUnit = 3,
                            QuantityAcademicHour = 108
                        });
                });
            Semesters.ForEach(
                x =>
                {
                    x.Elements.ToList().ForEach(
                        y =>
                        {
                            if (y.IsCourseWork == true)
                            {
                                y.CourseWork = "Курсовая работа";
                            }
                        });
                });
        }

        public void GenerateElementsWithoutSemester()
        {
            SelectedItem.SyllabusDisciplines.ForEach(
                x =>
                {
                    ElementsWithoutSemester.Add(
                        new Element()
                        {
                            Id = x.Id,
                            Name = x.Discipline.Name,
                            FormIntermediateCertification = x.Discipline.FormIntermediateCertification,
                            Place = x.Discipline.Place,
                            IsCourseWork = x.Discipline.IsHaveCourseWork,
                            QuantityCreditUnit = x.Discipline.QuantityCreditUnit,
                            QuantityAcademicHour = x.Discipline.QuantityAcademicHour
                        });
                });

            ElementsWithoutSemester.ToList().ForEach(
                x =>
                {
                    if (x.IsCourseWork == true)
                    {
                        x.CourseWork = "Курсовая работа";
                    }
                });
        }

        #endregion //GenerateSemester

        #endregion //Methods

        public class ListItemModel
        {
            public int Id { get; set; } = 0;
            public int ParentId { get; set; } = 0;
            public string Name { get; set; } = "";
            public bool IsChecked { get; set; } = false;
        }

        public class Semester
        {
            public Semester()
            {
                elements = new ObservableCollection<Element>();
            }

            private ObservableCollection<Element> elements;
            public ObservableCollection<Element> Elements 
            { 
                get => elements;
                set
                {
                    elements = value;
                    CalculateSemesterProperties();
                }
            }

            public float SemesterQuantityCreditUnit { get; set; }
            public float SemesterQuantityAcademicHour { get; set; }
            public int SemesterNumber { get; set; }

            private void CalculateSemesterProperties()
            {
                SemesterQuantityCreditUnit = 0;
                Elements.ToList().ForEach(
                    x => 
                    {
                        SemesterQuantityCreditUnit += x.QuantityCreditUnit;
                        SemesterQuantityAcademicHour += x.QuantityAcademicHour;
                    }
                    );

            }            
        }
        public class Element
        {
            public int Id { get; set; } = 0;
            public string Name { get; set; } = "";
            public string Type { get; set; } = "Дисциплина";
            public string FormIntermediateCertification { get; set; } = "";
            public string Place { get; set; } = "";
            public bool IsCourseWork { get; set; } = false;
            public string CourseWork { get; set; } = "";
            public float QuantityCreditUnit { get; set; } = 0;
            public float QuantityAcademicHour { get; set; } = 0;
            public Brush ColorBrush { get; set; } = Brushes.Coral;
        }

        public class DragAndDropElement
        {
            public Element MovementElement { get; set; }
            public ObservableCollection<Element> SourceCollection { get; set; }
        }
    }
}
