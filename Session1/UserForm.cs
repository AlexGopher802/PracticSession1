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
    public partial class UserForm : Form
    {
        DataClass myClass = new DataClass();
        public string emailUser = "";

        public UserForm()
        {
            InitializeComponent();
        }

        void viewDataTracking()
        {
            string query = "select " +
                "convert(varchar, [logindatetime], 104) as [Date], " +
                "convert(varchar, [logindatetime], 108) as [Login Time], " +
                "logoutdatetime as [Logout Time], " +
                "timeinsystem as [Time in System], " +
                "logoutreason as [Logout Reason], " +
                "userid as [User] " +
                "from tracking " +
                $"where userid=(select id from users where email='{emailUser}') ";
            DataSet ds = myClass.getData(query);
            if (ds.Tables.Count == 0) { MessageBox.Show("Query return 0n tablees", "Error"); return; }
            if (ds.Tables[0].Rows.Count == 0)
            {
                query = $"insert into tracking(logindatetime, userid) values " +
                $"('{DateTime.Now}', (select id from users where email='{emailUser}'))";
                myClass.executeQuery(query);
            }
            else
            {
                dataGridViewActive.DataSource = ds.Tables[0];
                dataGridViewActive.Columns[5].Visible = false;
                query = $"insert into tracking(logindatetime, userid) values " +
                $"('{DateTime.Now}', (select id from users where email='{emailUser}'))";
                myClass.executeQuery(query);
                viewActiveInfo();
            }
        }

        void viewActiveInfo()
        {
            TimeSpan allSeconds = new TimeSpan();
            int crashes = 0;
            foreach(DataGridViewRow i in dataGridViewActive.Rows)
            {
                if(i.Cells["Logout Time"].Value.ToString() == "")
                {
                    i.DefaultCellStyle.BackColor = Color.FromArgb(255, 0, 0);
                    i.DefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
                    crashes++;
                }
                else
                {
                    allSeconds = allSeconds.Add(TimeSpan.Parse(i.Cells["Time in System"].Value.ToString()));
                }
            }
            lblTimeInSystem.Text = $"{lblTimeInSystem.Text}: {allSeconds}s";
            lblCrashes.Text = $"{lblCrashes.Text}: {crashes}";
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            viewDataTracking();
        }

        private void UserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["LoginForm"].Show();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            myClass.executeQuery($"update top(1) tracking set LogoutDateTime = '{DateTime.Now}' where id = (select top(1) id from tracking where userid = (select id from users where email = '{emailUser}') order by id desc)");
            DataSet ds = myClass.getData($"select DATEDIFF(SS, [LoginDateTime], [LogoutDateTime]) from tracking where id = (select top (1) id from tracking where userid=(select id from users where email='{emailUser}') order by id desc)");
            TimeSpan ts = TimeSpan.FromSeconds((int)ds.Tables[0].Rows[0].ItemArray[0]);
            myClass.executeQuery($"update top (1) tracking set TimeInSystem='{ts}' where id = (select top (1) id from tracking where userid=(select id from users where email='{emailUser}') order by id desc)");
        }
    }
}
