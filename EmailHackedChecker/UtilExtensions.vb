'Public NotInheritable Class Util
'    Private Sub New()
'        MyBase.New()
'    End Sub

'    Public Shared Function SetWait(ByVal state As Boolean) As Boolean
'        Dim waitState As Boolean

'        waitState = System.Windows.Forms.Cursor.Current Is System.Windows.Forms.Cursors.WaitCursor

'        If state Then
'            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
'        Else
'            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
'        End If

'        Return waitState
'    End Function

'    Public Shared Sub WriteLogEmailCompromised(email As String)
'        Using writer = New System.IO.StreamWriter("E:\DLDBQueryToolLog.txt", True)
'            writer.WriteLine(email + " Compromised")
'        End Using
'    End Sub

'    Public Shared Sub WriteLogEmailError(email As String)
'        Using writer = New System.IO.StreamWriter("E:\DLDBQueryToolLog.txt", True)
'            writer.WriteLine(email + " Error")
'        End Using
'    End Sub
'End Class

Public Module UtilExtensions
    <System.Runtime.CompilerServices.Extension()>
    Public Sub SetWaitCursor(control As System.Windows.Forms.Control, ByVal state As Boolean)
        If state Then
            control.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Else
            control.Cursor = System.Windows.Forms.Cursors.Default
        End If

        For Each c As System.Windows.Forms.Control In control.Controls
            c.SetWaitCursor(state)
        Next
    End Sub

    <System.Runtime.CompilerServices.Extension()>
    Public Sub SetApplicationIcon(form As System.Windows.Forms.Form)
        form.Icon = System.Drawing.Icon.ExtractAssociatedIcon(
            System.Reflection.Assembly.GetEntryAssembly().Location)
    End Sub

    <System.Runtime.CompilerServices.Extension()>
    Public Function TrimNewLine(text As String) As String
        Dim value = text

        While value.EndsWith(Environment.NewLine)
            value = value.Remove(value.LastIndexOf(Environment.NewLine))
        End While

        Return value
    End Function
End Module