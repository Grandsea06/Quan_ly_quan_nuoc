Imports System.Data.SqlClient

Public Class main
    Private Const CmdText As String = "INSERT INTO chitietHoaDon(MaHD, MaDU, SoLuong, DonGia, ThanhTien) 
                                 VALUES(@hd,@du,@sl,@dg,@tt)"
    Public conn As SqlConnection

    ' HÀM KẾT NỐI SQL
    Private Sub OpenConnection()
        If conn Is Nothing Then
            conn = New SqlConnection("Data Source=DESKTOP-ELGG8MC\SQLEXPRESS01;Initial Catalog=Quanlyquannuoc;Integrated Security=True")
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
        LoadGoiMon()
        LoadDUCombo()
        LoadHoaDonThanhToan()
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

            Using conn As New SqlConnection("Data Source=DESKTOP-ELGG8MC\SQLEXPRESS01;Initial Catalog=Quanlyquannuoc;Integrated Security=True")
                conn.Open()
                Dim sql As String = "UPDATE VitriBan SET TrangThai = @tt WHERE MaBan = @mb"
                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@tt", trangThai)
                    cmd.Parameters.AddWithValue("@mb", maBan)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show(" Cập nhật trạng thái bàn thành công!")
            LoadBan()
        Else
            MessageBox.Show(" Vui lòng chọn 1 bàn để cập nhật!")
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

    Private Sub BtnthemDU_Click(sender As Object, e As EventArgs) Handles BtnthemDU.Click
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
    ' HIỂN THỊ DANH SÁCH MÓN GỌI THEO HÓA ĐƠN
    Private Sub Loadgoimon()
        OpenConnection()
        Dim sql As String = "SELECT cthd.MaHD, b.TenBan, du.MaDU, cthd.SoLuong, cthd.DonGia, cthd.ThanhTien
                         FROM ChiTietHoaDon cthd
                         JOIN DoUong du ON cthd.MaDU = du.MaDU
                         JOIN HoaDon hd ON cthd.MaHD = hd.MaHD
                         JOIN Vitriban b ON hd.MaBan = b.MaBan
                         ORDER BY cthd.MaHD DESC"
        Dim da As New SqlDataAdapter(sql, conn)
        Dim dt As New DataTable
        da.Fill(dt)
        dgvgoimon.DataSource = dt
        CloseConnection()
    End Sub


    Private Sub LoadDUCombo()
        OpenConnection()
        Dim da As New SqlDataAdapter("SELECT * FROM DoUong", conn)
        Dim dt As New DataTable
        da.Fill(dt)
        cbotendouong.DataSource = dt
        cbotendouong.DisplayMember = "MaDU"
        cbotendouong.ValueMember = "MaDU"
        CloseConnection()
    End Sub

    Private Sub btnThemdouong_Click(sender As Object, e As EventArgs) Handles btnThemdouong.Click
        Dim maHD As String = txtMaHD.Text
        Dim maBan As String = cbotenban.SelectedValue.ToString()
        Dim Tendouong As String = cbotendouong.SelectedValue.ToString()
        Dim soLuong As Integer = CInt(txtsoluong.Text)

        OpenConnection()

        ' Lấy giá đồ uống
        Dim cmdGia As New SqlCommand("SELECT DonGia FROM DoUong WHERE Tendouong=@TDU", conn)
        cmdGia.Parameters.AddWithValue("@TDU", Tendouong)
        Dim donGia As Integer = CInt(cmdGia.ExecuteScalar())
        Dim thanhTien As Integer = donGia * soLuong

        ' Chèn vào bảng chi tiết hóa đơn
        Dim cmdCT As New SqlCommand(CmdText, conn)
        cmdCT.Parameters.AddWithValue("@hd", maHD)
        cmdCT.Parameters.AddWithValue("@TenDoUong", cbotendouong.SelectedValue)
        cmdCT.Parameters.AddWithValue("@SoLuong", txtsoluong.Text)
        cmdCT.Parameters.AddWithValue("@dg", donGia)
        cmdCT.Parameters.AddWithValue("@tt", thanhTien)
        cmdCT.ExecuteNonQuery()

        CloseConnection()
        MessageBox.Show("Đã thêm món!")
    End Sub

    ' TAB 4: THANH TOÁN
    ' HIỂN THỊ DANH SÁCH HÓA ĐƠN CHỜ THANH TOÁN
    Private Sub LoadHoaDonThanhToan()
        OpenConnection()
        Dim sql As String = "SELECT hd.MaHD, b.TenBan, SUM(ct.ThanhTien) AS TongTien
                         FROM HoaDon hd
                         JOIN ChiTietHoaDon ct ON hd.MaHD = ct.MaHD
                         JOIN Vitriban b ON hd.MaBan = b.MaBan
                         WHERE hd.TongTien IS NULL OR hd.TongTien = 0
                         GROUP BY hd.MaHD, b.TenBan
                         ORDER BY hd.MaHD DESC"
        Dim da As New SqlDataAdapter(sql, conn)
        Dim dt As New DataTable
        da.Fill(dt)
        dgvthanhtoan.DataSource = dt
        CloseConnection()
    End Sub

    Private Sub btnthanhtoan_Click(sender As Object, e As EventArgs) Handles btnthanhtoan.Click
        Dim maHD As String = txtMaHD_TT.Text

        OpenConnection()
        ' Tính tổng tiền
        Dim cmdSum As New SqlCommand("SELECT SUM(ThanhTien) FROM ChuTietHoaDon WHERE MaHD=@hd", conn)
        cmdSum.Parameters.AddWithValue("@hd", maHD)
        Dim tongTien As Integer = CInt(cmdSum.ExecuteScalar())

        ' Cập Nhật hóa đơn
        Dim cmdUpdate As New SqlCommand("UPDATE HoaDon SET TongTien=@tt WHERE MaHD=@hd", conn)
        cmdUpdate.Parameters.AddWithValue("@tt", tongTien)
        cmdUpdate.Parameters.AddWithValue("@hd", maHD)
        cmdUpdate.ExecuteNonQuery()

        ' Lấy mã bàn
        Dim cmdBan As New SqlCommand("SELECT MaBan FROM HoaDon WHERE MaHD=@hd", conn)
        cmdBan.Parameters.AddWithValue("@hd", maHD)
        Dim maBan As String = cmdBan.ExecuteScalar().ToString()

        ' Cập nhật trạng thái bàn
        Dim cmdUpdBan As New SqlCommand("UPDATE VitriBan SET TrangThai='Trống' WHERE MaBan=@mb", conn)
        cmdUpdBan.Parameters.AddWithValue("@mb", maBan)
        cmdUpdBan.ExecuteNonQuery()

        CloseConnection()
        MessageBox.Show("Thanh toán thành công! Tổng tiền: " & tongTien.ToString("N0"))
        LoadBan()
    End Sub
End Class
