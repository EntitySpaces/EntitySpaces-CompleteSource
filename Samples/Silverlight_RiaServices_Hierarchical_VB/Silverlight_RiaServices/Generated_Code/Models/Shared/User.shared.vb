Namespace Web

    Partial Public Class User
        ''' <summary>
        ''' Returns the user display name, which by default is its Friendly Name,
        ''' and if that is not set, its User Name
        ''' </summary>
        Public ReadOnly Property DisplayName() As String
            Get
                If Not String.IsNullOrEmpty(Me.FriendlyName) Then
                    Return Me.FriendlyName
                Else
                    Return Me.Name
                End If
            End Get
        End Property
    End Class
End Namespace