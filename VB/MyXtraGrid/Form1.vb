' Developer Express Code Central Example:
' How to create a GridView descendant class and register it for design-time use
' 
' This is an example of a custom GridView and a custom control that inherits the
' DevExpress.XtraGrid.GridControl. Make sure to build the project prior to opening
' Form1 in the designer. Please refer to the http://www.devexpress.com/scid=A859
' Knowledge Base article for the additional information.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E900


Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data

Namespace MyXtraGrid
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub SetImagesToColumnsHeader()
			myGridView1.Columns("Name").ImageIndex = 0
			myGridView1.Columns("Order").ImageIndex = 1
			myGridView1.Columns("Order").ImageAlignment = StringAlignment.Center
			myGridView1.Columns("ID").Image = imageCollection1.Images(2)
			myGridView1.Columns("ID").ImageAlignment = StringAlignment.Far
		End Sub
		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			myGridControl1.DataSource = CreateDataSource()
			SetImagesToColumnsHeader()
		End Sub


		Private Function CreateDataSource() As DataTable
			Dim dataTable As New DataTable()

			dataTable.Columns.Add("Name", GetType(String))
			dataTable.Columns.Add("ID", GetType(Integer))
			dataTable.Columns.Add("Order", GetType(String))
			dataTable.Columns.Add("Cost", GetType(Integer))
			dataTable.Rows.Add(New Object() { "Smit", 2,"Food",100})
			dataTable.Rows.Add(New Object() { "Stoun", 0, "Cars",1000 })
			dataTable.Rows.Add(New Object() { "Alex", 1, "Cars" })

			Return dataTable
		End Function

		Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
			 myGridView1.ShowPrintPreview()
			'myGridView1.ExportToPdf("1.pdf");
			'myGridView1.ExportToXlsx("1.xlsx");
			'myGridView1.ExportToXls("1.xls");
			'myGridView1.ExportToHtml("1.html");
		End Sub



	End Class
End Namespace