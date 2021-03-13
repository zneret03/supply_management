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

namespace supply_management.Model
{
    class Users : ConnectionSql 
    {
        MySqlConnection conn;
        MySqlCommand command;
        String con;
        MySqlDataReader reader;
        DateTime now = DateTime.Now;

        protected MySqlDataReader returnData(String username)
        {
            conn = new MySqlConnection(this.connection());
            conn.Open();
            using(command = new MySqlCommand("SELECT * FROM users WHERE username = '" + username + "'", conn))
            {
                reader = command.ExecuteReader();
            }

            return reader;
        }

        protected void DeleteCashier(String id, frmEmployeeReg clear)
        {
            try
            {
                DialogResult check = MessageBox.Show("Delete this account?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                conn = new MySqlConnection(this.connection());
                conn.Open();

                if(check == DialogResult.Yes)
                {
                    using (command = new MySqlCommand("DELETE FROM users WHERE user_id = '" + id + "'", conn))
                    {
                        bool checkResult = (int)command.ExecuteNonQuery() > 0;

                        if (checkResult == true)
                        {
                            MessageBox.Show("Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clear.clearTheWay();
                        }
                    }
                    return;
                }
              
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Login Credentials
        protected void userLogin(String username, String password, Form1 suspend)
        {
            try
            {
                con = this.connection();

                conn = new MySqlConnection(con);
                conn.Open();

                command = new MySqlCommand("SELECT * FROM users WHERE username = @username AND password = @password", conn);

                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);


                MySqlDataAdapter sda = new MySqlDataAdapter();
                DataTable dt = new DataTable();
                command.ExecuteNonQuery();
                sda.SelectCommand = command;
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    String usertype = dt.Rows[0][9].ToString();
                    if(usertype == "Admin")
                    {
                        MessageBox.Show("Successfully Login " + username.ToUpper(), "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Main main = new Main(suspend);
                        suspend.Hide();
                        main.Show();
                    }
                    else
                    {
                        MessageBox.Show("Successfully Login " + username.ToUpper(), "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmPOS pos = new frmPOS(username);
                        pos.Show();
                        pos.Logout.Show();
                        suspend.Hide();
                        
                    }
                }
                else
                {
                    MessageBox.Show("Account is not yet registered please register first", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                command.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Check user if exist
        protected String ifExist(TextBox[] cred)
        {
            conn = new MySqlConnection(this.connection());
            conn.Open();
            String username = " ";
            command = new MySqlCommand("SELECT * FROM users WHERE username=@username", conn);
            command.Parameters.AddWithValue("@username", cred[0].Text);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    username = reader.GetString(reader.GetOrdinal("username"));
                }

            }
            return username;
        }

        //Delete user from table
        protected void Delete(String id, Form1 frm, Main main)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you want to Delete this data?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                conn = new MySqlConnection(this.connection());
                if (result == DialogResult.Yes)
                {
                    conn.Open();
                    command = new MySqlCommand("DELETE FROM users WHERE user_id = @user_id", conn);
                    command.Parameters.AddWithValue("@user_id", id);

                    bool isConfirm = (int)command.ExecuteNonQuery() > 0;

                    if (isConfirm == true)
                    {
                        MessageBox.Show("Data deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if(MessageBox.Show("You are no longer access to this account","Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            main.Hide();
                            frm.username.Text = "";
                            frm.password.Text = "";
                            frm.Show();
                        }
                    }
                   
                    command.Dispose();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Your data is safe");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Get Employee Credentials
        protected void EmpCredential(String Id, TextBox[] cred, ComboBox[] options)
        {
           try
           {
                   Model.Users use = new Model.Users();
                   //Register reg = new Register();

                   conn = new MySqlConnection(this.connection());
                   conn.Open();
                   command = new MySqlCommand("INSERT INTO users (user_id, username, password, fname, mname, lname, address, age, gender, usertype, date_created) VALUES (@Id,@username,@password,@fname,@mname,@lname,@address,@age,@gender,@usertype,@date_created)", conn);
                   command.Parameters.AddWithValue("@Id", Id);
                   command.Parameters.AddWithValue("@username", cred[0].Text);
                   command.Parameters.AddWithValue("@password", cred[1].Text);
                   command.Parameters.AddWithValue("@fname", cred[2].Text);
                   command.Parameters.AddWithValue("@mname", cred[3].Text);
                   command.Parameters.AddWithValue("@lname", cred[4].Text);
                   command.Parameters.AddWithValue("@address", cred[5].Text);
                   command.Parameters.AddWithValue("@age", cred[6].Text);
                   command.Parameters.AddWithValue("@gender", options[0].SelectedItem.ToString());
                   command.Parameters.AddWithValue("@usertype", options[1].SelectedItem.ToString());
                   command.Parameters.AddWithValue("@date_created", now);

                   if (command.ExecuteNonQuery() > 0)
                   {
                       MessageBox.Show("Successfully Created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       //Load Data From database
                   }

                   foreach (TextBox txt in cred)
                   {
                       txt.Clear();
                   }

                   foreach (ComboBox combo in options)
                   {
                       combo.SelectedIndex = 0;
                   }

                   //reg.dataGridView1.DataSource = use.loadData();
                   command.Dispose();
                   conn.Close();
           }
            catch(Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
        }

        //Change Password
        protected String getPassword(String username)
        {
                String password = "";
                conn = new MySqlConnection(this.connection());
                conn.Open();
                using(command = new MySqlCommand("SELECT * FROM users WHERE username = @user",conn))
                {
                    command.Parameters.AddWithValue("@user", username);
                    reader = command.ExecuteReader();
                    reader.Read();
                    if(reader.HasRows)
                    {
                        password = reader["password"].ToString();
                    }
                }
                conn.Close();
                return password;
        }

        protected void ChangePassword(String username, String password)
        {
            try
            {
                conn = new MySqlConnection(this.connection());
                conn.Open();
                using(command = new MySqlCommand("UPDATE users SET password = @password WHERE username = @username", conn))
                {
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@username", username);

                    bool checkResult = (int)command.ExecuteNonQuery() > 0;

                    if(checkResult == true)
                    {
                        MessageBox.Show("Your password change successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }

                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Change Password

        //Load Data From specific Table
        protected BindingSource loadData()
        {
                 conn = new MySqlConnection(this.connection());
                 DataTable dt = new DataTable();
                 MySqlDataAdapter sda = new MySqlDataAdapter();
                 String query = "SELECT * FROM users";
                 sda.SelectCommand = new MySqlCommand(query, conn);
                 sda.Fill(dt);

                 BindingSource bind = new BindingSource();
                 bind.DataSource = dt;
                
                 return bind;
        }

    }
}
