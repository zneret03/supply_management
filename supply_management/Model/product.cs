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
 
    class product : ConnectionSql
    {
        MySqlConnection conn;
        MySqlDataAdapter sda;
        MySqlDataReader reader;
        DataTable dt;
        MySqlCommand command;
        BindingSource bind;
        DateTime dateNow = DateTime.Now;

        string brandid;
        string categoryid;
        /// <summary>
        /// It returns the value of a table brand to how data
        /// </summary>
        /// <returns>bind</returns>
        protected BindingSource loadTable()
        {
            String query = "SELECT products_id,barcode, product_name, category_name, brand_name, description, quantity, price, reorder, capital, gain, percentage, product.date_created, product.date_updated " +
            "FROM product INNER JOIN category ON category.category_id = product.category_id INNER JOIN brand ON brand.brand_id = product.brand_id";
            conn = new MySqlConnection(this.connection());
            conn.Open();
            dt = new DataTable();
            sda = new MySqlDataAdapter(query, conn);
            sda.Fill(dt);
            bind = new BindingSource();
            bind.DataSource = dt;

            return bind;
        }

        protected object countProducts()
        {
            conn = new MySqlConnection(this.connection());
            conn.Open();
            object count;

            using(command = new MySqlCommand("SELECt count(*) FROM product", conn))
            {
                count = command.ExecuteScalar();
            }

            return count;
           
        }

        protected String isExist(TextBox[] productname)
        {
            conn = new MySqlConnection(this.connection());
            conn.Open();
            String product_name = " ";
            command = new MySqlCommand("SELECT * FROM product WHERE product_name = @name", conn);
            command.Parameters.AddWithValue("@name", productname[0].Text);
            using(reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    product_name = reader.GetString(reader.GetOrdinal("product_name"));
                }
                
            }

            return product_name;
        }

        /// <summary>
        /// Search Data to data Grid
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        protected DataTable search(String search)
        {
            conn = new MySqlConnection(this.connection());
            conn.Open();
            sda = new MySqlDataAdapter("SELECT products_id,barcode, product_name, category_name, brand_name, description, quantity, price, capital, gain, product.date_created, product.date_updated FROM product INNER JOIN category ON category.category_id = product.category_id INNER JOIN brand ON brand.brand_id = product.brand_id WHERE product_name LIKE '%" + search + "%' OR products_id LIKE '%" + search +"%'", conn);
            dt = new DataTable();
            sda.Fill(dt);

            return dt;
        }

        /// <summary>
        /// Returning Category name and removing duplicated if exist
        /// </summary>
        /// <param name="combo"></param>
        /// <returns></returns>
        protected void loadCategory(ComboBox category)
        {
            conn = new MySqlConnection(this.connection());
            conn.Open();
            
            command = new MySqlCommand("SELECT DISTINCT * FROM category", conn);
            using(reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    category.Items.Add(reader.GetString("category_name"));
                }
            }

        }

        /// <summary>
        /// Returning brand name and removing duplicated if exist
        /// </summary>
        /// <param name="brand"></param>
        protected void loadBrand(ComboBox brand)
        {
            conn = new MySqlConnection(this.connection());
            conn.Open();

            command = new MySqlCommand("SELECT DISTINCT * FROM brand", conn);
            using (reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    brand.Items.Add(reader.GetString("brand_name"));
                }
            }
        }

        /// <summary>
        /// Returning Selected ID in ComboBox
        /// </summary>
        /// <param name="selecteId"></param>
        /// <returns></returns>
        protected String getSelectedId(String selecteId)
        {
            using(conn = new MySqlConnection(this.connection()))
            {
                conn.Open();
                command = new MySqlCommand("SELECT category_id FROM category WHERE category_name LIKE '" + selecteId + "'", conn);
                using(reader = command.ExecuteReader())
                {
                    reader.Read();
                    if(reader.HasRows)
                    {
                        categoryid = Convert.ToString(reader[0]);
                    }   
                }
            }

            return categoryid;
        }

        /// <summary>
        /// Returning Selected ID in ComboBox
        /// </summary>
        /// <param name="selecteId"></param>
        /// <returns></returns>
        protected String getSelectedIdBrand(String selecteId)
        {
            conn = new MySqlConnection(this.connection());
            conn.Open();
            command = new MySqlCommand("SELECT brand_id FROM brand WHERE brand_name LIKE '" + selecteId +"'", conn);
            using(reader = command.ExecuteReader())
            {
                reader.Read();
                if (reader.HasRows)
                {
                    brandid = reader[0].ToString();
                }
            }
            

            return brandid;
        }


        protected void insert(String category_id, String brand_id, TextBox[] product, int txtGain, addProducts suspend)
        {
            try
            {
                
                Random math = new Random();
                int rand = math.Next(1, 1000);
                String id = "P-00" + rand.ToString();

                conn = new MySqlConnection(this.connection());
                conn.Open();
                //MessageBox.Show(brand_id);

                command = new MySqlCommand("INSERT INTO product (products_id,barcode, product_name, category_id, brand_id, description, quantity, price, reorder, date_created, capital, gain, percentage)" +
                    "VALUES (@id,@bar, @names, @categoryid, @brandid, @description, @quantity, @price, @reorder, @date_created, @capital, @gain, @percentage)", conn);
                    
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@names", product[0].Text);
                    command.Parameters.AddWithValue("@bar", product[1].Text);
                    command.Parameters.AddWithValue("@categoryid", int.Parse(category_id));
                    command.Parameters.AddWithValue("@brandid", int.Parse(brand_id));
                    command.Parameters.AddWithValue("@description", product[2].Text);
                    command.Parameters.AddWithValue("@quantity", product[3].Text);
                    command.Parameters.AddWithValue("@price", product[4].Text);
                    command.Parameters.AddWithValue("@reorder", product[5].Text);
                    command.Parameters.AddWithValue("@date_created", dateNow);
                    command.Parameters.AddWithValue("@capital", product[6].Text);
                    command.Parameters.AddWithValue("@gain", txtGain);
                    command.Parameters.AddWithValue("@percentage", product[7].Text);

                bool result = (int)command.ExecuteNonQuery() > 0;
                    
                    if (result == true)
                    {
                        MessageBox.Show("Successfully Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        suspend.Hide();
                        
                    }

                    foreach(TextBox reset in product)
                    {
                        reset.Clear();
                    }
                    
                    command.Dispose();
                    conn.Close();
                
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
             
        }


        protected void Delete(String id, addProducts suspend)
        {
            try
            {
                conn = new MySqlConnection(this.connection());
                conn.Open();
                DialogResult result = MessageBox.Show("Do you want to Delete this Data?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(result == DialogResult.Yes)
                {
                    command = new MySqlCommand("DELETE FROM product WHERE products_id = @id", conn);
                    command.Parameters.AddWithValue("@id", id);
                    bool checkResult = (int)command.ExecuteNonQuery() > 0;

                    if (checkResult == true)
                    {
                        MessageBox.Show("Successfully Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        suspend.Hide();
                    } 
                }
                else
                {
                    MessageBox.Show("Your data is safe", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void Update(String category_id, String brand_id, TextBox[] product,String id, int txtGain, addProducts suspend)
        {
            try
            {
                conn = new MySqlConnection(this.connection());
                conn.Open();
                command = new MySqlCommand("UPDATE product SET barcode = @bar, product_name = @name , category_id = @categoryid, brand_id = @brandid, description = @desc, price = @price, reorder=@reorder, capital = @capital, gain = @gain, percentage = @percentage, date_updated = @date_updated WHERE products_id = @id", conn);
                command.Parameters.AddWithValue("@name", product[0].Text);
                command.Parameters.AddWithValue("@bar", product[1].Text);
                command.Parameters.AddWithValue("@categoryid", int.Parse(category_id));
                command.Parameters.AddWithValue("@brandid", int.Parse(brand_id));
                command.Parameters.AddWithValue("@desc", product[2].Text);
                command.Parameters.AddWithValue("@price", product[3].Text);
                command.Parameters.AddWithValue("@reorder", product[4].Text);
                command.Parameters.AddWithValue("@capital", product[5].Text);
                command.Parameters.AddWithValue("@gain", txtGain);
                command.Parameters.AddWithValue("@percentage", product[6].Text);
                command.Parameters.AddWithValue("@date_updated", dateNow);
                command.Parameters.AddWithValue("@id", id);

                bool checkResult = (int)command.ExecuteNonQuery() > 0;
                if(checkResult == true)
                {
                    MessageBox.Show("Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    suspend.Hide();
                }

                command.Dispose();
                conn.Close();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
         
    }
}
