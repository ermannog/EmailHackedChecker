Public Class MainForm
    Private FormInitializing As Boolean = True

    Private Sub SetFormText()
        Me.Text = My.Application.Info.AssemblyName & " " &
            String.Format("{0}.{1}.{2}", My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build) & " - " &
            My.Application.Info.Description
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initializations
        Me.SetApplicationIcon()
        Me.SetFormText()
        Me.NudCacheTTL.Value = Query.CacheTTLDefaultValue
        Me.NudSourceRequestDelay.Value = Query.DatabaseRequestDelayDefaulValue
        Me.colResultLastDataLeakDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.colResultLastDataLeakPublicationDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        'Reset Flag initialization
        Me.FormInitializing = False

        '*** Test ***
        Me.TxtEmail.Text = "test@example.com"
        Me.TxtEmailListFilePath.Text = "EmailList.txt"
        Me.ChkEnableCache.Checked = False
    End Sub

#Region "Menu File"
    Private Sub MniFileExit_Click(sender As Object, e As EventArgs) Handles MniFileExit.Click
        System.Environment.Exit(0)
    End Sub
#End Region

#Region "Menu Actions"
    Private QueryRunnig As Boolean = False
    Private QueryException As System.Exception = Nothing
    Private Query As Query = Nothing

    Private Sub MniActionsExecute_Click(sender As Object, e As EventArgs) Handles MniActionsExecute.Click
        'Set Wait Cursor
        Me.SetWaitCursor(True)

        'Set Flag Running
        Me.QueryRunnig = True

        'Reset Query Exception
        Me.QueryException = Nothing

        'Set ToolBar
        Me.ActivateExecute(False)

        'Clear Grid Result DataSet
        Me.DstResultSchema.Clear()

        'Reset Output
        Me.TxtOutput.ResetText()

        'Creation and set Query Object
        Try
            ''Gestione abilitazione Log
            'Dim logFile = Util.ReplaceParameter(Me.CurrentAutoTelnetScript.LogFile, Me.CurrentAutoTelnetScript, parameters)
            'If Not String.IsNullOrWhiteSpace(logFile) Then
            '    UtilLogFileWriter.Enable(logFile, Me.CurrentAutoTelnetScript.LogMode, Me.CurrentAutoTelnetScript.LogCommandAndResponseEntriesEncrypted)
            'Else
            '    UtilLogFileWriter.Disable()
            'End If

            'Creation Query
            Me.Query = New HackedEmailsChecker.Query
            Me.Query.DatabaseHaveIBeenPwnedEnabled = Me.ChkHaveIBeenPwned.Checked
            Me.Query.DatabaseHackedEmailsEnabled = Me.ChkHackedEmails.Checked
            Me.Query.EnableCache = Me.ChkEnableCache.Checked
            Me.Query.CacheTTL = System.Convert.ToUInt16(Me.NudCacheTTL.Value)

            'Add  Query event handler
            AddHandler Me.Query.OutputInformationAdded, AddressOf Me.Query_OutputInformationAdded
            AddHandler Me.Query.OutputResultEmailFoundAdded, AddressOf Me.Query_OutputResultEmailFoundAdded
            AddHandler Me.Query.OutputResultEmailNotFoundAdded, AddressOf Me.Query_OutputResultEmailNotFoundAdded
            AddHandler Me.Query.OutputErrorAdded, AddressOf Me.Query_OutputErrorAdded
        Catch ex As Exception
            UtilMsgBox.ShowErrorException(ex, False)

            Me.ActivateExecute(True)
            Me.SetWaitCursor(False)
        End Try

        'Avvio Backgroud Worker
        Me.BkwQuery.RunWorkerAsync()
    End Sub

    Private Sub MniActionsStop_Click(sender As Object, e As EventArgs) Handles MniActionsStop.Click
        Try
            Me.Query.StopExecuteQueryFlag = True
            Me.LblStatus.Text = "Stopping execution query..."
        Catch ex As Exception
            UtilMsgBox.ShowErrorException("Error during stopping query", ex, False)
        End Try
    End Sub

    Private Sub BtnExecute_Click(sender As Object, e As EventArgs) Handles BtnExecute.Click
        Me.MniActionsExecute.PerformClick()
    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click
        Me.MniActionsStop.PerformClick()
    End Sub

    Private Sub ActivateExecute(enabled As Boolean)
        Me.MniActionsExecute.Enabled = enabled
        Me.MniActionsStop.Enabled = Not enabled AndAlso Me.QueryRunnig
        Me.MniClearCache.Enabled = enabled AndAlso Not Me.QueryRunnig

        Me.BtnExecute.Enabled = Me.MniActionsExecute.Enabled
        Me.BtnStop.Enabled = Me.MniActionsStop.Enabled
        Me.BtnClearCache.Enabled = Me.MniClearCache.Enabled
        Me.TlsMain.Refresh()
    End Sub

    Private Sub BkwQuery_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BkwQuery.DoWork
        'Set email list
        Dim emails = New List(Of String)

        Try
            If Me.RbtCheckSingleEmail.Checked Then
                'Add email
                emails.Add(Me.TxtEmail.Text)
            ElseIf Me.RbtCheckEmailList.Checked Then
                'Add emailS read from file
                If System.IO.File.Exists(Me.TxtEmailListFilePath.Text) Then
                    Me.LblStatus.Text = "Reading email list test file..."
                    emails.AddRange(System.IO.File.ReadLines(Me.TxtEmailListFilePath.Text))
                Else
                    UtilMsgBox.ShowError(String.Format("Error Email List file {0} not exists", System.IO.Path.GetFileName(Me.TxtEmailListFilePath.Text)), False)
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            UtilMsgBox.ShowErrorException("Error during reading Email List file " & System.IO.Path.GetFileName(Me.TxtEmailListFilePath.Text), ex, False)
            e.Cancel = True
            Exit Sub
        End Try

        'Execute Query
        Try
            'Setting StatusBar label
            Me.LblStatus.Text = "Execution query in progress..."

            Me.Query.Execute(emails)
        Catch ex As Exception
            Me.QueryException = ex
            e.Cancel = True
        End Try
    End Sub

    Private Sub Query_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BkwQuery.RunWorkerCompleted
        'Reset Flag Running
        Me.QueryRunnig = False

        'Setting StatusBar label
        If e.Cancelled Then
            If Me.QueryException IsNot Nothing Then
                Me.LblStatus.Text = "An error occurred while running the query"
                Me.AddOutput(OutputTypes.Error, UtilMsgBox.GetExceptionMessage(Me.LblStatus.Text, Me.QueryException))
            Else
                Me.LblStatus.Text = "Execution query cancelled"
            End If
        ElseIf Me.Query.StopExecuteQueryFlag Then
            Me.LblStatus.Text = "Execution query interrupted"
        Else
            Me.LblStatus.Text = "Execution query completed"
        End If

        'Setting ToolBar
        Me.ActivateExecute(True)

        'Reset Wait Cursor
        Me.SetWaitCursor(False)
    End Sub

    Private Sub BkwQuery_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BkwQuery.ProgressChanged
        If TypeOf e.UserState Is QueryOutputInformationAddedEventArgs Then
            Me.AddOutput(OutputTypes.Information, DirectCast(e.UserState, QueryOutputInformationAddedEventArgs).Text)
        ElseIf TypeOf e.UserState Is QueryOutputResultEmailFoundAddedEventArgs Then
            Me.AddGridResultRow(DirectCast(e.UserState, QueryOutputResultEmailFoundAddedEventArgs).Result)
            Me.AddOutput(OutputTypes.ResultEmailFound, DirectCast(e.UserState, QueryOutputResultEmailFoundAddedEventArgs).Text, False)
        ElseIf TypeOf e.UserState Is QueryOutputResultEmailNotFoundAddedEventArgs Then
            Me.AddOutput(OutputTypes.ResultEmailNotFound, DirectCast(e.UserState, QueryOutputResultEmailNotFoundAddedEventArgs).Text, False)
            Me.AddGridResultRow(DirectCast(e.UserState, QueryOutputResultEmailNotFoundAddedEventArgs).Result)
        ElseIf TypeOf e.UserState Is QueryOutputErrorAddedEventArgs Then
            With DirectCast(e.UserState, QueryOutputErrorAddedEventArgs)
                Me.AddOutput(OutputTypes.Error, UtilMsgBox.GetExceptionMessage(.Text, .Exception))
            End With
        End If
    End Sub

    Private Sub Query_OutputInformationAdded(sender As Object, e As QueryOutputInformationAddedEventArgs)
        Me.BkwQuery.ReportProgress(Nothing, e)
    End Sub

    Private Sub Query_OutputResultEmailFoundAdded(sender As Object, e As QueryOutputResultEmailFoundAddedEventArgs)
        Me.BkwQuery.ReportProgress(Nothing, e)
    End Sub

    Private Sub Query_OutputResultEmailNotFoundAdded(sender As Object, e As QueryOutputResultEmailNotFoundAddedEventArgs)
        Me.BkwQuery.ReportProgress(Nothing, e)
    End Sub

    Private Sub Query_OutputErrorAdded(sender As Object, e As QueryOutputErrorAddedEventArgs)
        Me.BkwQuery.ReportProgress(Nothing, e)
    End Sub
#End Region

#Region "Menu Cache"
    Private Sub MniClearCache_Click(sender As Object, e As EventArgs) Handles MniClearCache.Click
        Try
            Dim cacheDirectoryPath = Util.GetCacheDirectoryPath()
            If System.IO.Directory.Exists(cacheDirectoryPath) Then
                If UtilMsgBox.ShowQuestion("Confirm clear cache directory?", MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    System.IO.Directory.Delete(cacheDirectoryPath, True)
                End If
            Else
                UtilMsgBox.ShowMessage("Cache directory not found")
            End If
        Catch ex As Exception
            UtilMsgBox.ShowErrorException("Error during clear cache", ex, False)
        End Try
    End Sub
    Private Sub BtnClearCache_Click(sender As Object, e As EventArgs) Handles BtnClearCache.Click
        Me.MniClearCache.PerformClick()
    End Sub
#End Region

#Region "Menu Help"
    Private Sub MniHelpAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MniHelpAbout.Click
        Using frm As New AboutBox
            frm.ShowDialog(Me)
        End Using
    End Sub
#End Region

#Region "Query Type controls"
    Private Sub RadioButtonCheckEmailType_CheckedChanged(sender As Object, e As EventArgs) Handles RbtCheckSingleEmail.CheckedChanged, RbtCheckEmailList.CheckedChanged
        If Me.FormInitializing Then Exit Sub

        Me.TxtEmail.Enabled = Me.RbtCheckSingleEmail.Checked
        Me.TxtEmailListFilePath.Enabled = Me.RbtCheckEmailList.Checked
        Me.BtnBrowseEmailListFile.Enabled = Me.RbtCheckEmailList.Checked

        If Me.RbtCheckSingleEmail.Checked Then
            Me.ActivateExecute(Not String.IsNullOrWhiteSpace(Me.TxtEmail.Text))
        ElseIf Me.RbtCheckEmailList.Checked Then
            Me.ActivateExecute(Not String.IsNullOrWhiteSpace(Me.TxtEmailListFilePath.Text))
        End If
    End Sub

    Private Sub TxtEmail_TextChanged(sender As Object, e As EventArgs) Handles TxtEmail.TextChanged
        Me.ActivateExecute(Not String.IsNullOrWhiteSpace(Me.TxtEmail.Text))
    End Sub

    Private Sub TxtEmailListFilePath_TextChanged(sender As Object, e As EventArgs) Handles TxtEmailListFilePath.TextChanged
        Me.ActivateExecute(Not String.IsNullOrWhiteSpace(Me.TxtEmailListFilePath.Text))
    End Sub

    Private Sub BtnBrowseEmailListFile_Click(sender As Object, e As EventArgs) Handles BtnBrowseEmailListFile.Click
        Try
            If Me.OfdEmailList.ShowDialog(Me) = DialogResult.OK Then
                Me.TxtEmailListFilePath.Text = Me.OfdEmailList.FileName
            End If
        Catch ex As Exception
            UtilMsgBox.ShowErrorException("Error during select Email list file", ex, False)
        End Try
    End Sub
#End Region

#Region "Query Source controls"
    Private Sub LblHaveIBeenPwned_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LblHaveIBeenPwned.LinkClicked
        Try
            System.Diagnostics.Process.Start("https://haveibeenpwned.com/")
        Catch ex As Exception
            UtilMsgBox.ShowErrorException(ex, False)
        End Try
    End Sub

    Private Sub LblHackedEmails_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LblHackedEmails.LinkClicked
        Try
            System.Diagnostics.Process.Start("https://hacked-emails.com/")
        Catch ex As Exception
            UtilMsgBox.ShowErrorException(ex, False)
        End Try
    End Sub

    Private Sub ChkEnableCache_CheckedChanged(sender As Object, e As EventArgs) Handles ChkEnableCache.CheckedChanged
        Me.LblCacheTTL.Enabled = Me.ChkEnableCache.Checked
        Me.NudCacheTTL.Enabled = Me.ChkEnableCache.Checked
    End Sub
#End Region

#Region "Query Result controls"
    Private Sub GrdResult_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles GrdResult.DataError
        Me.AddOutput(OutputTypes.Error, String.Format("Error in Grid result (Row {0} - Column {1}) " & e.Exception.Message, e.RowIndex, e.ColumnIndex))

    End Sub

    Private Sub GrdResult_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles GrdResult.CellFormatting
        'http://msdn.microsoft.com/en-us/library/system.windows.forms.datagridviewcellformattingeventargs.formattingapplied.aspx
        'When handling the CellFormatting event, set the FormattingApplied property to true
        'after setting the Value property if no further value formatting is required.
        'If the FormattingApplied property value is false when the event handler exits, 
        'the formatting will be applied to the value as indicated by the Format, FormatProvider, NullValue, 
        'and DataSourceNullValue properties of the DataGridViewCellStyle object returned by 
        'the CellStyle property.

        Try
            If e.ColumnIndex = Me.colResultImage.Index Then
                Dim resultRow = DirectCast(DirectCast(Me.GridResultBindingSource.List(e.RowIndex), System.Data.DataRowView).Row, ResultSchema.GridResultRow)

                If resultRow.DataLeakFound Then
                    e.Value = My.Resources.SecurityShieldsCritical
                Else
                    e.Value = My.Resources.SecurityShieldsOk
                End If

                e.FormattingApplied = True
            ElseIf e.ColumnIndex = Me.colResultHaveIBeenPwned.Index OrElse e.ColumnIndex = Me.colResultHackedEmails.Index Then
                Dim resultRow = DirectCast(DirectCast(Me.GridResultBindingSource.List(e.RowIndex), System.Data.DataRowView).Row, ResultSchema.GridResultRow)

                Dim leaks As Int64? = Nothing
                If e.ColumnIndex = Me.colResultHaveIBeenPwned.Index AndAlso Not resultRow.IsHaveIBeenPwnedNull() Then leaks = resultRow.HaveIBeenPwned
                If e.ColumnIndex = Me.colResultHackedEmails.Index AndAlso Not resultRow.IsHackedEmailsNull() Then leaks = resultRow.HackedEmails

                If leaks.HasValue AndAlso leaks.Value = 0 Then
                    e.Value = "Not found"
                    e.FormattingApplied = True
                    e.CellStyle.ForeColor = System.Drawing.Color.Green
                ElseIf leaks.HasValue AndAlso leaks.Value > 0 Then
                    e.Value = String.Format("Found {0} leaks", System.Convert.ToInt64(leaks))
                    e.FormattingApplied = True
                    e.CellStyle.ForeColor = System.Drawing.Color.Red
                End If




                'ElseIf e.ColumnIndex = Me.colResultHackedEmails.Index Then
                '    Dim resultRow = DirectCast(DirectCast(Me.GridResultBindingSource.List(e.RowIndex), System.Data.DataRowView).Row, ResultSchema.GridResultRow)

                'If System.Convert.ToInt64(e.Value) = 0 Then
                '    e.Value = "Not found"
                '    e.CellStyle.ForeColor = System.Drawing.Color.Green
                'Else
                '    e.Value = String.Format("Found {0} leaks", System.Convert.ToInt64(e.Value))
                '    e.CellStyle.ForeColor = System.Drawing.Color.Red
                'End If

                'e.FormattingApplied = True

                'If resultRow.DataLeakFound Then
                '        e.CellStyle.ForeColor = System.Drawing.Color.Red
                '    Else
                '        e.CellStyle.ForeColor = System.Drawing.Color.Green
                '    End If
            ElseIf e.ColumnIndex = Me.colResultLastDataLeakDate.Index OrElse
                    e.ColumnIndex = Me.colResultLastDataLeakPublicationDate.Index Then
                If e.Value IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(e.Value.ToString()) Then
                    e.Value = DirectCast(e.Value, DateTime).ToString("dd MMMM yyyy", New System.Globalization.CultureInfo("en-US"))
                    e.FormattingApplied = True
                End If
                'ElseIf e.ColumnIndex = Me.colResultHackedEmails.Index Then

            End If
        Catch ex As Exception
            Me.AddOutput(OutputTypes.Error, "Error during formatting cell in Grid result")
        End Try
    End Sub

    Private Sub AddGridResultRow(result As QueryResult)
        'Search Row and if not foud create a new row
        Dim row = Me.DstResultSchema.GridResult.FindByEmail(result.Email)
        If row Is Nothing Then
            row = Me.DstResultSchema.GridResult.NewGridResultRow()
            row.Email = result.Email
            Me.DstResultSchema.GridResult.AddGridResultRow(row)
        End If

        If result.Found Then row.DataLeakFound = True

        'Set Result Leaks
        'Dim resultDetail As String = String.Empty
        'If result.Found Then
        '    resultDetail = String.Format("Found {0} leaks", result.Items.Count)
        'Else
        '    resultDetail = "Not found"
        'End If

        Dim resultDetailColumn = (From c In row.Table.Columns Where DirectCast(c, System.Data.DataColumn).ColumnName = result.Database.ToString()).SingleOrDefault()
        If resultDetailColumn IsNot Nothing Then
            'row(DirectCast(resultDetailColumn, System.Data.DataColumn)) = resultDetail
            row(DirectCast(resultDetailColumn, System.Data.DataColumn)) = result.Items.Count
        End If

        'Set Last data leak date
        If result.Found AndAlso result.LastDataLeak.DataLeakDate.HasValue Then
            If row.IsLastDataLeakDateNull() OrElse row.LastDataLeakDate < result.LastDataLeak.DataLeakDate.Value Then
                row.LastDataLeakDate = result.LastDataLeak.DataLeakDate.Value
            End If
        End If


        'Set Last data leak publication date
        If result.Found AndAlso result.LastDataLeakPublished.DataLeakDate.HasValue Then
            If row.IsLastDataLeakPublicationDateNull() OrElse row.LastDataLeakPublicationDate < result.LastDataLeakPublished.DataLeakDate.Value Then
                row.LastDataLeakPublicationDate = result.LastDataLeakPublished.DataLeakDate.Value
            End If
        End If





        Me.DstResultSchema.GridResult.AcceptChanges()
    End Sub
#End Region

    '#Region "Context Menu Grid Result"
    'https://msdn.microsoft.com/it-it/library/system.windows.forms.datagridview.clipboardcopymode(v=vs.110).aspx
    '    Private Sub GrdResult_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles GrdResult.CellMouseClick
    '        'Dim hitTest = Me.GrdResult.HitTest(e.X, e.Y)
    '        ''hitTest.Type=
    '        If e.Button = MouseButtons.Right AndAlso e.RowIndex >= 0 Then
    '            If Me.GrdResult.ContextMenuStrip Is Nothing Then Me.GrdResult.ContextMenuStrip = Me.CmnGridResult
    '        Else
    '            If Me.GrdResult.ContextMenuStrip IsNot Nothing Then Me.GrdResult.ContextMenuStrip = Nothing
    '        End If
    '    End Sub
    '#End Region

#Region "Gestione Output"
    Private Enum OutputTypes As Integer
        Information
        ResultEmailFound
        ResultEmailNotFound
        [Error]
    End Enum

    Private Overloads Sub AddOutput(type As OutputTypes, text As String)
        Me.AddOutput(type, text, True)
    End Sub

    Private Overloads Sub AddOutput(type As OutputTypes, text As String, addNewLine As Boolean)
        'Set Color and  log entry type
        Dim logEntryType As UtilLogFileWriter.EntryTypes = Nothing
        Select Case type
            Case OutputTypes.Information
                Me.TxtOutput.SelectionColor = Color.Black
                logEntryType = UtilLogFileWriter.EntryTypes.Information
            Case OutputTypes.ResultEmailFound
                Me.TxtOutput.SelectionColor = Color.OrangeRed
                logEntryType = UtilLogFileWriter.EntryTypes.ResultEmailFound
            Case OutputTypes.ResultEmailNotFound
                Me.TxtOutput.SelectionColor = Color.Green
                logEntryType = UtilLogFileWriter.EntryTypes.ResultEmailNotFound
            Case OutputTypes.Error
                Me.TxtOutput.SelectionColor = Color.Red
                logEntryType = UtilLogFileWriter.EntryTypes.Error
        End Select

        Me.TxtOutput.SuspendLayout()
        Dim selectedText = String.Empty
        If Not String.IsNullOrEmpty(Me.TxtOutput.Text) AndAlso addNewLine Then selectedText &= System.Environment.NewLine
        selectedText &= text.TrimNewLine()

        Me.TxtOutput.SelectedText &= selectedText
        Me.TxtOutput.ScrollToCaret()
        Me.TxtOutput.ResumeLayout()

        If UtilLogFileWriter.LogEnabled Then UtilLogFileWriter.WriteNewEntry(logEntryType, text.TrimNewLine())
    End Sub
#End Region

End Class