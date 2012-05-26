﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json;

namespace EMCRestService
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class TimeService
    {
        [WebGet(UriTemplate = "CurrentTime")]
        public string CurrentTime()
        {
            //return DateTime.Now.ToString();
            return JsonConvert.SerializeObject(new { value = DateTime.Now.ToString() });
        }
    }
}