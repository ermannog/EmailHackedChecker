Public NotInheritable Class UtilHaveIBeenPwned
    Private Sub New()
    End Sub

    Public Shared Function Query(ByVal email As String) As QueryResult
        Dim result As QueryResult = Nothing

        ' Setting Request
        Dim request = System.Net.WebRequest.Create(("https://haveibeenpwned.com/api/v2/breachedaccount/" & email))
        request.Proxy = System.Net.WebRequest.GetSystemWebProxy
        request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials
        DirectCast(request, System.Net.HttpWebRequest).UserAgent = Util.UserAgent
        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12

        ' Get Response
        Try
            Using response = request.GetResponse()
                If (DirectCast(response, System.Net.HttpWebResponse).StatusCode = System.Net.HttpStatusCode.OK) Then
                    Using stream = response.GetResponseStream
                        Using reader = New System.IO.StreamReader(stream)
                            result = New QueryResult(email, Util.Databases.HaveIBeenPwned, reader.ReadToEnd, Now)
                            reader.Close()
                        End Using
                    End Using
                End If
                response.Close()
            End Using
        Catch ex As Exception
            If TypeOf ex Is System.Net.WebException AndAlso DirectCast(DirectCast(ex, System.Net.WebException).Response, System.Net.HttpWebResponse).StatusCode = System.Net.HttpStatusCode.NotFound Then
                result = New QueryResult(email, Util.Databases.HaveIBeenPwned, String.Empty, Now)
            Else
                Throw ex
            End If
        Finally
            request = Nothing
        End Try

        Return result
    End Function

    Public Shared Function FillQueryItems(items As List(Of QueryResultItem), response As String) As Boolean
        Dim dataLeakFound = False

        If Not String.IsNullOrWhiteSpace(response) Then
            Dim list As List(Of QueryHaveIBeenPwnedResultItem) = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of QueryHaveIBeenPwnedResultItem))(response)
            If ((Not list Is Nothing) AndAlso (list.Count > 0)) Then
                Dim item As QueryHaveIBeenPwnedResultItem
                For Each item In list
                    Dim additionalInformation As String = String.Empty
                    If ((Not item.DataClasses Is Nothing) AndAlso (item.DataClasses.Count > 0)) Then
                        additionalInformation = String.Join(",", item.DataClasses.ToArray)
                    End If
                    items.Add(New QueryResultItem(item.Title, item.Description, item.BreachDate, item.AddedDate, additionalInformation))
                Next
            End If

            dataLeakFound = True
        End If

        Return dataLeakFound
    End Function

    Private Class QueryHaveIBeenPwnedResultItem
        Public Property Title As String
        Public Property Name As String
        Public Property Domain As String
        Public Property BreachDate As DateTime
        Public Property AddedDate As DateTime
        Public Property ModifiedDate As DateTime
        Public Property PwnCount As Integer
        Public Property Description As String
        Public Property DataClasses As List(Of String)
        Public Property IsVerified As Boolean
        Public Property IsFabricated As Boolean
        Public Property IsSensitive As Boolean
        Public Property IsActive As Boolean
        Public Property IsRetired As Boolean
        Public Property IsSpamList As Boolean
        Public Property LogoType As String
    End Class

End Class

