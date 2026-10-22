Public Class LoginForm

    Private Const ADMIN_USERNAME As String = "admin"
    Private Const ADMIN_PASSWORD As String = "admin1"

    Private Sub Guna2TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtUser.TextChanged

    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Dim username As String = txtUser.Text
        Dim password As String = txtPass.Text

        If username = ADMIN_USERNAME AndAlso password = ADMIN_PASSWORD Then
            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Hide()
            Main.Show()

        Else
            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub chkBox_CheckedChanged(sender As Object, e As EventArgs) Handles chkBox.CheckedChanged
        txtPass.UseSystemPasswordChar = Not chkBox.Checked
    End Sub
End Class
