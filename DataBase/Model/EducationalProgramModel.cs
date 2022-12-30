using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Model
{
    internal class EducationalProgramModel
    {
        #region Constructor
        public EducationalProgramModel()
        {

        }
        #endregion //Constructor

        #region Properties
        #endregion //Properties

        #region Methods

        public List<EducationalProgram> GetEducationalPrograms()
        {
            List<EducationalProgram> educationalPrograms = new();

            try
            {
                using (ApplicationContext db = new())
                {
                    educationalPrograms =
                        db.EducationalPrograms
                        .Include(x=>x.EducationalStandart)
                        .ToList();
                    return educationalPrograms;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Ошибка! " + ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
                return educationalPrograms;
            }
        }

        public void SetEducationalProgram(EducationalProgram educationalProgram)
        {
            try
            {
                using (ApplicationContext db = new())
                {
                    db.EducationalPrograms.Add(educationalProgram);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }

        public void DeleteEducationalProgram(EducationalProgram educationalProgram)
        {
            try
            {
                using (ApplicationContext db = new())
                {
                    db.Remove(educationalProgram);
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
