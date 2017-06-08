Public Class QueryOutputErrorAddedEventArgs
    Inherits System.EventArgs

    Public Sub New(text As String, ex As System.Exception)
        MyBase.New()
        Me.textValue = text
        Me.exceptionValue = ex
    End Sub

#Region "Property Text"
    Private textValue As String = String.Empty
    Public ReadOnly Property Text As String
        Get
            Return Me.textValue
        End Get
    End Property
#End Region

#Region "Property Exception"
    Private exceptionValue As System.Exception = Nothing
    Public ReadOnly Property Exception As System.Exception
        Get
            Return Me.exceptionValue
        End Get
    End Property
#End Region
End Class

