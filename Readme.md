<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128644993/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3459)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WPF Editors - Indicate Errors and Warnings by Implementing IDataErrorInfo

Please implement the `IDataErrorInfo` interface on the data object. Then, pass the text and type of error in the `IDataErrorInfo.Error` property ( it is possible to easily parse this string). Implement a custom style for the `ErrorControl`. This element presents the error icon. Modify the `ErrorControl` style in such a way as to take into account a custom error type and text (use the converter).

## Implementation Details

...

## Files to Review

* [MainWindow.xaml](./CS/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/MainWindow.xaml.vb))

## Documentation

* [TextEdit](https://docs.devexpress.com/WPF/DevExpress.Xpf.Editors.TextEdit)
* [EditValue](https://docs.devexpress.com/WPF/DevExpress.Xpf.Editors.BaseEdit.EditValue)
* [ErrorToolTipContentTemplate](https://docs.devexpress.com/WPF/DevExpress.Xpf.Editors.BaseEdit.ErrorToolTipContentTemplate)
* [ErrorContent](https://docs.devexpress.com/WPF/DevExpress.Xpf.Editors.Validation.BaseValidationError.ErrorContent)

## More Examples

* [WPF Data Editors - Create a Registration Form](https://github.com/DevExpress-Examples/wpf-data-editors-create-registration-form)
* [WPF Data Editors - Allow Users to Enter Only Positive Numbers](https://github.com/DevExpress-Examples/wpf-editors-prevent-negative-values)
* [WPF Data Grid - Use Custom Editors to Edit Cell Values](https://github.com/DevExpress-Examples/wpf-data-grid-use-custom-editors-to-edit-cell-values)
* [WPF Data Grid - How to Validate Cell Editors](https://github.com/DevExpress-Examples/wpf-data-grid-validate-cell-editors)

<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-editors-validate-user-input-indicate-errors-idataerrorinfo&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-editors-validate-user-input-indicate-errors-idataerrorinfo&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
