<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Btnsuaban = New System.Windows.Forms.Button()
        Me.dgvBan = New System.Windows.Forms.DataGridView()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.btnXoadouong = New System.Windows.Forms.Button()
        Me.btnThemdouong = New System.Windows.Forms.Button()
        Me.dgvquanlydouong = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txttendu = New System.Windows.Forms.TextBox()
        Me.txtmabangm = New System.Windows.Forms.TextBox()
        Me.txtMaHD = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnhuy = New System.Windows.Forms.Button()
        Me.BtnthemDU = New System.Windows.Forms.Button()
        Me.dgvgoimon = New System.Windows.Forms.DataGridView()
        Me.txtsoluong = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.txttenbantt = New System.Windows.Forms.TextBox()
        Me.txtMaHD_TT = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnthanhtoan = New System.Windows.Forms.Button()
        Me.dgvthanhtoan = New System.Windows.Forms.DataGridView()
        Me.txttongtien = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvBan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.dgvquanlydouong, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvgoimon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvthanhtoan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(829, 752)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Btnsuaban)
        Me.TabPage1.Controls.Add(Me.dgvBan)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(7)
        Me.TabPage1.Size = New System.Drawing.Size(821, 723)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Quản lý bàn"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Btnsuaban
        '
        Me.Btnsuaban.Location = New System.Drawing.Point(240, 456)
        Me.Btnsuaban.Name = "Btnsuaban"
        Me.Btnsuaban.Size = New System.Drawing.Size(173, 85)
        Me.Btnsuaban.TabIndex = 2
        Me.Btnsuaban.Text = "Sửa"
        Me.Btnsuaban.UseVisualStyleBackColor = True
        '
        'dgvBan
        '
        Me.dgvBan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBan.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvBan.Location = New System.Drawing.Point(7, 7)
        Me.dgvBan.Name = "dgvBan"
        Me.dgvBan.RowHeadersWidth = 51
        Me.dgvBan.Size = New System.Drawing.Size(807, 311)
        Me.dgvBan.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.btnXoadouong)
        Me.TabPage4.Controls.Add(Me.btnThemdouong)
        Me.TabPage4.Controls.Add(Me.dgvquanlydouong)
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(821, 723)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Quản lý đồ uống"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'btnXoadouong
        '
        Me.btnXoadouong.Location = New System.Drawing.Point(340, 563)
        Me.btnXoadouong.Name = "btnXoadouong"
        Me.btnXoadouong.Size = New System.Drawing.Size(133, 96)
        Me.btnXoadouong.TabIndex = 3
        Me.btnXoadouong.Text = "Xóa"
        Me.btnXoadouong.UseVisualStyleBackColor = True
        '
        'btnThemdouong
        '
        Me.btnThemdouong.Location = New System.Drawing.Point(340, 414)
        Me.btnThemdouong.Name = "btnThemdouong"
        Me.btnThemdouong.Size = New System.Drawing.Size(133, 96)
        Me.btnThemdouong.TabIndex = 1
        Me.btnThemdouong.Text = "Thêm"
        Me.btnThemdouong.UseVisualStyleBackColor = True
        '
        'dgvquanlydouong
        '
        Me.dgvquanlydouong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvquanlydouong.Location = New System.Drawing.Point(13, 14)
        Me.dgvquanlydouong.Name = "dgvquanlydouong"
        Me.dgvquanlydouong.RowHeadersWidth = 51
        Me.dgvquanlydouong.RowTemplate.Height = 24
        Me.dgvquanlydouong.Size = New System.Drawing.Size(800, 323)
        Me.dgvquanlydouong.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txttendu)
        Me.TabPage2.Controls.Add(Me.txtmabangm)
        Me.TabPage2.Controls.Add(Me.txtMaHD)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.btnhuy)
        Me.TabPage2.Controls.Add(Me.BtnthemDU)
        Me.TabPage2.Controls.Add(Me.dgvgoimon)
        Me.TabPage2.Controls.Add(Me.txtsoluong)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(7)
        Me.TabPage2.Size = New System.Drawing.Size(821, 723)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Gọi món"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txttendu
        '
        Me.txttendu.Location = New System.Drawing.Point(278, 69)
        Me.txttendu.Name = "txttendu"
        Me.txttendu.Size = New System.Drawing.Size(260, 27)
        Me.txttendu.TabIndex = 14
        '
        'txtmabangm
        '
        Me.txtmabangm.Location = New System.Drawing.Point(278, 19)
        Me.txtmabangm.Name = "txtmabangm"
        Me.txtmabangm.Size = New System.Drawing.Size(260, 27)
        Me.txtmabangm.TabIndex = 13
        '
        'txtMaHD
        '
        Me.txtMaHD.Location = New System.Drawing.Point(622, 47)
        Me.txtMaHD.Name = "txtMaHD"
        Me.txtMaHD.Size = New System.Drawing.Size(94, 27)
        Me.txtMaHD.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(618, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 20)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Mã hóa đơn"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(97, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 29)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Mã bàn"
        '
        'btnhuy
        '
        Me.btnhuy.Location = New System.Drawing.Point(488, 552)
        Me.btnhuy.Name = "btnhuy"
        Me.btnhuy.Size = New System.Drawing.Size(157, 74)
        Me.btnhuy.TabIndex = 6
        Me.btnhuy.Text = "Hủy"
        Me.btnhuy.UseVisualStyleBackColor = True
        '
        'BtnthemDU
        '
        Me.BtnthemDU.Location = New System.Drawing.Point(152, 552)
        Me.BtnthemDU.Name = "BtnthemDU"
        Me.BtnthemDU.Size = New System.Drawing.Size(157, 74)
        Me.BtnthemDU.TabIndex = 5
        Me.BtnthemDU.Text = "Thêm"
        Me.BtnthemDU.UseVisualStyleBackColor = True
        '
        'dgvgoimon
        '
        Me.dgvgoimon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvgoimon.Location = New System.Drawing.Point(35, 177)
        Me.dgvgoimon.Name = "dgvgoimon"
        Me.dgvgoimon.RowHeadersWidth = 51
        Me.dgvgoimon.RowTemplate.Height = 24
        Me.dgvgoimon.Size = New System.Drawing.Size(750, 299)
        Me.dgvgoimon.TabIndex = 4
        '
        'txtsoluong
        '
        Me.txtsoluong.Location = New System.Drawing.Point(278, 122)
        Me.txtsoluong.Name = "txtsoluong"
        Me.txtsoluong.Size = New System.Drawing.Size(260, 27)
        Me.txtsoluong.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(97, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 29)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Số lượng"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(97, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 29)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Mã đồ uống"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.txttenbantt)
        Me.TabPage3.Controls.Add(Me.txtMaHD_TT)
        Me.TabPage3.Controls.Add(Me.Label7)
        Me.TabPage3.Controls.Add(Me.btnthanhtoan)
        Me.TabPage3.Controls.Add(Me.dgvthanhtoan)
        Me.TabPage3.Controls.Add(Me.txttongtien)
        Me.TabPage3.Controls.Add(Me.Label6)
        Me.TabPage3.Controls.Add(Me.Label5)
        Me.TabPage3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(7)
        Me.TabPage3.Size = New System.Drawing.Size(821, 723)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Thanh toán"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'txttenbantt
        '
        Me.txttenbantt.Location = New System.Drawing.Point(124, 20)
        Me.txttenbantt.Name = "txttenbantt"
        Me.txttenbantt.Size = New System.Drawing.Size(237, 27)
        Me.txttenbantt.TabIndex = 9
        '
        'txtMaHD_TT
        '
        Me.txtMaHD_TT.Location = New System.Drawing.Point(579, 82)
        Me.txtMaHD_TT.Name = "txtMaHD_TT"
        Me.txtMaHD_TT.Size = New System.Drawing.Size(175, 27)
        Me.txtMaHD_TT.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(575, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(179, 20)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Mã hóa đơn thanh toán"
        '
        'btnthanhtoan
        '
        Me.btnthanhtoan.Location = New System.Drawing.Point(329, 526)
        Me.btnthanhtoan.Name = "btnthanhtoan"
        Me.btnthanhtoan.Size = New System.Drawing.Size(159, 82)
        Me.btnthanhtoan.TabIndex = 5
        Me.btnthanhtoan.Text = "Thanh toán"
        Me.btnthanhtoan.UseVisualStyleBackColor = True
        '
        'dgvthanhtoan
        '
        Me.dgvthanhtoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvthanhtoan.Location = New System.Drawing.Point(54, 157)
        Me.dgvthanhtoan.Name = "dgvthanhtoan"
        Me.dgvthanhtoan.RowHeadersWidth = 51
        Me.dgvthanhtoan.RowTemplate.Height = 24
        Me.dgvthanhtoan.Size = New System.Drawing.Size(713, 313)
        Me.dgvthanhtoan.TabIndex = 4
        '
        'txttongtien
        '
        Me.txttongtien.Location = New System.Drawing.Point(124, 77)
        Me.txttongtien.Name = "txttongtien"
        Me.txttongtien.Size = New System.Drawing.Size(237, 27)
        Me.txttongtien.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 85)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 20)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Tổng tiền"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 20)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Tên bàn"
        '
        'Column4
        '
        Me.Column4.HeaderText = "Trạng thái"
        Me.Column4.MinimumWidth = 6
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 125
        '
        'Column3
        '
        Me.Column3.HeaderText = "Tên bàn"
        Me.Column3.MinimumWidth = 6
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 125
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(829, 752)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "main"
        Me.Text = "Form1"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvBan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.dgvquanlydouong, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgvgoimon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.dgvthanhtoan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvgoimon As DataGridView
    Friend WithEvents txtsoluong As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnhuy As Button
    Friend WithEvents BtnthemDU As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnthanhtoan As Button
    Friend WithEvents dgvthanhtoan As DataGridView
    Friend WithEvents txttongtien As TextBox
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents btnThemdouong As Button
    Friend WithEvents dgvquanlydouong As DataGridView
    Friend WithEvents btnXoadouong As Button
    Friend WithEvents txtMaHD As TextBox
    Friend WithEvents txtMaHD_TT As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Btnsuaban As Button
    Friend WithEvents dgvBan As DataGridView
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents txttendu As TextBox
    Friend WithEvents txtmabangm As TextBox
    Friend WithEvents txttenbantt As TextBox
End Class
