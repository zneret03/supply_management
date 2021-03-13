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
using System.Windows.Forms.DataVisualization.Charting;
using System.Runtime.InteropServices;

namespace supply_management
{
    public partial class frmChartSoldItems : Form
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
        public frmChartSoldItems(frmTopItems frm)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            soldItems = frm;
        }

        public void loadChartSoldItems()
        {
            try
            {
                Controller.posController pos = new Controller.posController();
                MySqlDataAdapter sda = pos.loadChartSoldItems(soldItems.dateTimePicker4.Value.ToString("yyyy-MM-dd"), soldItems.dateTimePicker3.Value.ToString("yyyy-MM-dd"));
                DataSet data = new DataSet();
                sda.Fill(data, "SOLDITEMS");
                chart1.DataSource = data.Tables["SOLDITEMS"];
                Series series = chart1.Series[0];
                series.ChartType = SeriesChartType.Doughnut;

                series.LabelForeColor = Color.White;
                series.Name = "SOLD ITEMS";

                var chart = chart1;

                chart1.Series[0].XValueMember = "description";
                chart1.Series[0].YValueMembers = "total";

                chart.Series[0].IsValueShownAsLabel = true;
                chart.Series[0].LabelFormat = "{#,##0.00}";

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
