using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using EricUtility;
using EricUtility2011.Data;
using Newtonsoft.Json;

namespace EMCRestService.Services
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class UserService
    {
        private SqlServerConnector Connector = new SqlServerConnector("TURNSOL.arvixe.com", "emc", "emc.webservice", "Emc42FTW");

        [WebGet(UriTemplate = "Connect/{user}/{pass}")]
        public string Connect(string user, string pass)
        {
            string error = null;
            bool ok = false;
            SqlConnection myConnection = Connector.GetConnection();
            try
            {
                Dictionary<string, object> result = Connector.SelectOneRow(myConnection, "select * from ericmas001.TUser where username = @User", new Dictionary<string, object>() { { "User", user } });
                if (pass.Trim() == result["password"].ToString().Trim())
                    ok = true;
                if (!ok)
                    error = "User or Password is incorrect";
            }
            catch (Exception e)
            {
                error = "Read Error: " + e.ToString();
            }

            if (ok)
            {
                string t = StringUtility.GetMd5Hash(user + ";" + DateTime.Now.ToString());
                DateTime validUntil = DateTime.Now + TimeSpan.FromMinutes(5);
                Connector.Execute(myConnection, "update ericmas001.TUser set lastToken = @Token, tokenValidUntil = @Valid where username = @User", new Dictionary<string, object>() { { "Token", t }, { "Valid", validUntil }, { "User", user } });

                if (myConnection != null)
                    myConnection.Close();
                return JsonConvert.SerializeObject(new { success = ok, token = t, until = validUntil });
            }
            else
            {
                if (myConnection != null)
                    myConnection.Close();
                return JsonConvert.SerializeObject(new { success = ok, problem = error });
            }
        }


    }
}