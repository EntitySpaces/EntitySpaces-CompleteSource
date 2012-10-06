Imports System
Imports System.ComponentModel
Imports System.Globalization
Imports System.Windows.Browser


''' <summary>
''' Wraps accessing string resources in a way that Bindings can be set through 
''' XAML (which is not supported when binding to a resource class directly 
''' since they have no public constructors)
''' </summary>
Public NotInheritable Class ResourceWrapper
    Private Shared _applicationStrings As New ApplicationStrings()
    Private Shared _securityQuestions As New SecurityQuestions()

    ''' <summary>
    ''' Gets the <see cref="ApplicationStrings"/>.
    ''' </summary>
    Public ReadOnly Property ApplicationStrings() As ApplicationStrings
        Get
            Return _applicationStrings
        End Get
    End Property

    ''' <summary>
    ''' Gets the <see cref="SecurityQuestions"/>.
    ''' </summary>
    Public ReadOnly Property SecurityQuestions() As SecurityQuestions
        Get
            Return _securityQuestions
        End Get
    End Property
End Class
