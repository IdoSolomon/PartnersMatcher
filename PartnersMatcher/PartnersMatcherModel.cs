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

namespace PartnersMatcher
{
    public class PartnersMatcherModel
    {
        private ObservableCollection<string> fields;
        private ObservableCollection<string> geographicAreas;
        private Dictionary<string, ObservableCollection<string>> activities;
        private ObservableCollection<DateTime> startOn;
        private ObservableCollection<string> numOfParticipates;
        private ObservableCollection<string> frequency;
        private ObservableCollection<string> difficulty;
        public OleDbConnection connection;
        private string dbPath;
        
        #region email settings
        private string sender = "dbpd2016@gmail.com";
        private string sender_pass = "ISSE2016";
        private string smtp = "smtp.gmail.com";
        private int port = 587;
        #endregion


        

        public PartnersMatcherModel()
        {
            InitStructures();
            dbPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\PartnersMatcher.accdb";
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

        public void InsertToUserTable(params string[] data)
        {
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
            return;
        }

        public string RetrieveUserLogin(string email)
        {
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
            return login;
        }

        public DataSet Search(string geographicArea, string field)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;
            DataSet ds = new DataSet();

            //Create the InsertCommand.
            command = new OleDbCommand(
                "SELECT * FROM Activities WHERE [Field] = '" + field + "' AND [Location] = '" + geographicArea + "'", connection);

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            return ds;
        }

        public Boolean emailExists(string email)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;
            DataSet ds = new DataSet();

            //Create the InsertCommand.
            command = new OleDbCommand(
                "SELECT [Email] FROM Users WHERE [Email] = '" + email + "'", connection);

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
                return true;

            return false;
        }

        #endregion

        #region Init
        public void InitStructures()
        {
            fields = new ObservableCollection<string>();
            fields.Add("Sport");
            fields.Add("Relationship");
            fields.Add("Residence");

            geographicAreas = new ObservableCollection<string>();
            geographicAreas.Add("Jerusalem");
            geographicAreas.Add("Tel Aviv");
            geographicAreas.Add("Be'er Sheva");
            geographicAreas.Add("Haifa");
            geographicAreas.Add("Eilat");
            activities = new Dictionary<string, ObservableCollection<string>>();

            ObservableCollection<string> activitiesInSport = new ObservableCollection<string>();
            activitiesInSport.Add("Playing soccer");
            activitiesInSport.Add("Playing basketball");
            activitiesInSport.Add("Ping pong");
            activities.Add("Sport", activitiesInSport);
            ObservableCollection<string> activitiesInDating = new ObservableCollection<string>();
            activitiesInDating.Add("Dating");
            activities.Add("Relationship", activitiesInDating);
            ObservableCollection<string> activitiesInResidence = new ObservableCollection<string>();
            activitiesInResidence.Add("Roomates");
            activities.Add("Residence", activitiesInResidence);
            activities.Add("None", new ObservableCollection<string>());


            startOn = new ObservableCollection<DateTime>();
            startOn.Add(new DateTime(2017, 1, 1));
            startOn.Add(new DateTime(2017, 12, 5));
            startOn.Add(new DateTime(2017, 6, 12));

            numOfParticipates = new ObservableCollection<string>();
            numOfParticipates.Add("2");
            numOfParticipates.Add("3");
            numOfParticipates.Add("4");
            numOfParticipates.Add("5");
            numOfParticipates.Add("More");

            frequency = new ObservableCollection<string>();
            frequency.Add("Weekly");
            frequency.Add("One time event");
            frequency.Add("Conitnuos");

            difficulty = new ObservableCollection<string>();
            difficulty.Add("easy");
            difficulty.Add("medium");
            difficulty.Add("hard");
            difficulty.Add("very hard");
        }

        #endregion
        #region properties
        public ObservableCollection<string> Fields
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


        public ObservableCollection<string> GeographicAreas
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

        public Dictionary<string, ObservableCollection<string>> Activities
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

        public ObservableCollection<DateTime> StartOn
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

        public ObservableCollection<string> NumOfParticipates
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

        public ObservableCollection<string> Frequency
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

        public ObservableCollection<string> Difficulty
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
