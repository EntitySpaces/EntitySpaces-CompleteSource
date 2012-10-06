Imports System
Imports System.ComponentModel.DataAnnotations
Imports System.ServiceModel.DomainServices.Client.ApplicationServices
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Input
Imports Silverlight_RiaServices.Controls

Namespace LoginUI
    ''' <summary>
    ''' Form that presents the login fields and handles the login process.
    ''' </summary>
    Partial Public Class LoginForm
        Inherits StackPanel
        Private parentWindow As LoginRegistrationWindow
        Private loginInfo As New LoginInfo()

        ''' <summary>
        ''' Creates a new <see cref="LoginForm"/> instance.
        ''' </summary>
        Public Sub New()
            InitializeComponent()

            ' Set the DataContext of this control to the
            ' LoginInfo instance to allow for easy binding
            Me.DataContext = loginInfo
        End Sub

        ''' <summary>
        ''' Sets the parent window for the current <see cref="LoginForm"/>.
        ''' </summary>
        ''' <param name="window">The window to use as the parent.</param>
        Public Sub SetParentWindow(ByVal window As LoginRegistrationWindow)
            Me.parentWindow = window
        End Sub

        ''' <summary>
        ''' Handles <see cref="DataForm.AutoGeneratingField"/> to provide the PasswordAccessor.
        ''' </summary>
        Private Sub LoginForm_AutoGeneratingField(ByVal sender As Object, ByVal e As DataFormAutoGeneratingFieldEventArgs)
            If e.PropertyName = "Password" Then
                Dim passwordBox As PasswordBox = DirectCast(e.Field.Content, PasswordBox)
                loginInfo.PasswordAccessor = Function() passwordBox.Password
            End If
        End Sub

        ''' <summary>
        ''' Submits the <see cref="LoginOperation"/> to the server
        ''' </summary>
        Private Sub LoginButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' We need to force validation since we are not using the standard OK
            ' button from the DataForm.  Without ensuring the form is valid, we
            ' would get an exception invoking the operation if the entity is invalid.
            If Me.loginForm.ValidateItem() Then
                loginInfo.CurrentLoginOperation = WebContext.Current.Authentication.Login(loginInfo.ToLoginParameters(), AddressOf Me.LoginOperation_Completed, Nothing)
                parentWindow.AddPendingOperation(loginInfo.CurrentLoginOperation)
            End If
        End Sub

        ''' <summary>
        ''' Completion handler for a <see cref="LoginOperation"/>. If operation succeeds,
        ''' it closes the window. If it has an error, we show an <see cref="ErrorWindow"/>
        ''' and mark the error as handled. If it was not canceled, but login failed, it must
        ''' have been because credentials were incorrect so we add a validation error to
        ''' to notify the user.
        ''' </summary>        
        Private Sub LoginOperation_Completed(ByVal loginOperation As LoginOperation)
            If loginOperation.LoginSuccess Then
                parentWindow.Close()
            ElseIf loginOperation.HasError Then
                ErrorWindow.CreateNew(loginOperation.Error)
                loginOperation.MarkErrorAsHandled()
            ElseIf Not loginOperation.IsCanceled Then
                loginInfo.ValidationErrors.Add(New ValidationResult(ErrorResources.ErrorBadUserNameOrPassword, New String() {"UserName", "Password"}))
            End If
        End Sub

        ''' <summary>
        ''' Switches to the registration form.
        ''' </summary>
        Private Sub RegisterNow_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            parentWindow.NavigateToRegistration()
        End Sub

        ''' <summary>
        ''' If a login operation is in progress and is cancellable, cancel it.
        ''' Otherwise, close the window.
        ''' </summary>
        Private Sub CancelButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Not IsNothing(loginInfo.CurrentLoginOperation)) AndAlso loginInfo.CurrentLoginOperation.CanCancel Then
                loginInfo.CurrentLoginOperation.Cancel()
            Else
                parentWindow.Close()
            End If
        End Sub

        ''' <summary>
        ''' Maps Esc to the cancel button and Enter to the OK button.
        ''' </summary>
        Private Sub LoginForm_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
            If e.Key = Key.Escape Then
                Me.CancelButton_Click(sender, e)
            ElseIf e.Key = Key.Enter AndAlso Me.loginButton.IsEnabled Then
                Me.LoginButton_Click(sender, e)
            End If
        End Sub
    End Class
End Namespace