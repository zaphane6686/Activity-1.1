<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lbl_1 = New Label()
        txtbx_input = New TextBox()
        btn_next = New Button()
        chk_show_pass = New CheckBox()
        btn_create_acc = New Button()
        Panel1 = New Panel()
        TableLayoutPanel1 = New TableLayoutPanel()
        Panel1.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' lbl_1
        ' 
        lbl_1.AutoSize = True
        lbl_1.Font = New Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lbl_1.Location = New Point(536, 151)
        lbl_1.Name = "lbl_1"
        lbl_1.Size = New Size(295, 81)
        lbl_1.TabIndex = 0
        lbl_1.Text = "Welcome"
        ' 
        ' txtbx_input
        ' 
        txtbx_input.Location = New Point(306, 320)
        txtbx_input.Multiline = True
        txtbx_input.Name = "txtbx_input"
        txtbx_input.Size = New Size(746, 34)
        txtbx_input.TabIndex = 1
        txtbx_input.Text = "Enter Username"
        ' 
        ' btn_next
        ' 
        btn_next.Location = New Point(627, 434)
        btn_next.Name = "btn_next"
        btn_next.Size = New Size(94, 29)
        btn_next.TabIndex = 2
        btn_next.Text = "Next"
        btn_next.UseVisualStyleBackColor = True
        ' 
        ' chk_show_pass
        ' 
        chk_show_pass.AutoSize = True
        chk_show_pass.Location = New Point(306, 360)
        chk_show_pass.Name = "chk_show_pass"
        chk_show_pass.Size = New Size(132, 24)
        chk_show_pass.TabIndex = 3
        chk_show_pass.Text = "Show Password"
        chk_show_pass.UseVisualStyleBackColor = True
        ' 
        ' btn_create_acc
        ' 
        btn_create_acc.Location = New Point(46, 656)
        btn_create_acc.Name = "btn_create_acc"
        btn_create_acc.Size = New Size(135, 34)
        btn_create_acc.TabIndex = 4
        btn_create_acc.Text = "Create Account"
        btn_create_acc.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(lbl_1)
        Panel1.Controls.Add(chk_show_pass)
        Panel1.Controls.Add(btn_create_acc)
        Panel1.Controls.Add(txtbx_input)
        Panel1.Controls.Add(btn_next)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(3, 3)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1326, 728)
        Panel1.TabIndex = 5
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(Panel1, 0, 0)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Size = New Size(1332, 734)
        TableLayoutPanel1.TabIndex = 6
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1332, 734)
        Controls.Add(TableLayoutPanel1)
        Name = "Form1"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        TableLayoutPanel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents lbl_1 As Label
    Friend WithEvents txtbx_input As TextBox
    Friend WithEvents btn_next As Button
    Friend WithEvents chk_show_pass As CheckBox
    Friend WithEvents btn_create_acc As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel

End Class
