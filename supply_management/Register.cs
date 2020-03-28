using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace supply_management
{
    public partial class Register : Form
    {
 
        //Model.ConnectionSql consql = new Model.ConnectionSql();
        Controller.userAccount user = new Controller.userAccount();
        public Register()
        {
            InitializeComponent();
            
        }

        private void Register_Load(object sender, EventArgs e)
        {
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(54, 54, 54);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            getData();
            
        }

        public void getData()
        {
            try
            {
                dataGridView1.DataSource = user.loadDataView();

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Columns[i].Width = 150;
                }

                dataGridView1.Columns[0].HeaderText = "#";
                dataGridView1.Columns[1].HeaderText = "Username";
                dataGridView1.Columns[2].HeaderText = "Password";
                dataGridView1.Columns[3].HeaderText = "Firstname";
                dataGridView1.Columns[4].HeaderText = "Middlename";                                 
                dataGridView1.Columns[5].HeaderText = "Lastname";
                dataGridView1.Columns[6].HeaderText = "Address";
                dataGridView1.Columns[7].HeaderText = "Age";
                dataGridView1.Columns[8].HeaderText = "Gender";
                dataGridView1.Columns[9].HeaderText = "Usertype";
                dataGridView1.Columns[10].HeaderText = "Date Created";
                dataGridView1.Columns[11].HeaderText = "Date Updated";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearch_OnTextChange(object sender, EventArgs e)
        {
          
            String query = "SELECT " +
                "user_id,username,fname,mname,lname,address,age,gender,usertype,date_created,date_updated FROM users WHERE " +
            "username LIKE '%" + txtSearch.text + "%' OR fname LIKE '%" + txtSearch.text + "%'";
            dataGridView1.DataSource = user.search(query);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EmployeeReg emp = new EmployeeReg(this);
            if(e.RowIndex >= 0)
            {
               DataGridViewRow dt = this.dataGridView1.Rows[e.RowIndex];
               emp.Id.Text = dt.Cells[0].Value.ToString();
               emp.username.Text = dt.Cells[1].Value.ToString();
               emp.password.Text = dt.Cells[2].Value.ToString();
               emp.firstname.Text = dt.Cells[3].Value.ToString();
               emp.middlename.Text = dt.Cells[4].Value.ToString();
               emp.Lastname.Text = dt.Cells[5].Value.ToString();
               emp.address.Text = dt.Cells[6].Value.ToString();
               emp.age.Text = dt.Cells[7].Value.ToString();
               emp.Gender.SelectedItem = dt.Cells[8].Value.ToString();
               emp.usertype.SelectedItem = dt.Cells[9].Value.ToString();

               //emp.Gender.SelectedIndex = emp.Gender.Items.Count - 1;
               //emp.usertype.SelectedIndex = emp.usertype.Items.Count - 1;
               
               emp.btnUpdate.Enabled = true;
               emp.submit.Enabled = false;
               emp.checkedDelete.Show();
               emp.delete.Show();
               //emp.password.Enabled = false;
               emp.IdLabel.Show();
               emp.Show();
            }
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            EmployeeReg reg = new EmployeeReg(this);
            reg.Show();
            reg.btnUpdate.Enabled = false;
            reg.IdLabel.Hide();
            reg.checkedDelete.Hide();
            reg.delete.Hide();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = user.loadDataView();
        }
    }
}
