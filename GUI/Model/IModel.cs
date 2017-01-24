using GUI.classes;
using GUI.DataGridRecords;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Model
{
    /// <summary>
    /// MVC model interface
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// connects to the access DB
        /// </summary>
        /// <returns>true if successful, false otherwise</returns>
        Boolean dbConnect();

        /// <summary>
        /// show whether a user is currently connected
        /// </summary>
        /// <returns>true if connected, fals
        Boolean IsConnected();

        /// <summary>
        /// sets the current logged on user
        /// </summary>
        /// <param name="login">user email</param>
        void SetUser(string login);

        /// <summary>
        /// "logs out" the current active user
        /// </summary>
        void RemoveUser();

        /// <summary>
        /// changes the user connection status
        /// </summary>
        /// <param name="mode">status</param>
        void SetConnected(Boolean mode);

        /// <summary>
        /// disconnects from the access db
        /// </summary>
        void dbClose();

        /// <summary>
        /// inserts a new user record into DB
        /// </summary>
        /// <param name="data">array of user data</param>
        /// <returns>true if successful, false otherwise</returns>
        Boolean InsertToUserTable(params string[] data);

        /// <summary>
        /// gets a registered user's password
        /// </summary>
        /// <param name="email">user email</param>
        /// <returns>user password</returns>
        string RetrieveUserLogin(string email);

        /// <summary>
        /// searchs DB for activity records
        /// </summary>
        /// <param name="geographicArea">activity location</param>
        /// <param name="field">activity field</param>
        /// <returns>dataset with results</returns>
        DataSet Search(string geographicArea, string field);

        /// <summary>
        /// searches DB for activity records
        /// </summary>
        /// <param name="criteria">activity object with search criteria</param>
        /// <returns>dataset with results</returns>
        DataSet AdvSearch(Activity criteria);

        /// <summary>
        /// checks whether an email is already in use by an existing user
        /// </summary>
        /// <param name="email">email address</param>
        /// <returns>true if exists, false otherwise</returns>
        Boolean emailExists(string email);

        /// <summary>
        /// get fields from DB for GUI
        /// </summary>
        /// <returns>ObservableCollection of fields</returns>
        ObservableCollection<string> GetFields();

        /// <summary>
        /// get locations from DB for GUI
        /// </summary>
        /// <returns>ObservableCollection of locations</returns>
        ObservableCollection<string> GetGeographicAreas();

        /// <summary>
        /// get genders for GUI
        /// </summary>
        /// <returns>ObservableCollection of genders</returns>
        ObservableCollection<string> GetGenders();

        /// <summary>
        /// get activities from DB for GUI
        /// </summary>
        /// <returns>Dictionary of fields and corrosponding activities</returns>
        Dictionary<string, ObservableCollection<string>> GetActivities();

        /// <summary>
        /// get start dates from DB for GUI
        /// </summary>
        /// <returns>ObservableCollection of start dates</returns>
        ObservableCollection<DateTime> GetStartOn();

        /// <summary>
        /// get participant numbers for GUI
        /// </summary>
        /// <returns>ObservableCollection of participant numbers</returns>
        ObservableCollection<string> GetNumOfParticipates();

        /// <summary>
        /// get frequencies numbers for GUI
        /// </summary>
        /// <returns>ObservableCollection of frequencies</returns>
        ObservableCollection<string> GetFrequency();

        /// <summary>
        /// get difficulties for GUI
        /// </summary>
        /// <returns>ObservableCollection of difficulties</returns>
        ObservableCollection<string> GetDifficulty();

        /// <summary>
        /// validates user details from DB
        /// </summary>
        /// <param name="user">user email</param>
        /// <param name="pass">password</param>
        /// <returns>true if there's a match, false otherwise</returns>
        Boolean ValidateUser(string user, string pass);

        /// <summary>
        /// validates email string format
        /// </summary>
        /// <param name="email">email address</param>
        /// <returns>true if valid, false otherwise</returns>
        Boolean emailCheck(string email);

        /// <summary>
        /// sends mail to new user
        /// </summary>
        /// <param name="target">user email</param>
        /// <param name="pass">user password<param>
        /// <returns>true if successful, false otherwise</returns>
        Boolean SendRegistrationMail(string target, string pass);

        /// <summary>
        /// adds new activity record to DB
        /// </summary>
        /// <param name="activity">field name</param>
        /// <returns>true if successful, false otherwise</returns>
        Boolean CreateNewActivity(Activity activity);

        /// <summary>
        /// checks if a field exists in DB
        /// </summary>
        /// <param name="field">field name</param>
        /// <returns>true if exists, false otherwise</returns>
        Boolean FiledExist(string field);

        /// <summary>
        /// adds new field record to DB
        /// </summary>
        /// <param name="field">field name</param>
        /// <returns>true if successful, false otherwise</returns>
        Boolean CreateNewField(string field);

        /// <summary>
        /// ups the activity ID static counter
        /// </summary>
        void UpdateActivityNextId();

        /// <summary>
        /// pulls current user's preferences from DB
        /// </summary>
        /// <returns>true if successful, false otherwise</returns>
        Preference GetUserPreference();

        /// <summary>
        /// sets current user preferences in DB
        /// </summary>
        /// <param name="pref">user's updated preferences</param>
        /// <returns>true if successful, false otherwise</returns>
        bool SetUserPreferences(Preference pref);
    }
}
