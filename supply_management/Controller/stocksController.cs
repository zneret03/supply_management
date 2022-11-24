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

namespace supply_management.Controller
{
    class stocksController : Model.stocks
    {
        Controller.ErrorHandler error = new Controller.ErrorHandler();
        public BindingSource loadProducts()
        {
            String query = "SELECT products_id, product_name, description, quantity FROM product";
            return this.loadData(query);
        }

        
        public BindingSource loadStocks()
        {
            String query = "SELECT stock_id, referenceNo, product.products_id, product_name, description, quantity, product.capital, product.gain, stockDate, stockInBy, status, vendor FROM stocks INNER JOIN product ON product.products_id = stocks.products_id INNER JOIN vendor ON vendor.vendor_id = stocks.vendor_id";
            return this.loadData(query);
        }

        public MySqlDataReader loadStockHistory(String date1, String date2, String status)
        {
            String query = "SELECT stock_id, referenceNo, product.products_id, product_name, description, quantity, stockDate, stockInBy, status, vendor FROM stocks INNER JOIN product ON product.products_id = stocks.products_id INNER JOIN vendor ON vendor.vendor_id = stocks.vendor_id WHERE stockDate BETWEEN '" +date1+ "' AND '" +date2+ "' AND status LIKE '" + status + "'";
            return this.display(query);                                                    
        }

        public MySqlDataReader returnData()
        {
            String query = "SELECT * FROM vendor";
            return this.display(query);
        }

        public void stockadjustment(TextBox[] adjustment, String cmbCommand)
        {
            if(adjustment[1].Text == string.Empty || adjustment[2].Text == string.Empty || adjustment[3].Text == string.Empty)
            {
                MessageBox.Show("Please fill all the empty fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.insertAdjustment(adjustment, cmbCommand);
        }

        public MySqlDataReader extractdata(String vendorsName)
        {
            String query = "SELECT * FROM vendor WHERE vendor = '"+vendorsName+"'";
            return this.display(query);
        }
        public void notOrder(String id, frmStock load)
        {
            this.notOutofOrder(id, load);
        }

        //Vendor events
        public void Insvendor(TextBox[] vendors, frmVendor vendor)
        {
            foreach (TextBox text in vendors)
            {
                if (string.IsNullOrEmpty(text.Text))
                {
                    MessageBox.Show("Please Fill all empty fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
                else
                {
                    this.insertVendor(vendors, vendor);
                    break;
                }
            }
          
        }

        public void delVendor(String id)
        {
            this.deleteVendor(id);
        }

        public void updVendor(TextBox[] vendor, String id, addVendor suspend)
        {
            this.updateVendor(vendor, id, suspend);
        }
        public MySqlDataReader loadVendor()
        {
            String query = "SELECT * FROM vendor";
            return this.display(query);
        }

        public MySqlDataReader searchVendor(String search)
        {
            String query = "SELECT * FROM vendor WHERE vendor LIKE '%" + search + "%' OR contactPerson LIKE '%" + search + "%'";
            return this.display(query);
        }
        
        
        //Vendor events
        
        public void insertProduct(String pcode, frmStock load, TextBox[] textStocks, String date, String id)
        {
            bool isNum = error.checkNum(textStocks[0].Text);
            String isExist = this.isExist(pcode);
            if (isNum == true) 
            {
                if (pcode == isExist)
                {
                    MessageBox.Show("This Data is already exist please try again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    foreach (TextBox isEmpty in textStocks)
                    {
                        if (string.IsNullOrEmpty(isEmpty.Text))
                        {
                            MessageBox.Show("Dont leave the field empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        else
                        {
                            this.insert(pcode, load, textStocks, date, id);
                            break;
                        }
                    }
                }
               
            }
            else
            {
                MessageBox.Show("Error Reference Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        public void updateDataStocks(String qty,String REF, String stockInBy, String id, frmStock update)
        {
            this.updateQuantity(qty ,REF ,stockInBy, id, update);
        }

        public DataTable searchData(String search)
        {
            return this.search(search);
        }

        public void isDelete(String id, frmStock load)
        {
            this.Delete(id, load);
        }

        public String countStocks()
        {
            return this.count();
        }
    }
}
