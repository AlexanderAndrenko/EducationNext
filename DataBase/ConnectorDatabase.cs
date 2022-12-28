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

        public List<EducationalStandart> GetEducationalStandarts()
        {
            EducationalStandartModel m = new();
            return m.GetEducationalStandarts();
        }

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

        #endregion //Methods

    }
}
