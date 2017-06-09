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

    <System.Runtime.CompilerServices.Extension()>
    Public Sub ScrollToLastRow(dataGridView As System.Windows.Forms.DataGridView)
        If dataGridView.RowCount > 0 Then
            dataGridView.FirstDisplayedScrollingRowIndex = dataGridView.RowCount - 1
        End If
    End Sub
End Module