using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace supply_management.Model
{
    class Brand : ConnectionSql
    {
        MySqlConnection conn;
        MySqlDataAdapter sda;
        MySqlCommand command;
        DataTable dt;
        MySqlDataReader reader;
        DateTime dateNow = DateTime.Now;

        //If brand name exist throw error
        protected String isExist(TextBox text)
        {
            conn = new MySqlConnection(this.connection());
            conn.Open();
            String isDuplicate = " ";
            command = new MySqlCommand("SELECT brand_name FROM brand WHERe brand_name = @brand_name", conn);
            command.Parameters.AddWithValue("@brand_name", text.Text);
            using(reader = command.ExecuteReader())
            {
                if(reader.Read())
                {
                    isDuplicate = reader.GetString(reader.GetOrdinal("brand_name"));
                }
            }
            
            return isDuplicate;
        }

        //Search datagrid
        protected DataTable search(String text)
        {
            conn = new MySqlConnection(this.connection());
            conn.Open();
            dt = new DataTable();
            sda = new MySqlDataAdapter("SELECT * FROM brand WHERE brand_name LIKE '%" + text + "%'", conn);
            sda.Fill(dt);
           
            return dt;
        }


        //Load data to the datagridview also update
        protected BindingSource loadData()
        {
            conn = new MySqlConnection(this.connection());
            conn.Open();
            String query = "SELECT * FROM brand";
            sda = new MySqlDataAdapter();
            command = new MySqlCommand(query, conn);
            sda.SelectCommand = command;

            dt = new DataTable();
            sda.Fill(dt);

            BindingSource bind = new BindingSource();
            bind.DataSource = dt;

            return bind;
        }

        //Insert Data
        protected void insert(TextBox text)
        {
            try
            {
                conn = new MySqlConnection(this.connection());
                conn.Open();
                command = new MySqlCommand("INSERT INTO brand (brand_name, date_created) VALUES (@brand_name, @date_created)", conn);
                command.Parameters.AddWithValue("@brand_name", text.Text);
                command.Parameters.AddWithValue("@date_created", dateNow);

                bool result = (int)command.ExecuteNonQuery() > 0;

                if(result == true)
                {
                    MessageBox.Show("Brand Inserted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                text.Clear();

                conn.Close();
                command.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Update Data
        protected void update(TextBox text, Label Id, addBrand suspend)
        {
            try
            {
                conn = new MySqlConnection(this.connection());
                conn.Open();
                command = new MySqlCommand("UPDATE brand SET brand_name = @brand_name, date_updated = @date_updated WHERE brand_id = @brand_id", conn);
                command.Parameters.AddWithValue("@brand_name", text.Text);
                command.Parameters.AddWithValue("@date_updated", dateNow);
                command.Parameters.AddWithValue("@brand_id", Id.Text);

                bool result = (int)command.ExecuteNonQuery() > 0;

                if(result == true)
                {
                    MessageBox.Show("Updated Successfully", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    suspend.Hide();
                }

                text.Clear();

                conn.Close();
                command.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Delete data
        protected void Delete(Label Id, addBrand suspend)
        {
            try
            {
                conn = new MySqlConnection(this.connection());
                conn.Open();
                DialogResult result = MessageBox.Show("Do you want to Delete this data?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    command = new MySqlCommand("DELETE FROM brand WHERE brand_id = @brand_id", conn);
                    command.Parameters.AddWithValue("@brand_id", Id.Text);

                    bool isCheck = (int)command.ExecuteNonQuery() > 0;

                    if (isCheck == true)
                    {
                        MessageBox.Show("Successfully Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        suspend.Hide();
                    }

                    command.Dispose();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Your Data is safe", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
              
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
