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

            try
            {
                using (ApplicationContext db = new())
                {
                    Syllabuss =
                        db.Syllabuses
                        .Include(x=>x.SyllabusDisciplines).ThenInclude(y=>y.Discipline)
                        .Include(x=>x.SyllabusPractics).ThenInclude(y=>y.Practic)
                        .Include(x=>x.SyllabusStateFinalCertifications).ThenInclude(y=>y.StateFinalCertification)
                        .Include(x=>x.EducationalProgram).ThenInclude(y=>y.EducationalStandart)
                        .ToList();
                    return Syllabuss;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Ошибка! " + ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
                return Syllabuss;
            }
        }

        public void SetSyllabus(Syllabus Syllabus)
        {
            try
            {
                using (ApplicationContext db = new())
                {
                    db.Syllabuses.Add(Syllabus);
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
