Imports System
Imports System.Runtime.Serialization
Imports System.ServiceModel.DomainServices.Client.ApplicationServices
Imports System.Windows
Imports System.Windows.Controls
Imports Silverlight_RiaServices.Controls


''' <summary>
''' Main <see cref="Application"/> class.
''' </summary>
Partial Public Class App
    Inherits Application

    Dim busyIndicator As BusyIndicator

    ''' <summary>
    ''' Creates a new <see cref="App"/> instance.
    ''' </summary>
    Public Sub New()
        InitializeComponent()

        ' Create a WebContext and add it to the ApplicationLifetimeObjects
        ' collection.  This will then be available as WebContext.Current.
        Dim webContext As New WebContext()
        webContext.Authentication = New FormsAuthentication()
        'webContext.Authentication = New WindowsAuthentication()
        Me.ApplicationLifetimeObjects.Add(webContext)
    End Sub

    Private Sub Application_Startup(ByVal sender As Object, ByVal e As StartupEventArgs)
        ' This will enable you to bind controls in XAML files to WebContext.Current
        ' properties
        Me.Resources.Add("WebContext", WebContext.Current)

        ' This will automatically authenticate a user when using windows authentication
        ' or when the user chose "Keep me signed in" on a previous login attempt
        WebContext.Current.Authentication.LoadUser(AddressOf Me.Application_UserLoaded, Nothing)

        ' Show some UI to the user while LoadUser is in progress
        Me.InitializeRootVisual()
    End Sub

    ''' <summary>
    ''' Invoked when the <see cref="LoadUserOperation"/> completes. Use this
    ''' event handler to switch from the "loading UI" you created in
    ''' <see cref="InitializeRootVisual"/> to the "application UI"
    ''' </summary>
    Private Sub Application_UserLoaded(ByVal operation As LoadUserOperation)
    End Sub

    ''' <summary>
    ''' Initializes the <see cref="Application.RootVisual"/> property. The
    ''' initial UI will be displayed before the LoadUser operation has completed
    ''' (The LoadUser operation will cause user to be logged automatically if
    ''' using windows authentication or if the user had selected the "keep
    ''' me signed in" option on a previous login).
    ''' </summary>
    Protected Overridable Sub InitializeRootVisual()
        Me.busyIndicator = New BusyIndicator()
        Me.busyIndicator.Content = New MainPage()
        Me.busyIndicator.HorizontalContentAlignment = HorizontalAlignment.Stretch
        Me.busyIndicator.VerticalContentAlignment = VerticalAlignment.Stretch

        Me.RootVisual = Me.busyIndicator
    End Sub

    Private Sub Application_UnhandledException(ByVal sender As Object, ByVal e As ApplicationUnhandledExceptionEventArgs)
        ' If the app is running outside of the debugger then report the exception using
        ' a ChildWindow control.
        If Not System.Diagnostics.Debugger.IsAttached Then
            ' NOTE: This will allow the application to continue running after an exception has been thrown
            ' but not handled. 
            ' For production applications this error handling should be replaced with something that will 
            ' report the error to the website and stop the application.
            e.Handled = True
            ErrorWindow.CreateNew(e.ExceptionObject)
        End If
    End Sub
End Class