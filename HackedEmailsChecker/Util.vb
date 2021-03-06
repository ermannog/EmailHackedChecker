Public NotInheritable Class Util
    Private Sub New()
    End Sub

    Public Shared ReadOnly Property UserAgent As String
        Get
            Return My.Application.Info.AssemblyName & "/" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor
        End Get
    End Property

    Public Enum Databases As Integer
        Undefined = -1
        <System.ComponentModel.Description("haveibeenpwned.com")>
        HaveIBeenPwned = 1
        <System.ComponentModel.Description("hacked-emails.com")>
        HackedEmails = 2
    End Enum


#Region "Cache"
    Public Shared Function GetCacheDirectoryPath() As String
        Return System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Cache")
    End Function

    Public Shared Function GetCacheFilePath(database As Util.Databases, email As String) As String
        Dim path = Util.GetCacheDirectoryPath()
        path = System.IO.Path.Combine(path, database.ToString())
        path = System.IO.Path.Combine(path, email)

        Return path
    End Function

    Public Shared Sub SaveQueryCache(result As QueryResult)
        Dim cacheFilePath = Util.GetCacheFilePath(result.Database, result.Email)
        Dim cacheDirectoryPath = System.IO.Path.GetDirectoryName(cacheFilePath)

        If Not System.IO.Directory.Exists(cacheDirectoryPath) Then
            System.IO.Directory.CreateDirectory(cacheDirectoryPath)
        End If

        'System.IO.File.WriteAllText(cacheFilePath, Newtonsoft.Json.JsonConvert.SerializeObject(result))
        System.IO.File.WriteAllText(cacheFilePath, result.Response)
    End Sub

    Public Shared Function FindInCache(database As Util.Databases, email As String, ttl As UInt16) As QueryResult
        Dim cacheFilePath = Util.GetCacheFilePath(database, email)

        If Not System.IO.File.Exists(cacheFilePath) Then Return Nothing

        Dim cacheFileCreationTime = System.IO.File.GetCreationTime(cacheFilePath)

        If (Now - cacheFileCreationTime).TotalHours() > ttl Then Return Nothing

        Dim result = New QueryResult(email, database, System.IO.File.ReadAllText(cacheFilePath), System.IO.File.GetCreationTime(cacheFilePath))

        Return result
    End Function
#End Region

#Region "License"
    Public Shared Function CheckEulaAccepted(ByVal companyName As String, ByVal productName As String) As Boolean
        Const EulaAcceptedValueName As String = "EulaAccepted"
        Dim registryKey As String = String.Format("Software\{0}\{1}",
            companyName, productName)

        Dim key = My.Computer.Registry.CurrentUser.OpenSubKey(registryKey, True)
        Dim value As Object = Nothing

        If key IsNot Nothing Then
            value = key.GetValue(EulaAcceptedValueName)
        End If

        If key Is Nothing OrElse
            value Is Nothing OrElse
            String.IsNullOrEmpty(value.ToString()) OrElse
            value.ToString <> "1" Then

            'Visualizzazione Dialog
            Using frm As New LicenseForm
                If frm.ShowDialog() <> DialogResult.OK Then
                    Return False
                End If
            End Using

            'Creazione Key
            If key Is Nothing Then
                key = My.Computer.Registry.CurrentUser.CreateSubKey(registryKey)
            End If

            'Impostazione Valore
            If value Is Nothing OrElse
                String.IsNullOrEmpty(value.ToString()) OrElse
                value.ToString <> "1" Then
                key.SetValue(EulaAcceptedValueName, 1, Microsoft.Win32.RegistryValueKind.DWord)
            End If
        End If

        Return True
    End Function
#End Region


    ''' <summary>
    ''' Check if value is Nothing or DBNull or an String null or empty
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsNullOrEmpty(ByVal value As Object) As Boolean
        Return value Is Nothing OrElse
            IsDBNull(value) OrElse
            ((TypeOf value Is String) AndAlso String.IsNullOrEmpty(DirectCast(value, String)))
    End Function
End Class