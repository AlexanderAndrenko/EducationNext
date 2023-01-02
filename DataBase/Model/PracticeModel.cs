using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
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
                        db.Practics
                        .AsNoTracking()
                        .Include(x=>x.PracticCompetences).ThenInclude(y=>y.Competence)
                        .ToList();

                    db.ChangeTracker.Clear();
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
                    if (practice.Id != 0)
                    {
                        db.Entry(practice).State = EntityState.Modified;

                        var practiceCompetence = new List<PracticCompetence>(practice.PracticCompetences);

                        db.PracticsCompetences.RemoveRange(
                            db.PracticsCompetences.Where(x=>x.PracticID == practice.Id)
                            );

                        db.PracticsCompetences.AddRange(practiceCompetence);       
                    }
                    else
                    {
                        db.Practics.Add(practice);
                    }

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
