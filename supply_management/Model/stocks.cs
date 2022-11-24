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
    class stocks : ConnectionSql
    {
        

        MySqlConnection conn;
        MySqlCommand command;
        MySqlDataReader reader;
        MySqlDataAdapter sda;
        DataTable dt;
        BindingSource bind;
        protected BindingSource loadData(String query)
        {
            conn = new MySqlConnection(this.connection());
            conn.Open();
            sda = new MySqlDataAdapter(query, conn);
            dt = new DataTable();
            sda.Fill(dt);

            bind = new BindingSource();
            bind.DataSource = dt;

            return bind;
        }

        protected MySqlDataReader display(String query)
        {
            conn = new MySqlConnection(this.connection());
            conn.Open();
            command = new MySqlCommand(query, conn);
            reader = command.ExecuteReader();

            return reader;
        }

        protected String count()
        {
            conn = new MySqlConnection(this.connection());
            conn.Open();
            String countData = "";
            using(command = new MySqlCommand("SELECT SUM(p.quantity) as qty FROM stocks as s INNER JOIN product as p ON p.products_id = s.products_id", conn))
            {
                countData = command.ExecuteScalar().ToString();
            }

            return countData;
        }

        //Stock Adjustment events
        protected void insertAdjustment(TextBox[] adjustment, String cmbCommand)
        {
            try
            {
                String query = "";
                conn = new MySqlConnection(this.connection());
                conn.Open();
                using(command = new MySqlCommand("INSERT INTO stock_adjustment (referenceNo, products_id, quantity, action, remarks, users) VALUES (@reference, @pcode, @qty, @act, @remarks, @user)", conn))
                {
                    command.Parameters.AddWithValue("@reference", adjustment[0].Text);
                    command.Parameters.AddWithValue("@pcode", adjustment[1].Text);
                    command.Parameters.AddWithValue("@qty", adjustment[2].Text);
                    command.Parameters.AddWithValue("@act",cmbCommand);
                    command.Parameters.AddWithValue("@remarks", adjustment[3].Text);
                    command.Parameters.AddWithValue("@user", adjustment[4].Text);

                    bool checkResult = (int)command.ExecuteNonQuery() > 0;

                    if(checkResult == true)
                    {
                        MessageBox.Show("Successfully Save", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (cmbCommand == "REMOVE FROM INVENTORY")
                    {
                        query = "UPDATE viewproductinventory SET quantity = quantity - '" + adjustment[2].Text + "' WHERE products_id = '" + adjustment[1].Text + "'";
                        addRemoveEvent(adjustment, query);
                        return;
                    }

                        query = "UPDATE viewproductinventory SET quantity = quantity + '" + adjustment[2].Text + "' WHERE products_id = '" + adjustment[1].Text + "'";
                        addRemoveEvent(adjustment, query);
                    
                    alterData();

                  
                }

                conn.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addRemoveEvent(TextBox[] adjustment, String query)
        {
            try
            {
                conn = new MySqlConnection(this.connection());
                conn.Open();
                using (command = new MySqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Stock Adjustment events
        protected void deleteVendor(String id)
        {
            try
            {
                conn = new MySqlConnection(this.connection());
                conn.Open();
                DialogResult result = MessageBox.Show("Delete this data?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    using (command = new MySqlCommand("DELETE FROM vendor WHERE vendor_id = @id", conn))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        bool checkResult = (int)command.ExecuteNonQuery() > 0;
                        if (checkResult == true)
                        {
                            MessageBox.Show("Successfully Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            alterData();
                        }
                    }
                }
                else
                {
                    return;
                }
               
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void alterData()
        {
            try
            {
                conn = new MySqlConnection(this.connection());
                conn.Open();
                using(command = new MySqlCommand("ALTER TABLE vendor AUTO_INCREMENT = 1", conn))
                {
                    command.ExecuteNonQuery();
                }

                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void updateVendor(TextBox[] vendors, String id, addVendor ven)
        {
            try
            {
                conn = new MySqlConnection(this.connection());
                conn.Open();
                using (command = new MySqlCommand("UPDATE vendor SET vendor = @vendor, address = @address, contactPerson = @contactperson, telephoneNo = @telephone, email = @mail, fax = @fax WHERE vendor_id = @id", conn))
                {
                    command.Parameters.AddWithValue("@vendor", vendors[0].Text);
                    command.Parameters.AddWithValue("@address", vendors[1].Text);
                    command.Parameters.AddWithValue("@contactperson", vendors[2].Text);
                    command.Parameters.AddWithValue("@telephone", vendors[3].Text);
                    command.Parameters.AddWithValue("@mail", vendors[4].Text);
                    command.Parameters.AddWithValue("@fax", vendors[5].Text);
                    command.Parameters.AddWithValue("@id", id);

                    bool checkResult = (int)command.ExecuteNonQuery() > 0;

                    if (checkResult == true)
                    {
                        MessageBox.Show("Successfully Save", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 
                    }

                    foreach (TextBox vendor in vendors)
                    {
                        vendor.Clear();
                    }

                    ven.Hide();
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        protected void insertVendor(TextBox[] vendors, frmVendor ven)
        {
            try
            {
                conn = new MySqlConnection(this.connection());
                conn.Open();
                using(command = new MySqlCommand("INSERT INTO vendor (vendor, address, contactPerson, telephoneNo, email, fax) VALUES (@vendor, @address, @contactperson, @telephone, @mail, @fax)", conn))
                {
                    command.Parameters.AddWithValue("@vendor", vendors[0].Text);
                    command.Parameters.AddWithValue("@address", vendors[1].Text);
                    command.Parameters.AddWithValue("@contactperson", vendors[2].Text);
                    command.Parameters.AddWithValue("@telephone", vendors[3].Text);
                    command.Parameters.AddWithValue("@mail", vendors[4].Text);
                    command.Parameters.AddWithValue("@fax", vendors[5].Text);

                    bool checkResult = (int)command.ExecuteNonQuery() > 0;

                    if(checkResult == true)
                    {
                        MessageBox.Show("Successfully Save", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ven.loadDataVendor();
                    }

                   foreach(TextBox vendor in vendors)
                   {
                       vendor.Clear();
                   }

                }

                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void notOutofOrder(String id, frmStock load)
        {
            try
            {
                
                conn = new MySqlConnection(this.connection());
                conn.Open();
                using (command = new MySqlCommand("UPDATE stocks INNER JOIN product ON product.products_id = stocks.products_id SET status = 'Functioning' WHERE product.quantity > 0 AND stock_id = '" + id + "'", conn))
                {
                    bool check = (int)command.ExecuteNonQuery() > 0;
                    if(check == true)
                    {
                        load.loadStocks();
                    }
                    else
                    {
                        command = new MySqlCommand("UPDATE stocks INNER JOIN product ON product.products_id = stocks.products_id SET status = 'Out of order' WHERE product.quantity = 0 AND stock_id = '" + id + "'", conn);
                        command.ExecuteNonQuery();
                        load.loadStocks();
                    }

                    command.Dispose();
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        protected void Delete(String id, frmStock load)
        {
            try
            {
                conn = new MySqlConnection(this.connection());
                conn.Open();
                DialogResult result = MessageBox.Show("Do you want to delete your data?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    using (command = new MySqlCommand("DELETE FROM stocks WHERE stock_id = @id", conn))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        bool checkResult = (int)command.ExecuteNonQuery() > 0;
                        if (checkResult == true)
                        {
                            MessageBox.Show("Deleted Successfully", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            load.loadStocks();
                        }
                        command.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show("Your Data is safe", "Safe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void updateQuantity(String QTY, String REF, String stockInBy, String id, frmStock update)
        {
            try
            {
                conn = new MySqlConnection(this.connection());
                conn.Open();
                command = new MySqlCommand("UPDATE stocks INNER JOIN product ON product.products_id = stocks.products_id SET quantity = @qty, referenceNo = @ref, stockInBy = @stockby WHERE stock_id = @id ", conn);
                command.Parameters.AddWithValue("@qty", QTY);
                command.Parameters.AddWithValue("@ref", REF);
                command.Parameters.AddWithValue("@stockby", stockInBy);
                command.Parameters.AddWithValue("@id", id);

                bool result = (int)command.ExecuteNonQuery() > 0;

                if(result == true)
                {
                    MessageBox.Show("Data Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    update.loadStocks();
                    update.getDataProducts();
                }



                conn.Close();
                command.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected DataTable search(String search)
        {
            conn = new MySqlConnection(this.connection());
            conn.Open();
            sda = new MySqlDataAdapter("SELECT products_id, product_name, description, quantity FROM product WHERE products_id LIKE '%" +search + "%' OR product_name LIKE '%" + search + "%'", conn);
            dt = new DataTable();
            sda.Fill(dt);

            return dt;
        }

        protected String isExist(String pcode)
        {
            conn = new MySqlConnection(this.connection());
            conn.Open();
            String Pcode = " ";
            using(command = new MySqlCommand("SELECT * FROM stocks WHERE products_id = @id", conn))
            {
                command.Parameters.AddWithValue("@id", pcode);
                reader = command.ExecuteReader();
                if(reader.Read())
                {
                    Pcode = reader.GetString(reader.GetOrdinal("products_id"));
                }
                command.Dispose();
            }
            conn.Close();

            return Pcode;
        }

        protected void insert(String pcode, frmStock load, TextBox[] textStocks, String date, String id)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you want to save this data?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                conn = new MySqlConnection(this.connection());
                if(result == DialogResult.Yes)
                {
                    conn.Open();
                    command = new MySqlCommand("INSERT INTO stocks (referenceNo, products_id, stockDate, stockInBy, vendor_id) VALUES (@referenceNo ,@id, @Date, @stockBy, @vendors)", conn);
                    command.Parameters.AddWithValue("@referenceNo", textStocks[0].Text);
                    command.Parameters.AddWithValue("@id", pcode);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@stockBy", textStocks[1].Text);
                    command.Parameters.AddWithValue("@vendors", id);

                    bool checkResult = (int)command.ExecuteNonQuery() > 0;
                    if (checkResult == true)
                    {
                        MessageBox.Show("You data save successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load.loadStocks();
                    }
                }
                else
                {
                    MessageBox.Show("You data is safe", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                command.Dispose();
                conn.Close();
                
            }
            catch(MySqlException ex)
            {
                int errorCode = ex.Number;
                if (errorCode == 1366)
                {
                    MessageBox.Show("Stock fields are empty please try again!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }   
            }
        }
    }
}
