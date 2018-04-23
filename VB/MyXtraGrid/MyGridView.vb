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

Namespace MyXtraGrid
	Public Class MyGridView
		Inherits DevExpress.XtraGrid.Views.Grid.GridView
		Public Sub New()
			Me.New(Nothing)
		End Sub
		Public Sub New(ByVal grid As DevExpress.XtraGrid.GridControl)
			MyBase.New(grid)
			' put your initialization code here
		End Sub
		Protected Overrides ReadOnly Property ViewName() As String
			Get
				Return "MyGridView"
			End Get
		End Property

		Protected Overrides Function CreatePrintInfoInstance(ByVal args As DevExpress.XtraGrid.Views.Printing.PrintInfoArgs) As DevExpress.XtraGrid.Views.Printing.BaseViewPrintInfo
			Return New MyPrintInfo(args)
		End Function


	End Class
End Namespace