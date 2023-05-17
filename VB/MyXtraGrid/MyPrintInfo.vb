Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.XtraGrid.Views.Printing
Imports System.Drawing
Imports DevExpress.XtraPrinting
Imports DevExpress.Utils
Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraPrinting.NativeBricks
Imports System.Windows.Forms

Namespace MyXtraGrid
	Public Class MyPrintInfo
		Inherits GridViewPrintInfo

		Public Sub New(ByVal args As PrintInfoArgs)
			MyBase.New(args)
		End Sub

		Private Sub MakeInflate(ByRef itb As TextBrick, ByVal offsetByHorizontalAxis As Single, ByVal offsetByVerticalAxis As Single)
			itb.Rect = New RectangleF(itb.Rect.Location, New SizeF(itb.Rect.Width - offsetByHorizontalAxis, itb.Rect.Height - offsetByVerticalAxis))
		End Sub

		Public Overrides Sub PrintHeader(ByVal graph As BrickGraphics)
			If (Not View.OptionsPrint.PrintHeader) Then
				Return
			End If

            Dim indentByBothAxes As New Point(Indent, HeaderY)
			Dim r As Rectangle = Rectangle.Empty
			Dim usePrintStyles As Boolean = View.OptionsPrint.UsePrintStyles
			SetDefaultBrickStyle(graph, Bricks("HeaderPanel"))

			For Each col As PrintColumnInfo In Columns
				If (Not usePrintStyles) Then
					Dim temp As New AppearanceObject()
					AppearanceHelper.Combine(temp, New AppearanceObject() { col.Column.AppearanceHeader, View.Appearance.HeaderPanel, AppearancePrint.HeaderPanel })
					SetDefaultBrickStyle(graph, Bricks.Create(temp, BorderSide.All, temp.BorderColor, 1))
				End If
				r = col.Bounds
                r.Offset(indentByBothAxes)
				Dim caption As String = col.Column.GetTextCaption()
				If (Not ColumnsInfo(Columns.IndexOf(col)).Column.OptionsColumn.ShowCaption) Then
					caption = String.Empty
				End If

                Dim columnInfo As DevExpress.XtraGrid.Drawing.GridColumnInfoArgs = ColumnsInfo(Columns.IndexOf(col))
                Dim innerElements As DrawElementInfoCollection = columnInfo.InnerElements
                Dim columnImageInfo As DrawElementInfo = Nothing
                Dim elementInfo As GlyphElementInfoArgs = Nothing
                Me.ViewViewInfo.Painter.ElementsPainter.Column.CalcObjectBounds(columnInfo)
                For i As Integer = 0 To innerElements.Count - 1
                    If TypeOf innerElements(i).ElementInfo Is DevExpress.Utils.Drawing.GlyphElementInfoArgs Then
                        columnImageInfo = innerElements(i)
                        elementInfo = TryCast(columnImageInfo.ElementInfo, GlyphElementInfoArgs)
                        Exit For
                    End If
                Next i

                Dim tBrick As TextBrick = Nothing
                If elementInfo.Glyph Is Nothing AndAlso elementInfo.ImageIndex < 0 Then
                    tBrick = DrawTextBrick(graph, caption, r)

                Else
                    Dim panelBrick As PanelBrick = New XETextPanelBrick(graph.DefaultBrickStyle)
                    Dim offsetForBorder As Single = panelBrick.BorderWidth

                    If columnImageInfo.Alignment <> StringAlignment.Center Then
                        tBrick = New TextBrick()
                        tBrick.Rect = New RectangleF(offsetForBorder, offsetForBorder, r.Width, r.Height)
                        tBrick.Text = caption
                        tBrick.Style = graph.DefaultBrickStyle
                        tBrick.Sides = BorderSide.None
                        panelBrick.Bricks.Add(tBrick)
                    End If

                    panelBrick.Value = caption
                    Dim columnRect As Rectangle = r
                    Dim imageRect As New Rectangle(New Point(CInt(Fix(offsetForBorder)), CInt(Fix(offsetForBorder))), elementInfo.GlyphSize)
                    imageRect.Y = r.Y + columnImageInfo.ElementInterval

                    Select Case columnImageInfo.Alignment
                        Case StringAlignment.Near
                            tBrick.Rect = New RectangleF(New PointF(imageRect.Location.X + imageRect.Size.Width, tBrick.Rect.Y), tBrick.Rect.Size)
                            MakeInflate(tBrick, 2 * offsetForBorder, 2 * offsetForBorder)
                        Case StringAlignment.Center
                            imageRect.X += CInt((r.Width - imageRect.Width) / 2)
                        Case StringAlignment.Far
                            tBrick.Rect = New RectangleF(tBrick.Rect.Location, New SizeF(tBrick.Rect.Width - imageRect.Width, tBrick.Rect.Height))
                            MakeInflate(tBrick, 2 * offsetForBorder, 2 * offsetForBorder)
                            imageRect.X = CInt(Fix(tBrick.Rect.Right))
                    End Select


                    Dim iBrick As ImageBrick = GetImageBrick(imageRect, columnImageInfo)
                    If iBrick IsNot Nothing Then
                        panelBrick.Bricks.Add(iBrick)
                    End If

                    graph.DrawBrick(panelBrick, columnRect)
                End If


					If tBrick Is Nothing Then
						Continue For
					End If

					If AppearancePrint.HeaderPanel.TextOptions.WordWrap = WordWrap.NoWrap AndAlso View.OptionsPrint.UsePrintStyles Then
						Using g As Graphics = Me.View.GridControl.CreateGraphics()
							Dim s As SizeF = g.MeasureString(tBrick.Text, tBrick.Font, 1000, tBrick.StringFormat.Value)
							If s.Width + 5 >= r.Width Then
								tBrick.Text = ""
								tBrick.TextValue = ""
							End If
						End Using
					End If
			Next col
		End Sub


		Private Function GetImageBrick(ByVal rect As Rectangle, ByVal element As DrawElementInfo) As ImageBrick
			Dim ib As New ImageBrick(BorderSide.None, 0, AppearancePrint.HeaderPanel.BorderColor, AppearancePrint.HeaderPanel.BackColor)
			ib.Rect = rect
			Dim glyphInfo As GlyphElementInfoArgs = TryCast(element.ElementInfo, GlyphElementInfoArgs)

			If glyphInfo.Glyph IsNot Nothing Then
				ib.Image = glyphInfo.Glyph
			Else
				If glyphInfo.ImageIndex < 0 Then
					Return Nothing
				End If

				If TypeOf glyphInfo.ImageList Is ImageCollection Then
					Dim imageList As ImageCollection = TryCast(glyphInfo.ImageList, ImageCollection)
					ib.Image = imageList.Images(glyphInfo.ImageIndex)
				ElseIf TypeOf glyphInfo.ImageList Is ImageList Then
					Dim imageList As ImageList = TryCast(glyphInfo.ImageList, ImageList)
					ib.Image = imageList.Images(glyphInfo.ImageIndex)
				Else
					Dim collection As SharedImageCollection = TryCast(glyphInfo.ImageList, SharedImageCollection)
					ib.Image = collection.ImageSource.Images(glyphInfo.ImageIndex)
				End If
			End If

			Return ib
		End Function
	End Class
End Namespace
