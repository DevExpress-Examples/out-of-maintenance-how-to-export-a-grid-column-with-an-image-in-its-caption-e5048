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

namespace MyXtraGrid {
	public class MyGridView : DevExpress.XtraGrid.Views.Grid.GridView {
        public MyGridView() : this(null) { }
		public MyGridView(DevExpress.XtraGrid.GridControl grid) : base(grid) {
			// put your initialization code here
		}
		protected override string ViewName { get { return "MyGridView"; } }

        protected override DevExpress.XtraGrid.Views.Printing.BaseViewPrintInfo CreatePrintInfoInstance(DevExpress.XtraGrid.Views.Printing.PrintInfoArgs args) {
            return new MyPrintInfo(args);
        }


	}
}