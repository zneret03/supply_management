using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace supply_management
{
    public partial class addCategory : Form
    {
        private int moveStart;
        private int moveStartX;
        private int moveStartY;

        Controller.CategoryController category = new Controller.CategoryController();
        frmCategory frm = new frmCategory();
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
        frmCategory frmCategory;
        public addCategory(frmCategory frmCateg)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            frmCategory = frmCateg;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(moveStart == 1)
            {
                this.SetDesktopLocation(MousePosition.X - moveStartX, MousePosition.Y - moveStartY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moveStart = 0;
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

        private void addCategory_Load(object sender, EventArgs e)
        {
            ID.Hide();
            label4.Hide();
            checkDelete.Hide();
            
        }

        private void submit_Click(object sender, EventArgs e)
        {
            TextBox[] text = new TextBox[] {txtCategory};

                category.getData(txtCategory);
                frmCategory.getData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Label[] label = new Label[]{ID};
            TextBox[] txt = new TextBox[]{txtCategory};
            category.update(ID, txtCategory, this);
            frmCategory.getData();
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            Label[] label = new Label[] { ID };
            if(checkDelete.Checked == true)
            {
                category.isDelete(ID, this);
                frmCategory.getData();
                this.Hide();
            }
        }
    }
}
