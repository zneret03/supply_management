﻿using System;
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
    public partial class frmPrintSales : Form
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
        frmSoldItems sold;
        public frmPrintSales(frmSoldItems soldItems)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            sold = soldItems;
        }

        public void loadPrintSaleData()
        {
            try
            {
                String store = "HD Supply";
                String address = "Sta. Barbara, Iloilo City";
                ReportDataSource reportViewer;
                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath +  @"\Reports\Report2.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                MySqlConnection conn = new MySqlConnection(connect.connection());
                conn.Open();
                DataSet1 printSale = new DataSet1();
                MySqlDataAdapter sda = new MySqlDataAdapter();
                using (sda.SelectCommand = new MySqlCommand("SELECT transaction_id, transactionNo, t.products_id, p.description, p.price, t.quantity, discount, total FROM transaction as t INNER JOIN product as p ON p.products_id = t.products_id WHERE t.date_created BETWEEN '" + sold.dateTimePicker1.Value.ToLongDateString() + "' AND '" + sold.dateTimePicker2.Value.ToLongDateString() + "' AND cashier = '" + sold.username.Text  + "'", conn))
                {
                    sda.Fill(printSale.Tables["soldItems"]);
                }
                conn.Close();

                ReportParameter tstore = new ReportParameter("tStore", store);
                ReportParameter taddress = new ReportParameter("tAddress", address);

                this.reportViewer1.LocalReport.SetParameters(tstore);
                this.reportViewer1.LocalReport.SetParameters(taddress);

                reportViewer = new ReportDataSource("DataSet1", printSale.Tables["soldItems"]);
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

        private void label1_Click(object sender, EventArgs e)
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

        private void frmPrintSales_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
