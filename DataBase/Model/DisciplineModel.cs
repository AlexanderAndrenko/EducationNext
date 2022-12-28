using DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Model
{
    internal class DisciplineModel
    {
        #region Constructor
        public DisciplineModel()
        {

        }
        #endregion //Constructor

        #region Properties
        #endregion //Properties

        #region Methods

        public List<Discipline> GetDiscipline()
        {
            List<Discipline> disciplines = new();

            try
            {
                using (ApplicationContext db = new())
                {
                    disciplines =
                        db.Disciplines.ToList();
                    return disciplines;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Ошибка! " + ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
                return disciplines;
            }
        }

        public void SetDiscipline(Discipline discipline)
        {
            try
            {
                using (ApplicationContext db = new())
                {
                    db.Disciplines.Add(discipline);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }

        public void DeleteDiscipline(Discipline discipline)
        {
            try
            {
                using (ApplicationContext db = new())
                {
                    db.Remove(discipline);
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
