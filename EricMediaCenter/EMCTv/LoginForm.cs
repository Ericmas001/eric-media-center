using EMCTv.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMCTv
{
    public partial class LoginForm : Form
    {
        private SessionInfo m_Session = null;

        internal SessionInfo Session
        {
            get { return m_Session; }
            set { m_Session = value; }
        }
        bool ok;
        public LoginForm()
        {
            InitializeComponent();
            Settings s = Properties.Settings.Default;
            if (s.login_Remember)
            {
                txtUser.Text = s.login_User;
                txtPass.Text = s.login_Pass;
                chkRemember.Checked = true;
                chkConnect.Checked = s.login_Automatic;
            }
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtUser.Text) || String.IsNullOrWhiteSpace(txtUser.Text))
                return;
            EnableAll(false);
            m_Session = new SessionInfo(txtUser.Text, txtPass.Text);
            ok = await m_Session.Connect();
            if (ok)
            {
                Settings s = Properties.Settings.Default;
                if (chkRemember.Checked)
                {
                    s.login_Automatic = chkConnect.Checked;
                    s.login_Pass = txtPass.Text;
                    s.login_Remember = true;
                    s.login_User = txtUser.Text;
                }
                else
                {
                    s.login_Automatic = false;
                    s.login_Pass = "";
                    s.login_Remember = false;
                    s.login_User = "";
                }
                s.Save();
                Close();
            }
            else
                EnableAll(true);
        }

        private void EnableAll(bool p)
        {
            pictureBox1.Visible = !p;
            txtUser.Enabled = p;
            txtPass.Enabled = p;
            chkConnect.Enabled = p?chkRemember.Checked:p;
            chkRemember.Enabled = p;
            btnConnect.Enabled = p;
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ok)
                DialogResult = System.Windows.Forms.DialogResult.OK;
            else
            {
                m_Session = null;
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnConnect_Click(sender, e);
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnConnect_Click(sender, e);
            }
        }

        private void chkRemember_CheckedChanged(object sender, EventArgs e)
        {
            chkConnect.Enabled = chkRemember.Checked;
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                Close();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.login_Automatic)
                btnConnect_Click(sender, e);
        }
    }
}
