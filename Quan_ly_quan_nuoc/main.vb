Imports System.Data.SqlClient

Public Class main
    Public conn As SqlConnection

    '=======================
    ' HÀM KẾT NỐI SQL
    '=======================
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

    '=======================
    ' FORM LOAD
    '=======================
    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBan()
        LoadDoUong()
        LoadGoiMon()
        LoadDUCombo()
    End Sub

    '=======================
    ' TAB 1: QUẢN LÝ BÀN
    '=======================
    Private Sub LoadBan()
        OpenConnection()
        Dim da As New SqlDataAdapter("SELECT * FROM Vitriban", conn)
        Dim dt As New DataTable
        da.Fill(dt)
        dgvBan.DataSource = dt
        CloseConnection()
    End Sub

    Private Sub Btnsuaban_Click(sender As Object, e As EventArgs) Handles Btnsuaban.Click
        If dgvBan.CurrentRow IsNot Nothing Then
            Dim maBan As String = dgvBan.CurrentRow.Cells("MaBan").Value.ToString()
            Dim trangThai As String = dgvBan.CurrentRow.Cells("TrangThai").Value.ToString()

            OpenConnection()
            Dim cmd As New SqlCommand("UPDATE Ban SET TrangThai=@tt WHERE MaBan=@mb", conn)
            cmd.Parameters.AddWithValue("@tt", trangThai)
            cmd.Parameters.AddWithValue("@mb", maBan)
            cmd.ExecuteNonQuery()
            CloseConnection()

            MessageBox.Show("Cập nhật trạng thái bàn thành công!")
            LoadBan()
        End If
    End Sub

    '=======================
    ' TAB 2: QUẢN LÝ ĐỒ UỐNG
    '=======================
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

    '=======================
    ' TAB 3: GỌI MÓN
    '=======================
    Private Sub LoadGoiMon()
        OpenConnection()
        Dim da As New SqlDataAdapter("SELECT * FROM Vitriban", conn)
        Dim dt As New DataTable
        da.Fill(dt)
        cbotenban.DataSource = dt
        cbotenban.DisplayMember = "TenBan"
        cbotenban.ValueMember = "MaBan"
        CloseConnection()
    End Sub

    Private Sub LoadDUCombo()
        OpenConnection()
        Dim da As New SqlDataAdapter("SELECT * FROM DoUong", conn)
        Dim dt As New DataTable
        da.Fill(dt)
        cbotendouong.DataSource = dt
        cbotendouong.DisplayMember = "TenDU"
        cbotendouong.ValueMember = "MaDU"
        CloseConnection()
    End Sub

    Private Sub btnThemdouong_Click(sender As Object, e As EventArgs) Handles btnThemdouong.Click
        Dim maHD As String = txtMaHD.Text
        Dim maBan As String = cbotenban.SelectedValue.ToString()
        Dim maDU As String = cbotendouong.SelectedValue.ToString()
        Dim soLuong As Integer = CInt(txtsoluong.Text)

        OpenConnection()
        ' Kiểm tra hóa đơn đã có chưa
        Dim cmdCheck As New SqlCommand("SELECT COUNT(*) FROM HoaDon WHERE MaHD=@ma", conn)
        cmdCheck.Parameters.AddWithValue("@ma", maHD)
        Dim exist As Integer = CInt(cmdCheck.ExecuteScalar())

        If exist = 0 Then
            Dim cmdHD As New SqlCommand("INSERT INTO HoaDon(MaHD, MaBan, Soluong, TongTien) VALUES(@mahd, @mb, @sl, 0)", conn)
            cmdHD.Parameters.AddWithValue("@mahd", maHD)
            cmdHD.Parameters.AddWithValue("@sl", soLuong)
            cmdHD.Parameters.AddWithValue("@mb", maBan)
            cmdHD.ExecuteNonQuery()
        End If

        ' Lấy giá đồ uống
        Dim cmdGia As New SqlCommand("SELECT DonGia FROM DoUong WHERE MaDU=@ma", conn)
        cmdGia.Parameters.AddWithValue("@ma", maDU)
        Dim donGia As Integer = CInt(cmdGia.ExecuteScalar())
        Dim thanhTien As Integer = donGia * soLuong

        ' Thêm chi tiết hóa đơn
        Dim cmdCT As New SqlCommand("INSERT INTO CTHoaDon(MaHD, MaDU, SoLuong, DonGia, ThanhTien) VALUES(@hd,@du,@sl,@dg,@tt)", conn)
        cmdCT.Parameters.AddWithValue("@hd", maHD)
        cmdCT.Parameters.AddWithValue("@du", maDU)
        cmdCT.Parameters.AddWithValue("@sl", soLuong)
        cmdCT.Parameters.AddWithValue("@dg", donGia)
        cmdCT.Parameters.AddWithValue("@tt", thanhTien)
        cmdCT.ExecuteNonQuery()

        CloseConnection()
        MessageBox.Show("Đã thêm món!")
    End Sub

    '=======================
    ' TAB 4: THANH TOÁN
    '=======================
    Private Sub btnthanhtoan_Click(sender As Object, e As EventArgs) Handles btnthanhtoan.Click
        Dim maHD As String = txtMaHD_TT.Text

        OpenConnection()
        ' Tính tổng tiền
        Dim cmdSum As New SqlCommand("SELECT SUM(ThanhTien) FROM CTHoaDon WHERE MaHD=@hd", conn)
        cmdSum.Parameters.AddWithValue("@hd", maHD)
        Dim tongTien As Integer = CInt(cmdSum.ExecuteScalar())

        ' Cập nhật hóa đơn
        Dim cmdUpdate As New SqlCommand("UPDATE HoaDon SET TongTien=@tt WHERE MaHD=@hd", conn)
        cmdUpdate.Parameters.AddWithValue("@tt", tongTien)
        cmdUpdate.Parameters.AddWithValue("@hd", maHD)
        cmdUpdate.ExecuteNonQuery()

        ' Lấy mã bàn
        Dim cmdBan As New SqlCommand("SELECT MaBan FROM HoaDon WHERE MaHD=@hd", conn)
        cmdBan.Parameters.AddWithValue("@hd", maHD)
        Dim maBan As String = cmdBan.ExecuteScalar().ToString()

        ' Cập nhật trạng thái bàn
        Dim cmdUpdBan As New SqlCommand("UPDATE Ban SET TrangThai='Trống' WHERE MaBan=@mb", conn)
        cmdUpdBan.Parameters.AddWithValue("@mb", maBan)
        cmdUpdBan.ExecuteNonQuery()

        CloseConnection()
        MessageBox.Show("Thanh toán thành công! Tổng tiền: " & tongTien.ToString("N0"))
        LoadBan()
    End Sub
End Class
