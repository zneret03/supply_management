using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace supply_management
{
    public partial class frmPrintTopSelling : Form
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
        frmTopItems topsell;
        public frmPrintTopSelling(frmTopItems frm)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            topsell = frm;
        }

        private void frmPrintTopSelling_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        public void loadTopSelling()
        {
            try
            {
                Model.ConnectionSql connect = new Model.ConnectionSql();
                MySqlConnection conn = new MySqlConnection(connect.connection());
                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\Report7.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();
                conn.Open();
                ReportDataSource reportViewer;
                DataSet1 data = new DataSet1();
                MySqlDataAdapter sda = new MySqlDataAdapter();
                if (topsell.topSalesSorting.Text == "SORT BY QTY")
                {
                    using (sda.SelectCommand = new MySqlCommand("SELECT transaction_id, t.products_id, p.description, sum(t.quantity) as quantity, SUM(total) as total FROM transaction as t INNER JOIN product as p ON p.products_id = t.products_id WHERE t.date_created BETWEEN '" + topsell.dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + topsell.dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' AND t.quantity != 0 GROUP BY products_id, discount ORDER BY quantity DESC LIMIT 10 ", conn))
                    {
                        sda.Fill(data.Tables["transaction"]);
                    }
                }
                else
                {
                    using (sda.SelectCommand = new MySqlCommand("SELECT transaction_id, t.products_id, p.description, sum(t.quantity) as quantity, SUM(total) as total FROM transaction as t INNER JOIN product as p ON p.products_id = t.products_id WHERE t.date_created BETWEEN '" + topsell.dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + topsell.dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' AND t.quantity != 0 GROUP BY products_id, discount ORDER BY total DESC LIMIT 10 ", conn))
                    {
                        sda.Fill(data.Tables["transaction"]);
                    }
                }
               

                reportViewer = new ReportDataSource("DataSet1", data.Tables["transaction"]);
                this.reportViewer1.LocalReport.DataSources.Add(reportViewer);
                this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                this.reportViewer1.ZoomMode = ZoomMode.Percent;
                this.reportViewer1.ZoomPercent = 100;

                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
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
    }
}
