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
                        .Include(x => x.EducationalStandartCompetences).ThenInclude(y=>y.Competence)
                        .Include(x => x.EducationalStandartStateFinalCertifications).ThenInclude(y=>y.StateFinalCertification)
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

        #endregion //Methods
    }
}
