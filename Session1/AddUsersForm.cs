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
    public partial class AddUsersForm : Form
    {
        DataClass myClass = new DataClass();

        public AddUsersForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddUsersForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AdminMainForm admin = (AdminMainForm)Application.OpenForms["AdminMainForm"];
            admin.viewDataUsers();
            admin.Show();
        }

        private void AddUsersForm_Load(object sender, EventArgs e)
        {
            //Загружаем список всех офисов в comboBox
            List<string> listOfices = new List<string>();
            foreach (DataRow i in myClass.getData("select Title from Offices").Tables[0].Rows)
            {
                listOfices.Add(i.ItemArray[0].ToString());
            }
            cbOffices.DataSource = listOfices;
        }

        bool validForm()
        {
            if((tbEmail.Text != "") && (tbFirstName.Text != "") && (tbLastName.Text != "") && (tbPassword.Text != "") && (cbOffices.SelectedItem != null))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Please, write all fields", "Error");
                return false;
            }
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            if (!validForm()) { return; }
            string query = $"insert into users(RoleID, Email, Password, FirstName, LastName, OfficeID, Birthdate, Active) values " +
                $"(2, '{tbEmail.Text}', '{tbPassword.Text}', '{tbFirstName.Text}', '{tbLastName.Text}', " +
                $"(select id from offices where title='{cbOffices.SelectedItem}'), " +
                $"'{dateTimePicker.Value.ToString("yyyy-MM-dd")}', 1) ";
            try
            {
                myClass.executeQuery(query);
                this.Close();
            }
            catch(Exception excep)
            {
                MessageBox.Show(excep.Message, "Error");
            }
        }
    }
}
