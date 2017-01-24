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
using GUI.classes;
using GUI.DataGridRecords;

namespace GUI.Controller
{
    /// <summary>
    /// our controller object
    /// </summary>
    public class PartnersMatcherController : IController
    {
        private IModel m_model;
        private IView m_view;

        /// <summary>
        /// sets the model object
        /// </summary>
        /// <param name="model">our model object</param>
        public void SetModel(IModel model)
        {
            m_model = model;
        }

        /// <summary>
        /// sets the view object
        /// </summary>
        /// <param name="view">our view object</param>
        public void SetView(IView view)
        {
            m_view = view;
        }

        /// <summary>
        /// sets the current logged on user
        /// </summary>
        /// <param name="login">user email</param>
        public void SetUser(string login)
        {
            m_model.SetUser(login);
        }

        /// <summary>
        /// "logs out" the current active user
        /// </summary>
        public void RemoveUser()
        {
            m_model.RemoveUser();
        }

        /// <summary>
        /// show whether a user is currently connected
        /// </summary>
        /// <returns>true if connected, false otherwise</returns>
        public Boolean IsConnected()
        {
            return m_model.IsConnected();
        }

        /// <summary>
        /// changes the user connection status
        /// </summary>
        /// <param name="mode">status</param>
        public void SetConnected(Boolean mode)
        {
            m_model.SetConnected(mode);
        }

        /// <summary>
        /// disconnects from the access db
        /// </summary>
        public void dbClose()
        {
            m_model.dbClose();
        }

        /// <summary>
        /// connects to the access DB
        /// </summary>
        /// <returns>true if successful, false otherwise</returns>
        public bool dbConnect()
        {
            return m_model.dbConnect();
        }

        /// <summary>
        /// validates email string format
        /// </summary>
        /// <param name="email">email address</param>
        /// <returns>true if valid, false otherwise</returns>
        public bool emailCheck(string email)
        {
            return m_model.emailCheck(email);
        }

        /// <summary>
        /// checks whether an email is already in use by an existing user
        /// </summary>
        /// <param name="email">email address</param>
        /// <returns>true if exists, false otherwise</returns>
        public bool emailExists(string email)
        {
            return m_model.emailExists(email);
        }

        /// <summary>
        /// get activities from DB for GUI
        /// </summary>
        /// <returns>Dictionary of fields and corrosponding activities</returns>
        public Dictionary<string, ObservableCollection<string>> GetActivities()
        {
            return m_model.GetActivities();
        }

        /// <summary>
        /// get difficulties for GUI
        /// </summary>
        /// <returns>ObservableCollection of difficulties</returns>
        public ObservableCollection<string> GetDifficulty()
        {
            return m_model.GetDifficulty();
        }

        /// <summary>
        /// get fields from DB for GUI
        /// </summary>
        /// <returns>ObservableCollection of fields</returns>
        public ObservableCollection<string> GetFields()
        {
            return m_model.GetFields();
        }

        /// <summary>
        /// get genders for GUI
        /// </summary>
        /// <returns>ObservableCollection of genders</returns>
        public ObservableCollection<string> GetGenders()
        {
            return m_model.GetGenders();
        }

        /// <summary>
        /// get frequencies numbers for GUI
        /// </summary>
        /// <returns>ObservableCollection of frequencies</returns>
        public ObservableCollection<string> GetFrequency()
        {
            return m_model.GetFrequency();
        }

        /// <summary>
        /// get locations from DB for GUI
        /// </summary>
        /// <returns>ObservableCollection of locations</returns>
        public ObservableCollection<string> GetGeographicAreas()
        {
            return m_model.GetGeographicAreas();
        }

        /// <summary>
        /// get participant numbers for GUI
        /// </summary>
        /// <returns>ObservableCollection of participant numbers</returns>
        public ObservableCollection<string> GetNumOfParticipates()
        {
            return m_model.GetNumOfParticipates();
        }

        /// <summary>
        /// get start dates from DB for GUI
        /// </summary>
        /// <returns>ObservableCollection of start dates</returns>
        public ObservableCollection<DateTime> GetStartOn()
        {
            return m_model.GetStartOn();
        }

        /// <summary>
        /// inserts a new user record into DB
        /// </summary>
        /// <param name="data">array of user data</param>
        /// <returns>true if successful, false otherwise</returns>
        public bool InsertToUserTable(params string[] data)
        {
            return m_model.InsertToUserTable(data);
        }

        /// <summary>
        /// gets a registered user's password
        /// </summary>
        /// <param name="email">user email</param>
        /// <returns>user password</returns>
        public string RetrieveUserLogin(string email)
        {
            return m_model.RetrieveUserLogin(email);
        }

        /// <summary>
        /// searchs DB for activity records
        /// </summary>
        /// <param name="geographicArea">activity location</param>
        /// <param name="field">activity field</param>
        /// <returns>dataset with results</returns>
        public DataSet Search(string geographicArea, string field)
        {
            return m_model.Search(geographicArea, field);
        }

        /// <summary>
        /// searches DB for activity records
        /// </summary>
        /// <param name="criteria">activity object with search criteria</param>
        /// <returns>dataset with results</returns>
        public DataSet AdvSearch(Activity criteria)
        {
            return m_model.AdvSearch(criteria);
        }

        /// <summary>
        /// sends mail to new user
        /// </summary>
        /// <param name="target">user email</param>
        /// <param name="pass">user password<param>
        /// <returns>true if successful, false otherwise</returns>
        public bool SendRegistrationMail(string target, string pass)
        {
            return m_model.SendRegistrationMail(target, pass);
        }

        /// <summary>
        /// validates user details from DB
        /// </summary>
        /// <param name="user">user email</param>
        /// <param name="pass">password</param>
        /// <returns>true if there's a match, false otherwise</returns>
        public bool ValidateUser(string user, string pass)
        {
            return m_model.ValidateUser(user, pass);
        }

        /// <summary>
        /// adds new activity record to DB
        /// </summary>
        /// <param name="activity">field name</param>
        /// <returns>true if successful, false otherwise</returns>
        public Boolean CreateNewActivity(Activity activity)
        {
            return m_model.CreateNewActivity(activity);
        }

        /// <summary>
        /// checks if a field exists in DB
        /// </summary>
        /// <param name="field">field name</param>
        /// <returns>true if exists, false otherwise</returns>
        public Boolean FiledExist(string field)
        {
            return m_model.FiledExist(field);
        }

        /// <summary>
        /// adds new field record to DB
        /// </summary>
        /// <param name="field">field name</param>
        /// <returns>true if successful, false otherwise</returns>
        public Boolean CreateNewField(string field)
        {
            return m_model.CreateNewField(field);
        }

        /// <summary>
        /// ups the activity ID static counter
        /// </summary>
        public void UpdateActivityNextId()
        {
            m_model.UpdateActivityNextId();
        }

        /// <summary>
        /// pulls current user's preferences from DB
        /// </summary>
        /// <returns>true if successful, false otherwise</returns>
        public Preference GetUserPreference()
        {
            return m_model.GetUserPreference();
        }

        /// <summary>
        /// sets current user preferences in DB
        /// </summary>
        /// <param name="pref">user's updated preferences</param>
        /// <returns>true if successful, false otherwise</returns>
        public bool SetUserPreferences(Preference pref)
        {
            return m_model.SetUserPreferences(pref);
        }
    }
}
