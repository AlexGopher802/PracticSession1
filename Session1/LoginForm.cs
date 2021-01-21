using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Session1
{
    public partial class LoginForm : Form
    {
        DataClass myClass = new DataClass();
        int quantity = 0;
        int timerSec = 0;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataSet ds = myClass.getData($"select RoleID, Email, Active from Users where Email='{tbLogin.Text}' and Password='{tbPassword.Text}'");
            if (ds.Tables[0].Rows.Count == 0)
            {
                quantity++;
                if(quantity == 3)
                {
                    MessageBox.Show($"Wait 10 sec before login again", "Error");
                    lblInfo.Visible = true;
                    timer.Start();
                    formBlocked();
                    quantity = 0;
                    return;
                }
                else
                {
                    MessageBox.Show($"Login Denied, attempts left: {3 - quantity}", "Error");
                    return;
                }
                
            }

            if(!(bool)ds.Tables[0].Rows[0].ItemArray[2])
            {
                quantity = 0;
                MessageBox.Show("You has be Banned!", "Error");
                return;
            }

            if((int)ds.Tables[0].Rows[0].ItemArray[0] == 1)
            {
                quantity = 0;
                this.Hide();
                new AdminMainForm().Show();
            }
            else if((int)ds.Tables[0].Rows[0].ItemArray[0] == 2)
            {
                quantity = 0;
                string query = $"select top (1) " +
                $"convert(varchar, [logindatetime], 104) as [Date], " +
                $"convert(varchar, [logindatetime], 108) as [Login Time], " +
                $"logoutdatetime as [Logout Time], " +
                $"logoutreason as [Reason], " +
                $"id " +
                $"from tracking where userid=(select id from users where email='{tbLogin.Text}') order by id desc ";
                ds = myClass.getData(query);
                if (((ds.Tables.Count != 0) && (ds.Tables[0].Rows.Count != 0)) && ((ds.Tables[0].Rows[0].ItemArray[2].ToString() == "") &&(ds.Tables[0].Rows[0].ItemArray[3].ToString() == "")))
                {
                    this.Hide();
                    LogoutReasonForm reasonForm = new LogoutReasonForm();
                    reasonForm.lblInfo.Text = $"No logout detected for your last login on {ds.Tables[0].Rows[0].ItemArray[0]} at {ds.Tables[0].Rows[0].ItemArray[1]}";
                    reasonForm.logId = (int)ds.Tables[0].Rows[0].ItemArray[4];
                    reasonForm.Show();
                }
                else
                {
                    this.Hide();
                    UserForm user = new UserForm();
                    user.emailUser = tbLogin.Text;
                    user.Show();
                }
            }
        }

        void formBlocked()
        {
            tbLogin.Enabled = false;
            tbPassword.Enabled = false;
            btnLogin.Enabled = false;
            btnExit.Enabled = false;
        }

        void formUnBlocked()
        {
            tbLogin.Enabled = true;
            tbPassword.Enabled = true;
            btnLogin.Enabled = true;
            btnExit.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timerSec++;
            lblInfo.Text = $"Timer: {10 - timerSec}";
            if(timerSec == 10)
            {
                timerSec = 0;
                timer.Stop();
                lblInfo.Visible = false;
                formUnBlocked();
            }
        }
    }
}
