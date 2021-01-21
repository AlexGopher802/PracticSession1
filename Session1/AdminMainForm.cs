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
    public partial class AdminMainForm : Form
    {
        DataClass myClass = new DataClass();

        public AdminMainForm()
        {
            InitializeComponent();
        }

        private void AdminMainForm_Load(object sender, EventArgs e)
        {
            //Загружаем список всех офисов в comboBox
            List<string> listOfices = new List<string>() { "All Offices" };
            foreach (DataRow i in myClass.getData("select Title from Offices").Tables[0].Rows)
            {
                listOfices.Add(i.ItemArray[0].ToString());
            }
            cbOffices.DataSource = listOfices;

            viewDataUsers();
            
        }

        //Отображение всех пользователей
        public void viewDataUsers()
        {
            string where = "";
            if(cbOffices.SelectedIndex != 0) { where = $"where offices.title = '{cbOffices.SelectedItem}'"; }

            string query = "select users.firstname as Name, " +
                "users.lastname as [Last Name], " +
                "DATEDIFF(YEAR,[Birthdate], GETDATE()) as Age, " +
                "roles.title as Role, " +
                "users.email as Email, " +
                "offices.title as Office," +
                "users.active as Active " +
                "from users " +
                "left join roles on users.roleid = roles.id " +
                $"left join offices on users.officeid = offices.id {where}";
            dataGridViewUsers.DataSource = myClass.getData(query).Tables[0];
            dataGridViewUsers.Columns[6].Visible = false;

            setColorRows();
        }

        void setColorRows()
        {
            foreach (DataGridViewRow i in dataGridViewUsers.Rows)
            {
                if (!(bool)i.Cells["Active"].Value)
                {
                    i.DefaultCellStyle.BackColor = Color.FromArgb(255, 0, 0);
                    i.DefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
                    continue;
                }

                if (i.Cells["Role"].Value.ToString() == "Administrator")
                {
                    i.DefaultCellStyle.BackColor = Color.FromArgb(144, 238, 144);
                    i.DefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 0);
                    continue;
                }
            }
        }

        private void AdminMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["LoginForm"].Show();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbOffices_SelectedIndexChanged(object sender, EventArgs e)
        {
            viewDataUsers();
        }

        private void addUserMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AddUsersForm().Show();
        }

        private void dataGridViewUsers_Sorted(object sender, EventArgs e)
        {
            setColorRows();
        }

        private void btnEnableDisable_Click(object sender, EventArgs e)
        {
            if(dataGridViewUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select row", "Error");
                return;
            }

            DataSet ds = myClass.getData($"select active from users where email='{dataGridViewUsers.SelectedRows[0].Cells["Email"].Value}'");
            if((bool)ds.Tables[0].Rows[0].ItemArray[0] == false)
            {
                myClass.executeQuery($"update users set active=1 where email='{dataGridViewUsers.SelectedRows[0].Cells["Email"].Value}'");
            }
            else
            {
                myClass.executeQuery($"update users set active=0 where email='{dataGridViewUsers.SelectedRows[0].Cells["Email"].Value}'");
            }
            viewDataUsers();
        }

        private void btnEditRole_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select row", "Error");
                return;
            }
            this.Hide();
            EditRoleForm editForm = new EditRoleForm();
            editForm.tbEmail.Text = dataGridViewUsers.SelectedRows[0].Cells["Email"].Value.ToString();
            editForm.tbFirstName.Text = dataGridViewUsers.SelectedRows[0].Cells["Name"].Value.ToString();
            editForm.tbLastName.Text = dataGridViewUsers.SelectedRows[0].Cells["Last name"].Value.ToString();
            editForm.tbOffice.Text = dataGridViewUsers.SelectedRows[0].Cells["Office"].Value.ToString();
            if(dataGridViewUsers.SelectedRows[0].Cells["Role"].Value.ToString() == "Administrator") { editForm.rbUser.Checked = false;  editForm.rbAdmin.Checked = true; }
            else { editForm.rbAdmin.Checked = false; editForm.rbUser.Checked = true; }
            editForm.Show();
        }
    }
}
