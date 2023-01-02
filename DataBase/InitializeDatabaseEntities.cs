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

        public void InitializeEnitites()
        {

        }

        public void InitializeCompetences()
        {
            try
            {
                using (ApplicationContext db = new())
                {
                    List<Competence> competences =
                        new List<Competence>()
                        {
                            new Competence() 
                            {
                                Name = "ОК-1", 
                                ShortTypeCompetence = "ОК", 
                                TypeCompetence = "Общекультурные компетенции", 
                                Description = "Способностью использовать основы философских знаний для формирования мировоззренческой позиции"
                            },
                            new Competence()
                            {
                                Name = "ОК-2",
                                ShortTypeCompetence = "ОК",
                                TypeCompetence = "Общекультурные компетенции",
                                Description = "Способностью анализировать основные этапы и закономерности исторического развития общества для формирования гражданской позиции"
                            },
                            new Competence()
                            {
                                Name = "ОК-3",
                                ShortTypeCompetence = "ОК",
                                TypeCompetence = "Общекультурные компетенции",
                                Description = "Способностью использовать основы экономических знаний в различных сферах жизнедеятельности"
                            },
                            new Competence()
                            {
                                Name = "ОК-4",
                                ShortTypeCompetence = "ОК",
                                TypeCompetence = "Общекультурные компетенции",
                                Description = "Способностью использовать основы правовых знаний в различных сферах жизнедеятельности"
                            },
                            new Competence()
                            {
                                Name = "ОК-5",
                                ShortTypeCompetence = "ОК",
                                TypeCompetence = "Общекультурные компетенции",
                                Description = "Способностью к коммуникации в устной и письменной формах на русском и иностранном языках длярешения задач межличностного и межкультурного взаимодействия"
                            },
                            new Competence()
                            {
                                Name = "ОК-6",
                                ShortTypeCompetence = "ОК",
                                TypeCompetence = "Общекультурные компетенции",
                                Description = "Способностью работать в коллективе, толерантно воспринимать социальные, этнические, конфессиональные и культурные различия"
                            },
                            new Competence()
                            {
                                Name = "ОК-7",
                                ShortTypeCompetence = "ОК",
                                TypeCompetence = "Общекультурные компетенции",
                                Description = "Способностью к самоорганизации и самообразованию"
                            },
                            new Competence()
                            {
                                Name = "ОК-8",
                                ShortTypeCompetence = "ОК",
                                TypeCompetence = "Общекультурные компетенции",
                                Description = "Способностью использовать методы и средства физической культуры для обеспечения полноценной социальной и профессиональной деятельности"
                            },
                            new Competence()
                            {
                                Name = "ОК-9",
                                ShortTypeCompetence = "ОК",
                                TypeCompetence = "Общекультурные компетенции",
                                Description = "Способностью использовать приемы первой помощи, методы защиты в условиях чрезвычайныхситуаций"
                            },
                            new Competence()
                            {
                                Name = "ОК-10",
                                ShortTypeCompetence = "ОК",
                                TypeCompetence = "Общекультурные компетенции",
                                Description = "Готовностью к достижению должного уровня физической подготовленности, необходимого для обеспечения полноценной социальной и профессиональной деятельности"
                            },
                            new Competence()
                            {
                                Name = "ОК-11",
                                ShortTypeCompetence = "ОК",
                                TypeCompetence = "Общекультурные компетенции",
                                Description = "Способностью к обобщению, анализу, восприятию информации, постановке цели и выбору путей ее достижения"
                            },
                            new Competence()
                            {
                                Name = "ОК-12",
                                ShortTypeCompetence = "ОК",
                                TypeCompetence = "Общекультурные компетенции",
                                Description = "Готовностью критически оценить свои достоинства и недостатки, наметить пути и выбрать средства развития достоинств и устранения недостатков"
                            },
                            new Competence()
                            {
                                Name = "ОК-13",
                                ShortTypeCompetence = "ОК",
                                TypeCompetence = "Общекультурные компетенции",
                                Description = "Осознанием социальной значимости своей профессии, обладанием высокой мотивацией к выполнению профессиональной деятельности"
                            },
                            new Competence()
                            {
                                Name = "ОК-14",
                                ShortTypeCompetence = "ОК",
                                TypeCompetence = "Общекультурные компетенции",
                                Description = "Способностью анализировать социально-значимые проблемы и процессы"
                            },
                            new Competence()
                            {
                                Name = "ОК-15",
                                ShortTypeCompetence = "ОК",
                                TypeCompetence = "Общекультурные компетенции",
                                Description = "Использованием основных законов естественнонаучных дисциплин в профессиональной деятельности, применением методов математического анализа и моделирования, теоретического и\r\n\r\nэкспериментального исследования"
                            },
                            new Competence()
                            {
                                Name = "ОК-16",
                                ShortTypeCompetence = "ОК",
                                TypeCompetence = "Общекультурные компетенции",
                                Description = "Способностью понимать сущность и значение информации в развитии современного информационного общества, соблюдать основные требования информационной безопасности, в том числе защиты государственной тайны; владением основными методами, способами и средствами получения, хранения, переработки информации"
                            },
                            new Competence()
                            {
                                Name = "ОК-17",
                                ShortTypeCompetence = "ОК",
                                TypeCompetence = "Общекультурные компетенции",
                                Description = "Владением навыками работы с компьютером как средством управления информацией"
                            }
                        };

                    List<EducationalStandart> educationalStandart = new List<EducationalStandart>()
                    {
                        new EducationalStandart()
                        {
                            SpecializationCode = "09.04.04",
                            Name = "Программная инженерия",
                            QuantityCreditUnit = 120,
                            QuantityTerm = 4,
                            MaxQuantityCreditUnitPerYear = 70
                        }
                    };

                    List<EducationalProgram> educationalPrograms = new List<EducationalProgram>()
                    {
                        new EducationalProgram()
                        {

                        }
                    };


                }
            }
            catch (Exception)
            {

            }
        }
    }
}
