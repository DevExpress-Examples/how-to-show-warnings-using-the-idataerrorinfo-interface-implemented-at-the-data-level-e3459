<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/MainWindow.xaml.vb))
<!-- default file list end -->
# How to display notifications by implementing the IDataErrorInfo interface


<p>Please implement the IDataErrorInfo interface on the data object. Then, pass the text and type of error in the IDataErrorInfo.Error property ( it is possible to easily parse this string). Implement a custom style for the ErrorControl. This element presents the error icon. Modify the ErrorControl style in such a way as to take into account a custom error type and text (use the converter).</p><p><br />
</p>

<br/>


