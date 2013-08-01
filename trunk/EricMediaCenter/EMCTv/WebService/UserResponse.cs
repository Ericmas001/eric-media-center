using Newtonsoft.Json.Linq;
using System;

namespace EMCTv.WebService
{
    public class UserResponse
    {
        private bool m_Success;
        private string m_Problem;
        private string m_Token;
        private DateTime m_Until;

        public string Token
        {
            get { return m_Token; }
            set { m_Token = value; }
        }

        public DateTime Until
        {
            get { return m_Until; }
            set { m_Until = value; }
        }

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
    }
}