﻿using System;
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

        public void updTransactionStatus(String transactionNo)
        {
            try
            {
                conn = new MySqlConnection(this.connection());
                conn.Open();
                using (command = new MySqlCommand("UPDATE transaction SET status = 'approve' WHERE transactionNo = '" + transactionNo + "'",conn))
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

        protected DataTable barcodeSearcing(String query)
        {
                conn = new MySqlConnection(this.connection());
                conn.Open();
                sda = new MySqlDataAdapter(query, conn);
                dt = new DataTable();
                sda.Fill(dt);

                return dt;
        }

        protected MySqlDataAdapter loadChart(String query)
        {
            conn = new MySqlConnection(this.connection());
            conn.Open();
            sda = new MySqlDataAdapter(query, conn);
            conn.Close();

            return sda;
        }
        protected MySqlDataReader display(String query)
        {
            conn = new MySqlConnection(this.connection());
            conn.Open();
            command = new MySqlCommand(query, conn);
            reader = command.ExecuteReader();

            return reader;
        }

        protected String countData(String query)
        {
            String count = "";
            conn = new MySqlConnection(this.connection());
            conn.Open();
            using(command = new MySqlCommand(query, conn))
            {
                count = command.ExecuteScalar().ToString();
            }
            
            conn.Close();
            return count;
        }

        protected bool isExist(String transactioNo, String pcode)
        {
            bool found = false;
            conn = new MySqlConnection(this.connection());
            conn.Open();
            using(command = new MySqlCommand("SELECT * FROM transaction WHERE transactionNo = @trans AND products_id = @product", conn))
            {
                command.Parameters.AddWithValue("@trans", transactioNo);
                command.Parameters.AddWithValue("@product", pcode);
                reader = command.ExecuteReader();
                reader.Read();
                if(reader.HasRows)
                {
                    found = true;
                }
                else
                {
                    found = false;
                }

                return found;
            }
        }

        //Add Qunatity dynamically
        protected void addQuantity(String pcode, String transNo, double discount, int tableqty, int qty, double price, int totalGain)
        {
            try
            {
                conn = new MySqlConnection(this.connection());
                conn.Open();
                int i = 1;
                using(command = new MySqlCommand("SELECT SUM(quantity) as qty FROM product WHERE products_id LIKE '" + pcode + "' GROUP BY products_id", conn))
                {
                    i = int.Parse(command.ExecuteScalar().ToString());
                }
                conn.Close();

                if (discount == 0.00)
                {
                    //Calculate when discount was not entered qunatity++
                    addqty(i, tableqty, qty, pcode, transNo, price, totalGain);
                    return;
                }
                else
                {
                    //calculate when discount was entered
                    addQty_Discount(i, tableqty, qty, pcode, transNo, price, totalGain);
                    //MessageBox.Show("False");
                    return;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addqty(int i, int tableqty, int qty, String pcode, String transNo, double price, int totalGain)
        {
            try
            {
               
                conn = new MySqlConnection(this.connection());
                conn.Open();
                if (tableqty <= i)
                {
                    using (command = new MySqlCommand("UPDATE transaction SET quantity = quantity + '" + qty + "', total = quantity * '" + price + "', totalGain = quantity * '" + totalGain + "' WHERE transactionNo LIKE '" + transNo + "' AND products_id LIKE '" + pcode + "'", conn))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    MessageBox.Show("Remaining quantity on hand is " + i + "!" ,"Out of stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addQty_Discount(int i, int tableqty, int qty, String pcode, String transNo, double price, int totalGain)
        {
            try
            {

                conn = new MySqlConnection(this.connection());
                conn.Open();
                if (tableqty <= i)
                {
                    using (command = new MySqlCommand("UPDATE transaction SET quantity = quantity + '" + qty + "', discount = (('" + price + "' * quantity) * discount_percent), total = (('" + price + "' * quantity) - discount), totalGain = (('" + totalGain + "' * quantity) - discount) WHERE transactionNo LIKE '" + transNo + "' AND products_id LIKE '" + pcode + "'", conn))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    MessageBox.Show("Remaining quantity on hand is " + i + "!", "Out of stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //add quantity dynamically

        //remove quantity dynamically
        protected void removeQuantity(String pcode, String transNo, double discount, int qty, double price, int totalGain)
        {
            try
            {
                conn = new MySqlConnection(this.connection());
                conn.Open();
                int i = 0;
                using (command = new MySqlCommand("SELECT SUM(quantity) as qty FROM transaction WHERE products_id LIKE '" + pcode + "' AND transactionNo LIKE '" + transNo + "' GROUP BY transactionNo, products_id", conn))
                {
                    i = int.Parse(command.ExecuteScalar().ToString());
                }

                
                conn.Close();

                if (discount == 0.00)
                {
                    //Calculate when discount was not entered qunatity++
                    removeqty(i, qty, pcode, transNo, price, totalGain);
                    return;
                }
                else
                {
                    //calculate when discount was entered
                    removeqty_Discount(i, qty, pcode, transNo, price, totalGain);
                    //MessageBox.Show("False");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void removeqty(int i, int qty, String pcode, String transNo, double price, int totalGain)
        {
            try
            {
                conn = new MySqlConnection(this.connection());
                conn.Open();
                if (i > 1)
                {
                    using (command = new MySqlCommand("UPDATE transaction SET quantity = quantity - '" + qty + "', total = quantity * '" + price + "', totalGain = quantity * '" + totalGain + "' WHERE transactionNo LIKE '" + transNo + "' AND products_id LIKE '" + pcode + "'", conn))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    MessageBox.Show("Remaining quantity on hand is " + i + "!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void removeqty_Discount(int i, int qty, String pcode, String transNo, double price, int totalGain)
        {
            try
            {
                conn = new MySqlConnection(this.connection());
                conn.Open();
                if (i > 1)
                {
                    using (command = new MySqlCommand("UPDATE transaction SET quantity = quantity - '" + qty + "', discount = (('" + price + "' * quantity) * discount_percent), total = (('" + price + "' * quantity) - discount), totalGain = (('" + totalGain + "' * quantity) - discount) WHERE transactionNo LIKE '" + transNo + "' AND products_id LIKE '" + pcode + "'", conn))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    MessageBox.Show("Remaining quantity on hand is " + i + "!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //remove quantity dynamically
        

        //Change password
        protected String getPassword(String user)
        {
                String password = "";
                conn = new MySqlConnection(this.connection());
                conn.Open();
                    using(command = new MySqlCommand("SELECT * FROM users WHERE username = @user",conn))
                    {
                        command.Parameters.AddWithValue("@user", user);
                        reader = command.ExecuteReader();
                        reader.Read();
                        
                        if(reader.HasRows)
                        {
                            password = reader.GetString(reader.GetOrdinal("password"));
                        }
                    }
                conn.Close();
                return password;
        }

        protected void updatePassword(String username, String pass, frmChangePassword suspend)
        {
            try
            {
                conn = new MySqlConnection(this.connection());
                conn.Open();
                using(command = new MySqlCommand("UPDATE users SET password = @pass WHERE username = @user",conn))
                {
                    command.Parameters.AddWithValue("@user", username);
                    command.Parameters.AddWithValue("@pass", pass);

                    bool checkResult = (int)command.ExecuteNonQuery() > 0;

                    if(checkResult == true)
                    {
                        MessageBox.Show("Password change successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        suspend.Hide();
                    }
                }
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Change password
        protected void CancelConfirmation(String username, String password, TextBox[] cancelInformation, ComboBox[] inventory)
        {
            
            try
            {
                conn = new MySqlConnection(this.connection());
                conn.Open();
                String user;
                String usertype;
                using(command = new MySqlCommand("SELECT * FROM users WHERE username = @username AND password = @password", conn))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    reader = command.ExecuteReader();
                    reader.Read();
                    user = reader["username"].ToString();
                    usertype = reader["usertype"].ToString();
                    if (usertype != "Admin") 
                    { 
                        MessageBox.Show("Admin only", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                    } 
                    else 
                    {
                        if (reader.HasRows)
                        {
                            insertCancel(cancelInformation, user, inventory);
                            if (inventory[0].Text == "Yes")
                            {
                                //returning quantity
                                updateTable("UPDATE product SET quantity = quantity + '" + int.Parse(cancelInformation[5].Text) + "' WHERE products_id = '" + cancelInformation[1].Text + "'");
                                //Changing status stocks (Out of order) and (Functioning)
                                updateTable("UPDATE stocks as s INNER JOIN product as p ON p.products_id = s.products_id SET s.status = 'Functioning' WHERE p.quantity  > 0 AND s.products_id = '" + cancelInformation[1].Text + "'");
                            }
                            updateTable("UPDATE transaction SET quantity = quantity - '" + int.Parse(cancelInformation[5].Text) + "', total = quantity * '" + cancelInformation[6].Text + "' WHERE transaction_id = '" + cancelInformation[0].Text + "'");

                            MessageBox.Show("Order cancelled Succesffully!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                   
                }
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Insert into cancel_sales
        private void insertCancel(TextBox[] cancelInformation, String user, ComboBox[] inventory)
        {
            try
            {
                conn = new MySqlConnection(this.connection());
                conn.Open();
                using (command = new MySqlCommand("INSERT INTO cancel_sales (transaction_id, products_id, quantity, date_cancel, voidby, cancelBy, reason, action) VALUES (@transid, @pcode, @qty, @date, @void, @cancel, @reason, @action)", conn))
                {
                    command.Parameters.AddWithValue("@transid", cancelInformation[0].Text);
                    command.Parameters.AddWithValue("@pcode", cancelInformation[1].Text);
                    command.Parameters.AddWithValue("@qty", int.Parse(cancelInformation[2].Text));
                    command.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString());
                    command.Parameters.AddWithValue("@void", user);
                    command.Parameters.AddWithValue("@cancel", cancelInformation[3].Text);
                    command.Parameters.AddWithValue("@reason", cancelInformation[4].Text);
                    command.Parameters.AddWithValue("@action", inventory[0].Text);
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //update product when returning the chosen quantity
        private void updateTable(String sql)
        {
            try
            {
                conn = new MySqlConnection(this.connection());
                conn.Open();
                using(command = new MySqlCommand(sql,conn))
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

        protected void updateExistingOrder(String pcode, String quantity, double total, double totalGain)
        {
            try
            {
                conn = new MySqlConnection(this.connection());
                conn.Open();
                using(command = new MySqlCommand("UPDATE transaction SET quantity = quantity + '" + int.Parse(quantity) + "', total = total + '" + total + "',  totalGain = totalGain + '" + totalGain + "' WHERE products_id = '" + pcode +"'", conn))
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

        protected void loadUsers(ComboBox users)
        {
            try
            {
                conn = new MySqlConnection(this.connection());
                conn.Open();
                using(command = new MySqlCommand("SELECT DISTINCT * FROM users WHERE usertype = 'Employee'", conn))
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
        protected void isDiscount(String id, String discount, String discount_percent, frmdiscount suspend, double totalPrices, double discountedGain)
        {
            try
            {
                
                conn = new MySqlConnection(this.connection());
                conn.Open();
                DialogResult result = MessageBox.Show("Add this discount?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    using (command = new MySqlCommand("UPDATE transaction SET discount_percent = @disc_percent, discount = @desc, total = @ttal, totalGain = @totalGain WHERE transaction_id = @id", conn))
                    {
                        command.Parameters.AddWithValue("@disc_percent", Convert.ToDouble(discount_percent));
                        command.Parameters.AddWithValue("@desc", Convert.ToDouble(discount));
                        command.Parameters.AddWithValue("@ttal", totalPrices);
                        command.Parameters.AddWithValue("@totalGain", discountedGain);
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
        
        protected void insertTransaction(String pcode, String transactNo, String qty, double total, String cashier, double gainText)
        {
            try
            {
                using (conn = new MySqlConnection(this.connection()))
                {
                    String discount = "0.00";
                    String status = "pending";
                    conn.Open();
                    command = new MySqlCommand("INSERT INTO transaction (transactionNo, products_id, quantity, discount, total, cashier, totalGain, date_created, status) VALUES (@transactNo, @prodId, @qty, @desc ,@ttal, @cashier, @totalGain, @date, @status)", conn);
                    command.Parameters.AddWithValue("@transactNo", transactNo);
                    command.Parameters.AddWithValue("@prodId", pcode);
                    command.Parameters.AddWithValue("@qty", qty);
                    command.Parameters.AddWithValue("@desc", discount);
                    command.Parameters.AddWithValue("@ttal", total);
                    command.Parameters.AddWithValue("@cashier", cashier);
                    command.Parameters.AddWithValue("@totalGain", gainText);
                    command.Parameters.AddWithValue("@date", DateTime.Now.Date.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@status", status);

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
