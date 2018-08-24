<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
    Me.btnConvert = New System.Windows.Forms.Button()
    Me.txtResults = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.progBarConvertImage = New System.Windows.Forms.ProgressBar()
    Me.lblConvertImage = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'btnConvert
    '
    Me.btnConvert.Location = New System.Drawing.Point(40, 73)
    Me.btnConvert.Name = "btnConvert"
    Me.btnConvert.Size = New System.Drawing.Size(186, 44)
    Me.btnConvert.TabIndex = 0
    Me.btnConvert.Text = "Select and Convert Image File"
    Me.btnConvert.UseVisualStyleBackColor = True
    '
    'txtResults
    '
    Me.txtResults.Location = New System.Drawing.Point(40, 135)
    Me.txtResults.Multiline = True
    Me.txtResults.Name = "txtResults"
    Me.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtResults.Size = New System.Drawing.Size(700, 438)
    Me.txtResults.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(33, 19)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(542, 37)
    Me.Label1.TabIndex = 2
    Me.Label1.Text = "Convert Image File To Base64 String"
    '
    'progBarConvertImage
    '
    Me.progBarConvertImage.Location = New System.Drawing.Point(521, 94)
    Me.progBarConvertImage.Name = "progBarConvertImage"
    Me.progBarConvertImage.Size = New System.Drawing.Size(219, 23)
    Me.progBarConvertImage.Style = System.Windows.Forms.ProgressBarStyle.Marquee
    Me.progBarConvertImage.TabIndex = 3
    Me.progBarConvertImage.Visible = False
    '
    'lblConvertImage
    '
    Me.lblConvertImage.AutoSize = True
    Me.lblConvertImage.Location = New System.Drawing.Point(518, 78)
    Me.lblConvertImage.Name = "lblConvertImage"
    Me.lblConvertImage.Size = New System.Drawing.Size(99, 13)
    Me.lblConvertImage.TabIndex = 4
    Me.lblConvertImage.Text = "Converting Image..."
    Me.lblConvertImage.Visible = False
    '
    'Form1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(786, 622)
    Me.Controls.Add(Me.lblConvertImage)
    Me.Controls.Add(Me.progBarConvertImage)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.txtResults)
    Me.Controls.Add(Me.btnConvert)
    Me.Name = "Form1"
    Me.Text = "Form1"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents btnConvert As Button
  Friend WithEvents txtResults As TextBox
  Friend WithEvents Label1 As Label
  Friend WithEvents progBarConvertImage As ProgressBar
  Friend WithEvents lblConvertImage As Label
End Class
