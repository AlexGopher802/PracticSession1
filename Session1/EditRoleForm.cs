using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session1
{
    public partial class EditRoleForm : Form
    {
        DataClass myClass = new DataClass();

        public EditRoleForm()
        {
            InitializeComponent();
        }

        private void EditRoleForm_Load(object sender, EventArgs e)
        {
            
        }

        private void EditRoleForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AdminMainForm admin = new AdminMainForm();
            admin.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminMainForm admin = new AdminMainForm();
            admin.Show();
        }

        private void btnApplyUser_Click(object sender, EventArgs e)
        {
            if (rbAdmin.Checked)
            {
                myClass.executeQuery($"update users set roleid = 1 where email='{tbEmail.Text}'");
            }
            else
            {
                myClass.executeQuery($"update users set roleid = 2 where email='{tbEmail.Text}'");
            }
            this.Hide();
            AdminMainForm admin = new AdminMainForm();
            admin.Show();
        }
    }
}
