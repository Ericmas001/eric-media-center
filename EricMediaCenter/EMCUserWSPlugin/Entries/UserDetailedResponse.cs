using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace EMCUserWSPlugin.Entries
{
    public class UserDetailedResponse : UserResponse
    {
        private string m_Token;
        private DateTime m_ValidUntil;

        public string Token
        {
            get { return m_Token; }
            set { m_Token = value; }
        }

        public DateTime ValidUntil
        {
            get { return m_ValidUntil; }
            set { m_ValidUntil = value; }
        }

        public UserDetailedResponse(bool success, string message)
            : base(success, message)
        {
        }

        public UserDetailedResponse(bool success, string token, DateTime validUntil)
            : base(success, null)
        {
            m_Token = token;
            m_ValidUntil = validUntil;
        }

        public UserDetailedResponse(JObject r)
            : base(r)
        {
            //{"success":true,"token":"c6c91b11cdfed4b4b264b1e8e23f05b3","until":"2012-10-17T14:03:30"}
            //{"success":false,"problem":"User already exist"}
            if (Success)
            {
                m_Token = (string)r["token"];
                m_ValidUntil = (DateTime)r["until"];
            }
        }

        public override string ToString()
        {
            //TODO
            return base.ToString();
        }
    }
}
