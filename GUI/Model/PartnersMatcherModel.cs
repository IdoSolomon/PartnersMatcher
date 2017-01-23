﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.IO;
using GUI.classes;
using GUI.DataGridRecords;

namespace GUI.Model
{
    public class PartnersMatcherModel : IModel
    {
        private ObservableCollection<string> fields;
        private ObservableCollection<string> geographicAreas;
        private Dictionary<string, ObservableCollection<string>> activities;
        private ObservableCollection<DateTime> startOn;
        private ObservableCollection<string> numOfParticipates;
        private ObservableCollection<string> frequency;
        private ObservableCollection<string> difficulty;
        private ObservableCollection<string> gender;
        public OleDbConnection connection;
        public bool connected = false;
        private string dbPath;
        private string user = "";
        
        #region email settings
        private string sender = "dbpd2016@gmail.com";
        private string sender_pass = "ISSE2016";
        private string smtp = "smtp.gmail.com";
        private int port = 587;
        #endregion


        

        public PartnersMatcherModel()
        {
            dbPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\PartnersMatcher.accdb";
            InitStructures();
        }

        

        #region db

        /// <summary>
        /// Requires the "Microsoft Access Database Engine 2010 Redistributable"
        /// </summary>
        public Boolean dbConnect()
        {
            connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+dbPath+"; Persist Security Info=False;";
            try
            {
                connection.Open();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void dbClose()
        {
            connection.Close();
        }

        public Boolean CreateNewActivity(Activity activity)
        {

            if (!dbConnect())
            {
                return false;
            }
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;
            try
            {
                command = new OleDbCommand(
                    "INSERT INTO Activities ([Activity ID], [Activity Name], [Field], [Participants], [Location], [Start Date], [End Date], [Start Time], [End Time], [Difficulty], [Price], [Frequency], [Sunday], [Monday], [Tuesday], [Wednesday], [Thursday], [Friday], [Saturday], [Gender])" + 
                                       "VALUES (?,                ?,              ?,         ?,           ?,          ?,             ?,          ?,           ?,           ?,          ?,         ?,          ?,       ?,         ?,          ?,           ?,         ?,         ?,         ?)", connection);

                command.Parameters.AddWithValue("@Activity ID", activity.id);
                command.Parameters.AddWithValue("@Activity Name", activity.name);
                command.Parameters.AddWithValue("@Field", activity.field);
                command.Parameters.AddWithValue("@Participants", activity.numberOfParticipants);
                command.Parameters.AddWithValue("@Location", activity.location);
                command.Parameters.AddWithValue("@Start Date", activity.startDate);
                command.Parameters.AddWithValue("@End Date", activity.endDate);
                command.Parameters.AddWithValue("@Start Time", activity.startTime);
                command.Parameters.AddWithValue("@End Time", activity.endTime);
                command.Parameters.AddWithValue("@Difficulty", activity.difficulty);
                command.Parameters.AddWithValue("@Price", activity.price);
                command.Parameters.AddWithValue("@Frequency", activity.frequency);
                command.Parameters.AddWithValue("@Sunday", activity.days[0]);
                command.Parameters.AddWithValue("@Monday", activity.days[1]);
                command.Parameters.AddWithValue("@Tuesday", activity.days[2]);
                command.Parameters.AddWithValue("@Wednesday", activity.days[3]);
                command.Parameters.AddWithValue("@Thursday", activity.days[4]);
                command.Parameters.AddWithValue("@Friday", activity.days[5]);
                command.Parameters.AddWithValue("@Saturday", activity.days[6]);
                string gender = "";
                if (activity.gender == "Male")
                    gender = "M";
                else if (activity.gender == "Female")
                    gender = "F";
                command.Parameters.AddWithValue("@Gender", gender);


                 adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();
                dbClose();
                UpdateActivityNextId();
                UpdateActivityMenegment(activity);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public void UpdateActivityNextId()
        {
            if (dbConnect())
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                OleDbCommand command;
                DataSet ds = new DataSet();

                //Create the InsertCommand.
                command = new OleDbCommand(
                    "SELECT * FROM Activities", connection);

                adapter.SelectCommand = command;
                adapter.Fill(ds);
                Activity.NextId = ds.Tables[0].Rows.Count + 1;
                dbClose();
            }
        }

        private void UpdateActivityMenegment(Activity activity)
        {
            if (dbConnect())
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                OleDbCommand command;
                try
                {
                    command = new OleDbCommand(
                        "INSERT INTO [Activity-Management] ([Activity ID], [User Email])" +
                                             "VALUES (         ?,              ?)", connection);

                    command.Parameters.AddWithValue("@Activity ID", activity.id);
                    command.Parameters.AddWithValue("@User Email", user);

                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    dbClose();
                }
                catch(Exception e)
                {
                    e.ToString();
                }
            }
        }

        private ObservableCollection<string> GetFieldsFromDatabase()
        {
            if (!dbConnect())
                return null;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;
            DataSet ds = new DataSet();

            //Create the InsertCommand.
            command = new OleDbCommand(
                "SELECT * FROM Fields", connection);

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            ObservableCollection<string> databaseFieldes = new ObservableCollection<string>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string field = ds.Tables[0].Rows[i][0].ToString();
                if (!databaseFieldes.Contains(field))
                    databaseFieldes.Add(field);
            }
            dbClose();
            return databaseFieldes;
        }

        private ObservableCollection<string> GetAreasFromDatabase()
        {
            if (!dbConnect())
                return null;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;
            DataSet ds = new DataSet();

            //Create the InsertCommand.
            command = new OleDbCommand(
                "SELECT [Location] FROM Activities", connection);

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            ObservableCollection<string> geographicAreas = new ObservableCollection<string>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string location = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                if (!geographicAreas.Contains(location))
                    geographicAreas.Add(location);
            }
            dbClose();
            return geographicAreas;
        }

        public Boolean FiledExist(string field)
        {
            fields = GetFieldsFromDatabase();
            if (fields.Contains(field))
                return true;
            return false;
        }


        public Boolean CreateNewField(string field)
        {

            if (!dbConnect())
            {
                return false;
            }
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;
            try
            {
                //Create the InsertCommand.
                command = new OleDbCommand(
                    "INSERT INTO Fields ([Field Name]) VALUES (?)", connection);

                command.Parameters.AddWithValue("@Field Name", field);

                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();
                dbClose();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public Boolean InsertToUserTable(params string[] data)
        {
            if (!dbConnect())
            {
                return false;
            }
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;

            //Create the InsertCommand.
            command = new OleDbCommand(
                "INSERT INTO Users ([Email], [First Name], [Last Name], [Password], [Birth Date], [Sex], [Phone Number], [Location], [Smokes], [Pet], [Resume]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", connection);

            command.Parameters.AddWithValue("@Email", data[2]);
            command.Parameters.AddWithValue("@First Name", data[0]);
            command.Parameters.AddWithValue("@Last Name", data[1]);
            command.Parameters.AddWithValue("@Password", data[3]);
            //convert data[3] to datetime here
            string[] date = data[5].Split('/');
            DateTime dt = new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0]));
            command.Parameters.AddWithValue("@Birth Date", dt);
            //convert data[t] to M/F here
            string sex;
            if (data[6] == "Male")
                sex = "M";
            else sex = "F";
            command.Parameters.AddWithValue("@Sex", sex);
            command.Parameters.AddWithValue("@Phone Number", data[7]);
            command.Parameters.AddWithValue("@Location", data[8]);
            //convert data[9] to bool here
            bool smokes;
            if (data[9] == "Yes")
                smokes = true;
            else smokes = false;
            command.Parameters.AddWithValue("@Smokes", smokes);
            //convert data[10] to bool here
            bool pet;
            if (data[10] == "Yes")
                pet = true;
            else pet = false;
            command.Parameters.AddWithValue("@Pet", pet);
            command.Parameters.AddWithValue("@Resume", data[11]);
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            dbClose();
            return true;
        }

        public string RetrieveUserLogin(string email)
        {
            if (!dbConnect())
                return "";
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;
            DataSet ds = new DataSet();

            //Create the InsertCommand.
            command = new OleDbCommand(
                "SELECT [Password] FROM Users WHERE [Email] = '" + email + "'", connection);

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            string login = "";
            if (ds.Tables[0].Rows.Count != 0)
                login = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            dbClose();
            return login;
        }

        public DataSet Search(string geographicArea, string field)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;
            DataSet ds = new DataSet();

            if (!dbConnect())
                return ds;

            //Create the SelectCommand.
            command = new OleDbCommand(
                "SELECT * FROM Activities WHERE [Field] = '" + field + "' AND [Location] = '" + geographicArea + "'", connection);

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            dbClose();
            return ds;
        }

        public Boolean emailExists(string email)
        {
            if (!dbConnect())
                return false;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;
            DataSet ds = new DataSet();

            //Create the InsertCommand.
            command = new OleDbCommand(
                "SELECT [Email] FROM Users WHERE [Email] = '" + email + "'", connection);

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            dbClose();
            if (ds.Tables[0].Rows.Count != 0)
                return true;

            return false;
        }

        private string BuildAdvSearchCmd(Activity criteria)
        {
            string cmd = "SELECT * FROM Activities WHERE [Field] = '" + criteria.field + "' AND [Location] = '" + criteria.location + "'";

            if (criteria.frequency != null)
                cmd += " AND [Frequency] = '" + criteria.frequency + "'";
            if (criteria.numberOfParticipants != 0)
                cmd += " AND [Participants] = '" + criteria.numberOfParticipants.ToString() + "'";
            if (criteria.difficulty != null)
                cmd += " AND [Difficulty] = '" + criteria.difficulty + "'";
            //DateTime strings might not be compatible with search
            if (criteria.startDate.ToShortDateString() != "01/01/0001")
                cmd += " AND [Start Date] = '" + criteria.startDate.ToShortDateString() + "'";
            if (criteria.endDate.ToShortDateString() != "01/01/0001")
                cmd += " AND [End Date] = '" + criteria.endDate.ToShortDateString() + "'";
            if (criteria.gender == "M")
                cmd += " AND [Gender] = 'M'";
            else if (criteria.gender == "F")
                cmd += " AND [Gender] = 'F'";
            if (criteria.days[0])
                cmd += " AND [Sunday] = Yes";
            if (criteria.days[1])
                cmd += " AND [Monday] = Yes";
            if (criteria.days[2])
                cmd += " AND [Tuesday] = Yes";
            if (criteria.days[3])
                cmd += " AND [Wedensday] = Yes";
            if (criteria.days[4])
                cmd += " AND [Thursday] = Yes";
            if (criteria.days[5])
                cmd += " AND [Friday] = Yes";
            if (criteria.days[6])
                cmd += " AND [Saturday] = Yes";
            return cmd;
        }

        public DataSet AdvSearch(Activity criteria)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;
            DataSet ds = new DataSet();

            if (!dbConnect())
                return ds;
            string cmd = BuildAdvSearchCmd(criteria);
            //Create the InsertCommand.
            command = new OleDbCommand(cmd, connection);

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            dbClose();
            return ds;
        }

        public Preference GetUserPreference()
        {
            Preference pref = new Preference();

            if (!dbConnect())
                return pref;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;
            DataSet ds = new DataSet();

            //Create the InsertCommand.
            command = new OleDbCommand(
                "SELECT * FROM [User-Preferences] WHERE [User Email] = '" + user + "'", connection);

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            dbClose();

            if (ds.Tables[0].Rows.Count != 0)
            {
                pref.userEmail = ds.Tables[0].Rows[0][0].ToString();
                pref.sex = ds.Tables[0].Rows[0][1].ToString();
                if(ds.Tables[0].Rows[0][2] != DBNull.Value)
                    pref.minAge = Convert.ToInt32(ds.Tables[0].Rows[0][2]);
                if (ds.Tables[0].Rows[0][3] != DBNull.Value)
                    pref.maxAge = Convert.ToInt32(ds.Tables[0].Rows[0][3]);
                pref.smokes = Convert.ToBoolean(ds.Tables[0].Rows[0][4]);
                pref.pet = Convert.ToBoolean(ds.Tables[0].Rows[0][5]);
                if (ds.Tables[0].Rows[0][6] != DBNull.Value)
                    pref.maxPrice = Convert.ToInt32(ds.Tables[0].Rows[0][6]);
                if (ds.Tables[0].Rows[0][7] != DBNull.Value)
                    pref.location = ds.Tables[0].Rows[0][7].ToString();
                if(!(ds.Tables[0].Rows[0][8] is DBNull))
                    pref.startHour = Convert.ToDateTime(ds.Tables[0].Rows[0][8]).TimeOfDay;
                if (!(ds.Tables[0].Rows[0][9] is DBNull))
                    pref.endHour = Convert.ToDateTime(ds.Tables[0].Rows[0][9]).TimeOfDay;
                if (ds.Tables[0].Rows[0][10] != DBNull.Value)
                    pref.numberOfParticipants = Convert.ToInt32(ds.Tables[0].Rows[0][10]);
                if (ds.Tables[0].Rows[0][11] != DBNull.Value)
                    pref.difficulty = ds.Tables[0].Rows[0][11].ToString();
                if (ds.Tables[0].Rows[0][12] != DBNull.Value)
                    pref.frequency = ds.Tables[0].Rows[0][12].ToString();
                for (int i = 0; i < 7; i++)
                {
                    if (ds.Tables[0].Rows[0][13 + i] != null)
                        pref.days[i] = Convert.ToBoolean(ds.Tables[0].Rows[0][13 + i]);
                    else pref.days[i] = false;
                }
            }

            return pref;
        }

        public bool SetUserPreferences(Preference pref)
        {
            if (!RemovePref())
                return false;
            if (!InsertPref(pref))
                return false;
            return true;
        }

        private Boolean RemovePref()
        {
            if (!dbConnect())
            {
                return false;
            }
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            OleDbCommand command = new OleDbCommand(
                    "DELETE FROM [User-Preferences] WHERE [User Email] = '" + user + "'", connection);

            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            dbClose();
            return true;

        }


        private Boolean InsertPref(Preference pref)
        {
            //int check: x > 0
            //string check: x != null
            //boolean check: x != null then: x == true/false
            //timespan check: possibly x.tostring() != 00:00:00

            if (!dbConnect())
            {
                return false;
            }
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            OleDbCommand command = new OleDbCommand(
                    "INSERT INTO [User-Preferences] ([User Email], [Sex], [Min Age], [Max Age], [Smoking], [Pets], [Max Price], [Location], [Start Time], [End Time], [Participants], [Difficulty], [Frequency], [Sunday], [Monday], [Tuesday], [Wednesday], [Thursday], [Friday], [Saturday])" +
                                       "VALUES (?,                   ?,        ?,         ?,          ?,      ?,          ?,           ?,           ?,          ?,         ?,                ?,            ?,          ?,       ?,         ?,          ?,           ?,         ?,         ?)", connection);

            command.Parameters.AddWithValue("@User Email", user);
            if (pref.sex != null && pref.sex != "")
                command.Parameters.AddWithValue("@Sex", pref.sex);
            else command.Parameters.AddWithValue("@Sex", DBNull.Value);
            if (pref.minAge > 0)
                command.Parameters.AddWithValue("@Min Age", pref.minAge);
            else command.Parameters.AddWithValue("@Min Age", DBNull.Value);
            if (pref.maxAge > 0)
                command.Parameters.AddWithValue("@Max Age", pref.maxAge);
            else command.Parameters.AddWithValue("@Max Age", DBNull.Value);
            if (pref.smokes)
                command.Parameters.AddWithValue("@Smoking", true);
            else command.Parameters.AddWithValue("@Smoking", false);
            if (pref.pet)
                command.Parameters.AddWithValue("@Pets", true);
            else command.Parameters.AddWithValue("@Pets", false);
            if (pref.maxPrice > 0)
                command.Parameters.AddWithValue("@Max Price", pref.maxPrice);
            else command.Parameters.AddWithValue("@Max Price", DBNull.Value);
            if (pref.location != null && pref.location != "")
                command.Parameters.AddWithValue("@Location", pref.location);
            else command.Parameters.AddWithValue("@Location", DBNull.Value);
            if (pref.startHour.ToString() != "00:00:00")
                command.Parameters.AddWithValue("@Start Time", pref.startHour);
            else command.Parameters.AddWithValue("@Start Time", DBNull.Value);
            if (pref.endHour.ToString() != "00:00:00")
                command.Parameters.AddWithValue("@End Time", pref.endHour);
            else command.Parameters.AddWithValue("@End Time", DBNull.Value);
            if (pref.numberOfParticipants > 0)
                command.Parameters.AddWithValue("@Participants", pref.numberOfParticipants);
            else command.Parameters.AddWithValue("@Participants", DBNull.Value);
            if (pref.difficulty != null && pref.difficulty != "")
                command.Parameters.AddWithValue("@Difficulty", pref.difficulty);
            else command.Parameters.AddWithValue("@Difficulty", DBNull.Value);
            if (pref.frequency != null && pref.frequency != "")
                command.Parameters.AddWithValue("@Frequency", pref.frequency);
            else command.Parameters.AddWithValue("@Frequency", DBNull.Value);
            if (pref.days[0])
                command.Parameters.AddWithValue("@Sunday", true);
            else command.Parameters.AddWithValue("@Sunday", false);
            if (pref.days[1])
                command.Parameters.AddWithValue("@Monday", true);
            else command.Parameters.AddWithValue("@Monday", false);
            if (pref.days[2])
                command.Parameters.AddWithValue("@Tuesday", true);
            else command.Parameters.AddWithValue("@Tuesday", false);
            if (pref.days[3])
                command.Parameters.AddWithValue("@Wednesday", true);
            else command.Parameters.AddWithValue("@Wednesday", false);
            if (pref.days[4])
                command.Parameters.AddWithValue("@Thursday", true);
            else command.Parameters.AddWithValue("@Thursday", false);
            if (pref.days[5])
                command.Parameters.AddWithValue("@Friday", true);
            else command.Parameters.AddWithValue("@Friday", false);
            if (pref.days[6])
                command.Parameters.AddWithValue("@Saturday", true);
            else command.Parameters.AddWithValue("@Saturday", false);

            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            dbClose();
            return true;
        }
        #endregion

        #region Init
        private void InitStructures()
        {
            //Create the InsertCommand.
            //InitFields();
            //InitGeographicAreas();
            //InitActivities();

            numOfParticipates = new ObservableCollection<string>();
            numOfParticipates.Add("2");
            numOfParticipates.Add("3");
            numOfParticipates.Add("4");
            numOfParticipates.Add("5");
            numOfParticipates.Add("More");

            frequency = new ObservableCollection<string>();
            frequency.Add("One-off");
            frequency.Add("Weekly");
            frequency.Add("Monthly");
            frequency.Add("Continuous");

            difficulty = new ObservableCollection<string>();
            difficulty.Add("Easy");
            difficulty.Add("Medium");
            difficulty.Add("Hard");
            difficulty.Add("Very hard");
            difficulty.Add("Non relevant");

            gender = new ObservableCollection<string>();
            gender.Add("Female");
            gender.Add("Male");
            gender.Add("Mixed");
        }

        /*private void InitActivities()
        {
            if (!dbConnect())
                return;
            DataSet ds = new DataSet();
            activities = new Dictionary<string, ObservableCollection<string>>();
            OleDbCommand command;
            foreach (string field in Fields)
            {
                command = new OleDbCommand(
                "SELECT [Activity Name] FROM Activities WHERE [Field] = '" + field + "'", connection);
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(ds);
                //TODO "Key Not Found Exception"
                ObservableCollection<string> collection = new ObservableCollection<string>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    collection.Add(ds.Tables[0].Rows[i].ItemArray[0].ToString());
                }
                activities.Add(field, collection);
                ds.Clear();
            }
            dbClose();
        }*/

        /*private void InitGeographicAreas()
        {
            if (!dbConnect())
                return;

            geographicAreas = new ObservableCollection<string>();
            DataSet ds = new DataSet();
            OleDbCommand command = new OleDbCommand(
                "SELECT [Location] FROM Activities", connection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string location = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                if (!geographicAreas.Contains(location))
                    geographicAreas.Add(location);
            }
            dbClose();

        }*/

        /*private void InitFields()
        {
            if (!dbConnect())
                return;
            DataSet ds = new DataSet();
            OleDbCommand command = new OleDbCommand(
                "SELECT [Field Name] FROM Fields", connection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(ds);
            fields = new ObservableCollection<string>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string f = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                if(!fields.Contains(f))
                fields.Add(f);
            }
            dbClose();

        }*/

        #endregion

        #region properties

        public Boolean IsConnected()
        {
            return connected;
        }

        public void SetUser(string login)
        {
            user = login;
        }

        public void RemoveUser()
        {
            user = "";
        }

        public void SetConnected(Boolean mode)
        {
            connected = mode;
            if (!mode)
                user = "";
        }

        private ObservableCollection<string> Fields
        {
            get
            {
                return fields;
            }
            set
            {
                fields = value;
            }
        }

        public ObservableCollection<string> GetFields()
        {
            fields = GetFieldsFromDatabase();
            return fields;
        }


        private ObservableCollection<string> GeographicAreas
        {
            get
            {
                geographicAreas = GetLocationsFromDatabase();
                return geographicAreas;
            }
            set
            {
                geographicAreas = value;
            }
        }

        private ObservableCollection<string> GetLocationsFromDatabase()
        {
            if (!dbConnect())
                return null;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;
            DataSet ds = new DataSet();

            //Create the InsertCommand.
            command = new OleDbCommand(
                "SELECT Location FROM Activities", connection);

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            ObservableCollection<string> databaseLocatins = new ObservableCollection<string>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string location = ds.Tables[0].Rows[i][0].ToString();
                if (!databaseLocatins.Contains(location))
                    databaseLocatins.Add(location);
            }
            dbClose();
            return databaseLocatins;
        }

        public ObservableCollection<string> GetGeographicAreas()
        {
            geographicAreas = GetAreasFromDatabase();
            return geographicAreas;
        }

        public ObservableCollection<string> GetGenders()
        {
            return gender;
        }

        private Dictionary<string, ObservableCollection<string>> Activities
        {
            get
            {
                return activities;
            }
            set
            {
                activities = value;
            }
        }

        public Dictionary<string, ObservableCollection<string>> GetActivities()
        {
            return activities;
        }

        private ObservableCollection<DateTime> StartOn
        {
            get
            {
                return startOn;
            }
            set
            {
                startOn = value;
            }
        }

        public ObservableCollection<DateTime> GetStartOn()
        {
            return startOn;
        }

        private ObservableCollection<string> NumOfParticipates
        {
            get
            {
                return numOfParticipates;
            }
            set
            {
                numOfParticipates = value;
            }
        }

        public ObservableCollection<string> GetNumOfParticipates()
        {
            return numOfParticipates;
        }

        private ObservableCollection<string> Frequency
        {
            get
            {
                return frequency;
            }
            set
            {
                frequency = value;
            }
        }

        public ObservableCollection<string> GetFrequency()
        {
            return frequency;
        }

        private ObservableCollection<string> Difficulty
        {
            get
            {
                return difficulty;
            }
            set
            {
                difficulty = value;
            }
        }

        public ObservableCollection<string> GetDifficulty()
        {
            return difficulty;
        }

        #endregion

        public Boolean ValidateUser(string user, string pass)
        {
            if(!emailExists(user))
            {
                return false;
            }
            else if (pass != RetrieveUserLogin(user))
            {
                return false;
            }
            return true;
        }

        public Boolean emailCheck(string email)
        {
            if (!email.Contains("@"))
                return false;
            string[] split = email.Split('@');
            if (split.Length != 2)
                return false;
            if (split[0].Length == 0)
                return false;
            if (!split[1].Contains("."))
                return false;
            string[] split2 = split[1].Split('.');
            if (split2.Length != 2)
                return false;
            if (split2[0].Length == 0 || split2[1].Length == 0)
                return false;
            return true;
        }

        public Boolean SendRegistrationMail(string target, string pass)
        {
                Thread.CurrentThread.IsBackground = true;
                SmtpClient SmtpServer = new SmtpClient(smtp, port);
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential(sender, sender_pass);
                SmtpServer.EnableSsl = true;

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(sender);
                mail.To.Add(new MailAddress(target));
                mail.IsBodyHtml = false;
                mail.Subject = "Your PartnersMatcher™ account has been created!";
                mail.Body = "Your PartnersMatcher™ account, " + target + ", has been created and is ready to use." + System.Environment.NewLine + System.Environment.NewLine + "Your password is " + pass + System.Environment.NewLine + System.Environment.NewLine + "You may now sign in to PartnersMatcher™ using your new account.";


                try
                {
                    ///this gets blocked by McAfee anti-virus
                    SmtpServer.Send(mail);
                }
                catch
                {
                    return false;
                }
                finally
                {
                    mail.Dispose();
                }
                return true;
        }

        
    }

}