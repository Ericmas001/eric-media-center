using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json;
using EricUtility.Networking.Gathering;
using EricUtility;
using EricUtility2011;
using System.Globalization;
using System.Data.SqlClient;

namespace EMCRestService.Services
{
    // user emc.webservice ... pass Emc42FTW
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class UserService
    {
        [WebGet(UriTemplate = "Connect/{user}/{pass}")]
        public string Connect(string user, string pass)
        {
            bool ok = false;

            SqlConnection myConnection = new SqlConnection("user id=emc.webservice;" +
                                       "password=Emc42FTW;server=TURNSOL.arvixe.com;" +
                                       "Trusted_Connection=no;" +
                                       "database=emc; " +
                                       "connection timeout=30");
            try
            {
                myConnection.Open();
            }
            catch (Exception e)
            {
                return "Connection Error: " + e.ToString();
            }


            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("select * from ericmas001.TUser where username = '" + user + "'",
                                                         myConnection);
                myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                    if (pass.Trim() == myReader["password"].ToString().Trim())
                        ok = true;

                myReader.Close();
            }
            catch (Exception e)
            {
                return "Read Error: " + e.ToString();
            }

            return JsonConvert.SerializeObject(new { success = ok });
        }
    }
}