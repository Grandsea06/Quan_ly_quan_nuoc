Imports System.Data.SqlClient

Public Class main
    Private Const CmdText As String = "INSERT INTO ChiTietHoaDon(MaHD, MaDU, SoLuong, DonGia, ThanhTien) 
                                       VALUES(@hd,@du,@sl,@dg,@tt)"
    Public conn As SqlConnection

    'KẾT NỐI SQL
    Private Sub OpenConnection()
        If conn Is Nothing Then
            conn = New SqlConnection(connectionString)
        End If
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub

    Private Sub CloseConnection()
        If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub

    ' FORM LOAD
    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBan()
        LoadDoUong()
    End Sub

    ' TAB 1: QUẢN LÝ BÀN
    Private Sub LoadBan()
        OpenConnection()
        Dim da As New SqlDataAdapter("SELECT * FROM Vitriban", conn)
        Dim dt As New DataTable
        da.Fill(dt)
        dgvBan.DataSource = dt
        CloseConnection()
    End Sub

    Private Sub Btnsuaban_Click(sender As Object, e As EventArgs) Handles Btnsuaban.Click
        dgvBan.EndEdit()

        If dgvBan.CurrentRow IsNot Nothing Then
            Dim maBan As String = dgvBan.CurrentRow.Cells("MaBan").Value.ToString()
            Dim trangThai As String = dgvBan.CurrentRow.Cells("TrangThai").Value.ToString()

            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim sql As String = "UPDATE Vitriban SET TrangThai = @tt WHERE MaBan = @mb"
                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@tt", trangThai)
                    cmd.Parameters.AddWithValue("@mb", maBan)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("✅ Cập nhật trạng thái bàn thành công!")
            LoadBan()
        Else
            MessageBox.Show("⚠️ Vui lòng chọn 1 bàn để cập nhật!")
        End If
    End Sub

    ' TAB 2: QUẢN LÝ ĐỒ UỐNG
    Private Sub LoadDoUong()
        OpenConnection()
        Dim da As New SqlDataAdapter("SELECT * FROM DoUong", conn)
        Dim dt As New DataTable
        da.Fill(dt)
        dgvquanlydouong.DataSource = dt
        CloseConnection()
    End Sub

    Private Sub BtnthemDU_Click(sender As Object, e As EventArgs) Handles btnThemdouong.Click
        If dgvquanlydouong.CurrentRow IsNot Nothing Then
            OpenConnection()
            Dim sql As String = "INSERT INTO DoUong(MaDU, TenDoUong, DonGia, DonVi) VALUES(@ma, @ten, @gia, @dv)"
            Dim cmd As New SqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@ma", Guid.NewGuid().ToString().Substring(0, 5))
            cmd.Parameters.AddWithValue("@ten", dgvquanlydouong.CurrentRow.Cells("TenDoUong").Value.ToString())
            cmd.Parameters.AddWithValue("@gia", CInt(dgvquanlydouong.CurrentRow.Cells("DonGia").Value))
            cmd.Parameters.AddWithValue("@dv", dgvquanlydouong.CurrentRow.Cells("DonVi").Value.ToString())
            cmd.ExecuteNonQuery()
            CloseConnection()
            LoadDoUong()
        End If
    End Sub

    Private Sub btnXoadouong_Click(sender As Object, e As EventArgs) Handles btnXoadouong.Click
        If dgvquanlydouong.CurrentRow IsNot Nothing Then
            Dim maDU As String = dgvquanlydouong.CurrentRow.Cells("MaDU").Value.ToString()
            OpenConnection()
            Dim cmd As New SqlCommand("DELETE FROM DoUong WHERE MaDU=@ma", conn)
            cmd.Parameters.AddWithValue("@ma", maDU)
            cmd.ExecuteNonQuery()
            CloseConnection()
            LoadDoUong()
        End If
    End Sub

    ' TAB 3: GỌI MÓN
    Private Sub LoadChiTietHoaDon()
        Using conn As New SqlConnection(connectionString)
            conn.Open()

            Dim sql As String = "
            SELECT cthd.MaHD, du.TenDoUong, cthd.SoLuong, cthd.DonGia, cthd.ThanhTien
            FROM ChiTietHoaDon cthd
            JOIN DoUong du ON cthd.MaDU = du.MaDU
            WHERE cthd.MaHD = @mahd
        "

            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@mahd", txtMaHD.Text.Trim())

                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)

                dgvgoimon.DataSource = dt
            End Using
        End Using
    End Sub


    Private Sub btnThemMon_Click(sender As Object, e As EventArgs) Handles BtnthemDU.Click
        If txtMaHD.Text.Trim() = "" Or txtmabangm.Text.Trim() = "" Or txttendu.Text.Trim() = "" Or txtsoluong.Text.Trim() = "" Then
            MessageBox.Show("⚠️ Vui lòng nhập đầy đủ thông tin!", "Thông báo")
            Return
        End If

        Dim maHD As String = txtMaHD.Text.Trim()
        Dim maBan As String = txtmabangm.Text.Trim()
        Dim maDU As String = txttendu.Text.Trim()
        Dim soLuong As Integer = CInt(txtsoluong.Text)

        Using conn As New SqlConnection(connectionString)
            conn.Open()

            ' Kiểm tra hóa đơn
            Dim checkCmd As New SqlCommand("SELECT COUNT(*) FROM HoaDon WHERE MaHD = @mahd", conn)
            checkCmd.Parameters.AddWithValue("@mahd", maHD)
            Dim count As Integer = CInt(checkCmd.ExecuteScalar())

            If count = 0 Then
                Dim cmdHD As New SqlCommand("INSERT INTO HoaDon(MaHD, MaBan) VALUES(@mahd, @maban)", conn)
                cmdHD.Parameters.AddWithValue("@mahd", maHD)
                cmdHD.Parameters.AddWithValue("@maban", maBan)
                cmdHD.ExecuteNonQuery()
            End If

            ' Lấy giá đồ uống
            Dim giaCmd As New SqlCommand("SELECT DonGia FROM DoUong WHERE MaDU = @madu", conn)
            giaCmd.Parameters.AddWithValue("@madu", maDU)
            Dim donGia As Decimal = CDec(giaCmd.ExecuteScalar())
            Dim thanhTien As Decimal = donGia * soLuong

            ' Thêm chi tiết hóa đơn
            Dim insertCmd As New SqlCommand("INSERT INTO ChiTietHoaDon(MaHD, MaDU, SoLuong, DonGia, ThanhTien) VALUES(@mahd, @madu, @sl, @gia, @tt)", conn)
            insertCmd.Parameters.AddWithValue("@mahd", maHD)
            insertCmd.Parameters.AddWithValue("@madu", maDU)
            insertCmd.Parameters.AddWithValue("@sl", soLuong)
            insertCmd.Parameters.AddWithValue("@gia", donGia)
            insertCmd.Parameters.AddWithValue("@tt", thanhTien)
            insertCmd.ExecuteNonQuery()
        End Using
        LoadChiTietHoaDon()
        MessageBox.Show("✅ Đã thêm món thành công!", "Thông báo")
    End Sub

    '  xóa dữ liệu nhập trên form
    Private Sub btnHuy_Click(sender As Object, e As EventArgs) Handles btnhuy.Click
        txtmabangm.Clear()
        txttendu.Clear()
        txtsoluong.Clear()
        txtMaHD.Clear()
        dgvgoimon.DataSource = Nothing
    End Sub
    ' TAB 4: THANH TOÁN
    Private Sub TabPage3_Click(sender As Object, e As EventArgs) Handles TabPage3.Click
        ' xóa sạch dữ liệu cũ
        txtMaHD_TT.Clear()
        txttenbantt.Clear()
        txttongtien.Clear()
        dgvthanhtoan.DataSource = Nothing
    End Sub

    ' tìm kiếm mã hóa đơn hoặc tên bàn
    Private Sub txtMaHDTT_TextChanged(sender As Object, e As EventArgs) Handles txtMaHD_TT.TextChanged
        TimHoaDon()
    End Sub

    Private Sub txttbtt_TextChanged(sender As Object, e As EventArgs) Handles txttenbantt.TextChanged
        TimHoaDon()
    End Sub

    Private Sub TimHoaDon()
        Dim maHD As String = txtMaHD_TT.Text.Trim()
        Dim tenBan As String = txttenbantt.Text.Trim()

        If maHD = "" And tenBan = "" Then
            dgvthanhtoan.DataSource = Nothing
            txttongtien.Text = ""
            Exit Sub
        End If

        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim sql As String = "
            SELECT hd.MaHD, b.TenBan, du.TenDoUong, ct.SoLuong, du.DonGia, 
                   (ct.SoLuong * du.DonGia) AS ThanhTien
            FROM HoaDon hd
            JOIN ChiTietHoaDon ct ON hd.MaHD = ct.MaHD
            JOIN DoUong du ON ct.MaDU = du.MaDU
            JOIN vitriBan b ON hd.MaBan = b.MaBan
            WHERE (@mahd = '' OR hd.MaHD = @mahd)
              AND (@tenban = '' OR b.TenBan LIKE '%' + @tenban + '%')
        "

            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@mahd", maHD)
                cmd.Parameters.AddWithValue("@tenban", tenBan)

                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                dgvthanhtoan.DataSource = dt

                '  Tính tổng tiền
                Dim tong As Decimal = 0
                For Each row As DataRow In dt.Rows
                    tong += Convert.ToDecimal(row("ThanhTien"))
                Next
                txttongtien.Text = tong.ToString("N0") & " VNĐ"
            End Using
        End Using
    End Sub

    Private Sub btnThanhToan_Click(sender As Object, e As EventArgs) Handles btnthanhtoan.Click
        If dgvthanhtoan.Rows.Count = 0 Then
            MessageBox.Show("⚠️ Không có hóa đơn để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim maHD As String = dgvthanhtoan.Rows(0).Cells("MaHD").Value.ToString()
        Dim tenBan As String = dgvthanhtoan.Rows(0).Cells("TenBan").Value.ToString()

        Using conn As New SqlConnection(connectionString)
            conn.Open()

            '  Xóa chi tiết hóa đơn
            Dim sqlCT As String = "DELETE FROM ChiTietHoaDon WHERE MaHD = @mahd"
            Using cmdCT As New SqlCommand(sqlCT, conn)
                cmdCT.Parameters.AddWithValue("@mahd", maHD)
                cmdCT.ExecuteNonQuery()
            End Using

            '  Xóa hóa đơn
            Dim sqlHD As String = "DELETE FROM HoaDon WHERE MaHD = @mahd"
            Using cmdHD As New SqlCommand(sqlHD, conn)
                cmdHD.Parameters.AddWithValue("@mahd", maHD)
                cmdHD.ExecuteNonQuery()
            End Using

            '  Cập nhật trạng thái bàn
            Dim sqlBan As String = "UPDATE VitriBan SET TrangThai = N'Trong' WHERE TenBan = @tenban"
            Using cmdBan As New SqlCommand(sqlBan, conn)
                cmdBan.Parameters.AddWithValue("@tenban", tenBan)
                cmdBan.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("✅ Thanh toán thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Reset lại form
        txtMaHD_TT.Clear()
        txttenbantt.Clear()
        txttongtien.Clear()
        dgvthanhtoan.DataSource = Nothing
    End Sub
End Class