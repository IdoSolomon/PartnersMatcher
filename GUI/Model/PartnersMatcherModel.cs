using System;
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

        public Boolean InsertToUserTable(params string[] data)
        {
            if(!dbConnect())
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
            string[] date = data[3].Split('/');
            DateTime dt = new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0]));
            command.Parameters.AddWithValue("@Birth Date", dt);
            //convert data[t] to M/F here
            string sex;
            if (data[9] == "Male")
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

            //Create the InsertCommand.
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
            if (ds.Tables[0].Rows.Count == 0)
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
            if (criteria.startDate != null)
                cmd += " AND [Start Date] = '" + criteria.startDate.ToShortDateString() + "'";
            if (criteria.endDate != null)
                cmd += " AND [End Date] = '" + criteria.endDate.ToShortDateString() + "'";
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

        public ObservableCollection<ActivityRecord> GenderMatch(DataSet ds, string gender)
        {
            ObservableCollection<ActivityRecord> filteredRecoreds = new ObservableCollection<ActivityRecord>();

            for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string id = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                DataSet users = GetActivityUsers(id);
                if(users.Tables[0].Rows.Count > 0)
                {
                    //if(MatchUserGenders(users, gender))
                    //create ActivityRecord and add to collection
                }
            }

            return filteredRecoreds;
        }

        private Boolean MatchUserGenders(DataSet ds, string gender)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string email = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                DataSet users = GetUserGender(email);
                if (!(users.Tables[0].Rows[i].ItemArray[0].ToString() == gender))
                    return false;
            }
            return true;
        }

        private DataSet GetActivityUsers(string id)
        {
            DataSet ds = new DataSet();

            string cmd = "SELECT [User Email] FROM Activity-Users WHERE [Activity ID] = '" + id + "'";

            if (!dbConnect())
                return ds;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;

            //Create the InsertCommand.
            command = new OleDbCommand(cmd, connection);

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            dbClose();

            return ds;
        }
        private DataSet GetUserGender(string email)
        {
            DataSet ds = new DataSet();

            string cmd = "SELECT [Sex] FROM Users WHERE [Email] = '" + email + "'";

            if (!dbConnect())
                return ds;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;

            //Create the InsertCommand.
            command = new OleDbCommand(cmd, connection);

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            dbClose();

            return ds;
        }

        #endregion

        #region Init
        private void InitStructures()
        {
            //Create the InsertCommand.
            InitFields();
            InitGeographicAreas();
            InitActivities();

            numOfParticipates = new ObservableCollection<string>();
            numOfParticipates.Add("2");
            numOfParticipates.Add("3");
            numOfParticipates.Add("4");
            numOfParticipates.Add("5");
            numOfParticipates.Add("More");

            frequency = new ObservableCollection<string>();
            frequency.Add("Weekly");
            frequency.Add("One-off");
            frequency.Add("Continuous");

            difficulty = new ObservableCollection<string>();
            difficulty.Add("Easy");
            difficulty.Add("Medium");
            difficulty.Add("Hard");
            difficulty.Add("Very hard");
        }

        private void InitActivities()
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
        }

        private void InitGeographicAreas()
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

        }

        private void InitFields()
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

        }

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
            return fields;
        }


        private ObservableCollection<string> GeographicAreas
        {
            get
            {
                return geographicAreas;
            }
            set
            {
                geographicAreas = value;
            }
        }

        public ObservableCollection<string> GetGeographicAreas()
        {
            return geographicAreas;
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

        public Boolean SendRegistrationMail(string target)
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
                mail.Body = "Your PartnersMatcher™ account, " + target + ", has been created and is ready to use." + System.Environment.NewLine + System.Environment.NewLine + "You may now sign in to PartnersMatcher™ using your new account.";


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
