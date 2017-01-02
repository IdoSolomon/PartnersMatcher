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
        private string user = "dbpd2016@gmail.com";
        public OleDbConnection connection;
        
        #region email settings
        private string sender = "dbpd2016@gmail.com";
        private string sender_pass = "ISSE2016";
        private string smtp = "smtp.gmail.com";
        private int port = 587;
        private string target = "dbpd2016@gmail.com";
        #endregion




        public PartnersMatcherModel()
        {
            InitStructures();
        }

        #region db

        /// <summary>
        /// Requires the "Microsoft Access Database Engine 2010 Redistributable"
        /// </summary>
        public Boolean dbConnect()
        {
            connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|DB\PartnersMatcher.accdb;
Persist Security Info=False;";
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

        public OleDbDataAdapter InsertToUserTable()
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command;

            //Create the InsertCommand.
            command = new OleDbCommand(
                "INSERT INTO Users (Email, FirstName, LastName, Passward, BirthDate, Sex, PhoneNumber, Location, Smokes, Pet, Resume) " +
                "VALUES (@Email, @FirstName, @LastName, @Passward, @BirthDate, @Sex, @PhoneNumber, @Location, @Smokes, @Pet, @Resume)");

            command.Parameters.Add("Email", OleDbType.Char, 255, "Email");
            command.Parameters.Add("First Name", OleDbType.VarChar, 255, "First Name");
            command.Parameters.Add("Last Name", OleDbType.VarChar, 255, "Last Name");
            command.Parameters.Add("Passward", OleDbType.VarChar, 255, "Passward");
            command.Parameters.Add("Birth Date", OleDbType.VarChar, 255, "Birth Date");
            command.Parameters.Add("Sex", OleDbType.VarChar, 1, "Sex");
            command.Parameters.Add("Phone Number", OleDbType.VarChar, 10, "Phone Number");
            command.Parameters.Add("Location", OleDbType.VarChar, 255, "Location");
            command.Parameters.Add("Smokes", OleDbType.Binary, 1, "Smokes");
            command.Parameters.Add("Pet", OleDbType.Binary, 1, "Pet");
            command.Parameters.Add("Resume", OleDbType.Char, 255, "Resume");
            adapter.InsertCommand = command;
            return adapter;
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
            geographicAreas.Add("Beer Sheva");
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
            if (user == "guest" && pass == "guest")
                return true;
            return false;
        }

        public Boolean SendRegistrationMail()
        {
           // new Thread(() =>
            //{
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
                mail.Body = "Your PartnersMatcher™ account, " + user + ", has been created and is ready to use." + System.Environment.NewLine + System.Environment.NewLine + "You may now sign in to PartnersMatcher™ using your new account.";


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
            //}).Start();
        }


        /// <summary>
        /// the function serch in the database for a match activity
        /// </summary>
        /// <param name="geographicArea"></param>
        /// <param name="field"></param>
        /// <returns>returns a set of matches activities    SHOULD CHANGE THE RETURN VALUE TYPE!!</returns>
        public bool Search(string geographicArea, string field)
        {
            throw new NotImplementedException();
        }
    }

}
