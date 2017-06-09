Public Class QueryResult
    ' Methods
    Public Sub New(ByVal email As String, ByVal database As Util.Databases, ByVal response As String, queryExecutionDate As DateTime)
        Me.emailValue = email
        Me.databaseValue = database
        Me.responseValue = response
        Me.queryExecutionDateValue = queryExecutionDate

        If Not String.IsNullOrWhiteSpace(response) Then
            Select Case database
                Case Util.Databases.HaveIBeenPwned
                    'Me.foundValue = True
                    Me.foundValue = UtilHaveIBeenPwned.FillQueryItems(Me.itemsValue, response)
                    'Dim list As List(Of QueryHaveIBeenPwnedResultItem) = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of QueryHaveIBeenPwnedResultItem))(response)
                    'If ((Not list Is Nothing) AndAlso (list.Count > 0)) Then
                    '    Dim item As QueryHaveIBeenPwnedResultItem
                    '    For Each item In list
                    '        Dim additionalInformation As String = String.Empty
                    '        If ((Not item.DataClasses Is Nothing) AndAlso (item.DataClasses.Count > 0)) Then
                    '            additionalInformation = String.Join(",", item.DataClasses.ToArray)
                    '        End If
                    '        Me.itemsValue.Add(New QueryResultItem(item.Title, item.Description, item.BreachDate, item.AddedDate, additionalInformation))
                    '    Next
                    'End If
                    'Exit Select
                Case Util.Databases.HackedEmails
                    'Dim item As QueryHackedEmailsResultItem = Newtonsoft.Json.JsonConvert.DeserializeObject(Of QueryHackedEmailsResultItem)(response)
                    'Me.foundValue = (item.status = "found")
                    'If ((Not item.data Is Nothing) AndAlso (item.data.Count > 0)) Then
                    '    Dim data As QueryHackedEmailsResultItemData
                    '    For Each data In item.data
                    '        Dim description = "<a href=""" & data.details & """target=""_blank"">" & data.details & "</a>"
                    '        Me.itemsValue.Add(New QueryResultItem(data.title, description, data.date_leaked, data.date_created, String.Empty))
                    '    Next
                    'End If
                    'Exit Select

                    Me.foundValue = UtilHackedEmails.FillQueryItems(Me.itemsValue, response)
                Case Else
                    Throw New System.NotImplementedException("New method in QueryResult class not implemented for database " & Me.databaseValue.ToString())
            End Select
        End If
    End Sub

    'Public Function ToHtml(ByVal summary As Boolean, ByVal detailMode As HtmlReportDetailModes) As String
    '    Dim html As String = String.Empty

    '    If (Not summary AndAlso (detailMode = HtmlReportDetailModes.Suppress)) Then
    '        Return html
    '    End If

    '    html &= "<p>"

    '    If summary Then
    '        html &= Me.emailValue
    '        If Me.foundValue Then
    '            html &= " <font color=""red""><strong>found {Me.itemsValue.Count} times</strong></font>"
    '        Else
    '            html &= " <font color=""green"">not found</font>"
    '        End If

    '        html &= " on <strong>" & UtilEnumExtensions.GetDescription(Me.databaseValue) & "</strong>"

    '        If Me.foundValue Then
    '            html &= " (last data leak date:<i>" & IIf((Me.LastDataLeak IsNot Nothing), Me.LastDataLeak.DataLeakDate.Value.ToString("dd MMMM yyyy"), "Unknow").ToString() & "</i>"
    '            html &= " - last publication date:<i>" & IIf((Me.LastDataLeakPublished IsNot Nothing), Me.LastDataLeakPublished.DataLeakPublicationDate.Value.ToString("dd MMMM yyyy"), "Unknow").ToString() & "</i>)"
    '        End If
    '    End If

    '    If (detailMode > HtmlReportDetailModes.Suppress) Then
    '        Dim provider As New System.Globalization.CultureInfo("en-US")
    '        html &= "<blockquote>"
    '        Dim item As QueryResultItem

    '        Dim counter As Integer = 0
    '        For Each item In Me.Items
    '            If counter > 0 Then html &= "<br>"

    '            html &= "<strong>" & item.Title & "</strong>"
    '            html &= " <i>" & IIf(item.DataLeakDate.HasValue, item.DataLeakDate.Value.ToString("d MMMM yyyy", provider), "Unknow").ToString() & "</i>"
    '            html &= " published on <i>" & IIf(item.DataLeakPublicationDate.HasValue, item.DataLeakPublicationDate.Value.ToString("d MMMM yyyy", provider), "Unknow").ToString() & "</i>"

    '            counter += 1
    '        Next
    '        html &= "</blockquote>"
    '    End If

    '    html &= "</p>"

    '    Return html
    'End Function

    ' Properties

    Private databaseValue As Util.Databases = Util.Databases.Undefined
    Public ReadOnly Property Database As Util.Databases
        Get
            Return Me.databaseValue
        End Get
    End Property

    Private emailValue As String = String.Empty
    Public ReadOnly Property Email As String
        Get
            Return Me.emailValue
        End Get
    End Property

    Private queryExecutionDateValue As DateTime = Nothing
    Public ReadOnly Property QueryExecutionDate As DateTime
        Get
            Return Me.queryExecutionDateValue
        End Get
    End Property

    Public ReadOnly Property QueryExecutionTTL As Double
        Get
            Return (Now - Me.queryExecutionDateValue).TotalHours()
        End Get
    End Property

    Private foundValue As Boolean = False
    Public ReadOnly Property Found As Boolean
        Get
            Return Me.foundValue
        End Get
    End Property

    Private itemsValue As List(Of QueryResultItem) = New List(Of QueryResultItem)
    Public ReadOnly Property Items As List(Of QueryResultItem)
        Get
            Return Me.itemsValue
        End Get
    End Property

    Public ReadOnly Property LastDataLeak As QueryResultItem
        Get
            If Not Me.itemsValue Is Nothing AndAlso Me.itemsValue.Count > 0 Then
                Return Me.itemsValue.OrderByDescending(Function(i) i.DataLeakDate).FirstOrDefault()
            End If
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property LastDataLeakPublished As QueryResultItem
        Get
            If Not Me.itemsValue Is Nothing AndAlso Me.itemsValue.Count > 0 Then
                Return Me.itemsValue.OrderByDescending(Function(i) i.DataLeakPublicationDate).FirstOrDefault()
            End If
            Return Nothing
        End Get
    End Property

    Private responseValue As String = String.Empty
    Public ReadOnly Property Response As String
        Get
            Return Me.responseValue
        End Get
    End Property

    'Public Enum HtmlReportDetailModes
    '    ' Fields
    '    Description = 1
    '    DescriptionAndAdditionalInfo = 2
    '    Suppress = 0
    'End Enum
End Class