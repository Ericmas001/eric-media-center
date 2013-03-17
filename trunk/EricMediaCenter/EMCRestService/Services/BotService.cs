using EMCRestService.TvWebsites.Entities;
using EricUtility2011.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace EMCRestService.Services
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class BotService
    {
        private SqlServerConnector Connector = new SqlServerConnector("TURNSOL.arvixe.com", "emc2", "emc.webservice", "Emc42FTW");

        [WebGet(UriTemplate = "TvUpdate")]
        public string TvUpdate()
        {

            SqlConnection myConnection = Connector.GetConnection();
            try
            {
                using (SqlCommand cmdAll = new SqlCommand("ericmas001.SPTvAllShows", myConnection))
                {
                    cmdAll.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sdr = cmdAll.ExecuteReader();
                    TvService tv = new TvService();
                    List<object> changes = new List<object>();
                    while (sdr.Read())
                    {
                        string website = (string)sdr["website"];
                        string name = (string)sdr["showname"];
                        string title = (string)sdr["showtitle"];
                        int lastS = (int)sdr["lastSeason"];
                        int lastE = (int)sdr["lastEpisode"];

                        string res = tv.Show(website, name);
                        if (res == null)
                        {
                            changes.Add(new { showname = name, website = website,  info = "Show not found" });
                            continue;
                        }

                        TvShow show = JsonConvert.DeserializeObject<TvShow>(res);
                        if (lastS == show.NoLastSeason && lastE == show.NoLastEpisode)
                        {
                            changes.Add(new { showname = name, website = website, info = "Already Up to Date" });
                            continue;
                        }
                        try
                        {
                            using (SqlCommand cmdUpdade = new SqlCommand("ericmas001.SPTvLastEpisode", myConnection))
                            {
                                cmdUpdade.CommandType = CommandType.StoredProcedure;

                                cmdUpdade.Parameters.Add("@website", SqlDbType.VarChar, 50);
                                cmdUpdade.Parameters.Add("@name", SqlDbType.VarChar, 50);
                                cmdUpdade.Parameters.Add("@lastSeason", SqlDbType.Int);
                                cmdUpdade.Parameters.Add("@lastEpisode", SqlDbType.Int);
                                cmdUpdade.Parameters.Add("@ok", SqlDbType.Bit).Direction = ParameterDirection.Output;
                                cmdUpdade.Parameters.Add("@info", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                                cmdUpdade.Parameters["@website"].Value = website;
                                cmdUpdade.Parameters["@name"].Value = name;
                                cmdUpdade.Parameters["@lastSeason"].Value = show.NoLastSeason;
                                cmdUpdade.Parameters["@lastEpisode"].Value = show.NoLastEpisode;

                                cmdUpdade.ExecuteNonQuery();

                                changes.Add(new { showname = name, website = website, info = (String)cmdUpdade.Parameters["@info"].Value });
                            }
                        }
                        catch (Exception e)
                        {
                            if (myConnection != null)
                                myConnection.Close();
                            return JsonConvert.SerializeObject(new { success = false, problem = e.ToString() });
                        }
                    }
                    sdr.Close();
                    if (myConnection != null)
                        myConnection.Close();
                    return JsonConvert.SerializeObject(new { success = true, log = changes });
                }
            }
            catch (Exception e)
            {
                if (myConnection != null)
                    myConnection.Close();
                return JsonConvert.SerializeObject(new { success = false, problem = e.ToString() });
            }
        }
    }
}