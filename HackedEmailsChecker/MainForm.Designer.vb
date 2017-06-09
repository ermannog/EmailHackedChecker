<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.RbtCheckSingleEmail = New System.Windows.Forms.RadioButton()
        Me.TxtEmail = New System.Windows.Forms.TextBox()
        Me.MnuMain = New System.Windows.Forms.MenuStrip()
        Me.MniFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.MniFileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MniActions = New System.Windows.Forms.ToolStripMenuItem()
        Me.MniActionsExecute = New System.Windows.Forms.ToolStripMenuItem()
        Me.MniActionsStop = New System.Windows.Forms.ToolStripMenuItem()
        Me.MniCache = New System.Windows.Forms.ToolStripMenuItem()
        Me.MniClearCache = New System.Windows.Forms.ToolStripMenuItem()
        Me.MniHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.MniHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.TlsMain = New System.Windows.Forms.ToolStrip()
        Me.BtnExecute = New System.Windows.Forms.ToolStripButton()
        Me.BtnStop = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnCopyCell = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnClearCache = New System.Windows.Forms.ToolStripButton()
        Me.StsMain = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GrbQueryResult = New System.Windows.Forms.GroupBox()
        Me.GrdResult = New System.Windows.Forms.DataGridView()
        Me.colResultImage = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colResultEmail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colResultHaveIBeenPwned = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colResultHackedEmails = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colResultLastDataLeakDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colResultLastDataLeakPublicationDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GridResultBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DstResultSchema = New HackedEmailsChecker.ResultSchema()
        Me.CmnGridResult = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CmiGridResultCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.BkwQuery = New System.ComponentModel.BackgroundWorker()
        Me.GrbQueryType = New System.Windows.Forms.GroupBox()
        Me.BtnBrowseEmailListFile = New System.Windows.Forms.Button()
        Me.TxtEmailListFilePath = New System.Windows.Forms.TextBox()
        Me.RbtCheckEmailList = New System.Windows.Forms.RadioButton()
        Me.GrbQuerySource = New System.Windows.Forms.GroupBox()
        Me.LblHackedEmails = New System.Windows.Forms.LinkLabel()
        Me.ChkHackedEmails = New System.Windows.Forms.CheckBox()
        Me.LblHaveIBeenPwned = New System.Windows.Forms.LinkLabel()
        Me.ChkHaveIBeenPwned = New System.Windows.Forms.CheckBox()
        Me.NudCacheTTL = New System.Windows.Forms.NumericUpDown()
        Me.LblCacheTTL = New System.Windows.Forms.Label()
        Me.ChkEnableCache = New System.Windows.Forms.CheckBox()
        Me.TxtOutput = New System.Windows.Forms.RichTextBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GrbOutput = New System.Windows.Forms.GroupBox()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.GrbQueryOptions = New System.Windows.Forms.GroupBox()
        Me.NudSourceRequestDelay = New System.Windows.Forms.NumericUpDown()
        Me.Lbl = New System.Windows.Forms.Label()
        Me.OfdEmailList = New System.Windows.Forms.OpenFileDialog()
        Me.DataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.MniEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MniEditCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuMain.SuspendLayout()
        Me.TlsMain.SuspendLayout()
        Me.StsMain.SuspendLayout()
        Me.GrbQueryResult.SuspendLayout()
        CType(Me.GrdResult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridResultBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DstResultSchema, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CmnGridResult.SuspendLayout()
        Me.GrbQueryType.SuspendLayout()
        Me.GrbQuerySource.SuspendLayout()
        CType(Me.NudCacheTTL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GrbOutput.SuspendLayout()
        Me.GrbQueryOptions.SuspendLayout()
        CType(Me.NudSourceRequestDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RbtCheckSingleEmail
        '
        Me.RbtCheckSingleEmail.AutoSize = True
        Me.RbtCheckSingleEmail.Checked = True
        Me.RbtCheckSingleEmail.Location = New System.Drawing.Point(4, 18)
        Me.RbtCheckSingleEmail.Margin = New System.Windows.Forms.Padding(2)
        Me.RbtCheckSingleEmail.Name = "RbtCheckSingleEmail"
        Me.RbtCheckSingleEmail.Size = New System.Drawing.Size(117, 17)
        Me.RbtCheckSingleEmail.TabIndex = 0
        Me.RbtCheckSingleEmail.TabStop = True
        Me.RbtCheckSingleEmail.Text = "Check single Email:"
        Me.RbtCheckSingleEmail.UseVisualStyleBackColor = True
        '
        'TxtEmail
        '
        Me.TxtEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtEmail.Location = New System.Drawing.Point(146, 17)
        Me.TxtEmail.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(477, 20)
        Me.TxtEmail.TabIndex = 1
        '
        'MnuMain
        '
        Me.MnuMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MniFile, Me.MniEdit, Me.MniActions, Me.MniCache, Me.MniHelp})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MnuMain.Size = New System.Drawing.Size(884, 24)
        Me.MnuMain.TabIndex = 2
        Me.MnuMain.Text = "MenuStrip1"
        '
        'MniFile
        '
        Me.MniFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MniFileExit})
        Me.MniFile.Name = "MniFile"
        Me.MniFile.Size = New System.Drawing.Size(37, 20)
        Me.MniFile.Text = "&File"
        '
        'MniFileExit
        '
        Me.MniFileExit.Name = "MniFileExit"
        Me.MniFileExit.Size = New System.Drawing.Size(152, 22)
        Me.MniFileExit.Text = "E&xit"
        '
        'MniActions
        '
        Me.MniActions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MniActionsExecute, Me.MniActionsStop})
        Me.MniActions.Name = "MniActions"
        Me.MniActions.Size = New System.Drawing.Size(59, 20)
        Me.MniActions.Text = "&Actions"
        '
        'MniActionsExecute
        '
        Me.MniActionsExecute.Enabled = False
        Me.MniActionsExecute.Image = CType(resources.GetObject("MniActionsExecute.Image"), System.Drawing.Image)
        Me.MniActionsExecute.Name = "MniActionsExecute"
        Me.MniActionsExecute.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.MniActionsExecute.Size = New System.Drawing.Size(188, 22)
        Me.MniActionsExecute.Text = "&Execute query"
        '
        'MniActionsStop
        '
        Me.MniActionsStop.Enabled = False
        Me.MniActionsStop.Image = CType(resources.GetObject("MniActionsStop.Image"), System.Drawing.Image)
        Me.MniActionsStop.Name = "MniActionsStop"
        Me.MniActionsStop.Size = New System.Drawing.Size(188, 22)
        Me.MniActionsStop.Text = "&Stop query"
        '
        'MniCache
        '
        Me.MniCache.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MniClearCache})
        Me.MniCache.Name = "MniCache"
        Me.MniCache.Size = New System.Drawing.Size(52, 20)
        Me.MniCache.Text = "Cache"
        '
        'MniClearCache
        '
        Me.MniClearCache.Image = CType(resources.GetObject("MniClearCache.Image"), System.Drawing.Image)
        Me.MniClearCache.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MniClearCache.Name = "MniClearCache"
        Me.MniClearCache.Size = New System.Drawing.Size(135, 22)
        Me.MniClearCache.Text = "&Clear cache"
        '
        'MniHelp
        '
        Me.MniHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MniHelpAbout})
        Me.MniHelp.Name = "MniHelp"
        Me.MniHelp.Size = New System.Drawing.Size(44, 20)
        Me.MniHelp.Text = "&Help"
        '
        'MniHelpAbout
        '
        Me.MniHelpAbout.Name = "MniHelpAbout"
        Me.MniHelpAbout.Size = New System.Drawing.Size(116, 22)
        Me.MniHelpAbout.Text = "&About..."
        '
        'TlsMain
        '
        Me.TlsMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.TlsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnExecute, Me.BtnStop, Me.ToolStripSeparator1, Me.BtnCopyCell, Me.ToolStripSeparator2, Me.BtnClearCache})
        Me.TlsMain.Location = New System.Drawing.Point(0, 24)
        Me.TlsMain.Name = "TlsMain"
        Me.TlsMain.Size = New System.Drawing.Size(884, 27)
        Me.TlsMain.TabIndex = 3
        Me.TlsMain.Text = "ToolStrip1"
        '
        'BtnExecute
        '
        Me.BtnExecute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnExecute.Enabled = False
        Me.BtnExecute.Image = CType(resources.GetObject("BtnExecute.Image"), System.Drawing.Image)
        Me.BtnExecute.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnExecute.Name = "BtnExecute"
        Me.BtnExecute.Size = New System.Drawing.Size(24, 24)
        Me.BtnExecute.Text = "Execute query"
        '
        'BtnStop
        '
        Me.BtnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnStop.Enabled = False
        Me.BtnStop.Image = CType(resources.GetObject("BtnStop.Image"), System.Drawing.Image)
        Me.BtnStop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnStop.Name = "BtnStop"
        Me.BtnStop.Size = New System.Drawing.Size(24, 24)
        Me.BtnStop.Text = "Stop query"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'BtnCopyCell
        '
        Me.BtnCopyCell.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnCopyCell.Enabled = False
        Me.BtnCopyCell.Image = CType(resources.GetObject("BtnCopyCell.Image"), System.Drawing.Image)
        Me.BtnCopyCell.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCopyCell.Name = "BtnCopyCell"
        Me.BtnCopyCell.Size = New System.Drawing.Size(24, 24)
        Me.BtnCopyCell.Text = "Copy cell value in Clipboard"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'BtnClearCache
        '
        Me.BtnClearCache.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnClearCache.Image = CType(resources.GetObject("BtnClearCache.Image"), System.Drawing.Image)
        Me.BtnClearCache.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnClearCache.Name = "BtnClearCache"
        Me.BtnClearCache.Size = New System.Drawing.Size(24, 24)
        Me.BtnClearCache.Text = "Clear cache"
        '
        'StsMain
        '
        Me.StsMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StsMain.Location = New System.Drawing.Point(0, 539)
        Me.StsMain.Name = "StsMain"
        Me.StsMain.Padding = New System.Windows.Forms.Padding(1, 0, 10, 0)
        Me.StsMain.Size = New System.Drawing.Size(884, 22)
        Me.StsMain.TabIndex = 4
        Me.StsMain.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(39, 17)
        Me.LblStatus.Text = "Ready"
        Me.LblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GrbQueryResult
        '
        Me.GrbQueryResult.Controls.Add(Me.GrdResult)
        Me.GrbQueryResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrbQueryResult.Location = New System.Drawing.Point(0, 0)
        Me.GrbQueryResult.Margin = New System.Windows.Forms.Padding(2)
        Me.GrbQueryResult.Name = "GrbQueryResult"
        Me.GrbQueryResult.Padding = New System.Windows.Forms.Padding(2)
        Me.GrbQueryResult.Size = New System.Drawing.Size(866, 235)
        Me.GrbQueryResult.TabIndex = 5
        Me.GrbQueryResult.TabStop = False
        Me.GrbQueryResult.Text = "Query result"
        '
        'GrdResult
        '
        Me.GrdResult.AllowUserToAddRows = False
        Me.GrdResult.AllowUserToDeleteRows = False
        Me.GrdResult.AutoGenerateColumns = False
        Me.GrdResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GrdResult.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colResultImage, Me.colResultEmail, Me.colResultHaveIBeenPwned, Me.colResultHackedEmails, Me.colResultLastDataLeakDate, Me.colResultLastDataLeakPublicationDate})
        Me.GrdResult.DataSource = Me.GridResultBindingSource
        Me.GrdResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrdResult.Location = New System.Drawing.Point(2, 15)
        Me.GrdResult.Name = "GrdResult"
        Me.GrdResult.ReadOnly = True
        Me.GrdResult.RowHeadersVisible = False
        Me.GrdResult.Size = New System.Drawing.Size(862, 218)
        Me.GrdResult.TabIndex = 0
        '
        'colResultImage
        '
        Me.colResultImage.HeaderText = ""
        Me.colResultImage.Name = "colResultImage"
        Me.colResultImage.ReadOnly = True
        Me.colResultImage.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colResultImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colResultImage.Width = 32
        '
        'colResultEmail
        '
        Me.colResultEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colResultEmail.DataPropertyName = "Email"
        Me.colResultEmail.HeaderText = "Email"
        Me.colResultEmail.Name = "colResultEmail"
        Me.colResultEmail.ReadOnly = True
        Me.colResultEmail.Width = 57
        '
        'colResultHaveIBeenPwned
        '
        Me.colResultHaveIBeenPwned.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colResultHaveIBeenPwned.HeaderText = "Have I Been Pwned"
        Me.colResultHaveIBeenPwned.Name = "colResultHaveIBeenPwned"
        Me.colResultHaveIBeenPwned.ReadOnly = True
        Me.colResultHaveIBeenPwned.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colResultHaveIBeenPwned.Width = 109
        '
        'colResultHackedEmails
        '
        Me.colResultHackedEmails.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colResultHackedEmails.HeaderText = "Has my email been hacked?"
        Me.colResultHackedEmails.Name = "colResultHackedEmails"
        Me.colResultHackedEmails.ReadOnly = True
        Me.colResultHackedEmails.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colResultHackedEmails.Width = 147
        '
        'colResultLastDataLeakDate
        '
        Me.colResultLastDataLeakDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colResultLastDataLeakDate.DataPropertyName = "LastDataLeakDate"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colResultLastDataLeakDate.DefaultCellStyle = DataGridViewCellStyle1
        Me.colResultLastDataLeakDate.HeaderText = "Last data leak"
        Me.colResultLastDataLeakDate.Name = "colResultLastDataLeakDate"
        Me.colResultLastDataLeakDate.ReadOnly = True
        Me.colResultLastDataLeakDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colResultLastDataLeakDate.Width = 80
        '
        'colResultLastDataLeakPublicationDate
        '
        Me.colResultLastDataLeakPublicationDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.colResultLastDataLeakPublicationDate.DataPropertyName = "LastDataLeakPublicationDate"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colResultLastDataLeakPublicationDate.DefaultCellStyle = DataGridViewCellStyle2
        Me.colResultLastDataLeakPublicationDate.HeaderText = "Last data leak publication"
        Me.colResultLastDataLeakPublicationDate.Name = "colResultLastDataLeakPublicationDate"
        Me.colResultLastDataLeakPublicationDate.ReadOnly = True
        Me.colResultLastDataLeakPublicationDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colResultLastDataLeakPublicationDate.Width = 134
        '
        'GridResultBindingSource
        '
        Me.GridResultBindingSource.AllowNew = False
        Me.GridResultBindingSource.DataMember = "GridResult"
        Me.GridResultBindingSource.DataSource = Me.DstResultSchema
        Me.GridResultBindingSource.Sort = ""
        '
        'DstResultSchema
        '
        Me.DstResultSchema.DataSetName = "ResultSchema"
        Me.DstResultSchema.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CmnGridResult
        '
        Me.CmnGridResult.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.CmnGridResult.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CmiGridResultCopy})
        Me.CmnGridResult.Name = "CmnGridResult"
        Me.CmnGridResult.Size = New System.Drawing.Size(107, 30)
        '
        'CmiGridResultCopy
        '
        Me.CmiGridResultCopy.Image = CType(resources.GetObject("CmiGridResultCopy.Image"), System.Drawing.Image)
        Me.CmiGridResultCopy.Name = "CmiGridResultCopy"
        Me.CmiGridResultCopy.Size = New System.Drawing.Size(106, 26)
        Me.CmiGridResultCopy.Text = "Copy"
        '
        'BkwQuery
        '
        Me.BkwQuery.WorkerReportsProgress = True
        Me.BkwQuery.WorkerSupportsCancellation = True
        '
        'GrbQueryType
        '
        Me.GrbQueryType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrbQueryType.Controls.Add(Me.BtnBrowseEmailListFile)
        Me.GrbQueryType.Controls.Add(Me.TxtEmailListFilePath)
        Me.GrbQueryType.Controls.Add(Me.RbtCheckEmailList)
        Me.GrbQueryType.Controls.Add(Me.TxtEmail)
        Me.GrbQueryType.Controls.Add(Me.RbtCheckSingleEmail)
        Me.GrbQueryType.Location = New System.Drawing.Point(9, 55)
        Me.GrbQueryType.Margin = New System.Windows.Forms.Padding(2)
        Me.GrbQueryType.Name = "GrbQueryType"
        Me.GrbQueryType.Padding = New System.Windows.Forms.Padding(2)
        Me.GrbQueryType.Size = New System.Drawing.Size(634, 84)
        Me.GrbQueryType.TabIndex = 6
        Me.GrbQueryType.TabStop = False
        Me.GrbQueryType.Text = "Query type"
        '
        'BtnBrowseEmailListFile
        '
        Me.BtnBrowseEmailListFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBrowseEmailListFile.Enabled = False
        Me.BtnBrowseEmailListFile.Location = New System.Drawing.Point(566, 47)
        Me.BtnBrowseEmailListFile.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnBrowseEmailListFile.Name = "BtnBrowseEmailListFile"
        Me.BtnBrowseEmailListFile.Size = New System.Drawing.Size(56, 19)
        Me.BtnBrowseEmailListFile.TabIndex = 4
        Me.BtnBrowseEmailListFile.Text = "Browse..."
        Me.BtnBrowseEmailListFile.UseVisualStyleBackColor = True
        '
        'TxtEmailListFilePath
        '
        Me.TxtEmailListFilePath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtEmailListFilePath.Enabled = False
        Me.TxtEmailListFilePath.Location = New System.Drawing.Point(146, 47)
        Me.TxtEmailListFilePath.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtEmailListFilePath.Name = "TxtEmailListFilePath"
        Me.TxtEmailListFilePath.Size = New System.Drawing.Size(416, 20)
        Me.TxtEmailListFilePath.TabIndex = 3
        '
        'RbtCheckEmailList
        '
        Me.RbtCheckEmailList.AutoSize = True
        Me.RbtCheckEmailList.Location = New System.Drawing.Point(4, 48)
        Me.RbtCheckEmailList.Margin = New System.Windows.Forms.Padding(2)
        Me.RbtCheckEmailList.Name = "RbtCheckEmailList"
        Me.RbtCheckEmailList.Size = New System.Drawing.Size(138, 17)
        Me.RbtCheckEmailList.TabIndex = 2
        Me.RbtCheckEmailList.Text = "Check Email list text file:"
        Me.RbtCheckEmailList.UseVisualStyleBackColor = True
        '
        'GrbQuerySource
        '
        Me.GrbQuerySource.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrbQuerySource.Controls.Add(Me.LblHackedEmails)
        Me.GrbQuerySource.Controls.Add(Me.ChkHackedEmails)
        Me.GrbQuerySource.Controls.Add(Me.LblHaveIBeenPwned)
        Me.GrbQuerySource.Controls.Add(Me.ChkHaveIBeenPwned)
        Me.GrbQuerySource.Location = New System.Drawing.Point(659, 55)
        Me.GrbQuerySource.Margin = New System.Windows.Forms.Padding(2)
        Me.GrbQuerySource.Name = "GrbQuerySource"
        Me.GrbQuerySource.Padding = New System.Windows.Forms.Padding(2)
        Me.GrbQuerySource.Size = New System.Drawing.Size(215, 84)
        Me.GrbQuerySource.TabIndex = 6
        Me.GrbQuerySource.TabStop = False
        Me.GrbQuerySource.Text = "Query source"
        '
        'LblHackedEmails
        '
        Me.LblHackedEmails.AutoSize = True
        Me.LblHackedEmails.Location = New System.Drawing.Point(22, 36)
        Me.LblHackedEmails.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblHackedEmails.Name = "LblHackedEmails"
        Me.LblHackedEmails.Size = New System.Drawing.Size(141, 13)
        Me.LblHackedEmails.TabIndex = 3
        Me.LblHackedEmails.TabStop = True
        Me.LblHackedEmails.Text = "Has my email been hacked?"
        '
        'ChkHackedEmails
        '
        Me.ChkHackedEmails.AutoSize = True
        Me.ChkHackedEmails.Checked = True
        Me.ChkHackedEmails.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkHackedEmails.Location = New System.Drawing.Point(4, 37)
        Me.ChkHackedEmails.Margin = New System.Windows.Forms.Padding(2)
        Me.ChkHackedEmails.Name = "ChkHackedEmails"
        Me.ChkHackedEmails.Size = New System.Drawing.Size(15, 14)
        Me.ChkHackedEmails.TabIndex = 2
        Me.ChkHackedEmails.UseVisualStyleBackColor = True
        '
        'LblHaveIBeenPwned
        '
        Me.LblHaveIBeenPwned.AutoSize = True
        Me.LblHaveIBeenPwned.Location = New System.Drawing.Point(22, 18)
        Me.LblHaveIBeenPwned.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblHaveIBeenPwned.Name = "LblHaveIBeenPwned"
        Me.LblHaveIBeenPwned.Size = New System.Drawing.Size(109, 13)
        Me.LblHaveIBeenPwned.TabIndex = 1
        Me.LblHaveIBeenPwned.TabStop = True
        Me.LblHaveIBeenPwned.Text = "Have I Been Pwned?"
        '
        'ChkHaveIBeenPwned
        '
        Me.ChkHaveIBeenPwned.AutoSize = True
        Me.ChkHaveIBeenPwned.Checked = True
        Me.ChkHaveIBeenPwned.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkHaveIBeenPwned.Location = New System.Drawing.Point(4, 19)
        Me.ChkHaveIBeenPwned.Margin = New System.Windows.Forms.Padding(2)
        Me.ChkHaveIBeenPwned.Name = "ChkHaveIBeenPwned"
        Me.ChkHaveIBeenPwned.Size = New System.Drawing.Size(15, 14)
        Me.ChkHaveIBeenPwned.TabIndex = 0
        Me.ChkHaveIBeenPwned.UseVisualStyleBackColor = True
        '
        'NudCacheTTL
        '
        Me.NudCacheTTL.Location = New System.Drawing.Point(234, 18)
        Me.NudCacheTTL.Maximum = New Decimal(New Integer() {720, 0, 0, 0})
        Me.NudCacheTTL.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudCacheTTL.Name = "NudCacheTTL"
        Me.NudCacheTTL.Size = New System.Drawing.Size(40, 20)
        Me.NudCacheTTL.TabIndex = 6
        Me.NudCacheTTL.Value = New Decimal(New Integer() {48, 0, 0, 0})
        '
        'LblCacheTTL
        '
        Me.LblCacheTTL.AutoSize = True
        Me.LblCacheTTL.Location = New System.Drawing.Point(104, 20)
        Me.LblCacheTTL.Name = "LblCacheTTL"
        Me.LblCacheTTL.Size = New System.Drawing.Size(124, 13)
        Me.LblCacheTTL.TabIndex = 5
        Me.LblCacheTTL.Text = "Cache expiration (hours):"
        '
        'ChkEnableCache
        '
        Me.ChkEnableCache.AutoSize = True
        Me.ChkEnableCache.Checked = True
        Me.ChkEnableCache.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEnableCache.Location = New System.Drawing.Point(6, 19)
        Me.ChkEnableCache.Name = "ChkEnableCache"
        Me.ChkEnableCache.Size = New System.Drawing.Size(92, 17)
        Me.ChkEnableCache.TabIndex = 4
        Me.ChkEnableCache.Text = "Enable cache"
        Me.ChkEnableCache.UseVisualStyleBackColor = True
        '
        'TxtOutput
        '
        Me.TxtOutput.BackColor = System.Drawing.Color.White
        Me.TxtOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtOutput.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOutput.Location = New System.Drawing.Point(2, 15)
        Me.TxtOutput.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtOutput.Name = "TxtOutput"
        Me.TxtOutput.ReadOnly = True
        Me.TxtOutput.Size = New System.Drawing.Size(862, 77)
        Me.TxtOutput.TabIndex = 7
        Me.TxtOutput.Text = ""
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(9, 207)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(2)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GrbQueryResult)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GrbOutput)
        Me.SplitContainer1.Size = New System.Drawing.Size(866, 332)
        Me.SplitContainer1.SplitterDistance = 235
        Me.SplitContainer1.SplitterWidth = 3
        Me.SplitContainer1.TabIndex = 8
        '
        'GrbOutput
        '
        Me.GrbOutput.Controls.Add(Me.TxtOutput)
        Me.GrbOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrbOutput.Location = New System.Drawing.Point(0, 0)
        Me.GrbOutput.Margin = New System.Windows.Forms.Padding(2)
        Me.GrbOutput.Name = "GrbOutput"
        Me.GrbOutput.Padding = New System.Windows.Forms.Padding(2)
        Me.GrbOutput.Size = New System.Drawing.Size(866, 94)
        Me.GrbOutput.TabIndex = 8
        Me.GrbOutput.TabStop = False
        Me.GrbOutput.Text = "Output"
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.DataPropertyName = "Image"
        Me.DataGridViewImageColumn1.HeaderText = ""
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.ReadOnly = True
        Me.DataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewImageColumn1.Width = 32
        '
        'GrbQueryOptions
        '
        Me.GrbQueryOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrbQueryOptions.Controls.Add(Me.NudSourceRequestDelay)
        Me.GrbQueryOptions.Controls.Add(Me.Lbl)
        Me.GrbQueryOptions.Controls.Add(Me.NudCacheTTL)
        Me.GrbQueryOptions.Controls.Add(Me.ChkEnableCache)
        Me.GrbQueryOptions.Controls.Add(Me.LblCacheTTL)
        Me.GrbQueryOptions.Location = New System.Drawing.Point(9, 144)
        Me.GrbQueryOptions.Name = "GrbQueryOptions"
        Me.GrbQueryOptions.Size = New System.Drawing.Size(865, 58)
        Me.GrbQueryOptions.TabIndex = 9
        Me.GrbQueryOptions.TabStop = False
        Me.GrbQueryOptions.Text = "Query options"
        '
        'NudSourceRequestDelay
        '
        Me.NudSourceRequestDelay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NudSourceRequestDelay.Location = New System.Drawing.Point(806, 18)
        Me.NudSourceRequestDelay.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.NudSourceRequestDelay.Name = "NudSourceRequestDelay"
        Me.NudSourceRequestDelay.Size = New System.Drawing.Size(53, 20)
        Me.NudSourceRequestDelay.TabIndex = 8
        Me.NudSourceRequestDelay.Value = New Decimal(New Integer() {2000, 0, 0, 0})
        '
        'Lbl
        '
        Me.Lbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl.AutoSize = True
        Me.Lbl.Location = New System.Drawing.Point(530, 20)
        Me.Lbl.Name = "Lbl"
        Me.Lbl.Size = New System.Drawing.Size(270, 13)
        Me.Lbl.TabIndex = 7
        Me.Lbl.Text = "Delay between requests on  same source (milliseconds):"
        '
        'OfdEmailList
        '
        Me.OfdEmailList.DefaultExt = "txt"
        Me.OfdEmailList.Filter = "Text file|*.txt|All files|*.*"
        Me.OfdEmailList.Title = "Open Email List file"
        '
        'DataGridViewImageColumn2
        '
        Me.DataGridViewImageColumn2.DataPropertyName = "Image"
        Me.DataGridViewImageColumn2.HeaderText = ""
        Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
        Me.DataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewImageColumn2.Width = 32
        '
        'MniEdit
        '
        Me.MniEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MniEditCopy})
        Me.MniEdit.Name = "MniEdit"
        Me.MniEdit.Size = New System.Drawing.Size(39, 20)
        Me.MniEdit.Text = "&Edit"
        '
        'MniEditCopy
        '
        Me.MniEditCopy.Enabled = False
        Me.MniEditCopy.Image = CType(resources.GetObject("MniEditCopy.Image"), System.Drawing.Image)
        Me.MniEditCopy.Name = "MniEditCopy"
        Me.MniEditCopy.Size = New System.Drawing.Size(156, 26)
        Me.MniEditCopy.Text = "&Copy"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.GrbQueryOptions)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.GrbQuerySource)
        Me.Controls.Add(Me.GrbQueryType)
        Me.Controls.Add(Me.StsMain)
        Me.Controls.Add(Me.TlsMain)
        Me.Controls.Add(Me.MnuMain)
        Me.MainMenuStrip = Me.MnuMain
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MainForm"
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.TlsMain.ResumeLayout(False)
        Me.TlsMain.PerformLayout()
        Me.StsMain.ResumeLayout(False)
        Me.StsMain.PerformLayout()
        Me.GrbQueryResult.ResumeLayout(False)
        CType(Me.GrdResult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridResultBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DstResultSchema, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CmnGridResult.ResumeLayout(False)
        Me.GrbQueryType.ResumeLayout(False)
        Me.GrbQueryType.PerformLayout()
        Me.GrbQuerySource.ResumeLayout(False)
        Me.GrbQuerySource.PerformLayout()
        CType(Me.NudCacheTTL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GrbOutput.ResumeLayout(False)
        Me.GrbQueryOptions.ResumeLayout(False)
        Me.GrbQueryOptions.PerformLayout()
        CType(Me.NudSourceRequestDelay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RbtCheckSingleEmail As RadioButton
    Friend WithEvents TxtEmail As TextBox
    Friend WithEvents MnuMain As MenuStrip
    Friend WithEvents TlsMain As ToolStrip
    Friend WithEvents StsMain As StatusStrip
    Friend WithEvents GrbQueryResult As GroupBox
    Friend WithEvents MniActions As ToolStripMenuItem
    Friend WithEvents MniActionsExecute As ToolStripMenuItem
    Friend WithEvents MniActionsStop As ToolStripMenuItem
    Friend WithEvents BtnExecute As ToolStripButton
    Friend WithEvents BtnStop As ToolStripButton
    Friend WithEvents BkwQuery As System.ComponentModel.BackgroundWorker
    Friend WithEvents GrbQueryType As GroupBox
    Friend WithEvents GrbQuerySource As GroupBox
    Friend WithEvents LblHaveIBeenPwned As LinkLabel
    Friend WithEvents ChkHaveIBeenPwned As CheckBox
    Friend WithEvents ChkHackedEmails As CheckBox
    Friend WithEvents LblHackedEmails As LinkLabel
    Friend WithEvents LblStatus As ToolStripStatusLabel
    Friend WithEvents TxtOutput As RichTextBox
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents GrbOutput As GroupBox
    Friend WithEvents ChkEnableCache As CheckBox
    Friend WithEvents NudCacheTTL As NumericUpDown
    Friend WithEvents LblCacheTTL As Label
    Friend WithEvents BtnClearCache As ToolStripButton
    Friend WithEvents GrdResult As DataGridView
    Friend WithEvents ImageDataGridViewTextBoxColumn As DataGridViewImageColumn
    Friend WithEvents GridResultBindingSource As BindingSource
    Friend WithEvents DstResultSchema As ResultSchema
    Friend WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
    Friend WithEvents BtnBrowseEmailListFile As Button
    Friend WithEvents TxtEmailListFilePath As TextBox
    Friend WithEvents RbtCheckEmailList As RadioButton
    Friend WithEvents MniCache As ToolStripMenuItem
    Friend WithEvents MniClearCache As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents GrbQueryOptions As GroupBox
    Friend WithEvents OfdEmailList As OpenFileDialog
    Friend WithEvents NudSourceRequestDelay As NumericUpDown
    Friend WithEvents Lbl As Label
    Friend WithEvents MniHelp As ToolStripMenuItem
    Friend WithEvents MniHelpAbout As ToolStripMenuItem
    Friend WithEvents DataGridViewImageColumn2 As DataGridViewImageColumn
    Friend WithEvents MniFile As ToolStripMenuItem
    Friend WithEvents MniFileExit As ToolStripMenuItem
    Friend WithEvents CmnGridResult As ContextMenuStrip
    Friend WithEvents CmiGridResultCopy As ToolStripMenuItem
    Friend WithEvents colResultImage As DataGridViewImageColumn
    Friend WithEvents colResultEmail As DataGridViewTextBoxColumn
    Friend WithEvents colResultHaveIBeenPwned As DataGridViewTextBoxColumn
    Friend WithEvents colResultHackedEmails As DataGridViewTextBoxColumn
    Friend WithEvents colResultLastDataLeakDate As DataGridViewTextBoxColumn
    Friend WithEvents colResultLastDataLeakPublicationDate As DataGridViewTextBoxColumn
    Friend WithEvents BtnCopyCell As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents MniEdit As ToolStripMenuItem
    Friend WithEvents MniEditCopy As ToolStripMenuItem
End Class
