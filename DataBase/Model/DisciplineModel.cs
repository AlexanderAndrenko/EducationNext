using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
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

        public List<Discipline> GetDisciplines()
        {
            List<Discipline> disciplines = new();

            try
            {
                using (ApplicationContext db = new())
                {
                    disciplines =
                        db.Disciplines
                        .Include(x=>x.DisciplineCompetences).ThenInclude(y=>y.Competence)
                        .ToList();
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
                    if (discipline.Id != 0)
                    {
                        db.Entry(discipline).State = EntityState.Modified;

                        var disciplineCompetence = new List<DisciplineCompetence>(discipline.DisciplineCompetences);

                        db.DisciplinesCompetences.RemoveRange(
                            db.DisciplinesCompetences.Where(x => x.DisciplineID == discipline.Id)
                            );

                        db.DisciplinesCompetences.AddRange(disciplineCompetence);
                    }
                    else
                    {
                        db.Disciplines.Add(discipline);
                    }
                    
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
