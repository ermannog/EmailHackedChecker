Public NotInheritable Class UtilHackedEmails
    Private Sub New()
    End Sub

    Public Shared Function Query(ByVal email As String) As QueryResult
        Dim result As QueryResult = Nothing

        ' Setting Request
        Dim request = System.Net.WebRequest.Create(("https://hacked-emails.com/api?q=" & email))
        request.Proxy = System.Net.WebRequest.GetSystemWebProxy
        request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials
        DirectCast(request, System.Net.HttpWebRequest).UserAgent = Util.UserAgent
        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12

        ' Setting Request
        Try
            Using response = request.GetResponse
                If (DirectCast(response, System.Net.HttpWebResponse).StatusCode = System.Net.HttpStatusCode.OK) Then
                    Using stream = response.GetResponseStream
                        Using reader = New System.IO.StreamReader(stream)
                            result = New QueryResult(email, Util.Databases.HackedEmails, reader.ReadToEnd, Now)
                            reader.Close()
                        End Using
                    End Using
                End If
                response.Close()
            End Using
        Catch ex As Exception
            Throw ex
        Finally
            request = Nothing
        End Try

        Return result
    End Function

    Public Shared Function FillQueryItems(items As List(Of QueryResultItem), response As String) As Boolean
        Dim dataLeakFound = False

        Dim item As QueryHackedEmailsResultItem = Newtonsoft.Json.JsonConvert.DeserializeObject(Of QueryHackedEmailsResultItem)(response)

        dataLeakFound = (item.status = "found")

        If ((Not item.data Is Nothing) AndAlso (item.data.Count > 0)) Then
            Dim data As QueryHackedEmailsResultItemData
            For Each data In item.data
                Dim description = "<a href=""" & data.details & """target=""_blank"">" & data.details & "</a>"
                items.Add(New QueryResultItem(data.title, description, data.date_leaked, data.date_created, String.Empty))
            Next
        End If

        Return dataLeakFound
    End Function

    Private Class QueryHackedEmailsResultItem
        Public Property status As String
        Public Property query As String
        Public Property results As Integer
        Public Property data As List(Of QueryHackedEmailsResultItemData)
    End Class

    Private Class QueryHackedEmailsResultItemData
        Public Property title As String
        Public Property author As String
        Public Property verified As Boolean
        Public Property date_created As DateTime
        Public Property date_leaked As DateTime
        Public Property emails_count As Int64
        Public Property details As String
        Public Property source_url As String
        Public Property source_lines As Int64
        Public Property source_size As Int64
        Public Property source_network As String
        Public Property source_provider As String
    End Class
End Class