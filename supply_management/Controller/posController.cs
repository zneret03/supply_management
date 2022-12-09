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
    class posController : Model.POS
    {

        public DataTable barcode(String search)
        {
            String query = "SELECT * FROM product WHERE barcode = '" + search + "'";
            return this.barcodeSearcing(query);
        }

        public MySqlDataReader displayRecord(String transNo)
        {
            String query = "SELECT transaction_id, transactionNo, product.products_id, description, product.product_name, price, transaction.quantity, discount, total FROM transaction INNER JOIN product ON product.products_id = transaction.products_id WHERE transactionNo LIKE '" + transNo +"'";
            return this.display(query);
        }

        public MySqlDataReader displayRecoveryData()
        {
            String query = "SELECT transaction_id, transactionNo, product.products_id, description, product.product_name, price, transaction.quantity, discount, total, status FROM transaction INNER JOIN product ON product.products_id = transaction.products_id WHERE status = 'pending'";
            return this.display(query);
        }
        

        public DataTable loadProductLookup()
        {
            String query = "SELECT products_id, barcode, product_name, category_name, brand_name, description,quantity, price FROM product INNER JOIN category ON category.category_id = product.category_id INNER JOIN brand ON brand.brand_id = product.brand_id WHERE quantity > 0";
            return this.barcodeSearcing(query);
        }

        public DataTable SearchProducts(String search)
        {
            String query = "SELECT products_id, barcode, product_name, category_name, brand_name, description, quantity, price FROM product INNER JOIN category ON category.category_id = product.category_id INNER JOIN brand ON brand.brand_id = product.brand_id WHERE barcode LIKE '%" + search + "%' OR product_name LIKE '%" + search + "%' AND quantity > 0";
            return this.barcodeSearcing(query);
        }

        public MySqlDataReader SearchProductsAdjustment(String search)
        {
            String query = "SELECT products_id, barcode, product_name, category_name, brand_name, description, quantity, price FROM product INNER JOIN category ON category.category_id = product.category_id INNER JOIN brand ON brand.brand_id = product.brand_id WHERE barcode LIKE '%" + search + "%' OR description LIKE '%" + search + "%'";
            return this.display(query);
        }

        public MySqlDataReader loadTopSales(String date1, String date2, String sorting)
        {
            String query = "";
            if (sorting == "SORT BY QTY")
            {
                query = "SELECT transaction_id, t.products_id, p.description, p.product_name, SUM(t.quantity) as quantity, SUM(total) as total FROM transaction as t INNER JOIN product as p ON p.products_id = t.products_id WHERE t.date_created BETWEEN '" + date1 + "' AND '" + date2 + "' AND t.quantity != 0 GROUP BY products_id, discount ORDER BY quantity DESC LIMIT 10 ";
            }
            else
            {
                query = "SELECT transaction_id, t.products_id, p.description, p.product_name, SUM(t.quantity) as quantity, SUM(total) as total FROM transaction as t INNER JOIN product as p ON p.products_id = t.products_id WHERE t.date_created BETWEEN '" + date1 + "' AND '" + date2 + "' AND t.quantity != 0 GROUP BY products_id, discount ORDER BY total DESC LIMIT 10 ";
            }
            
            return this.display(query);
        }

        public MySqlDataAdapter loadChartTopSell(String date1, String date2, String sorting)
        {
            String query = "";
            if (sorting == "SORT BY QTY")
            {
                query = "SELECT transaction_id, t.products_id, p.description, SUM(t.quantity) as quantity, SUM(total) as total FROM transaction as t INNER JOIN product as p ON p.products_id = t.products_id WHERE t.date_created BETWEEN '" + date1 + "' AND '" + date2 + "' AND t.quantity != 0 GROUP BY products_id, discount ORDER BY quantity DESC LIMIT 10 ";
            }
            else
            {
                query = "SELECT transaction_id, t.products_id, p.description, SUM(t.quantity) as quantity, SUM(total) as total FROM transaction as t INNER JOIN product as p ON p.products_id = t.products_id WHERE t.date_created BETWEEN '" + date1 + "' AND '" + date2 + "' AND t.quantity != 0 GROUP BY products_id, discount ORDER BY total DESC LIMIT 10 ";
            }
            return this.loadChart(query);
        }
        public MySqlDataReader loadCriticalStocks()
        {
            String query = "SELECT * FROM viewcriticalitems";
            return this.display(query);
        }


        public MySqlDataReader loadProductInventory()
        {
            String query = "SELECT * FROM viewproductInventory";
            return this.display(query);
        }

        public String countCritical()
        {
            String query = "SELECT COUNT(*) FROM viewcriticalitems";
            return this.countData(query);
        }

        public String dailySales()
        {
            String date = DateTime.Now.Date.ToString("yyyy-MM-dd");
            String query = "SELECT SUM(total) as total FROM transaction WHERE date_created = '" + date + "'";
            return this.countData(query);
        }

        public MySqlDataReader loadCancel(String date1, String date2)
        {
            String query = "SELECT * FROM viewcance_sales WHERE date_cancel BETWEEN '" + date1 + "' AND '" + date2 + "'";
            return this.display(query);
        }
        public String changePassword(String username)
        {
            return this.getPassword(username);
        }

        public void updPassword(String username, String password, frmChangePassword suspend)
        {
            this.updatePassword(username, password, suspend);
        }
        public MySqlDataReader loadSoldItems(String date1, String date2)
        {
            String query = "SELECT t.products_id, p.description, p.product_name, price, SUM(t.quantity) as qty, SUM(discount) as disc, SUM(total) as total FROM transaction AS t INNER JOIN product as p ON p.products_id = t.products_id WHERE t.date_created BETWEEN '" + date1 + "' AND '" + date2 + "' AND t.quantity != 0 GROUP BY t.products_id";
            return this.display(query);
        }

        public MySqlDataAdapter loadChartSoldItems(String date1, String date2)
        {
            String query = "SELECT t.products_id, p.description, p.product_name, price, SUM(t.quantity) as qty, SUM(discount) as disc, SUM(total) as total FROM transaction AS t INNER JOIN product as p ON p.products_id = t.products_id WHERE t.date_created BETWEEN '" + date1 + "' AND '" + date2 + "' AND t.quantity != 0 GROUP BY t.products_id";
            return this.loadChart(query);
        }


        public void addQty(String pcode, String transNo, double discount, int tableqty, int qty , double price)
        {
            this.addQuantity(pcode, transNo, discount, tableqty, qty, price);
        }

        public void removeQty(String pcode, String transNo, double discount, int qty, double price)
        {
            this.removeQuantity(pcode, transNo, discount, qty, price);
        }
         
        public void insertTransact(String pcode, String transactNo, String qty, double total,  String cashier)
        {
            this.insertTransaction(pcode, transactNo, qty, total,  cashier);
        }

        public void cancelItems(String user, String password, TextBox[] information, ComboBox[] invetory)
        {
            this.CancelConfirmation(user, password, information, invetory);
        }

        public MySqlDataReader showSoldItems(String date1, String date2, String user)
        {
            String query = "";
            if(user.ToString() == "all cashier sales")
            {
                query = "SELECT transaction_id, transactionNo, t.products_id, p.description, p.product_name, p.price, t.quantity, discount, p.gain, total FROM transaction as t INNER JOIN product as p ON p.products_id = t.products_id WHERE t.date_created BETWEEN '" + date1 + "' AND '" + date2 + "' AND t.quantity != 0  AND status != 'pending'";
            }
            else
            {
                //MessageBox.Show(date1 + " " + date2 + " " + user);
                query = "SELECT transaction_id, transactionNo, t.products_id, p.description, p.product_name, p.price, t.quantity, discount, p.gain, total FROM transaction as t INNER JOIN product as p ON p.products_id = t.products_id WHERE t.date_created BETWEEN '" + date1 + "' AND '" + date2 + "' AND cashier = '" + user.ToString() + "' AND t.quantity != 0 AND status != 'pending'";
            }
            
            return this.display(query);
            //MessageBox.Show(user);
        }

        public bool orderExist(String transactionNo, String pcode)
        {
            return this.isExist(transactionNo, pcode);
        }

        public void updateOrder(String pcode, String qty, double total)
        {
            this.updateExistingOrder(pcode, qty, total);
        }

        public void loadusername(ComboBox users)
        {
            this.loadUsers(users);
        }
        public void updQty(String qty, String id)
        {
            this.updateQty(qty, id);
        }

        public void outOfOrder(String id)
        {
            this.soldOut(id);
        }

        public double vatable()
        {
            return this.getVal();
        }

        public void deleteData(String id, frmPOS loadData)
        {
            this.delete(id, loadData);
        }

        public void discount(String id, String discount, String discount_percent, frmdiscount suspend, double totalPrice)
        {
            this.isDiscount(id, discount, discount_percent, suspend, totalPrice);
        }

        public void updTransactionStat(String transactionNo)
        {
            this.updTransactionStatus(transactionNo);
        }
    }
}
