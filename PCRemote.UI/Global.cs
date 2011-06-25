using System.Configuration;
using System.Windows.Forms;

namespace PCRemote.UI
{
    public class Global
    {
        public static string ConnectionString
        {
            get
            {
                var databasePath = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\") + 1) + "Database\\PCRemoteDB.db3";
                return string.Format(ConfigurationManager.ConnectionStrings["PCRemoteDB"].ConnectionString, databasePath);
            }
        }
    }
}