using DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Model
{
    internal class PracticeModel
    {
        #region Constructor
        public PracticeModel()
        {

        }
        #endregion //Constructor

        #region Properties
        #endregion //Properties

        #region Methods

        public List<Practic> GetPractices()
        {
            List<Practic> practices = new();

            try
            {
                using (ApplicationContext db = new())
                {
                    practices =
                        db.Practics.ToList();
                    return practices;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Ошибка! " + ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
                return practices;
            }
        }

        public void SetPractice(Practic practice)
        {
            try
            {
                using (ApplicationContext db = new())
                {
                    db.Practics.Add(practice);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }

        public void DeletePractice(Practic practice)
        {
            try
            {
                using (ApplicationContext db = new())
                {
                    db.Remove(practice);
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
