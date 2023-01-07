using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Model
{
    internal class SyllabusModel
    {
        #region Constructor
        public SyllabusModel()
        {

        }
        #endregion //Constructor

        #region Properties
        #endregion //Properties

        #region Method

        public List<Syllabus> GetSyllabuses()
        {
            List<Syllabus> Syllabuss = new();
            List<EducationalStandart> EducationalStandarts = new();
            List<EducationalProgram> EducationalPrograms = new();

            try
            {
                using (ApplicationContext db = new())
                {
                    Syllabuss =
                        db.Syllabuses
                        .Include(x=>x.SyllabusDisciplines).ThenInclude(y=>y.Discipline)
                        .Include(x=>x.SyllabusPractics).ThenInclude(y=>y.Practic)
                        .Include(x=>x.SyllabusStateFinalCertifications).ThenInclude(y=>y.StateFinalCertification)
                        /*
                        .Include(x => x.EducationalProgram)                        
                            .ThenInclude(y=>y.EducationalStandart)
                            .ThenInclude(z => z.EducationalStandartDisciplines)
                        .Include(x=>x.EducationalProgram)
                            .ThenInclude(y => y.EducationalStandart)
                            .ThenInclude(z => z.EducationalStandartPractices)
                        .Include(x => x.EducationalProgram)
                            .ThenInclude(y => y.EducationalStandart)
                            .ThenInclude(z => z.EducationalStandartStateFinalCertifications)
                        .Include(x => x.EducationalProgram)
                            .ThenInclude(y => y.EducationalStandart)
                            .ThenInclude(z => z.EducationalStandartCompetences)                        
                        */
                        .ToList();

                    EducationalPrograms =
                        db.EducationalPrograms.ToList();

                    EducationalStandarts =
                        db.EducationalStandarts
                        .Include(x => x.EducationalStandartDisciplines)
                        .Include(x => x.EducationalStandartPractices)
                        .Include(x => x.EducationalStandartStateFinalCertifications)
                        .Include(x => x.EducationalStandartCompetences)
                        .ToList();

                    EducationalPrograms.ForEach(
                        x =>
                        {
                            x.EducationalStandart = EducationalStandarts.Where(y => y.Id == x.EducationalStandartID).First();
                        }
                        );

                    Syllabuss.ForEach(
                        x =>
                        {
                            x.EducationalProgram = EducationalPrograms.Where(y => y.Id == x.EducationalProgramID).First();
                        });

                    return Syllabuss;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Ошибка! " + ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
                return Syllabuss;
            }
        }

        public void SetSyllabus(Syllabus syllabus)
        {
            try
            {
                using (ApplicationContext db = new())
                {
                    if (syllabus.Id != 0)
                    {
                        db.Entry(syllabus).State = EntityState.Modified;

                        var syllabusDiscipline = new List<SyllabusDiscipline>(syllabus.SyllabusDisciplines);
                        var syllabusPractice = new List<SyllabusPractic>(syllabus.SyllabusPractics);
                        var syllabusSFC = new List<SyllabusStateFinalCertification>(syllabus.SyllabusStateFinalCertifications);

                        db.SyllabusDisciplines.RemoveRange(
                            db.SyllabusDisciplines.Where(x => x.SyllabusID == syllabus.Id)
                            );
                        db.SyllabusPractics.RemoveRange(
                            db.SyllabusPractics.Where(x => x.SyllabusID == syllabus.Id)
                            );
                        db.SyllabusStateFinalCertifications.RemoveRange(
                            db.SyllabusStateFinalCertifications.Where(x => x.SyllabusID == syllabus.Id)
                            );

                        db.SyllabusDisciplines.AddRange(syllabusDiscipline);
                        db.SyllabusPractics.AddRange(syllabusPractice);
                        db.SyllabusStateFinalCertifications.AddRange(syllabusSFC);
                    }
                    else
                    {
                        db.Syllabuses.Add(syllabus);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }

        public void DeleteSyllabus(Syllabus Syllabus)
        {
            try
            {
                using (ApplicationContext db = new())
                {
                    db.Remove(Syllabus);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }

        #endregion //Method
    }
}
