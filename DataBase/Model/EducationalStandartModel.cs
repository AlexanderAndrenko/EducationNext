using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace DataBase.Model
{
    internal class EducationalStandartModel
    {
        #region Constructor
        public EducationalStandartModel()
        {

        }
        #endregion //Constructor

        #region Properties
        #endregion //Properties

        #region Methods

        public List<EducationalStandart> GetEducationalStandarts()
        {
            List<EducationalStandart> educationalStandarts = new();

            try
            {
                using (ApplicationContext db = new())
                {
                    educationalStandarts = 
                        db.EducationalStandarts
                        .Include(x=>x.EducationalStandartPractices).ThenInclude(y=>y.Practic)
                        .Include(x=>x.EducationalStandartDisciplines).ThenInclude(y=>y.Discipline)
                        .Include(x => x.EducationalStandartStateFinalCertifications).ThenInclude(y=>y.StateFinalCertification)
                        .Include(x => x.EducationalStandartCompetences).ThenInclude(y => y.Competence)
                        .ToList();

                    return educationalStandarts;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Ошибка! " + ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
                return educationalStandarts;
            }
        }

        public void SetStandart(EducationalStandart standart)
        {
            try
            {
                using (ApplicationContext db = new())
                {                  
                    if (standart.Id != 0)
                    {
                        db.Entry(standart).State = EntityState.Modified;

                        var educationalStandartDiscipline = new List<EducationalStandartDiscipline>(standart.EducationalStandartDisciplines);
                        var educationalStandartPractice = new List<EducationalStandartPractice>(standart.EducationalStandartPractices);
                        var educationalStandartSFC = new List<EducationalStandartStateFinalCertification>(standart.EducationalStandartStateFinalCertifications);
                        var educationalStandartCompetence = new List<EducationalStandartCompetence>(standart.EducationalStandartCompetences);

                        db.EducationalStandartDisciplines.RemoveRange(
                            db.EducationalStandartDisciplines.Where(x => x.EducationalStandartID == standart.Id)
                            );
                        db.EducationalStandartPractices.RemoveRange(
                            db.EducationalStandartPractices.Where(x => x.EducationalStandartID == standart.Id)
                            );
                        db.EducationalStandartStateFinalCertifications.RemoveRange(
                            db.EducationalStandartStateFinalCertifications.Where(x => x.EducationalStandartID == standart.Id)
                            );
                        db.EducationalStandartCompetences.RemoveRange(
                            db.EducationalStandartCompetences.Where(x => x.EducationalStandartID == standart.Id)
                            );

                        db.EducationalStandartDisciplines.AddRange(educationalStandartDiscipline);
                        db.EducationalStandartPractices.AddRange(educationalStandartPractice);
                        db.EducationalStandartStateFinalCertifications.AddRange(educationalStandartSFC);
                        db.EducationalStandartCompetences.AddRange(educationalStandartCompetence);
                    }
                    else
                    {
                        db.EducationalStandarts.Add(standart);
                    }

                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }

        public void DeleteStandart(EducationalStandart standart)
        {
            try
            {
                using (ApplicationContext db = new())
                {
                    db.Remove(standart);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }

        #endregion //Methods
    }
}
