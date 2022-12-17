Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.ComponentModel

Namespace WpfApplication147

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
        End Sub
    End Class

    Public Class TestClass
        Implements IDataErrorInfo, INotifyPropertyChanged

        Private testStringField As String

        Public Property TestString As String
            Get
                Return testStringField
            End Get

            Set(ByVal value As String)
                testStringField = value
                RaisePropertyChanged("TestString")
            End Set
        End Property

'#Region "INotifyPropertyChanged Members"
        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

        Private Sub RaisePropertyChanged(ByVal [property] As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs([property]))
        End Sub

'#End Region
'#Region "IDataErrorInfo Members"
        Private ReadOnly Property [Error] As String Implements IDataErrorInfo.[Error]
            Get
                Return GetError()
            End Get
        End Property

        Private Function GetError() As String
            If String.IsNullOrEmpty(TestString) Then Return "ErrorType=Critical;ErrorContent=empty"
            If TestString.Length < 3 Then Return "ErrorType=Critical;ErrorContent=error"
            If TestString.Length < 5 Then Return "ErrorType=Information;ErrorContent=warning"
            Return String.Empty
        End Function

        Private ReadOnly Property Item(ByVal columnName As String) As String Implements IDataErrorInfo.Item
            Get
                If Equals(columnName, "TestString") Then Return GetError()
                Return String.Empty
            End Get
        End Property
'#End Region
    End Class

    Public Class ErrorContentConverter
        Implements IValueConverter

        Public Property GetValueTag As String

        Public Property Separator As String

'#Region "IValueConverter Members"
        Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As Globalization.CultureInfo) As Object Implements IValueConverter.Convert
            If value Is Nothing OrElse Not(TypeOf value Is String) Then Return value
            Dim [error] As String = System.Convert.ToString(value, culture)
            If String.IsNullOrEmpty([error]) Then Return value
            Dim searchString As String = GetValueTag & "="
            For Each suberror As String In [error].Split(New String() {Separator}, StringSplitOptions.RemoveEmptyEntries)
                If suberror.Contains(searchString) Then Return suberror.Replace(searchString, String.Empty)
            Next

            Return value
        End Function

        Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
            Return Nothing
        End Function
'#End Region
    End Class
End Namespace
