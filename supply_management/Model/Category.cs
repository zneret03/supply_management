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
    class Category : ConnectionSql
    {
        MySqlConnection conn;
        MySqlCommand command;
        DateTime dateNow = DateTime.Now;
        MySqlDataAdapter sda;
        DataTable dt;
        //Fetch category data
        protected BindingSource fetchCategory()
        {
            conn = new MySqlConnection(this.connection());
            String query = "SELECT * FROM category";
            conn.Open();
            sda = new MySqlDataAdapter();
            dt = new DataTable();
            sda.SelectCommand = new MySqlCommand(query, conn);
            sda.Fill(dt);

            BindingSource bind = new BindingSource();
            bind.DataSource = dt;

            return bind;
        }

        //Data Searching
        protected DataTable searchData(String search)
        {
                conn = new MySqlConnection(this.connection());
                conn.Open();
                sda = new MySqlDataAdapter("SELECT * FROM category WHERE category_name LIKE '%" + search + "%'", conn);
                dt = new DataTable();

                sda.Fill(dt);

                return dt;
        }

        //Insert category
        protected void setData(TextBox category)
        {
            try
            {
                Model.Category cat = new Model.Category();
                frmCategory categ = new frmCategory();
                conn = new MySqlConnection(this.connection());
                conn.Open();
                command = new MySqlCommand("INSERT INTO category(category_name,date_created) VALUES (@category_name, @date_created)", conn);
                command.Parameters.AddWithValue("@category_name", category.Text);
                command.Parameters.AddWithValue("@date_created", dateNow);

                int result = command.ExecuteNonQuery();
                if(result > 0)
                {
                    MessageBox.Show("Successfully Inserted", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                category.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                command.Dispose();
                conn.Close();
            }
        }

        //Update category
        protected void updateCategory(Label Id, TextBox category, addCategory suspend)
        {
            try
            {
                conn = new MySqlConnection(this.connection());
                conn.Open();
                command = new MySqlCommand("UPDATE category SET category_name=@category_name, date_updated=@date_updated WHERE category_id=@id", conn);
                command.Parameters.AddWithValue("@category_name", category.Text);
                command.Parameters.AddWithValue("@date_updated", dateNow);
                command.Parameters.AddWithValue("@id", Id.Text);

                bool result = (int)command.ExecuteNonQuery() > 0;

                if(result == true)
                {
                    MessageBox.Show("Updated Successfully","Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    suspend.Hide();
                }

                category.Clear();
                conn.Close();
                command.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Check category name should not be duplicated
        protected String isDuplicate(TextBox category)
        {
            conn = new MySqlConnection(this.connection());
            conn.Open();
            String isExist = " ";
            command = new MySqlCommand("SELECT * FROM category WHERE category_name = @category_name", conn);
            command.Parameters.AddWithValue("@category_name", category.Text);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
               while(reader.Read())
               {
                   isExist = reader.GetString(reader.GetOrdinal("category_name"));
               }
            }

            return isExist;
        }

        //Delete category
        protected void DeleteCategory(Label Id, addCategory suspend)
        {
            try
            {
                
                conn = new MySqlConnection(this.connection());
                conn.Open();
                DialogResult result = MessageBox.Show("Do you want to Delete this item", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    command = new MySqlCommand("DELETE FROM category WHERE category_id = @category_id", conn);
                    command.Parameters.AddWithValue("@category_id", Id.Text);

                    bool check = (int)command.ExecuteNonQuery() > 0;
                    if (check == true)
                    {
                        MessageBox.Show("Deleted Successfully", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        suspend.Hide();
                    }
                    conn.Close();
                    command.Dispose();
                }
                else                
                {
                    MessageBox.Show("Your data is safe", "Safe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
                
        }
    }
}
