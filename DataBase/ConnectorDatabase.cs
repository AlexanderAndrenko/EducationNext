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
        public void SetEducationalStandart(EducationalStandart standart)
        {
            EducationalStandartModel m = new();
            m.SetStandart(standart);
        }
        public void DeleteEducationalStandart(EducationalStandart standart)
        {
            EducationalStandartModel m = new();
            m.DeleteStandart(standart);
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

        #region StateFinalCertification
        public List<StateFinalCertification> GetStateFinalCertifications()
        {
            StateFinalCertificationModel m = new();
            return m.GetStateFinalCertifications();
        }
        public void SetStateFinalCertification(StateFinalCertification stateFinalCertification)
        {
            StateFinalCertificationModel m = new();
            m.SetStateFinalCertification(stateFinalCertification);
        }
        public void DeleteStateFinalCertification(StateFinalCertification stateFinalCertification)
        {
            StateFinalCertificationModel m = new();
            m.DeleteStateFinalCertification(stateFinalCertification);
        }
        #endregion //StateFinalCertification

        #region EducationalProgram
        public List<EducationalProgram> GetEducationalPrograms()
        {
            EducationalProgramModel m = new();
            return m.GetEducationalPrograms();
        }
        public void SetEducationalProgram(EducationalProgram educationalProgram)
        {
            EducationalProgramModel m = new();
            m.SetEducationalProgram(educationalProgram);
        }
        public void DeleteEducationalProgram(EducationalProgram educationalProgram)
        {
            EducationalProgramModel m = new();
            m.DeleteEducationalProgram(educationalProgram);
        }
        #endregion //EducationalProgram

        #region Syllabus
        public List<Syllabus> GetSyllabuses()
        {
            SyllabusModel m = new();
            return m.GetSyllabuses();
        }
        public void SetSyllabus(Syllabus syllabus)
        {
            SyllabusModel m = new();
            m.SetSyllabus(syllabus);
        }
        public void DeleteSyllabus(Syllabus syllabus)
        {
            SyllabusModel m = new();
            m.DeleteSyllabus(syllabus);
        }
        #endregion //Syllabus

        #endregion //Methods

    }
}
