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
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;

namespace supply_management
{
    public partial class frmReceipt : Form
    {
        int moveStart;
        int moveStartX;
        int moveStartY;
        Model.ConnectionSql connect = new Model.ConnectionSql();
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

        frmPOS pointOfSale;
        public frmReceipt(frmPOS pos)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            pointOfSale = pos;
        }

        /// <summary>
        /// SELECT transaction_id, transactionNo, p.products_id, p.description, p.price, discount, total, t.date_created FROM transaction as t INNER JOIN product as p ON p.products_id = t.products_id
        /// </summary>
        public void loadData(String cash, String Change)
        {
            
            try
            {
                String store = "Gebs Bikehub";
                String address = "Brgy. Maya, Balasan, Iloilo City";
                ReportDataSource reportDataSource;
                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\Report1.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                MySqlConnection conn = new MySqlConnection(connect.connection());
                DataSet1 transact = new DataSet1();
                MySqlDataAdapter sda = new MySqlDataAdapter();
                conn.Open();
                using (sda.SelectCommand = new MySqlCommand("SELECT transactionNo, p.description, p.price, t.quantity, discount, total, t.date_created FROM transaction as t INNER JOIN product as p ON p.products_id = t.products_id WHERE transactionNo = '" + pointOfSale.Transactionlbl.Text + "'", conn))
                {
                    sda.Fill(transact.Tables["transaction"]);
                }
                conn.Close();

                ReportParameter pvatable = new ReportParameter("pVatable", pointOfSale.lblvatable.Text);
                ReportParameter pvat = new ReportParameter("pVat", pointOfSale.vatlbl.Text);
                ReportParameter pdiscount = new ReportParameter("pDiscount", pointOfSale.txtdiscount.Text);
                ReportParameter ptotalSales = new ReportParameter("pTotal", pointOfSale.total_sales.Text);
                ReportParameter pCash = new ReportParameter("pCash", cash);
                ReportParameter pchange = new ReportParameter("pChange", Change);
                ReportParameter pstore = new ReportParameter("pStore", store);
                ReportParameter paddress = new ReportParameter("pAddress", address);
                ReportParameter ptransaction = new ReportParameter("pTransaction","Invoice #: " + pointOfSale.Transactionlbl.Text);
                ReportParameter pCashier = new ReportParameter("pCashier",  pointOfSale.label1.Text);

                reportViewer1.LocalReport.SetParameters(pvatable);
                reportViewer1.LocalReport.SetParameters(pvat);
                reportViewer1.LocalReport.SetParameters(pdiscount);
                reportViewer1.LocalReport.SetParameters(ptotalSales);
                reportViewer1.LocalReport.SetParameters(pCash);
                reportViewer1.LocalReport.SetParameters(pchange);
                reportViewer1.LocalReport.SetParameters(pstore);
                reportViewer1.LocalReport.SetParameters(paddress);
                reportViewer1.LocalReport.SetParameters(ptransaction);
                reportViewer1.LocalReport.SetParameters(pCashier);

                reportDataSource = new ReportDataSource("DataSet1", transact.Tables["transaction"]);
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                this.reportViewer1.ZoomMode = ZoomMode.Percent;
                this.reportViewer1.ZoomPercent = 150;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
            //MessageBox.Show(pointOfSale.Transactionlbl.Text);
        }

        private void frmReceipt_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
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

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moveStart = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void reportViewer1_Load_1(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
