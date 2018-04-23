using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Editors;
using System.ComponentModel;

namespace WpfApplication147 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

    }

    public class TestClass : IDataErrorInfo, INotifyPropertyChanged {
        string testString;
        public string TestString {
            get { return testString; }
            set {
                testString = value;
                RaisePropertyChanged("TestString");
            }
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string property) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        #endregion

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error {
            get { return GetError(); }
        }
        string GetError() {
            if (string.IsNullOrEmpty(TestString))
                return "ErrorType=Critical;ErrorContent=empty";
            if (TestString.Length < 3)
                return "ErrorType=Critical;ErrorContent=error";
            if (TestString.Length < 5)
                return "ErrorType=Information;ErrorContent=warning";
            return string.Empty;
        }
        string IDataErrorInfo.this[string columnName] {
            get {
                if (columnName == "TestString")
                    return GetError();
                return string.Empty;
            }
        }

        #endregion
    }
    public class ErrorContentConverter : IValueConverter {
        public string GetValueTag { get; set; }
        public string Separator { get; set; }

        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            if (value == null || !(value is string))
                return value;
            string error = System.Convert.ToString(value, culture);
            if (string.IsNullOrEmpty(error))
                return value;

            string searchString = GetValueTag + "=";
            foreach (string suberror in error.Split(new string[] { Separator }, StringSplitOptions.RemoveEmptyEntries)) {
                if (suberror.Contains(searchString))
                    return suberror.Replace(searchString, string.Empty);
            }
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            return null;
        }

        #endregion
    }
}
