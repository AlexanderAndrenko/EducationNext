using DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    internal class InitializeDatabaseEntities
    {
        public InitializeDatabaseEntities() { }

        public void InitializeEntities()
        {
            try
            {
                using (ApplicationContext db = new())
                {
                    //Инициализируем компетенции
                    List<Competence> competences =
                        new List<Competence>()
                        {
                            //1 УК-1
                            new Competence()
                            {
                                Name = "УК-1", 
                                ShortTypeCompetence = "УК", 
                                TypeCompetence = "Универсальная", 
                                Description = "Способен осуществлять критический анализ проблемных ситуаций на основе системного подхода, вырабатывать стратегию действий"
                            },
                            //2 УК-2
                            new Competence()
                            {
                                Name = "УК-2",
                                ShortTypeCompetence = "УК",
                                TypeCompetence = "Универсальная",
                                Description = "Способен управлять проектом на всех этапах его жизненного цикла"
                            },
                            //3 УК-3
                            new Competence()
                            {
                                Name = "УК-3",
                                ShortTypeCompetence = "УК",
                                TypeCompetence = "Универсальная",
                                Description = "Способен организовать и руководить работой команды, вырабатывая командную стратегию для достижения поставленной цели"
                            },
                            //4 УК-4
                            new Competence()
                            {
                                Name = "УК-4",
                                ShortTypeCompetence = "УК",
                                TypeCompetence = "Универсальная",
                                Description = "Способен применять современные коммуникативные технологии, в том числе на иностранном(ых) языке(ах), для академического и профессионального взаимодействия"
                            },
                            //5 УК-5
                            new Competence()
                            {
                                Name = "УК-5",
                                ShortTypeCompetence = "УК",
                                TypeCompetence = "Универсальная",
                                Description = "Способен анализировать и учитывать разнообразие культур в процессе межкультурного взаимодействия"
                            },
                            //6 УК-6
                            new Competence()
                            {
                                Name = "УК-6",
                                ShortTypeCompetence = "УК",
                                TypeCompetence = "Универсальная",
                                Description = "Способен определять и реализовывать приоритеты собственной деятельности и способы ее совершенствования на основе самооценки"
                            },
                            //7 ОПК-1
                            new Competence()
                            {
                                Name = "ОПК-1",
                                ShortTypeCompetence = "ОПК",
                                TypeCompetence = "Общепрофессиональная",
                                Description = "Способен самостоятельно приобретать, развивать и применять математические, естественнонаучные, социально-экономические и профессиональные знания для решения нестандартных задач, в том числе в новой или незнакомой среде и в междисциплинарном контексте"
                            },
                            //8 ОПК-2
                            new Competence()
                            {
                                Name = "ОПК-2",
                                ShortTypeCompetence = "ОПК",
                                TypeCompetence = "Общепрофессиональная",
                                Description = " Способен разрабатывать оригинальные алгоритмы и программные средства, в том числе с использованием современных интеллектуальных технологий, для решения профессиональных задач"
                            },
                            //9 ОПК-3
                            new Competence()
                            {
                                Name = "ОПК-3",
                                ShortTypeCompetence = "ОПК",
                                TypeCompetence = "Общепрофессиональная",
                                Description = "Способен анализировать профессиональную информацию, выделять в ней главное, структурировать, оформлять и представлять в виде аналитических обзоров с обоснованными выводами и рекомендациями"
                            },
                            //10 ОПК-4
                            new Competence()
                            {
                                Name = "ОПК-4",
                                ShortTypeCompetence = "ОПК",
                                TypeCompetence = "Общепрофессиональная",
                                Description = "Способен применять на практике новые научные принципы и методы исследований"
                            },
                            //11 ОПК-5
                            new Competence()
                            {
                                Name = "ОПК-5",
                                ShortTypeCompetence = "ОПК",
                                TypeCompetence = "Общепрофессиональная",
                                Description = "Способен разрабатывать и модернизировать программное и аппаратное обеспечение информационных и автоматизированных систем"
                            },
                            //12 ОПК-6
                            new Competence()
                            {
                                Name = "ОПК-6",
                                ShortTypeCompetence = "ОПК",
                                TypeCompetence = "Общепрофессиональная",
                                Description = "Способен самостоятельно приобретать с помощью информационных технологий и использовать в практической деятельности новые знания и умения, в том числе в новых областях знаний, непосредственно не связанных со сферой деятельности"
                            },
                            //13 ОПК-7
                            new Competence()
                            {
                                Name = "ОПК-7",
                                ShortTypeCompetence = "ОПК",
                                TypeCompetence = "Общепрофессиональная",
                                Description = "Способен применять при решении профессиональных задач методы и средства получения, хранения, переработки и трансляции информации посредством современных компьютерных технологий, в том числе в глобальных компьютерных сетях"
                            },
                            //14 ОПК-8
                            new Competence()
                            {
                                Name = "ОПК-8",
                                ShortTypeCompetence = "ОПК",
                                TypeCompetence = "Общепрофессиональная",
                                Description = "Способен осуществлять эффективное управление разработкой программных средств и проектов"
                            },
                            //15 ПК-1
                            new Competence()
                            {
                                Name = "ПК-1",
                                ShortTypeCompetence = "ПК",
                                TypeCompetence = "Профессиональная",
                                Description = "Способен разрабатывать и исследовать модели объектов профессиональной деятельности, предлагать и адаптировать методики, определять качество проводимых исследований, составлять отчеты о проделанной работе, обзоры, готовить публикации"
                            },
                            //16 ПК-5
                            new Competence()
                            {
                                Name = "ПК-5",
                                ShortTypeCompetence = "ПК",
                                TypeCompetence = "Профессиональная",
                                Description = "Способен применять современные технологии разработки программных комплексов с использованием автоматизированных систем планирования и управления, осуществлять контроль качества разрабатываемых программных продуктов"
                            },
                            //17 ПК-8
                            new Competence()
                            {
                                Name = "ПК-8",
                                ShortTypeCompetence = "ПК",
                                TypeCompetence = "Профессиональная",
                                Description = "Способен выполнять техническое исследованиевозможных вариантов архитектуры компонентов, включающее описание вариантов и технико-экономическое обоснование выбранного варианта"
                            },
                            //18 ПК-7
                            new Competence() 
                            {
                                Name = "ПК-7",
                                ShortTypeCompetence = "ПК",
                                TypeCompetence = "Профессиональная",
                                Description = "Способен выполнять проекты в области программной инженерии на основе системного подхода, строить и использовать модели для описания и прогнозирования различных явлений, осуществлять их качественный и количественный анализ"
                            },
                            //19 ПК-6
                            new Competence()
                            {
                                Name = "ПК-6",
                                ShortTypeCompetence = "ПК",
                                TypeCompetence = "Профессиональная",
                                Description = "Способен отбирать и разрабатывать методы анализа объектов профессиональной деятельности на основе общих тенденций развития программной инженерии"
                            },
                            //20 ПК-2
                            new Competence()
                            {
                                Name = "ПК-2",
                                ShortTypeCompetence = "ПК",
                                TypeCompetence = "Профессиональная",
                                Description = "Способен применять современные технологии разработки программных комплексов с использованием автоматизированных систем планирования и управления, осуществлять контроль качества разрабатываемых программных продуктов"
                            }
                        };

                    //Инициализируем дисциплины
                    List<Discipline> disciplines = new List<Discipline>()
                    {
                        //1 Методология программной инженерии
                        new Discipline()
                        {
                            Name = "Методология программной инженерии",
                            QuantityCreditUnit = 6,
                            QuantityAcademicHour = 216,
                            FormIntermediateCertification = "Экзамен",
                            Place = "Б1",
                            IsHaveCourseWork = true,
                            DisciplineCompetences =
                            new List<DisciplineCompetence>()
                            {
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 1
                                },
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 11
                                },
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 12
                                }
                            }
                        },
                        //2 Методы исследования интеллектуального анализа в программной инженерии (семестр 1)
                        new Discipline()
                        {
                            Name = "Методы исследования интеллектуального анализа в программной инженерии (семестр 1)",
                            QuantityCreditUnit = 3,
                            QuantityAcademicHour = 108,
                            FormIntermediateCertification = "Зачет",
                            Place = "Б1.Б2",
                            DisciplineCompetences =
                            new List<DisciplineCompetence>()
                            {
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 8
                                },
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 9
                                },
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 10
                                }
                            }
                        },
                        //3 Методы исследования интеллектуального анализа в программной инженерии (семестр 2)
                        new Discipline()
                        {
                            Name = "Методы исследования интеллектуального анализа в программной инженерии (семестр 2)",
                            QuantityCreditUnit = 5,
                            QuantityAcademicHour = 180,
                            FormIntermediateCertification = "Экзамен",
                            Place = "Б1.Б2",
                            DisciplineCompetences =
                            new List<DisciplineCompetence>()
                            {
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 8
                                },
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 9
                                },
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 10
                                }
                            }
                        },
                        //4 Управление разработкой программных проектов
                        new Discipline()
                        {
                            Name = "Управление разработкой программных проектов",
                            QuantityCreditUnit = 6,
                            QuantityAcademicHour = 216,
                            FormIntermediateCertification = "Экзамен",
                            Place = "Б1.Б3",
                            DisciplineCompetences =
                            new List<DisciplineCompetence>()
                            {
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 2
                                },
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 3
                                },
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 14
                                }
                            }
                        },
                        //5 Методы передачи мультемедийных данных
                        new Discipline()
                        {
                            Name = "Методы передачи мультемедийных данных",
                            QuantityCreditUnit = 3,
                            QuantityAcademicHour = 108,
                            FormIntermediateCertification = "Зачет",
                            Place = "Б1.Б3",
                            DisciplineCompetences =
                            new List<DisciplineCompetence>()
                            {
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 13
                                }
                            }
                        },
                        //6 Иностранный язык в профессиональной сфере
                        new Discipline()
                        {
                            Name = "Иностранный язык в профессиональной сфере",
                            QuantityCreditUnit = 3,
                            QuantityAcademicHour = 108,
                            FormIntermediateCertification = "Зачет",
                            Place = "Б1.Б5",
                            DisciplineCompetences =
                            new List<DisciplineCompetence>()
                            {
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 4
                                },
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 5
                                },
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 7
                                }
                            }
                        },
                        //7 Теория аргументации
                        new Discipline()
                        {
                            Name = "Теория аргументации",
                            QuantityCreditUnit = 3,
                            QuantityAcademicHour = 108,
                            FormIntermediateCertification = "Зачет",
                            Place = "Б1.Б6",
                            DisciplineCompetences =
                            new List<DisciplineCompetence>()
                            {
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 4
                                },
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 5
                                },
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 7
                                }
                            }
                        },
                        //8 Технологическое предпринимательство
                        new Discipline()
                        {
                            Name = "Технологическое предпринимательство",
                            QuantityCreditUnit = 3,
                            QuantityAcademicHour = 108,
                            FormIntermediateCertification = "Зачет",
                            Place = "Б1.Б7",
                            DisciplineCompetences =
                            new List<DisciplineCompetence>()
                            {
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 3
                                },
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 6
                                },
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 7
                                },
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 14
                                }
                            }
                        },
                        //9 Методы самооргназации специалистов в программной инженерии
                        new Discipline()
                        {
                            Name = "Методы самооргназации специалистов в программной инженерии",
                            QuantityCreditUnit = 4,
                            QuantityAcademicHour = 144,
                            FormIntermediateCertification = "Экзамен",
                            Place = "Б1.В.ДВ1.1",
                            DisciplineCompetences =
                            new List<DisciplineCompetence>()
                            {
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 18
                                }
                            }
                        },
                        //10 Командообразование и методы групповой работы в ИТ отрасли
                        new Discipline()
                        {
                            Name = "Командообразование и методы групповой работы в ИТ отрасли",
                            QuantityCreditUnit = 4,
                            QuantityAcademicHour = 144,
                            FormIntermediateCertification = "Экзамен",
                            Place = "Б1.В.ДВ1.2",
                            DisciplineCompetences =
                            new List<DisciplineCompetence>()
                            {
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 18
                                }
                            }
                        },
                        //11 Управление данными об изделиях
                        new Discipline()
                        {
                            Name = "Управление данными об изделиях",
                            QuantityCreditUnit = 3,
                            QuantityAcademicHour = 108,
                            FormIntermediateCertification = "Зачет",
                            Place = "Б1.В.ДВ2.1",
                            DisciplineCompetences =
                            new List<DisciplineCompetence>()
                            {
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 15
                                },
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 17
                                }
                            }
                        },
                        //12 Аналитическая обработка данных
                        new Discipline()
                        {
                            Name = "Аналитическая обработка данных",
                            QuantityCreditUnit = 3,
                            QuantityAcademicHour = 108,
                            FormIntermediateCertification = "Зачет",
                            Place = "Б1.В.ДВ2.2",
                            DisciplineCompetences =
                            new List<DisciplineCompetence>()
                            {
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 15
                                },
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 17
                                }
                            }
                        },
                        //13 Корпоративные информационные системы
                        new Discipline()
                        {
                            Name = "Корпоративные информационные системы",
                            QuantityCreditUnit = 4,
                            QuantityAcademicHour = 144,
                            FormIntermediateCertification = "Зачет с оценкой",
                            Place = "Б1.В.ДВ3.1",
                            DisciplineCompetences =
                            new List<DisciplineCompetence>()
                            {
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 16
                                }
                            }
                        },
                        //14 Автоматизация управления предприятием
                        new Discipline()
                        {
                            Name = "Автоматизация управления предприятием",
                            QuantityCreditUnit = 4,
                            QuantityAcademicHour = 144,
                            FormIntermediateCertification = "Зачет с оценкой",
                            Place = "Б1.В.ДВ3.2",
                            DisciplineCompetences =
                            new List<DisciplineCompetence>()
                            {
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 16
                                }
                            }
                        },
                        //15 Сверточные сети и глубокое обучение
                        new Discipline()
                        {
                            Name = "Сверточные сети и глубокое обучение",
                            QuantityCreditUnit = 4,
                            QuantityAcademicHour = 144,
                            FormIntermediateCertification = "Зачет с оценкой",
                            Place = "Б1.В.ДВ4.1",
                            DisciplineCompetences =
                            new List<DisciplineCompetence>()
                            {
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 17
                                }
                            }
                        },
                        //16 Системно-онтологический анализ предметной области
                        new Discipline()
                        {
                            Name = "Системно-онтологический анализ предметной области",
                            QuantityCreditUnit = 4,
                            QuantityAcademicHour = 144,
                            FormIntermediateCertification = "Зачет с оценкой",
                            Place = "Б1.В.ДВ4.2",
                            DisciplineCompetences =
                            new List<DisciplineCompetence>()
                            {
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 17
                                }
                            }
                        },
                        //17 UX-Дизайн
                        new Discipline()
                        {
                            Name = "UX-Дизайн",
                            QuantityCreditUnit = 4,
                            QuantityAcademicHour = 144,
                            FormIntermediateCertification = "Зачет с оценкой",
                            Place = "Б1.В.ДВ5.1",
                            IsHaveCourseWork = true,
                            DisciplineCompetences =
                            new List<DisciplineCompetence>()
                            {
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 18
                                }
                            }
                        },
                        //18 Проектирование пользовательского интерфейса программных систем
                        new Discipline()
                        {
                            Name = "Проектирование пользовательского интерфейса программных систем",
                            QuantityCreditUnit = 4,
                            QuantityAcademicHour = 144,
                            FormIntermediateCertification = "Зачет с оценкой",
                            Place = "Б1.В.ДВ5.2",
                            IsHaveCourseWork = true,
                            DisciplineCompetences =
                            new List<DisciplineCompetence>()
                            {
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 18
                                }
                            }
                        },
                        //19 Управление информационными рисками
                        new Discipline()
                        {
                            Name = "Управление информационными рисками",
                            QuantityCreditUnit = 5,
                            QuantityAcademicHour = 180,
                            FormIntermediateCertification = "Экзамен",
                            Place = "Б1.В.ДВ6.1",
                            DisciplineCompetences =
                            new List<DisciplineCompetence>()
                            {
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 18
                                }
                            }
                        },
                        //20 Управление ИТ инфраструктурой
                        new Discipline()
                        {
                            Name = "Управление ИТ инфраструктурой",
                            QuantityCreditUnit = 5,
                            QuantityAcademicHour = 180,
                            FormIntermediateCertification = "Экзамен",
                            Place = "Б1.В.ДВ6.2",
                            DisciplineCompetences =
                            new List<DisciplineCompetence>()
                            {
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 18
                                }
                            }
                        },
                        //21 Управление жизненным циклом программных систем (семестр 1)
                        new Discipline()
                        {
                            Name = "Управление жизненным циклом программных систем (семестр 1)",
                            QuantityCreditUnit = 5,
                            QuantityAcademicHour = 180,
                            FormIntermediateCertification = "Зачет с оценкой",
                            Place = "Б1.В1",
                            DisciplineCompetences =
                            new List<DisciplineCompetence>()
                            {
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 2
                                },
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 19
                                }
                            }
                        },
                        //22 Управление жизненным циклом программных систем (семестр 2)
                        new Discipline()
                        {
                            Name = "Управление жизненным циклом программных систем (семестр 2)",
                            QuantityCreditUnit = 4,
                            QuantityAcademicHour = 144,
                            FormIntermediateCertification = "Экзамен",
                            Place = "Б1.В1",
                            DisciplineCompetences =
                            new List<DisciplineCompetence>()
                            {
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 2
                                },
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 19
                                }
                            }
                        },
                        //23 Прикладные задачи мобильных технологий
                        new Discipline()
                        {
                            Name = "Прикладные задачи мобильных технологий",
                            QuantityCreditUnit = 3,
                            QuantityAcademicHour = 108,
                            FormIntermediateCertification = "Зачет",
                            Place = "Б1.В2",
                            DisciplineCompetences =
                            new List<DisciplineCompetence>()
                            {
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 20
                                }
                            }
                        },
                        //24 Имитационное моделирование физических систем (семестр 1)
                        new Discipline()
                        {
                            Name = "Имитационное моделирование физических систем (семестр 1)",
                            QuantityCreditUnit = 3,
                            QuantityAcademicHour = 108,
                            FormIntermediateCertification = "Зачет с оценкой",
                            Place = "Б1.В3",
                            DisciplineCompetences =
                            new List<DisciplineCompetence>()
                            {
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 15
                                }
                            }
                        },
                        //25 Имитационное моделирование физических систем (семестр 2)
                        new Discipline()
                        {
                            Name = "Имитационное моделирование физических систем (семестр 2)",
                            QuantityCreditUnit = 5,
                            QuantityAcademicHour = 180,
                            FormIntermediateCertification = "Экзамен",
                            IsHaveCourseWork = true,
                            Place = "Б1.В3",
                            DisciplineCompetences =
                            new List<DisciplineCompetence>()
                            {
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 15
                                }
                            }
                        },
                        //26 Системная инженерия
                        new Discipline()
                        {
                            Name = "Системная инженерия",
                            QuantityCreditUnit = 5,
                            QuantityAcademicHour = 180,
                            FormIntermediateCertification = "Экзамен",
                            Place = "Б1.В4",
                            DisciplineCompetences =
                            new List<DisciplineCompetence>()
                            {
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 1
                                },
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 18
                                }
                            }
                        },
                        //27 Современные информационные системы управления предприятиями ракетно-космической отрасли
                        new Discipline()
                        {
                            Name = "Современные информационные системы управления предприятиями ракетно-космической отрасли",
                            QuantityCreditUnit = 1,
                            QuantityAcademicHour = 36,
                            FormIntermediateCertification = "Зачет",
                            Place = "Ф1",
                            DisciplineCompetences =
                            new List<DisciplineCompetence>()
                            {
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 16
                                }
                            }
                        },
                        //28 Промышленные SCADA-системы
                        new Discipline()
                        {
                            Name = "Промышленные SCADA-системы",
                            QuantityCreditUnit = 2,
                            QuantityAcademicHour = 72,
                            FormIntermediateCertification = "Зачет",
                            Place = "Ф2",
                            DisciplineCompetences =
                            new List<DisciplineCompetence>()
                            {
                                new DisciplineCompetence()
                                {
                                    CompetenceID = 2
                                }
                            }
                        }
                    };

                    //Инициализируем практики
                    List<Practic> practics = new List<Practic>()
                    {
                        new Practic()
                        {
                            Name = "09.04.04 Учебная №1",
                            MainType = "Учебная",
                            Type = "Ознакомительная практика",
                            Place = "Б2.Б.У1",
                            QuantityCreditUnit = 3,
                            QuantityAcademicHour = 108
                        },
                        new Practic()
                        {
                            Name = "09.04.04 Производственная №1",
                            MainType = "Производственная",
                            Type = "Научно-исследовательская работа",
                            Place = "Б2.Б.П1",
                            QuantityCreditUnit = 6,
                            QuantityAcademicHour = 216
                        },
                        new Practic()
                        {
                            Name = "09.04.04 Производственная №2",
                            MainType = "Производственная",
                            Type = "Педагогическая",
                            Place = "Б2.Б.П2",
                            QuantityCreditUnit = 6,
                            QuantityAcademicHour = 216
                        },
                        new Practic()
                        {
                            Name = "09.04.04 Производственная №3",
                            MainType = "Производственная",
                            Type = "Научно-исследовательская",
                            Place = "Б2.Б.П3",
                            QuantityCreditUnit = 9,
                            QuantityAcademicHour = 324
                        },
                        new Practic()
                        {
                            Name = "09.04.04 Производственная №4",
                            MainType = "Производственная",
                            Type = "Преддипломная",
                            Place = "Б2.Б.П4",
                            QuantityCreditUnit = 6,
                            QuantityAcademicHour = 216
                        }
                    };

                    //Инициализируем ГИА
                    List<StateFinalCertification> stateFinalCertifications = new List<StateFinalCertification>()
                    {
                        new StateFinalCertification()
                        {
                            Name = "Подготовка к сдаче и сдача государственного экзамена",
                            Place = "Б3.ГИА1",
                            QuantityCreditUnit = 1,
                            QuantityAcademicHour = 36
                        },
                        new StateFinalCertification()
                        {
                            Name = "Выполнение и защита выпускной квалификационной работы",
                            Place = "Б3.ГИА2",
                            QuantityCreditUnit = 8,
                            QuantityAcademicHour = 288
                        }
                    };

                    //Инициализируем списки дисциплин для стандарта и для учебного плана
                    List<EducationalStandartDiscipline> educationalStandartDisciplines = new List<EducationalStandartDiscipline>();
                    List<SyllabusDiscipline> syllabusDisciplines = new List<SyllabusDiscipline>();

                    for(int i = 1; i <= disciplines.Count(); i++)
                    {
                        educationalStandartDisciplines.Add(new EducationalStandartDiscipline() { DisciplineID = i });
                        syllabusDisciplines.Add(new SyllabusDiscipline() { DisciplineID = i });

                    }

                    //Инициализируем списки практик для стандарта и для учебного плана
                    List<EducationalStandartPractice> educationalStandartPractices = new List<EducationalStandartPractice>();
                    List<SyllabusPractic> syllabusPractics = new List<SyllabusPractic>();

                    for (int i = 1; i <= practics.Count(); i++)
                    {
                        educationalStandartPractices.Add(new EducationalStandartPractice() { PracticeID = i });
                        syllabusPractics.Add(new SyllabusPractic() { PracticID = i });

                    }

                    //Инициализируем списки ГИА для стандарта и для учебного плана
                    List<EducationalStandartStateFinalCertification> educationalStandartStateFinalCertifications = new List<EducationalStandartStateFinalCertification>();
                    List<SyllabusStateFinalCertification> syllabusStateFinalCertifications = new List<SyllabusStateFinalCertification>();

                    for (int i = 1; i <= stateFinalCertifications.Count(); i++)
                    {
                        educationalStandartStateFinalCertifications.Add(new EducationalStandartStateFinalCertification() { StateFinalCertificationID = i });
                        syllabusStateFinalCertifications.Add(new SyllabusStateFinalCertification() { StateFinalCertificationID = i });

                    }

                    //Инициализируем список компетенций для стандарта
                    List<EducationalStandartCompetence> educationalStandartCompetences = new List<EducationalStandartCompetence>();

                    for (int i = 1; i <= 18; i++)
                    {
                        educationalStandartCompetences.Add(new EducationalStandartCompetence() { CompetenceID = i });
                    }

                    //Инициализируем стандарт
                    EducationalStandart educationalStandart =
                        new EducationalStandart()
                        {
                            SpecializationCode = "09.04.04",
                            Name = "Программная инженерия",
                            QuantityCreditUnit = 120,
                            MaxQuantityCreditUnitPerYear = 70,
                            EducationalStandartDisciplines = educationalStandartDisciplines,
                            EducationalStandartPractices = educationalStandartPractices,
                            EducationalStandartStateFinalCertifications = educationalStandartStateFinalCertifications,
                            EducationalStandartCompetences = educationalStandartCompetences
                        };

                    //Инициализируем программу
                    EducationalProgram educationalProgram =
                        new EducationalProgram()
                        {
                            Name = "Программная инженерия",
                            Profile = "Системы программной поддержки жизненного цикла изделий",
                            QuantityTerm = 4,
                            EducationalStandartID = 1
                        };

                    //Инициализируем учебный план
                    Syllabus syllabus =
                        new Syllabus()
                        {
                            Name = "Учебный план №1 09.04.04",
                            EducationalProgramID = 1,
                            SyllabusDisciplines = syllabusDisciplines,
                            SyllabusPractics = syllabusPractics,
                            SyllabusStateFinalCertifications = syllabusStateFinalCertifications
                        };

                    db.Competences.AddRange(competences);
                    db.SaveChanges();
                    db.Disciplines.AddRange(disciplines);
                    db.SaveChanges();
                    db.Practics.AddRange(practics);
                    db.SaveChanges();
                    db.StateFinalCertifications.AddRange(stateFinalCertifications);
                    db.SaveChanges();
                    db.EducationalStandarts.Add(educationalStandart);
                    db.SaveChanges();
                    db.EducationalPrograms.Add(educationalProgram);
                    db.SaveChanges();
                    db.Syllabuses.Add(syllabus);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR " + ex.Message);
            }
        }
    }
}
