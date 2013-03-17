using EricUtility;
using EricUtility2011.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace EMCRestService.Services
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class UsersService
    {
        private SqlServerConnector Connector = new SqlServerConnector("TURNSOL.arvixe.com", "emc2", "emc.webservice", "Emc42FTW");

        [WebGet(UriTemplate = "Connect/{user}/{pass}")]
        public string Connect(string user, string pass)
        {
            SqlConnection myConnection = Connector.GetConnection();
            bool ok = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand("ericmas001.SPUserConnect", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@username", SqlDbType.VarChar, 50);
                    cmd.Parameters.Add("@password", SqlDbType.VarChar, 50);
                    cmd.Parameters.Add("@ok", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@info", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@validUntil", SqlDbType.DateTimeOffset).Direction = ParameterDirection.Output;

                    cmd.Parameters["@username"].Value = user;
                    cmd.Parameters["@password"].Value = pass;

                    cmd.ExecuteNonQuery();

                    ok = Convert.ToBoolean(cmd.Parameters["@ok"].Value);
                    if (ok)
                    {
                        DateTimeOffset d = (DateTimeOffset)cmd.Parameters["@validUntil"].Value;
                        string t = (String)cmd.Parameters["@info"].Value;
                        myConnection.Close();
                        return JsonConvert.SerializeObject(new { success = ok, token = t, until = d }, new IsoDateTimeConverter());
                    }
                    else
                    {
                        string e = (String)cmd.Parameters["@info"].Value;
                        myConnection.Close();
                        return JsonConvert.SerializeObject(new { success = ok, problem = e });
                    }
                }
            }
            catch (Exception e)
            {
                if (myConnection != null)
                    myConnection.Close();
                return JsonConvert.SerializeObject(new { success = ok, problem = e.ToString() });
            }
        }
    }
}