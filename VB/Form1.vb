Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraBars
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.Utils.Drawing
Imports DevExpress.Utils
Imports DevExpress.XtraVerticalGrid
Imports System.Reflection
Imports DevExpress.XtraVerticalGrid.Painters
Imports System.Collections
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Drawing
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.Utils.Text

Namespace WindowsApplication3
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Public Sub InitData()
			For i As Integer = 0 To 4
				If i Mod 2 = 0 Then
					dataSet11.Tables(0).Rows.Add(New Object() { i, i * 10, 0, i+100, i+10, i*100})
				Else
					dataSet11.Tables(0).Rows.Add(New Object() { i, i, 1, i, i, i })
				End If
			Next i
		End Sub



		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Me.InitData()
			gridControl1.ForceInitialize()
			gridView1.OptionsView.ShowFooter = True
			For i As Integer = 1 To 6
			   Dim item As New GridGroupSummaryItem()
			   item.FieldName = "Column" & i.ToString()
			   item.SummaryType = DevExpress.Data.SummaryItemType.Sum
			   item.DisplayFormat = "Sum {0:n0}"
			   gridView1.GroupSummary.Add(item)
			Next i
			gridView1.BeginSort()
			Try
				gridView1.ClearGrouping()
				gridView1.Columns("Column3").GroupIndex = 0
			Finally
				gridView1.EndSort()
			End Try
		End Sub

		Private Sub gridView1_CustomDrawGroupRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles gridView1.CustomDrawGroupRow
		   Dim view As GridView = TryCast(sender, GridView)
			Dim items As ArrayList = ExtractSummaryItems(view)
			If items.Count = 0 Then
				Return
			End If
			DrawBackground(e, view)
			DrawSummaryValues(e, view, items)
			e.Handled = True
		End Sub
		Private Function ExtractSummaryItems(ByVal view As GridView) As ArrayList
			Dim items As New ArrayList()
			For Each si As GridSummaryItem In view.GroupSummary
				If TypeOf si Is GridGroupSummaryItem AndAlso si.SummaryType <> DevExpress.Data.SummaryItemType.None Then
					items.Add(si)
				End If
			Next si
			Return items
		End Function

		Private Sub DrawBackground(ByVal e As RowObjectCustomDrawEventArgs, ByVal view As GridView)
			Dim painter As GridGroupRowPainter
			Dim info As GridGroupRowInfo
			painter = TryCast(e.Painter, GridGroupRowPainter)
			info = TryCast(e.Info, GridGroupRowInfo)
			Dim level As Integer = view.GetRowLevel(e.RowHandle)
			Dim row As Integer = view.GetDataRowHandleByGroupRowHandle(e.RowHandle)
			info.GroupText = String.Format("{0}: {1}", view.GroupedColumns(level).Caption, view.GetRowCellDisplayText(row, view.GroupedColumns(level)))
			e.Appearance.DrawBackground(e.Cache, info.Bounds)
			painter.ElementsPainter.GroupRow.DrawObject(info)
		End Sub

		Private Sub DrawSummaryValues(ByVal e As RowObjectCustomDrawEventArgs, ByVal view As GridView, ByVal items As ArrayList)
			Dim values As Hashtable = view.GetGroupSummaryValues(e.RowHandle)
			For Each item As GridGroupSummaryItem In items
				Dim rect As Rectangle = GetColumnBounds(view, item)
				If rect.IsEmpty Then
					Continue For
				End If
				Dim text As String = item.GetDisplayText(values(item), False)
				rect = CalcSummaryRect(text, e, view.Columns(item.FieldName))
				e.Appearance.DrawString(e.Cache, text, rect)
			Next item
		End Sub

		Private Function GetColumnBounds(ByVal view As GridView, ByVal item As GridGroupSummaryItem) As Rectangle
			Dim column As GridColumn = view.Columns(item.FieldName)
			Return GetColumnBounds(column)
		End Function
		Private gridInfo As GridViewInfo = Nothing
		Private Function GetColumnBounds(ByVal column As GridColumn) As Rectangle
			gridInfo = CType(column.View.GetViewInfo(), GridViewInfo)
			Dim colInfo As GridColumnInfoArgs = gridInfo.ColumnsInfo(column)

			If colInfo IsNot Nothing Then
				Return colInfo.Bounds
			Else
				Return Rectangle.Empty
			End If
		End Function

		Private Function CalcSummaryRect(ByVal text As String, ByVal e As RowObjectCustomDrawEventArgs, ByVal column As GridColumn) As Rectangle
			Dim result As Rectangle = GetColumnBounds(column)
			Dim sz As SizeF = TextUtils.GetStringSize(e.Graphics, text, e.Appearance.Font)
			Dim width As Integer = Convert.ToInt32(sz.Width) + 1
			If (Not gridInfo.ViewRects.FixedLeft.IsEmpty) Then
				Dim fixedLeftRight As Integer = gridInfo.ViewRects.FixedLeft.Right
				Dim marginLeft As Integer = result.Right - width - fixedLeftRight
				If marginLeft < 0 AndAlso column.Fixed = FixedStyle.None Then
					Return Rectangle.Empty
				End If
			End If
			If (Not gridInfo.ViewRects.FixedRight.IsEmpty) Then
				Dim fixedRightLeft As Integer = gridInfo.ViewRects.FixedRight.Left
				If fixedRightLeft <= result.Right AndAlso column.Fixed = FixedStyle.None Then
					Return Rectangle.Empty
				End If
			End If
			result = FixLeftEdge(width, result)
			result.Width = result.Width
			result.Y = e.Bounds.Y
			result.Height = e.Bounds.Height - 2

			Return PreventSummaryTextOverlapping(e, result)
		End Function

		Private Function FixLeftEdge(ByVal width As Integer, ByVal result As Rectangle) As Rectangle
			Dim delta As Integer = result.Width - width - 2
			If delta > 0 Then
				result.X += delta
				result.Width -= delta
			End If
			Return result
		End Function

		Private Function PreventSummaryTextOverlapping(ByVal e As RowObjectCustomDrawEventArgs, ByVal rect As Rectangle) As Rectangle
			Dim gInfo As GridGroupRowInfo = CType(e.Info, GridGroupRowInfo)
			Dim groupTextLocation As Integer = gInfo.ButtonBounds.Right + 10
			Dim groupTextWidth As Integer = TextUtils.GetStringSize(e.Graphics, gInfo.GroupText, e.Appearance.Font).Width
			Dim fixedLeft As Integer = gInfo.ViewInfo.ViewRects.FixedLeft.Left
			Dim r As New Rectangle(groupTextLocation, 0, groupTextWidth, e.Info.Bounds.Height)
			If r.Right > rect.X Then
				If r.Right > rect.Right Then
					rect.Width = 0
				Else
					rect.Width -= r.Right - rect.X
					rect.X = r.Right
				End If
			End If
			Return rect
		End Function
	End Class
End Namespace
