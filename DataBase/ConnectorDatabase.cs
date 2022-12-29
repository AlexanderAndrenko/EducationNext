using DataBase.Entities;
using DataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class ConnectorDatabase
    {
        #region Constructor
        public ConnectorDatabase()
        {

        }
        #endregion //Constructor

        #region Properties


        #endregion //Properties

        #region Methods

        #region EducationalStandart
        public List<EducationalStandart> GetEducationalStandarts()
        {
            EducationalStandartModel m = new();
            return m.GetEducationalStandarts();
        }
        #endregion //EducationalStandart

        #region Competence
        public List<Competence> GetCompetences()
        {
            CompetenceModel m = new();
            return m.GetCompetences();
        }
        public void SetCompetence(Competence competence)
        {
            CompetenceModel m = new();
            m.SetCompetence(competence);
        }
        public void DeleteCompetence(Competence competence)
        {
            CompetenceModel m = new();
            m.DeleteCompetence(competence);
        }
        #endregion //Competence

        #region Discipline
        public List<Discipline> GetDisciplines()
        {
            DisciplineModel m = new();
            return m.GetDisciplines();
        }
        public void SetDiscipline(Discipline Discipline)
        {
            DisciplineModel m = new();
            m.SetDiscipline(Discipline);
        }
        public void DeleteDiscipline(Discipline Discipline)
        {
            DisciplineModel m = new();
            m.DeleteDiscipline(Discipline);
        }
        #endregion //Discipline

        #region Practice
        public List<Practic> GetPractices()
        {
            PracticeModel m = new();
            return m.GetPractices();
        }
        public void SetPractice(Practic practice)
        {
            PracticeModel m = new();
            m.SetPractice(practice);
        }
        public void DeletePractice(Practic practice)
        {
            PracticeModel m = new();
            m.DeletePractice(practice);
        }
        #endregion //Practice

        #endregion //Methods

    }
}
