using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            String query = "SELECT stock_id, referenceNo, product.products_id, product_name, description, quantity, stockDate, stockInBy, status FROM stocks INNER JOIN product ON product.products_id = stocks.products_id";
            return this.loadData(query);
        }

        public BindingSource loadStockHistory(frmStock date)
        {
            String query = "SELECT stock_id, referenceNo, product.products_id, product_name, description, quantity, stockDate, stockInBy, status FROM stocks INNER JOIN product ON product.products_id = stocks.products_id WHERE stockDate BETWEEN '" + date.dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "' AND '" + date.dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "' AND status = 'Out of order'";
            return this.loadData(query);                                                    
        }

        public void notOrder(String id, frmStock load)
        {
            this.notOutofOrder(id, load);
        }
        
        public void insertProduct(String pcode, frmStock load, TextBox[] textStocks, DateTime date)
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
                            this.insert(pcode, load, textStocks, date);
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

        public object countStocks()
        {
            return this.count();
        }
    }
}
