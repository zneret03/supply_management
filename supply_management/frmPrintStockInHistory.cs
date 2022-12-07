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
using MySql.Data.MySqlClient;
using Microsoft.Reporting.WinForms;
namespace supply_management
{
    public partial class frmPrintStockInHistory : Form
    {
        int moveStart;
        int moveStartX;
        int moveStartY;

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
        frmTopItems history;
        public frmPrintStockInHistory(frmTopItems frm)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            history = frm;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void loadStochInHistory()
        {
            try
            {
                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\Report5.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();
                Model.ConnectionSql connect = new Model.ConnectionSql();
                MySqlConnection conn = new MySqlConnection(connect.connection());
                conn.Open();
                
                MySqlDataAdapter sda = new MySqlDataAdapter();
                ReportDataSource reportViewer;
                DataSet1 dataset = new DataSet1();
                using(sda.SelectCommand = new MySqlCommand("SELECT stock_id, referenceNo, product.products_id, product_name, description, quantity, stockDate, stockInBy, status FROM stocks INNER JOIN product ON product.products_id = stocks.products_id WHERE stockDate BETWEEN '" + history.dateTimePicker6.Value.ToShortDateString() + "' AND '" + history.dateTimePicker5.Value.ToShortDateString() + "' AND status LIKE '" + history.status.Text + "'",conn))                                                  
                {
                    sda.Fill(dataset.Tables["StockInHistory"]);
                }

                reportViewer = new ReportDataSource("DataSet1", dataset.Tables["StockInHistory"]);
                this.reportViewer1.LocalReport.DataSources.Add(reportViewer);
                this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                this.reportViewer1.ZoomMode = ZoomMode.Percent;
                this.reportViewer1.ZoomPercent = 100;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void frmPrintStockInHistory_Load(object sender, EventArgs e)
        {

        }
    }
}
