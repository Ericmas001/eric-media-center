﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EricUtility;

namespace WatchSeriesAppPlugin
{
    public partial class LoginPanel : UserControl
    {
        public event EventHandler<KeyEventArgs<UserInfo>> UserLoggedIn = delegate { };
        public LoginPanel()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string u = txtUser.Text;
            string p = txtPassword.Text;
            UserInfo usr = new UserInfo(u, p);
            if (usr.Connect())
            {
                //MessageBox.Show(usr.Token + " until " + usr.ValidUntil.ToLocalTime());
                //if (usr.GetFavs())
                //{
                //    MessageBox.Show(String.Join(Environment.NewLine, usr.Favorites.Values.Select(q=>q.ToString()).ToArray()));
                //}
                //else
                //{
                //    MessageBox.Show(usr.LastMessage);
                //}
                UserLoggedIn(this, new KeyEventArgs<UserInfo>(usr));
            }
            else
            {
                MessageBox.Show(usr.LastMessage);
                txtPassword.Text = "";
                FocusOn(txtUser);
            }
        }

        private void LoginPanel_Load(object sender, EventArgs e)
        {
            FocusOn(txtUser);
        }

        private void FocusOn(TextBox txt)
        {
            txt.Focus();
            txt.SelectAll();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConnect_Click(sender, e);
                e.Handled = true;
            }
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            UserLoggedIn(this, new KeyEventArgs<UserInfo>(null));
        }
    }
}
