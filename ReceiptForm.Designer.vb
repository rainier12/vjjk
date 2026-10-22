<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReceiptForm
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
        Me.rtbReceipt = New System.Windows.Forms.RichTextBox()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.bntPrint = New Guna.UI2.WinForms.Guna2Button()
        Me.SuspendLayout()
        '
        'rtbReceipt
        '
        Me.rtbReceipt.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbReceipt.Location = New System.Drawing.Point(62, 12)
        Me.rtbReceipt.Name = "rtbReceipt"
        Me.rtbReceipt.ReadOnly = True
        Me.rtbReceipt.Size = New System.Drawing.Size(195, 296)
        Me.rtbReceipt.TabIndex = 0
        Me.rtbReceipt.Text = ""
        '
        'PrintDocument1
        '
        '
        'bntPrint
        '
        Me.bntPrint.AutoRoundedCorners = True
        Me.bntPrint.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.bntPrint.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.bntPrint.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.bntPrint.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.bntPrint.FillColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.bntPrint.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bntPrint.ForeColor = System.Drawing.Color.White
        Me.bntPrint.Location = New System.Drawing.Point(62, 336)
        Me.bntPrint.Name = "bntPrint"
        Me.bntPrint.Size = New System.Drawing.Size(195, 26)
        Me.bntPrint.TabIndex = 1
        Me.bntPrint.Text = "Print"
        '
        'ReceiptForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(312, 383)
        Me.Controls.Add(Me.bntPrint)
        Me.Controls.Add(Me.rtbReceipt)
        Me.Name = "ReceiptForm"
        Me.Text = "ReceiptForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rtbReceipt As RichTextBox
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents bntPrint As Guna.UI2.WinForms.Guna2Button
End Class
