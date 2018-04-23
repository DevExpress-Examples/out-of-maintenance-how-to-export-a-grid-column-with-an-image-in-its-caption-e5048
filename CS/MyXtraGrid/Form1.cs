// Developer Express Code Central Example:
// How to create a GridView descendant class and register it for design-time use
// 
// This is an example of a custom GridView and a custom control that inherits the
// DevExpress.XtraGrid.GridControl. Make sure to build the project prior to opening
// Form1 in the designer. Please refer to the http://www.devexpress.com/scid=A859
// Knowledge Base article for the additional information.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E900

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace MyXtraGrid {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void SetImagesToColumnsHeader()
        {
            myGridView1.Columns["Name"].ImageIndex = 0;
            myGridView1.Columns["Order"].ImageIndex = 1;
            myGridView1.Columns["Order"].ImageAlignment = StringAlignment.Center;
            myGridView1.Columns["ID"].Image = imageCollection1.Images[2];
            myGridView1.Columns["ID"].ImageAlignment = StringAlignment.Far;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            myGridControl1.DataSource = CreateDataSource();
            SetImagesToColumnsHeader();
        }


        private DataTable CreateDataSource()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Order", typeof(string));
            dataTable.Columns.Add("Cost", typeof(int));
            dataTable.Rows.Add(new object[] { "Smit", 2 ,"Food",100});
            dataTable.Rows.Add(new object[] { "Stoun", 0, "Cars",1000 });
            dataTable.Rows.Add(new object[] { "Alex", 1, "Cars" });

            return dataTable;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
             myGridView1.ShowPrintPreview();
            //myGridView1.ExportToPdf("1.pdf");
            //myGridView1.ExportToXlsx("1.xlsx");
            //myGridView1.ExportToXls("1.xls");
            //myGridView1.ExportToHtml("1.html");
        }

      

    }
}