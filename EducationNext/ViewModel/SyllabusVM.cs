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
using System.Collections.Specialized;

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
            GetEducationalProgram();
            EditSyllabus = new(OpenWindowEditSyllabus);
            NewSyllabus = new(OpenWindowNewSyllabus);
            SaveSyllabus = new(SaveNewSyllabus);
            DeleteSyllabus = new(DeleteSelectedSyllabus);
            EditSyllabusElement = new(OpenWindowChooseElement);
            SaveChooseElementSyllabus = new(SaveChooseElement);
            CBSelectionChangedEP = new(CBSelectionChanged);
            Semesters = new ObservableCollection<Semester>();
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
        public OwnCommand CBSelectionChangedEP { get; set; }

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

        private ObservableCollection<Semester> semesters;
        public ObservableCollection<Semester> Semesters 
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

        public float TotalCreditUnuits { get; set; }
        public float TotalAcademicHours { get; set; }
        public string AllElementsDistribute { get; set; }

        #endregion //BoardProperties

        public bool IsOpenWindowChooseElements { get;set; } = false;

        #endregion //Properties

        #region Methods
        public void GetSyllabus()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            DataGridSyllabus = cdb.GetSyllabuses();
        }
        public void GetEducationalProgram()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            ComboBoxEducationalProgram = cdb.GetEducationalPrograms();
            ComboBoxEducationalProgram.ToList().ForEach(
                e =>
                {
                    e.CodePlusNamePlusProfile = 
                        e.EducationalStandart.SpecializationCode + " " +
                        e.Name + " \"" +
                        e.Profile + "\"";
                });
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
            ElementsWithoutSemester = new();
            Semesters = new();
            OpenWindowEdit();
        }
        public void OpenWindowEdit()
        {
            if (SelectedItem.Id != 0)
            {
                GenerateElementsWithoutSemester();
                GenerateSemester();
            }

            GetEducationalProgram();
            WindowEdit = new Pages.SyllabusEdit();
            WindowEdit.DataContext = this;
            WindowEdit.ShowDialog();
        }
        public void OpenWindowChooseElement()
        {
            UpdateListDiscipline();
            UpdateListPractice();
            UpdateListSFC();
            WindowChooseElement = new Pages.SyllabusChooseElement();
            WindowChooseElement.DataContext = this;
            WindowChooseElement.ShowDialog();
        }
        #endregion //WindowMethods

        #region EditWindowCommand
        private void SaveNewSyllabus()
        {
            //ConnectorDatabase cdb = new ConnectorDatabase();
            //cdb.SetSyllabus(SelectedItem);

            UpdateListDiscipline();
            UpdateListPractice();
            UpdateListSFC();
            SaveChooseElement();
            WindowEdit.DialogResult = true;
        }
        private void DeleteSelectedSyllabus()
        {
            ConnectorDatabase cdb = new ConnectorDatabase();
            cdb.DeleteSyllabus(SelectedItem);
            GetSyllabus();
        }
        public void CBSelectionChanged()
        {
            if (SelectedItem.SyllabusDisciplines == null)
            {
                SelectedItem.SyllabusDisciplines = new List<SyllabusDiscipline>();
            }

            if (SelectedItem.SyllabusPractics == null)
            {
                SelectedItem.SyllabusPractics = new List<SyllabusPractic>();
            }

            if (SelectedItem.SyllabusStateFinalCertifications == null)
            {
                SelectedItem.SyllabusStateFinalCertifications = new List<SyllabusStateFinalCertification>();
            }

            SelectedItem.SyllabusDisciplines.ForEach(syllabus => syllabus.Semester = 0);
            SelectedItem.SyllabusPractics.ForEach(practice => practice.Semester = 0);
            SelectedItem.SyllabusStateFinalCertifications.ForEach(sfc => sfc.Semester = 0);

            SelectedItem.EducationalProgram = ComboBoxEducationalProgram.Where(x => x.Id == SelectedItem.EducationalProgramID).FirstOrDefault();

            GenerateSemester();
            GenerateElementsWithoutSemester();        
        }

        #endregion //EditWindowCommand

        #region ChooseElementWindowCommand
        public void SaveChooseElement()
        {
            /*
             * Необходимо к выбранному списку элементов сопоставить те семестры, в которые некоторые элементы уже были определены.
             * Это нужно для того, чтобы список элементов не сбрасывался каждый раз при сохранении, а записывался в базу.
             */

            /*Подтягиваем семестры дисциплин*/
            Semesters
                .ToList()
                .ForEach(
                x =>
                {
                    x.Elements
                        .Where(y => y.TypeID == 1)
                        .ToList()
                        .ForEach(
                        z =>
                        {
                            ListDiscipline
                                .Where(x => x.IsChecked == true)
                                .ToList()
                                .ForEach(
                                y =>
                                {
                                    if (y.Id == z.Id)
                                    {
                                        y.Semester = x.SemesterNumber;
                                    }
                                });
                        });
                });

            /*Формируем список записей связок по дисциплинам*/
            List<SyllabusDiscipline> SyllabusDiscipline =
                ListDiscipline
                .Where(x => x.IsChecked == true)
                .Select(x => new SyllabusDiscipline() { SyllabusID = x.ParentId, DisciplineID = x.Id, Semester = x.Semester })
                .ToList();           

            SelectedItem.SyllabusDisciplines = SyllabusDiscipline;

            /*Подтягиваем семестры практик*/
            Semesters
                .ToList()
                .ForEach(
                x =>
                {
                    x.Elements
                        .Where(y => y.TypeID == 2)
                        .ToList()
                        .ForEach(
                        z =>
                        {
                            ListPractice
                                .Where(x => x.IsChecked == true)
                                .ToList()
                                .ForEach(
                                y =>
                                {
                                    if (y.Id == z.Id)
                                    {
                                        y.Semester = x.SemesterNumber;
                                    }
                                });
                        });
                });

            /*Формируем список записей связок по практикам*/
            List<SyllabusPractic> SyllabusPractice =
                ListPractice
                .Where(x => x.IsChecked == true)
                .Select(x => new SyllabusPractic() { SyllabusID = x.ParentId, PracticID = x.Id, Semester = x.Semester })
                .ToList();

            SelectedItem.SyllabusPractics = SyllabusPractice;

            /*Подтягиваем семестры ГИА*/
            Semesters
                .ToList()
                .ForEach(
                x =>
                {
                    x.Elements
                        .Where(y => y.TypeID == 3)
                        .ToList()
                        .ForEach(
                        z =>
                        {
                            ListSFC
                                .Where(x => x.IsChecked == true)
                                .ToList()
                                .ForEach(
                                y =>
                                {
                                    if (y.Id == z.Id)
                                    {
                                        y.Semester = x.SemesterNumber;
                                    }
                                });
                        });
                });

            /*Формируем список записей связок по ГИА*/
            List<SyllabusStateFinalCertification> SyllabusStateFinalCertification =
                ListSFC
                .Where(x => x.IsChecked == true)
                .Select(x => new SyllabusStateFinalCertification() { SyllabusID = x.ParentId, StateFinalCertificationID = x.Id, Semester = x.Semester })
                .ToList();

            SelectedItem.SyllabusStateFinalCertifications = SyllabusStateFinalCertification;

            ConnectorDatabase cdb = new ConnectorDatabase();
            cdb.SetSyllabus(SelectedItem);

            int IdSyllabus = SelectedItem.Id;
            GetSyllabus();
            if (IdSyllabus == 0)
            {
                SelectedItem = DataGridSyllabus.OrderBy(x=>x.Id).Last();
            }
            else
            {
                SelectedItem = DataGridSyllabus.Where(x => x.Id == IdSyllabus).FirstOrDefault();
            }            

            GenerateElementsWithoutSemester();

            if (SelectedItem.EducationalProgram != null && SelectedItem.EducationalProgram.EducationalStandart != null)
            {
                GenerateSemester();
            }

            if (WindowChooseElement != null && (WindowChooseElement.DialogResult == false || WindowChooseElement.DialogResult == null))
            {
                WindowChooseElement.DialogResult = true;
            }            
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

                    if (SelectedItem.EducationalProgram.EducationalStandart.EducationalStandartDisciplines != null)
                    {
                        foreach (var itemSI in SelectedItem.EducationalProgram.EducationalStandart.EducationalStandartDisciplines)
                        {
                            if (item.Id == itemSI.DisciplineID)
                            {
                                item.IsChecked = true;
                                item.IsNotMandatory = false;
                            }
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

                    if (SelectedItem.EducationalProgram.EducationalStandart.EducationalStandartPractices != null)
                    {
                        foreach (var itemSI in SelectedItem.EducationalProgram.EducationalStandart.EducationalStandartPractices)
                        {
                            if (item.Id == itemSI.PracticeID)
                            {
                                item.IsChecked = true;
                                item.IsNotMandatory = false;
                            }
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

                    if (SelectedItem.EducationalProgram.EducationalStandart.EducationalStandartStateFinalCertifications != null)
                    {
                        foreach (var itemSI in SelectedItem.EducationalProgram.EducationalStandart.EducationalStandartStateFinalCertifications)
                        {
                            if (item.Id == itemSI.StateFinalCertificationID)
                            {
                                item.IsChecked = true;
                                item.IsNotMandatory = false;
                            }
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
            for (int i = 1; i <= SelectedItem.EducationalProgram.EducationalStandart.QuantityTerm; i++)
            {
                Semesters.Add(
                    new Semester()
                    {
                        SemesterNumber = i,
                        SemesterQuantityCreditUnit = 0,
                        SemesterQuantityAcademicHour = 0,
                        MaxCreditUnit = SelectedItem.EducationalProgram.EducationalStandart.MaxQuantityCreditUnitPerYear
                    });
            }

            //Наполняет семестры дисциплинами, практиками и ГИА
            Semesters
                .ToList()
                .ForEach(
                    x =>
                    {
                        SelectedItem.SyllabusDisciplines
                            .Where(y => y.Semester == x.SemesterNumber)
                            .ToList()
                            .ForEach(
                                z => x.Elements.Add( new Element(z.Discipline))
                                );
                        SelectedItem.SyllabusPractics
                            .Where(y => y.Semester == x.SemesterNumber)
                            .ToList()
                            .ForEach(
                                z => x.Elements.Add(new Element(z.Practic))
                                );
                        SelectedItem.SyllabusStateFinalCertifications
                            .Where(y => y.Semester == x.SemesterNumber)
                            .ToList()
                            .ForEach(
                                z => x.Elements.Add(new Element(z.StateFinalCertification))
                                );
                    });
            RecalculateSemester();
        }
        public void CheckIsOverSemesters()
        {
            for (int i = 0; i < Semesters.Count(); i = i + 2)
            {
                int indexFirst = i;
                int indexSecond = i + 1;

                if (indexSecond < Semesters.Count())
                {
                    if (Semesters[indexFirst].SemesterQuantityCreditUnit + Semesters[indexSecond].SemesterQuantityCreditUnit > SelectedItem.EducationalProgram.EducationalStandart.MaxQuantityCreditUnitPerYear)
                    {
                        Semesters[indexFirst].IsOverMax = true;
                        Semesters[indexFirst].ListBorderBrush = new SolidColorBrush(Color.FromRgb(254, 192, 191));
                        Semesters[indexSecond].IsOverMax = true;
                        Semesters[indexSecond].ListBorderBrush = new SolidColorBrush(Color.FromRgb(254, 192, 191));
                    }
                    else
                    {
                        Semesters[indexFirst].IsOverMax = false;
                        Semesters[indexFirst].ListBorderBrush = new SolidColorBrush(Color.FromRgb(244, 245, 247));
                        Semesters[indexSecond].IsOverMax = false;
                        Semesters[indexSecond].ListBorderBrush = new SolidColorBrush(Color.FromRgb(244, 245, 247));
                    }

                }
                else if (Semesters[indexFirst].SemesterQuantityCreditUnit > SelectedItem.EducationalProgram.EducationalStandart.MaxQuantityCreditUnitPerYear)
                {
                    Semesters[indexFirst].IsOverMax = true;
                    Semesters[indexFirst].ListBorderBrush = new SolidColorBrush(Color.FromRgb(254, 192, 191));
                }
                else
                {
                    Semesters[indexFirst].IsOverMax = false;
                    Semesters[indexFirst].ListBorderBrush = new SolidColorBrush(Color.FromRgb(244, 245, 247));
                }
            }

            Semesters.Where(x=>x.IsOverMax == false).ToList().ForEach(x=>x.ListBorderBrush = new SolidColorBrush(Color.FromRgb(244, 245, 247)));
        }
        public void GenerateElementsWithoutSemester()
        {
            ElementsWithoutSemester = new();

            SelectedItem.SyllabusDisciplines
                .Where(y=>y.Semester == 0)
                .ToList()
                .ForEach(
                    x => 
                    { 
                        ElementsWithoutSemester.Add( new Element(x.Discipline));
                    });

            SelectedItem.SyllabusPractics
                .Where(y => y.Semester == 0)
                .ToList()
                .ForEach(
                    x =>
                    {
                        ElementsWithoutSemester.Add(new Element(x.Practic));
                    });

            SelectedItem.SyllabusStateFinalCertifications
                .Where(y => y.Semester == 0)
                .ToList()
                .ForEach(
                    x =>
                    {
                        ElementsWithoutSemester.Add(new Element(x.StateFinalCertification));
                    });
            CheckMandatoryElementsWithoutSemester();
            RecalculateSemester();
        }
        public void RecalculateSemester()
        {
            Semesters.ToList().ForEach(
                x => x.CalculateSemesterProperties()
                );
            RecalculateTotal();
            CheckIsOverSemesters();
            CheckNullElement();
            CheckMandatorySemesters();
            CheckDistributeMandatoryElements();
        }        
        public void CheckNullElement()
        {
            Semesters.ToList().ForEach(
                semesters =>
                {
                    semesters.Elements.ToList().ForEach(x =>
                    {
                        if (x == null)
                        {
                            semesters.Elements.Remove(x);
                        }
                    });
                });
            ElementsWithoutSemester.ToList().ForEach(
                x =>
                {
                    if (x == null)
                    {
                        ElementsWithoutSemester.Remove(x);
                    }
                }
                );
        }
        public void CheckMandatoryElementsWithoutSemester()
        {
            ElementsWithoutSemester.ToList().ForEach(
                x =>
                {
                    switch (x.TypeID)
                    {
                        case 1:
                            if (SelectedItem.EducationalProgram.EducationalStandart.EducationalStandartDisciplines == null)
                            {
                                SelectedItem.EducationalProgram.EducationalStandart.EducationalStandartDisciplines = new List<EducationalStandartDiscipline>();
                            }

                            SelectedItem.EducationalProgram.EducationalStandart.EducationalStandartDisciplines.ForEach(
                                y =>
                                {
                                    if (y.DisciplineID == x.Id)
                                    {
                                        x.Visibility = Visibility.Visible;
                                        x.IsNotMandatory = false;
                                    }
                                }
                                );
                            break;
                        case 2:
                            if (SelectedItem.EducationalProgram.EducationalStandart.EducationalStandartPractices == null)
                            {
                                SelectedItem.EducationalProgram.EducationalStandart.EducationalStandartPractices = new List<EducationalStandartPractice>();
                            }

                            SelectedItem.EducationalProgram.EducationalStandart.EducationalStandartPractices.ForEach(
                                y =>
                                {
                                    if (y.PracticeID == x.Id)
                                    {
                                        x.Visibility = Visibility.Visible;
                                        x.IsNotMandatory = false;
                                    }
                                }
                                );
                            break;
                        case 3:
                            if (SelectedItem.EducationalProgram.EducationalStandart.EducationalStandartStateFinalCertifications == null)
                            {
                                SelectedItem.EducationalProgram.EducationalStandart.EducationalStandartStateFinalCertifications = new List<EducationalStandartStateFinalCertification>();
                            }

                            SelectedItem.EducationalProgram.EducationalStandart.EducationalStandartStateFinalCertifications.ForEach(
                                y =>
                                {
                                    if (y.StateFinalCertificationID == x.Id)
                                    {
                                        x.Visibility = Visibility.Visible;
                                        x.IsNotMandatory = false;
                                    }
                                }
                                );
                            break;
                        default:
                            x.Visibility = Visibility.Hidden;
                            x.IsNotMandatory = true;
                            break;
                    }
                }
                );
        }
        public void CheckMandatorySemesters()
        {
            Semesters.ToList().ForEach(
                x =>
                {
                    x.Elements.ToList().ForEach(
                        y =>
                        {
                            switch (y.TypeID)
                            {
                                case 1:
                                    SelectedItem.EducationalProgram.EducationalStandart.EducationalStandartDisciplines.ForEach(
                                        z =>
                                        {
                                            if (z.DisciplineID == y.Id)
                                            {
                                                y.Visibility = Visibility.Visible;
                                                y.IsNotMandatory = false;
                                            }
                                        }
                                        );
                                    break;
                                case 2:
                                    SelectedItem.EducationalProgram.EducationalStandart.EducationalStandartPractices.ForEach(
                                        z =>
                                        {
                                            if (z.PracticeID == y.Id)
                                            {
                                                y.Visibility = Visibility.Visible;
                                                y.IsNotMandatory = false;
                                            }
                                        }
                                        );
                                    break;
                                case 3:
                                    SelectedItem.EducationalProgram.EducationalStandart.EducationalStandartStateFinalCertifications.ForEach(
                                        z =>
                                        {
                                            if (z.StateFinalCertificationID == y.Id)
                                            {
                                                y.Visibility = Visibility.Visible;
                                                y.IsNotMandatory = false;
                                            }
                                        }
                                        );
                                    break;
                                default:
                                    y.Visibility = Visibility.Hidden;
                                    y.IsNotMandatory = true;
                                    break;
                            }
                        }
                        );
                });
        }

        #endregion //GenerateSemester

        #region CalculationGlobalProperties
        public void RecalculateTotal()
        {
            TotalCreditUnuits = 0;
            TotalAcademicHours = 0;

            Semesters.ToList().ForEach(
                x =>
                {
                    TotalCreditUnuits += x.SemesterQuantityCreditUnit;
                    TotalAcademicHours += x.SemesterQuantityAcademicHour;
                });
            RaisePropertyChanged(nameof(TotalCreditUnuits));
            RaisePropertyChanged(nameof(TotalAcademicHours));
        }
        public void CheckDistributeMandatoryElements()
        {
            if (ElementsWithoutSemester.Where(x=>x.IsNotMandatory == false).ToList().Count() > 0)
            {
                AllElementsDistribute = "Распределены не все\nобязательные элементы";
            }
            else
            {
                AllElementsDistribute = "";
            }

            RaisePropertyChanged(nameof(AllElementsDistribute));
        }
        #endregion //CalculationGlobalProperties

        #endregion //Methods

        public class ListItemModel
        {
            public int Id { get; set; } = 0;
            public int ParentId { get; set; } = 0;
            public string Name { get; set; } = "";
            public bool IsChecked { get; set; } = false;
            public int Semester { get; set; } = 0;
            public bool IsNotMandatory { get; set; } = true;

        }
        public class Semester : BaseVM
        {
            public Semester()
            {
                Elements = new ObservableCollection<Element>();
                Elements.CollectionChanged += Elements_CollectionChanged;
                ListBorderBrush = new SolidColorBrush(Color.FromRgb(244, 245, 247));
            }

            private void Elements_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
            {
                CalculateSemesterProperties();
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

            private Brush listBorderBrush;
            public Brush ListBorderBrush
            {
                get => listBorderBrush;
                set
                {
                    listBorderBrush = value;
                    RaisePropertyChanged();
                }
            }
            public bool IsOverMax { get; set; } = false;
            public float MaxCreditUnit { get; set; } = 0;
            public void CalculateSemesterProperties()
            {
                SemesterQuantityCreditUnit = 0;
                SemesterQuantityAcademicHour = 0;

                if (Elements.Count() > 0)
                {
                    Elements.ToList().ForEach(
                        x =>
                        {
                            if (x != null)
                            {
                                SemesterQuantityCreditUnit += x.QuantityCreditUnit;
                                SemesterQuantityAcademicHour += x.QuantityAcademicHour;
                            }                            
                        }
                        );
                }
                RaisePropertyChanged(nameof(SemesterQuantityCreditUnit));
                RaisePropertyChanged(nameof(SemesterQuantityAcademicHour));
            }            
        }
        public class Element
        {
            public Element()
            {

            }

            public Element(Discipline? item)
            {
                if (item != null)
                {
                    Id = item.Id;
                    Name = item.Name;
                    Type = "Дисциплина";
                    TypeID = 1;
                    FormIntermediateCertification = item.FormIntermediateCertification;
                    Place = item.Place;
                    IsCourseWork = item.IsHaveCourseWork;
                    QuantityCreditUnit = item.QuantityCreditUnit;
                    QuantityAcademicHour = item.QuantityAcademicHour;
                    SetColor(item.Id);
                    if (item.IsHaveCourseWork)
                    {
                        CourseWork = "Курсовая работа";
                        CourseWorkBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    }

                }
            }
            public Element(Practic? item)
            {
                if (item != null)
                {
                    Id = item.Id;
                    Name = item.MainType + "\n" + item.Type + "\n" + item.Name;
                    Type = "Практика";
                    TypeID = 2;
                    FormIntermediateCertification = "";
                    Place = item.Place;
                    IsCourseWork = false;
                    QuantityCreditUnit = item.QuantityCreditUnit;
                    QuantityAcademicHour = item.QuantityAcademicHour;
                    SetColor(item.Id);
                }
            }
            public Element(StateFinalCertification? item)
            {
                if (item != null)
                {
                    Id = item.Id;
                    Name = item.Name;
                    Type = "ГИА";
                    TypeID = 3;
                    FormIntermediateCertification = "";
                    Place = item.Place;
                    IsCourseWork = false;
                    QuantityCreditUnit = item.QuantityCreditUnit;
                    QuantityAcademicHour = item.QuantityAcademicHour;
                    SetColor(item.Id);
                }
            }
            
            private void SetColor(int ID)
            {
                switch (ID % 10)
                {
                    case 0:
                        ColorBrush = new SolidColorBrush(Color.FromRgb(0, 18, 25));
                        TextBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                        CourseWorkBrush = ColorBrush;
                        break;
                    case 1:
                        ColorBrush = new SolidColorBrush(Color.FromRgb(0, 95, 115));
                        TextBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                        CourseWorkBrush = ColorBrush;
                        break;
                    case 2:
                        ColorBrush = new SolidColorBrush(Color.FromRgb(10, 147, 150));
                        CourseWorkBrush = ColorBrush;
                        break;
                    case 3:
                        ColorBrush = new SolidColorBrush(Color.FromRgb(148, 210, 189));
                        CourseWorkBrush = ColorBrush;
                        break;
                    case 4:
                        ColorBrush = new SolidColorBrush(Color.FromRgb(233, 216, 166));
                        CourseWorkBrush = ColorBrush;
                        break;
                    case 5:
                        ColorBrush = new SolidColorBrush(Color.FromRgb(238, 155, 0));
                        CourseWorkBrush = ColorBrush;
                        break;
                    case 6:
                        ColorBrush = new SolidColorBrush(Color.FromRgb(202, 103, 2));
                        CourseWorkBrush = ColorBrush;
                        break;
                    case 7:
                        ColorBrush = new SolidColorBrush(Color.FromRgb(187, 62, 3));
                        CourseWorkBrush = ColorBrush;
                        break;
                    case 8:
                        ColorBrush = new SolidColorBrush(Color.FromRgb(174, 32, 18));
                        CourseWorkBrush = ColorBrush;
                        break;
                    case 9:
                        ColorBrush = new SolidColorBrush(Color.FromRgb(155, 34, 38));
                        TextBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                        CourseWorkBrush = ColorBrush;
                        break;
                    default:
                        ColorBrush = new SolidColorBrush(Color.FromRgb(245, 222, 179));
                        CourseWorkBrush = ColorBrush;
                        break;
                }
            }
            public int Id { get; set; } = 0;
            public string Name { get; set; } = "";
            public string Type { get; set; } = "Дисциплина";
            public int TypeID { get; set; } = 1;//1 - Дисциплина, 2 - Практика, 3 - ГИА
            public string FormIntermediateCertification { get; set; } = "";
            public string Place { get; set; } = "";
            public bool IsCourseWork { get; set; } = false;
            public string CourseWork { get; set; } = "";
            public float QuantityCreditUnit { get; set; } = 0;
            public float QuantityAcademicHour { get; set; } = 0;
            public Brush ColorBrush { get; set; } = Brushes.Wheat;
            public Brush TextBrush { get; set; } = Brushes.Black;
            public Brush CourseWorkBrush { get; set; } = Brushes.White;
            public bool IsNotMandatory { get; set; } = true;
            public Visibility Visibility { get; set; } = Visibility.Hidden;
        }
        public class DragAndDropElement
        {
            public Element MovementElement { get; set; }
            public ObservableCollection<Element> SourceCollection { get; set; }
        }
    }
}
