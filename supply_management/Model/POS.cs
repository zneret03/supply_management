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
    class POS : ConnectionSql
    {
        MySqlConnection conn;
        MySqlCommand command;
        MySqlDataAdapter sda;
        MySqlDataReader reader;
        DataTable dt;

        Controller.ErrorHandler error = new Controller.ErrorHandler();
        //public double total;
        protected DataTable barcodeSearcing(String query)
        {
                conn = new MySqlConnection(this.connection());
                conn.Open();
                sda = new MySqlDataAdapter(query, conn);
                dt = new DataTable();
                sda.Fill(dt);

                return dt;
        }

        protected MySqlDataReader display(String query)
        {
            conn = new MySqlConnection(this.connection());
            conn.Open();
            command = new MySqlCommand(query, conn);
            reader = command.ExecuteReader();

            return reader;
        }

        protected void loadUsers(ComboBox users)
        {
            try
            {
                conn = new MySqlConnection(this.connection());
                conn.Open();
                using(command = new MySqlCommand("SELECT DISTINCT * FROM users", conn))
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        users.Items.Add(reader.GetString("username"));
                    }
                }
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Saving discount to transaction table;
        protected void isDiscount(String id, String discount, frmdiscount suspend, double totalPrices)
        {
            try
            {
                conn = new MySqlConnection(this.connection());
                conn.Open();
                DialogResult result = MessageBox.Show("Add this discount?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    using (command = new MySqlCommand("UPDATE transaction SET discount = @desc, total = @ttal WHERE transaction_id = @id", conn))
                    {
                        command.Parameters.AddWithValue("@desc", Convert.ToDouble(discount));
                        command.Parameters.AddWithValue("@ttal", totalPrices);
                        command.Parameters.AddWithValue("@id", Convert.ToInt32(id));

                        bool checkResult = (int)command.ExecuteNonQuery() > 0;

                        if (checkResult == true)
                        {
                            MessageBox.Show("Discount added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            suspend.Hide();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("discount not added");
                }
               
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void updateQty(String qty, String id)
        {
            try
            {
                conn = new MySqlConnection(this.connection());
                conn.Open();
               using(command = new MySqlCommand("UPDATE product SET quantity =  quantity - '" + int.Parse(qty) +"' WHERE products_id = '" + id + "'", conn))
               {
                   command.ExecuteNonQuery();
                   command.Dispose();
               }
               conn.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void soldOut(String id)
        {
            try
            {
                
                conn = new MySqlConnection(this.connection());
                conn.Open();
                String quantity = "";
                using(command = new MySqlCommand("SELECT product.product_name, product.description, product.quantity, product.price FROM stocks INNER JOIN product ON product.products_id = stocks.products_id WHERE product.products_id = @id", conn))
                {
                    command.Parameters.AddWithValue("@id", id);

                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        quantity = reader["quantity"].ToString();
                    }
                    command.Dispose();
                }
                conn.Close();
               
                conn.Open();
                using (command = new MySqlCommand("UPDATE stocks INNER JOIN product ON product.products_id = stocks.products_id SET status = 'Out of order' WHERE product.quantity <= 0 AND product.products_id = '" + id + "'", conn))
                {
                    command.ExecuteNonQuery();
                    command.Dispose();
                }
                conn.Close();
                 
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected double getVal()
        {
            conn = new MySqlConnection(this.connection());
            double val = 0;
            conn.Open();
            command = new MySqlCommand("SELECT * FROM vatable", conn);
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                val = Convert.ToDouble(reader["vat"].ToString());
            }

            return val;
        }

        protected void delete(String delete, frmPOS frm)
        {
            try
            {
                    conn = new MySqlConnection(this.connection());
                    conn.Open();
                    using (command = new MySqlCommand("DELETE FROM transaction WHERE transaction_id LIKE @id", conn))
                    {
                        command.Parameters.AddWithValue("@id", delete);

                        bool checkResult = (int)command.ExecuteNonQuery() > 0;
                        if (checkResult == true)
                        {
                            MessageBox.Show("Data deleted Successfully", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
               
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void insertTransaction(String pcode, String transactNo, String qty, double total, String date, String cashier)
        {
            try
            {
                using (conn = new MySqlConnection(this.connection()))
                {
                    String discount = "0.00";
                    conn.Open();
                    command = new MySqlCommand("INSERT INTO transaction (transactionNo, products_id, quantity, discount, total, cashier, date_created) VALUES (@transactNo, @prodId, @qty, @desc ,@ttal, @cashier, @date)", conn);
                    command.Parameters.AddWithValue("@transactNo", transactNo);
                    command.Parameters.AddWithValue("@prodId", pcode);
                    command.Parameters.AddWithValue("@qty", qty);
                    command.Parameters.AddWithValue("@desc", discount);
                    command.Parameters.AddWithValue("@ttal", total);
                    command.Parameters.AddWithValue("@cashier", cashier);
                    command.Parameters.AddWithValue("@date", date);

                    command.ExecuteNonQuery();

                    command.Dispose();
                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
