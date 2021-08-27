<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128628664/18.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E5048)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/MyXtraGrid/Form1.cs) (VB: [Form1.vb](./VB/MyXtraGrid/Form1.vb))
* [MyGridControl.cs](./CS/MyXtraGrid/MyGridControl.cs) (VB: [MyGridControl.vb](./VB/MyXtraGrid/MyGridControl.vb))
* [MyGridRegistration.cs](./CS/MyXtraGrid/MyGridRegistration.cs) (VB: [MyGridRegistration.vb](./VB/MyXtraGrid/MyGridRegistration.vb))
* [MyGridView.cs](./CS/MyXtraGrid/MyGridView.cs) (VB: [MyGridView.vb](./VB/MyXtraGrid/MyGridView.vb))
* [MyPrintInfo.cs](./CS/MyXtraGrid/MyPrintInfo.cs) (VB: [MyPrintInfo.vb](./VB/MyXtraGrid/MyPrintInfo.vb))
<!-- default file list end -->
# How to export a grid column with an image in its caption


<p>This example demonstrates how to create a GridControl descendant which allows exporting columns with an icon in its header. To accomplish this task, it is necessary to override the PrintHeader method in the custom GridViewPrintInfo class.</p><p><strong>Note:</strong> GridControl does not export images (include the column headers images) to Excel for performance reason. Refer to the <u><a href="https://community.devexpress.com/blogs/ctodx/archive/2011/04/05/sneak-peek-improving-the-performance-and-memory-footprint-of-excel-and-pdf-export-from-winforms-grid-coming-in-v2011-1.aspx">https://community.devexpress.com/blogs/ctodx/archive/2011/04/05/sneak-peek-improving-the-performance-and-memory-footprint-of-excel-and-pdf-export-from-winforms-grid-coming-in-v2011-1.aspx</a></u> blog for details.</p><p></p>

<br/>


