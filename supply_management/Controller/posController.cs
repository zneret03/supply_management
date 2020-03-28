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
            String query = "SELECT transaction_id, transactionNo, product.products_id, description, price, transaction.quantity, discount, total FROM transaction INNER JOIN product ON product.products_id = transaction.products_id WHERE transactionNo LIKE '" + transNo +"'";
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

        public void insertTransact(String pcode, String transactNo, String qty, double total, String date, String cashier)
        {
            this.insertTransaction(pcode, transactNo, qty, total, date, cashier);
        }

        public MySqlDataReader showSoldItems(String date1, String date2, String user)
        {
            String query = "SELECT transaction_id, transactionNo, t.products_id, p.description, p.price, t.quantity, discount, total FROM transaction as t INNER JOIN product as p ON p.products_id = t.products_id WHERE t.date_created BETWEEN '" + date1 + "' AND '" + date2 + "' AND cashier = '" + user.ToString() + "'";
            return this.display(query);
            //MessageBox.Show(user);
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

        public void discount(String id, String discount, frmdiscount suspend, double totalPrice)
        {
            this.isDiscount(id, discount, suspend, totalPrice);
        }

    }
}
