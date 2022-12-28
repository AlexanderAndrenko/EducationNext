using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Model
{
    internal class CompetenceModel
    {
        #region Constructor
        public CompetenceModel()
        {

        }
        #endregion //Constructor

        #region Properties
        #endregion //Properties

        #region Methods

        public List<Competence> GetCompetences()
        {
            List<Competence> competences = new();

            try
            {
                using (ApplicationContext db = new())
                {
                    competences =
                        db.Competences.ToList();
                    return competences;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Ошибка! " + ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
                return competences;
            }
        }

        public void SetCompetence(Competence competence)
        {
            try
            {
                using (ApplicationContext db = new())
                {
                    db.Competences.Add(competence);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }

        public void DeleteCompetence(Competence competence)
        {
            try
            {
                using (ApplicationContext db = new())
                {
                    db.Remove(competence);
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
