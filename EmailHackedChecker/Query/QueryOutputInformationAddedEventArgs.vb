Public Class QueryOutputInformationAddedEventArgs
    Inherits System.EventArgs

    Public Sub New(text As String)
        MyBase.New()
        Me.textValue = text
    End Sub

#Region "Property Text"
    Private textValue As String = String.Empty
    Public ReadOnly Property Text As String
        Get
            Return Me.textValue
        End Get
    End Property
#End Region
End Class
