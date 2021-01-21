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
    public partial class LogoutReasonForm : Form
    {
        DataClass myClass = new DataClass();
        public int logId = 0;

        public LogoutReasonForm()
        {
            InitializeComponent();
        }

        bool validForm()
        {
            if((rtbReason.Text != "") && ((rbSoftware.Checked) || (rbSystem.Checked)))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Please, Write all fields", "Error");
                return false;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!validForm()) { return; }
            string crashReport = "";
            if (rbSoftware.Checked) { crashReport = rbSoftware.Text + ": "; }
            else { crashReport = rbSystem.Text + ": "; }
            crashReport += rtbReason.Text;
            myClass.executeQuery($"update tracking set logoutreason='{crashReport}' where id={logId}");
            
            this.Hide();
            UserForm user = new UserForm();
            DataSet ds = myClass.getData($"select users.email from tracking left join users on tracking.userid = users.id where tracking.id={logId}");
            user.emailUser = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            user.Show();
        }

        private void LogoutReasonForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            MessageBox.Show("Please, Write all fields", "Error");
        }
    }
}
