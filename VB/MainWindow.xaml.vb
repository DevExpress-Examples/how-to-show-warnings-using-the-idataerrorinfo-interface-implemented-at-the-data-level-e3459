Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Editors
Imports System.ComponentModel

Namespace WpfApplication147
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub

	End Class

	Public Class TestClass
		Implements IDataErrorInfo, INotifyPropertyChanged
		Private testString_Renamed As String
		Public Property TestString() As String
			Get
				Return testString_Renamed
			End Get
			Set(ByVal value As String)
				testString_Renamed = value
				RaisePropertyChanged("TestString")
			End Set
		End Property


		#Region "INotifyPropertyChanged Members"

		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
		Private Sub RaisePropertyChanged(ByVal [property] As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs([property]))
		End Sub

		#End Region

		#Region "IDataErrorInfo Members"

		Private ReadOnly Property IDataErrorInfo_Error() As String Implements IDataErrorInfo.Error
			Get
				Return GetError()
			End Get
		End Property
		Private Function GetError() As String
			If String.IsNullOrEmpty(TestString) Then
				Return "ErrorType=Critical;ErrorContent=empty"
			End If
			If TestString.Length < 3 Then
				Return "ErrorType=Critical;ErrorContent=error"
			End If
			If TestString.Length < 5 Then
				Return "ErrorType=Information;ErrorContent=warning"
			End If
			Return String.Empty
		End Function
		Public ReadOnly Property IDataErrorInfo_Item(ByVal columnName As String) As String Implements IDataErrorInfo.Item
			Get
				If columnName = "TestString" Then
					Return GetError()
				End If
				Return String.Empty
			End Get
		End Property

		#End Region
	End Class
	Public Class ErrorContentConverter
		Implements IValueConverter
		Private privateGetValueTag As String
		Public Property GetValueTag() As String
			Get
				Return privateGetValueTag
			End Get
			Set(ByVal value As String)
				privateGetValueTag = value
			End Set
		End Property
		Private privateSeparator As String
		Public Property Separator() As String
			Get
				Return privateSeparator
			End Get
			Set(ByVal value As String)
				privateSeparator = value
			End Set
		End Property

		#Region "IValueConverter Members"
		Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.Convert
			If value Is Nothing OrElse Not(TypeOf value Is String) Then
				Return value
			End If
			Dim [error] As String = System.Convert.ToString(value, culture)
			If String.IsNullOrEmpty([error]) Then
				Return value
			End If

			Dim searchString As String = GetValueTag & "="
			For Each suberror As String In [error].Split(New String() { Separator }, StringSplitOptions.RemoveEmptyEntries)
				If suberror.Contains(searchString) Then
					Return suberror.Replace(searchString, String.Empty)
				End If
			Next suberror
			Return value
		End Function
		Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
			Return Nothing
		End Function

		#End Region
	End Class
End Namespace
