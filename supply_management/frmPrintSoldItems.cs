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
    public partial class frmPrintSoldItems : Form
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
        frmTopItems soldItems;
        public frmPrintSoldItems(frmTopItems frm)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            soldItems = frm;
        }

        public void loadSoldItems()
        {
            try
            {
                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\Report8.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();
                Model.ConnectionSql connect = new Model.ConnectionSql();
                MySqlConnection conn = new MySqlConnection(connect.connection());
                conn.Open();
                ReportDataSource reportViewer;
                MySqlDataAdapter sda = new MySqlDataAdapter();
                DataSet1 data = new DataSet1();
                using (sda.SelectCommand = new MySqlCommand("SELECT t.products_id, p.description, price, SUM(t.quantity) as qty, SUM(discount) as disc, SUM(total) as total FROM transaction AS t INNER JOIN product as p ON p.products_id = t.products_id WHERE t.date_created BETWEEN '" + soldItems.dateTimePicker4.Value.ToString("yyyy-MM-dd") + "' AND '" + soldItems.dateTimePicker3.Value.ToString("yyyy-MM-dd") + "' AND t.quantity != 0 GROUP BY t.products_id", conn))
                {
                    sda.Fill(data.Tables["_soldItems"]);
                }
                conn.Close();

                ReportParameter date = new ReportParameter("tDate", soldItems.dateTimePicker4.Value.ToLongDateString() + " to " + soldItems.dateTimePicker3.Value.ToLongDateString());
                this.reportViewer1.LocalReport.SetParameters(date);

                reportViewer = new ReportDataSource("DataSet1", data.Tables["_soldItems"]);
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

        private void frmPrintSoldItems_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
