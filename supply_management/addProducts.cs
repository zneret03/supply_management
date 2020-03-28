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
using System.Runtime.InteropServices;

namespace supply_management
{
    public partial class addProducts : Form
    {

        int moveStart;
        int moveStartX;
        int moveStartY;
        Controller.productController product = new Controller.productController();
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        frmProduct fmprod;
        public addProducts(frmProduct frmproduct)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            fmprod = frmproduct;
        }
        

        private void description_TextChanged(object sender, EventArgs e)
        {
            description.SelectionStart = description.Text.Length;
            description.ScrollToCaret();
        }

        private void addProducts_Load(object sender, EventArgs e)
        {
            ComboBox[] items = new ComboBox[]{ categoryName, brandName };
            Date.Text = DateTime.Now.ToString("dd/MM/yyyy");
            product.loadCombo(items[0]);
            product.loadBra(items[1]);
           
            barcode.ReadOnly = true;
            quantity.Text = "0";
        }

       

        private void Date_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moveStart = 0;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(moveStart == 1)
            {
                this.SetDesktopLocation(MousePosition.X - moveStartX, MousePosition.Y - moveStartY);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moveStart = 1;
            moveStartX = e.X;
            moveStartY = e.Y;
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void categoryName_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void submit_Click(object sender, EventArgs e)
        {
            
            String category_Id = product.seletedId(categoryName.Text);
            String brand_id = product.seletedIdBrand(brandName.Text);
           
            TextBox[] text = new TextBox[]
            {
                productName,
                barcode,
                description,
                quantity,
                price
            };

            String isExist = product.isDuplicate(text);
            
            if(text[0].Text == isExist)
            {
                MessageBox.Show("This data is already exist please try another one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (categoryName.SelectedIndex == -1 || brandName.SelectedIndex == -1)
                {
                    MessageBox.Show("Pleas select category and brand name", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    product.insertProduct(category_Id, brand_id, text, this);
                    categoryName.SelectedIndex = -1;
                    brandName.SelectedIndex = -1;
                    fmprod.getData();
                }
            }
           
        }

        private void checkDelete_OnChange(object sender, EventArgs e)
        {
            if(checkDelete.Checked == true)
            {
                product.isDelete(IdLabel.Text, this);
                fmprod.getData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            String category_Id = product.seletedId(categoryName.Text);
            String brand_id = product.seletedIdBrand(brandName.Text);

            TextBox[] text = new TextBox[]
            {
                productName,
                barcode,
                description,
                quantity,
                price
            };

            product.isUpdate(category_Id, brand_id, text, IdLabel.Text , this);
            categoryName.SelectedIndex = -1;
            brandName.SelectedIndex = -1;
            fmprod.getData();
        }
    }
}
