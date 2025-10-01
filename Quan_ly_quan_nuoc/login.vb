Imports System.Data.SqlClient

Public Class login
    Private Sub btdangnhap_Click(sender As Object, e As EventArgs) Handles btdangnhap.Click
        Dim tk As String = txttk.Text.Trim()
        Dim mk As String = txtmk.Text.Trim()

        If tk = "" Or mk = "" Then
            MsgBox("Vui lòng nhập đầy đủ tài khoản và mật khẩu!")
            Return
        End If

        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()

                Dim sql As String = "SELECT COUNT(*) FROM Nhanvien WHERE Tendangnhap = @tk AND MatKhau = @mk"
                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@tk", tk)
                    cmd.Parameters.AddWithValue("@mk", mk)

                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                    If count > 0 Then
                        MsgBox("Đăng nhập thành công!", MsgBoxStyle.Information)
                        Me.Hide()
                        main.Show()
                    Else
                        MsgBox("Tài khoản hoặc mật khẩu sai!", MsgBoxStyle.Critical)
                        txttk.Text = ""
                        txtmk.Text = ""
                        txttk.Focus()
                    End If
                End Using
            End Using

        Catch ex As Exception
            MsgBox("Lỗi kết nối SQL: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class
