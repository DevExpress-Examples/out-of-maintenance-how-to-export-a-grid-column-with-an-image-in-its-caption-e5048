Imports Microsoft.VisualBasic
Imports System
Namespace WindowsApplication3
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.customerInfoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
			Me.dataSet11 = New WindowsApplication3.DataSet1()
			Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.colColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.gridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
			CType(Me.customerInfoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dataSet11, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView2, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' customerInfoBindingSource
			' 
			Me.customerInfoBindingSource.DataMember = "CustomerInfo"
			Me.customerInfoBindingSource.DataSource = Me.dataSet11
			' 
			' dataSet11
			' 
			Me.dataSet11.DataSetName = "DataSet1"
			Me.dataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
			' 
			' gridControl1
			' 
			Me.gridControl1.DataSource = Me.customerInfoBindingSource
			Me.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.gridControl1.Location = New System.Drawing.Point(0, 0)
			Me.gridControl1.MainView = Me.gridView1
			Me.gridControl1.Name = "gridControl1"
			Me.gridControl1.Size = New System.Drawing.Size(969, 608)
			Me.gridControl1.TabIndex = 0
			Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1, Me.gridView2})
			' 
			' gridView1
			' 
			Me.gridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.colColumn1, Me.colColumn2, Me.colColumn3, Me.colColumn4, Me.colColumn5, Me.colColumn6})
			Me.gridView1.FixedLineWidth = 4
			Me.gridView1.GridControl = Me.gridControl1
			Me.gridView1.Name = "gridView1"
			Me.gridView1.OptionsView.ColumnAutoWidth = False
'			Me.gridView1.CustomDrawGroupRow += New DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(Me.gridView1_CustomDrawGroupRow);
			' 
			' colColumn1
			' 
			Me.colColumn1.Caption = "Column1"
			Me.colColumn1.FieldName = "Column1"
			Me.colColumn1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
			Me.colColumn1.Name = "colColumn1"
			Me.colColumn1.Visible = True
			Me.colColumn1.VisibleIndex = 0
			Me.colColumn1.Width = 200
			' 
			' colColumn2
			' 
			Me.colColumn2.Caption = "Column2"
			Me.colColumn2.FieldName = "Column2"
			Me.colColumn2.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right
			Me.colColumn2.Name = "colColumn2"
			Me.colColumn2.Visible = True
			Me.colColumn2.VisibleIndex = 5
			Me.colColumn2.Width = 200
			' 
			' colColumn3
			' 
			Me.colColumn3.Caption = "Column3"
			Me.colColumn3.FieldName = "Column3"
			Me.colColumn3.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
			Me.colColumn3.Name = "colColumn3"
			Me.colColumn3.Visible = True
			Me.colColumn3.VisibleIndex = 1
			Me.colColumn3.Width = 200
			' 
			' colColumn4
			' 
			Me.colColumn4.Caption = "Column4"
			Me.colColumn4.FieldName = "Column4"
			Me.colColumn4.Name = "colColumn4"
			Me.colColumn4.Visible = True
			Me.colColumn4.VisibleIndex = 2
			Me.colColumn4.Width = 200
			' 
			' colColumn5
			' 
			Me.colColumn5.Caption = "Column5"
			Me.colColumn5.FieldName = "Column5"
			Me.colColumn5.Name = "colColumn5"
			Me.colColumn5.Visible = True
			Me.colColumn5.VisibleIndex = 3
			Me.colColumn5.Width = 200
			' 
			' colColumn6
			' 
			Me.colColumn6.Caption = "Column6"
			Me.colColumn6.FieldName = "Column6"
			Me.colColumn6.Name = "colColumn6"
			Me.colColumn6.Visible = True
			Me.colColumn6.VisibleIndex = 4
			Me.colColumn6.Width = 200
			' 
			' gridView2
			' 
			Me.gridView2.GridControl = Me.gridControl1
			Me.gridView2.Name = "gridView2"
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(969, 608)
			Me.Controls.Add(Me.gridControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.customerInfoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dataSet11, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView2, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private customerInfoBindingSource As System.Windows.Forms.BindingSource
		Private dataSet11 As DataSet1
		Private gridControl1 As DevExpress.XtraGrid.GridControl
		Private WithEvents gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		Private gridView2 As DevExpress.XtraGrid.Views.Grid.GridView
		Private colColumn1 As DevExpress.XtraGrid.Columns.GridColumn
		Private colColumn2 As DevExpress.XtraGrid.Columns.GridColumn
		Private colColumn3 As DevExpress.XtraGrid.Columns.GridColumn
		Private colColumn4 As DevExpress.XtraGrid.Columns.GridColumn
		Private colColumn5 As DevExpress.XtraGrid.Columns.GridColumn
		Private colColumn6 As DevExpress.XtraGrid.Columns.GridColumn
	End Class
End Namespace

