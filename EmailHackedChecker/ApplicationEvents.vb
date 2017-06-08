Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Public Modalita As ModalitaApplicative = ModalitaApplicative.GUI

        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            'Check License 
            Try
                If Not Util.CheckEulaAccepted(My.Application.Info.CompanyName, My.Application.Info.ProductName) Then
                    e.Cancel = True
                    System.Environment.Exit(0)
                End If
            Catch ex As Exception
                UtilMsgBox.ShowErrorException("Error during check EULA accepted.", ex, True)
                e.Cancel = True
                Exit Sub
            End Try

        End Sub

        'Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
        '    Dim j = DLDBUtil.GetCacheSubDirectory(DLDBUtil.Databases.HackedEmails)

        'End Sub

        Public Enum ModalitaApplicative As Integer
            GUI = 0
            Batch = 1
        End Enum


    End Class
End Namespace
