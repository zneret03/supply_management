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
    public partial class frmPrintCancelSales : Form
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
        frmTopItems cancel_Sales;
        public frmPrintCancelSales(frmTopItems frm)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            cancel_Sales = frm;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void loadCancelSales()
        {
            try
            {
                Model.ConnectionSql connect = new Model.ConnectionSql();
                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\Report6.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                MySqlConnection conn = new MySqlConnection(connect.connection());
                conn.Open();
                MySqlDataAdapter sda = new MySqlDataAdapter();
                DataSet1 data = new DataSet1();
                ReportDataSource reportViewer;

                using(sda.SelectCommand = new MySqlCommand("SELECT * FROM viewcance_sales WHERE date_cancel BETWEEN '" + cancel_Sales.dateCancel1.Value.ToShortDateString() + "' AND '" + cancel_Sales.dateCancel2.Value.ToShortDateString() + "'",conn))
                {
                    sda.Fill(data.Tables["CancelSales"]);
                }
                conn.Close();

                reportViewer = new ReportDataSource("DataSet1", data.Tables["CancelSales"]);
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

        private void frmPrintCancelSales_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
