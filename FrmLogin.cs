using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SMS.Bll;
using SMS.Dao;
using SMS.Utils;

namespace SMS
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text.Equals("") || txtPassword.Text.Equals(""))
                {
                    MessageBox.Show("Fields are required", "SMS", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                else
                {
                   User u = new User();
                   u.Username = txtUsername.Text;
                   u.Password = txtPassword.Text;
                   UserDao ud = new UserDao();
                   DataTable dt = ud.CheckUser(u);

                    if(dt.Rows.Count > 0)
                    {
                        Gc.username = txtUsername.Text;
                        Gc.password = txtPassword.Text;
                        Gc.role = dt.Rows[0]["Role"].ToString();
                        this.Hide();
                        FrmMain fm = new FrmMain();
                        fm.Show();
                    }


                }
            }
            catch  (Exception ex)
            {
                MessageBox.Show(ex.Message, "SMS Error");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
