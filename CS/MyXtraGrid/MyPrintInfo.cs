using System;
using DevExpress.XtraGrid.Views.Printing;
using System.Drawing;
using DevExpress.XtraPrinting;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraPrinting.NativeBricks;
using System.Windows.Forms;

namespace MyXtraGrid {
    public class MyPrintInfo : GridViewPrintInfo {

        public MyPrintInfo(PrintInfoArgs args)
            : base(args) {
        }

        private void MakeInflate(ref ITextBrick itb, float offsetByHorizontalAxis, float offsetByVerticalAxis)
        {
            itb.Rect = new RectangleF(itb.Rect.Location, new SizeF(itb.Rect.Width - offsetByHorizontalAxis, itb.Rect.Height - offsetByVerticalAxis));
        }

        public override void PrintHeader(IBrickGraphics graph)
        {
            if (!View.OptionsPrint.PrintHeader) return;

            Point indent = new Point(Indent, HeaderY);
            Rectangle r = Rectangle.Empty;
            bool usePrintStyles = View.OptionsPrint.UsePrintStyles;
            SetDefaultBrickStyle(graph, Bricks["HeaderPanel"]);

            foreach (PrintColumnInfo col in Columns)
            {
                if (!usePrintStyles)
                {
                    AppearanceObject temp = new AppearanceObject();
                    AppearanceHelper.Combine(temp, new AppearanceObject[] { col.Column.AppearanceHeader, View.Appearance.HeaderPanel, AppearancePrint.HeaderPanel });
                    SetDefaultBrickStyle(graph, Bricks.Create(temp, BorderSide.All, temp.BorderColor, 1));
                }
                r = col.Bounds;
                r.Offset(indent);
                string caption = col.Column.GetTextCaption();
                if (!ColumnsInfo[Columns.IndexOf(col)].Column.OptionsColumn.ShowCaption) caption = string.Empty;

                    DevExpress.XtraGrid.Drawing.GridColumnInfoArgs columnsInfo = ColumnsInfo[Columns.IndexOf(col)];
                    DrawElementInfoCollection innerElements = columnsInfo.InnerElements;
                    DrawElementInfo columnImageInfo = null;
                    GlyphElementInfoArgs elementInfo = null;
                    this.ViewViewInfo.Painter.ElementsPainter.Column.CalcObjectBounds(columnsInfo);
                    for (int i = 0; i < innerElements.Count; i++)
                    {
                        if (innerElements[i].ElementInfo is DevExpress.Utils.Drawing.GlyphElementInfoArgs)
                        {
                            columnImageInfo = innerElements[i];
                            elementInfo = columnImageInfo.ElementInfo as GlyphElementInfoArgs;
                            break;
                        }
                    }

                    ITextBrick tBrick = null;
                    if (elementInfo.Glyph == null && elementInfo.ImageIndex < 0)
                    {
                        tBrick = DrawTextBrick(graph, caption, r);

                    }
                    else
                    {
                        IPanelBrick panelBrick = new XETextPanelBrick(graph.DefaultBrickStyle);
                        float offsetForBorder = panelBrick.BorderWidth;

                        if (columnImageInfo.Alignment != StringAlignment.Center)
                        {
                            tBrick = new TextBrick();
                            tBrick.Rect = new RectangleF(offsetForBorder, offsetForBorder, r.Width, r.Height);
                            tBrick.Text = caption;
                            tBrick.Style = graph.DefaultBrickStyle;
                            tBrick.Sides = BorderSide.None;
                            panelBrick.Bricks.Add(tBrick);
                        }
                        
                        panelBrick.Value = caption;
                        Rectangle columnRect = r;
                        Rectangle imageRect = new Rectangle(new Point((int)offsetForBorder, (int)offsetForBorder), elementInfo.GlyphSize);
                        imageRect.Y = r.Y + columnImageInfo.ElementInterval;

                        switch (columnImageInfo.Alignment)
                        {
                            case StringAlignment.Near:
                                tBrick.Rect = new RectangleF(new PointF(imageRect.Location.X + imageRect.Size.Width, tBrick.Rect.Y),tBrick.Rect.Size);
                                MakeInflate(ref tBrick, 2 * offsetForBorder, 2 * offsetForBorder);
                                break;
                            case StringAlignment.Center:
                                {
                                    imageRect.X += (r.Width - imageRect.Width) / 2;
                                }
                                break;
                            case StringAlignment.Far:
                                tBrick.Rect = new RectangleF(tBrick.Rect.Location, new SizeF(tBrick.Rect.Width - imageRect.Width, tBrick.Rect.Height));
                                MakeInflate(ref tBrick, 2 * offsetForBorder, 2 * offsetForBorder);
                                imageRect.X = (int)tBrick.Rect.Right;
                                break;
                        }


                        ImageBrick iBrick = GetImageBrick(imageRect, columnImageInfo);
                        if (iBrick != null)
                            panelBrick.Bricks.Add(iBrick);
                   
                        graph.DrawBrick(panelBrick, columnRect);
                    }
                    

                    if (tBrick == null) continue;

                    if (AppearancePrint.HeaderPanel.TextOptions.WordWrap == WordWrap.NoWrap && View.OptionsPrint.UsePrintStyles)
                    {
                        using (Graphics g = this.View.GridControl.CreateGraphics())
                        {
                            SizeF s = g.MeasureString(tBrick.Text, tBrick.Font, 1000, tBrick.StringFormat.Value);
                            if (s.Width + 5 >= r.Width)
                            {
                                tBrick.Text = "";
                                tBrick.TextValue = "";
                            }
                        }
                    }
            }
        }


        private ImageBrick GetImageBrick(Rectangle rect, DrawElementInfo element)
        {
            ImageBrick ib = new ImageBrick(BorderSide.None, 0, AppearancePrint.HeaderPanel.BorderColor, AppearancePrint.HeaderPanel.BackColor);
            ib.Rect = rect;
            GlyphElementInfoArgs glyphInfo = element.ElementInfo as GlyphElementInfoArgs;

            if (glyphInfo.Glyph != null)
            {
                ib.Image = glyphInfo.Glyph;
            }
            else
            {
                if (glyphInfo.ImageIndex < 0) return null;

                if (glyphInfo.ImageList is ImageCollection)
                {
                    ImageCollection imageList = glyphInfo.ImageList as ImageCollection;
                    ib.Image = imageList.Images[glyphInfo.ImageIndex];
                }
                else if (glyphInfo.ImageList is ImageList)
                {
                    ImageList imageList = glyphInfo.ImageList as ImageList;
                    ib.Image = imageList.Images[glyphInfo.ImageIndex];
                }
                else
                {
                    SharedImageCollection collection = glyphInfo.ImageList as SharedImageCollection;
                    ib.Image = collection.ImageSource.Images[glyphInfo.ImageIndex];
                }
            }
       
            return ib;
        }
    }
}
