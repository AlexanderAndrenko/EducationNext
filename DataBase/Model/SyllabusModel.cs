using DataBase.Entities;
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
                        db.Syllabuses.ToList();
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
