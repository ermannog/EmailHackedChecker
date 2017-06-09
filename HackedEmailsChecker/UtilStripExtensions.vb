Public Module UtilStripExtensions
    <System.Runtime.CompilerServices.Extension()>
    Public Sub SetText(ByVal label As ToolStripLabel, ByVal text As String)
        label.Text = text
        label.GetCurrentParent.Update()
    End Sub



End Module
