<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class login
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btdangnhap = New System.Windows.Forms.Button()
        Me.txtmk = New System.Windows.Forms.TextBox()
        Me.txttk = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(185, 25)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(193, 39)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Đăng nhập"
        '
        'btdangnhap
        '
        Me.btdangnhap.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btdangnhap.Location = New System.Drawing.Point(166, 259)
        Me.btdangnhap.Margin = New System.Windows.Forms.Padding(4)
        Me.btdangnhap.Name = "btdangnhap"
        Me.btdangnhap.Size = New System.Drawing.Size(191, 53)
        Me.btdangnhap.TabIndex = 12
        Me.btdangnhap.Text = "Đăng nhập"
        Me.btdangnhap.UseVisualStyleBackColor = True
        '
        'txtmk
        '
        Me.txtmk.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmk.Location = New System.Drawing.Point(206, 155)
        Me.txtmk.Margin = New System.Windows.Forms.Padding(4)
        Me.txtmk.Name = "txtmk"
        Me.txtmk.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtmk.Size = New System.Drawing.Size(265, 38)
        Me.txtmk.TabIndex = 11
        '
        'txttk
        '
        Me.txttk.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttk.Location = New System.Drawing.Point(206, 93)
        Me.txttk.Margin = New System.Windows.Forms.Padding(4)
        Me.txttk.Name = "txttk"
        Me.txttk.Size = New System.Drawing.Size(265, 38)
        Me.txttk.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(38, 161)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 32)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Mật khẩu:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(38, 99)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(147, 32)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Tài khoản:"
        '
        'login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 359)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btdangnhap)
        Me.Controls.Add(Me.txtmk)
        Me.Controls.Add(Me.txttk)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "login"
        Me.Text = "login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents btdangnhap As Button
    Friend WithEvents txtmk As TextBox
    Friend WithEvents txttk As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
