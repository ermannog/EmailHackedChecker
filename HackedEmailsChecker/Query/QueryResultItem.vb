Public Class QueryResultItem
    ' Methods
    Public Sub New(ByVal title As String, ByVal description As String, ByVal dataLeakDate As DateTime?, ByVal dataLeakPublicationDate As DateTime?, ByVal additionalInformation As String)
        Me.titleValue = title
        Me.descriptionValue = description
        Me.dataLeakDateValue = dataLeakDate
        Me.dataLeakPublicationDateValue = dataLeakPublicationDate
        If Not String.IsNullOrWhiteSpace(additionalInformation) Then
            Me.additionalInformationValue = additionalInformation
        End If
    End Sub

    Private additionalInformationValue As String = "Not specified"
    Public ReadOnly Property AdditionalInformation As String
        Get
            Return Me.additionalInformationValue
        End Get
    End Property

    Private dataLeakDateValue As DateTime? = Nothing
    Public ReadOnly Property DataLeakDate As DateTime?
        Get
            Return Me.dataLeakDateValue
        End Get
    End Property

    Private dataLeakPublicationDateValue As DateTime? = Nothing
    Public ReadOnly Property DataLeakPublicationDate As DateTime?
        Get
            Return Me.dataLeakPublicationDateValue
        End Get
    End Property

    Private descriptionValue As String = String.Empty
    Public ReadOnly Property Description As String
        Get
            Return Me.descriptionValue
        End Get
    End Property

    Private titleValue As String = String.Empty
    Public ReadOnly Property Title As String
        Get
            Return Me.titleValue
        End Get
    End Property
End Class