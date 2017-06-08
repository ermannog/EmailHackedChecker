Public Class QueryOutputResultEmailNotFoundAddedEventArgs
    Inherits System.EventArgs

    Public Sub New(text As String, result As QueryResult)
        MyBase.New()
        Me.textValue = text
        Me.resultValue = result
    End Sub

#Region "Property Text"
    Private textValue As String = String.Empty
    Public ReadOnly Property Text As String
        Get
            Return Me.textValue
        End Get
    End Property
#End Region

#Region "Property Result"
    Private resultValue As QueryResult = Nothing
    Public ReadOnly Property Result As QueryResult
        Get
            Return Me.resultValue
        End Get
    End Property
#End Region
End Class