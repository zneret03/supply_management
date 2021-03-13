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
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;

namespace supply_management
{
    public partial class frmprintCriticalStocks : Form
    {
        Model.ConnectionSql connect = new Model.ConnectionSql();
        frmTopItems top;
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
        public frmprintCriticalStocks(frmTopItems items)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            top = items;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void loadCriticalStocks()
        {
            try
            {
                ReportDataSource reportViewer;
                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\Report3.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();
                MySqlConnection conn = new MySqlConnection(connect.connection());
                MySqlDataAdapter sda = new MySqlDataAdapter();
                DataSet1 data = new DataSet1();
                conn.Open();
                using(sda.SelectCommand = new MySqlCommand("SELECT * FROM viewcriticalitems",conn))
                {
                    sda.Fill(data.Tables["criticalItems"]);
                }

                conn.Close();

               
                reportViewer = new ReportDataSource("DataSet1", data.Tables["criticalItems"]);
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
        private void frmprintCriticalStocks_Load(object sender, EventArgs e)
        {

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
    }
}
