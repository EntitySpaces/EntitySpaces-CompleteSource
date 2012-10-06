Imports System
Imports System.Runtime.CompilerServices
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data

Public Module DataFieldExtensions
    ''' <summary>
    ''' Replaces a <see cref="DataField" />'s <see cref="TextBox" /> control with another control,
    ''' and updates the bindings
    ''' </summary>
    ''' <param name="field">The <see cref="DataField"/> whose <see cref="TextBox"/> will be replaced.</param>
    ''' <param name="newControl">The new control you're going to set as <see cref="DataField.Content" />.</param>
    ''' <param name="dataBindingProperty">The control's property that will be used for data binding.</param>        
    ''' <param name="bindingSetupFunction">
    '''  An optional <c>Action</c> you can use to change parameters on the newly generated binding before
    '''  it is applied to <paramref name="newControl"/>
    ''' </param>
    <Extension()> _
    Public Sub ReplaceTextBox(ByVal field As DataField, ByVal newControl As FrameworkElement, ByVal dataBindingProperty As DependencyProperty, _
                              Optional ByVal bindingSetupFunction As Action(Of Binding) = Nothing)
        If field Is Nothing Then
            Throw New ArgumentNullException("field")
        End If

        If newControl Is Nothing Then
            Throw New ArgumentNullException("newControl")
        End If

        ' Construct new binding by copying existing one, and passing it to a user given function (if any)
        Dim newBinding As Binding = field.Content.GetBindingExpression(TextBox.TextProperty).ParentBinding.CreateCopy()

        If bindingSetupFunction IsNot Nothing Then
            bindingSetupFunction(newBinding)
        End If

        ' Replace field
        newControl.SetBinding(dataBindingProperty, newBinding)
        field.Content = newControl
    End Sub
End Module

