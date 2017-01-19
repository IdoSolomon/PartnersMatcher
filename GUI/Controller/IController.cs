using GUI.classes;
using GUI.Model;
using GUI.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Controller
{
    public interface IController
    {
        void SetModel(IModel model);
        void SetView(IView view);

        void SetUser(string login);

        Boolean IsConnected();

        void SetConnected(Boolean mode);

        Boolean dbConnect();

        void dbClose();

        Boolean InsertToUserTable(params string[] data);

        string RetrieveUserLogin(string email);

        DataSet Search(string geographicArea, string field);

        DataSet AdvSearch(Activity criteria);

        Boolean emailExists(string email);

        ObservableCollection<string> GetFields();

        ObservableCollection<string> GetGeographicAreas();

        Dictionary<string, ObservableCollection<string>> GetActivities();

        ObservableCollection<string> GetGenders();

        ObservableCollection<DateTime> GetStartOn();

        ObservableCollection<string> GetNumOfParticipates();

        ObservableCollection<string> GetFrequency();

        ObservableCollection<string> GetDifficulty();

        Boolean ValidateUser(string user, string pass);

        Boolean emailCheck(string email);

        Boolean SendRegistrationMail(string target, string pass);

        Boolean CreateNewActivity(Activity activity);

        Boolean FiledExist(string field);

        Boolean CreateNewField(string field);
    }
}
