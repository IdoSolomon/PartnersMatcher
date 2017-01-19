using GUI.classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Model
{
    public interface IModel
    {
        Boolean dbConnect();

        Boolean IsConnected();

        void SetUser(string login);

        void SetConnected(Boolean mode);

        void dbClose();

        Boolean InsertToUserTable(params string[] data);

        string RetrieveUserLogin(string email);

        DataSet Search(string geographicArea, string field);

        DataSet AdvSearch(Activity criteria);

        Boolean emailExists(string email);

        ObservableCollection<string> GetFields();

        ObservableCollection<string> GetGeographicAreas();

        ObservableCollection<string> GetGenders();

        Dictionary<string, ObservableCollection<string>> GetActivities();

        ObservableCollection<DateTime> GetStartOn();

        ObservableCollection<string> GetNumOfParticipates();

        ObservableCollection<string> GetFrequency();

        ObservableCollection<string> GetDifficulty();

        Boolean ValidateUser(string user, string pass);

        Boolean emailCheck(string email);

        Boolean SendRegistrationMail(string target, string pass);

        Boolean CreateNewActivity(Activity activity);
    }
}
