using Newtonsoft.Json.Linq;

namespace EMCTv
{
    public class UserResponse
    {
        private bool m_Success;
        private string m_Problem;

        public bool Success
        {
            get { return m_Success; }
            set { m_Success = value; }
        }

        public string Problem
        {
            get { return m_Problem; }
            set { m_Problem = value; }
        }

        public UserResponse(bool success, string message)
        {
            m_Success = success;
            m_Problem = message;
        }
        public UserResponse()
        {
        }

        public UserResponse(JObject r)
        {
            //{"success":true}
            //{"success":false,"problem":"User already exist"}
            m_Success = (bool)r["success"];
            m_Problem = m_Success ? null : (string)r["problem"];
        }

        public override string ToString()
        {
            //TODO
            return base.ToString();
        }
    }
}