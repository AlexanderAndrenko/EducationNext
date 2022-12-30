using DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Model
{
    internal class StateFinalCertificationModel
    {
        #region Constructor
        public StateFinalCertificationModel()
        {

        }
        #endregion //Constructor

        #region Properties
        #endregion //Properties

        #region Methods

        public List<StateFinalCertification> GetStateFinalCertifications()
        {
            List<StateFinalCertification> stateFinalCertifications = new();

            try
            {
                using (ApplicationContext db = new())
                {
                    stateFinalCertifications =
                        db.StateFinalCertifications.ToList();
                    return stateFinalCertifications;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Ошибка! " + ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
                return stateFinalCertifications;
            }
        }

        public void SetStateFinalCertification(StateFinalCertification stateFinalCertifications)
        {
            try
            {
                using (ApplicationContext db = new())
                {
                    db.StateFinalCertifications.Add(stateFinalCertifications);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }

        public void DeleteStateFinalCertification(StateFinalCertification stateFinalCertifications)
        {
            try
            {
                using (ApplicationContext db = new())
                {
                    db.Remove(stateFinalCertifications);
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

