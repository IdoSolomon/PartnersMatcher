using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI.Controller;
using GUI.View;
using GUI.Model;
using System.Collections.ObjectModel;
using System.Data;

namespace GUI.Controller
{
    public class PartnersMatcherController : IController
    {
        private IModel m_model;
        private IView m_view;

        public void SetModel(IModel model)
        {
            m_model = model;
        }

        public void SetView(IView view)
        {
            m_view = view;
        }

        public void SetUser(string login)
        {
            m_model.SetUser(login);
        }

        public Boolean IsConnected()
        {
            return m_model.IsConnected();
        }

        public void SetConnected(Boolean mode)
        {
            m_model.SetConnected(mode);
        }

        public void dbClose()
        {
            m_model.dbClose();
        }

        public bool dbConnect()
        {
            return m_model.dbConnect();
        }

        public bool emailCheck(string email)
        {
            return m_model.emailCheck(email);
        }

        public bool emailExists(string email)
        {
            return m_model.emailExists(email);
        }

        public Dictionary<string, ObservableCollection<string>> GetActivities()
        {
            return m_model.GetActivities();
        }

        public ObservableCollection<string> GetDifficulty()
        {
            return m_model.GetDifficulty();
        }

        public ObservableCollection<string> GetFields()
        {
            return m_model.GetFields();
        }

        public ObservableCollection<string> GetFrequency()
        {
            return m_model.GetFrequency();
        }

        public ObservableCollection<string> GetGeographicAreas()
        {
            return m_model.GetGeographicAreas();
        }

        public ObservableCollection<string> GetNumOfParticipates()
        {
            return m_model.GetNumOfParticipates();
        }

        public ObservableCollection<DateTime> GetStartOn()
        {
            return m_model.GetStartOn();
        }

        public bool InsertToUserTable(params string[] data)
        {
            return m_model.InsertToUserTable(data);
        }

        public string RetrieveUserLogin(string email)
        {
            return m_model.RetrieveUserLogin(email);
        }

        public DataSet Search(string geographicArea, string field)
        {
            return m_model.Search(geographicArea, field);
        }

        public bool SendRegistrationMail(string target)
        {
            return m_model.SendRegistrationMail(target);
        }

        public bool ValidateUser(string user, string pass)
        {
            return m_model.ValidateUser(user, pass);
        }
    }
}
