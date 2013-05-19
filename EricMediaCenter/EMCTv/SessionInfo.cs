using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMCTv
{
    public class SessionInfo
    {
        private string m_User;
        private string m_Password;
        private string m_Token;
        private DateTime m_Until;

        public string User
        {
            get { return m_User; }
            set { m_User = value; }
        }

        public string Password
        {
            get { return m_Password; }
            set { m_Password = value; }
        }

        public SessionInfo(string user, string pass)
        {
            m_User = user;
            m_Password = pass;
        }

        public async Task<bool> Connect()
        {
            var user = await WSUtility.CallWS<UserDetailedResponse>("user", "connect", m_User, m_Password);
            if (user.Success)
            {
                m_Token = user.Token;
                m_Until = user.Until;
            }
            return user.Success;
        }
    }
}
