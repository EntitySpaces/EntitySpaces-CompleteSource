Imports System
Imports System.Windows.Data

''' <summary>
''' Two way IValueConverter that lets you bind a property on a bindable object
''' to a dependency property when the dependency property treats empty as null
''' and the object property treats empty as the empty string
''' </summary>
Public Class TargetNullValueConverter
    Implements IValueConverter

    ''' <summary>
    ''' Converts <c>null</c> or empty strings to <c>null</c>.
    ''' </summary>
    ''' <param name="value">The value to convert.</param>
    ''' <param name="targetType">The expected type of the result (ignored).</param>
    ''' <param name="parameter">Optional parameter (ignored).</param>
    ''' <param name="culture">The culture for the conversion (ignored).</param>
    ''' <returns>If the <paramref name="value"/>is <c>null</c> or empty, this method returns <c>null</c> otherwise it returns the <paramref name="value"/>.</returns>
    Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.Convert
        Dim strValue As String = Nothing

        If TypeOf value Is String Then
            strValue = DirectCast(value, String)
        End If

        Return If(String.IsNullOrEmpty(strValue), Nothing, value)
    End Function

    ''' <summary>
    ''' Converts <c>null</c> back to <see cref="String.Empty"/>.
    ''' </summary>
    ''' <param name="value">The value to convert.</param>
    ''' <param name="targetType">The expected type of the result (ignored).</param>
    ''' <param name="parameter">Optional parameter (ignored).</param>
    ''' <param name="culture">The culture for the conversion (ignored).</param>
    ''' <returns>If <paramref name="value"/> is <c>null</c>, it returns <see cref="String.Empty"/> otherwise <paramref name="value"/>.</returns>
    Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
        Return If(value Is Nothing, String.Empty, value)
    End Function
End Class