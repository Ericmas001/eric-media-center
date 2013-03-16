using Newtonsoft.Json.Linq;

namespace EMCUserWSPlugin.Entries
{
    public class UserResponse
    {
        private bool m_Success;
        private string m_Message;

        public bool Success
        {
            get { return m_Success; }
            set { m_Success = value; }
        }

        public string Message
        {
            get { return m_Message; }
            set { m_Message = value; }
        }

        public UserResponse(bool success, string message)
        {
            m_Success = success;
            m_Message = message;
        }

        public UserResponse(JObject r)
        {
            //{"success":true}
            //{"success":false,"problem":"User already exist"}
            m_Success = (bool)r["success"];
            m_Message = m_Success ? null : (string)r["problem"];
        }

        public override string ToString()
        {
            //TODO
            return base.ToString();
        }
    }
}