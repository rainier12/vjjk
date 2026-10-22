Public Class UserControl1
    Public Event ProductClicked()

    Private _productName As String
    Public Property ProductName As String
        Get
            Return _productName
        End Get
        Set(value As String)
            _productName = value
            lblName.Text = value
        End Set
    End Property

    Private _productPrice As Decimal
    Public Property ProductPrice As Decimal
        Get
            Return _productPrice
        End Get
        Set(value As Decimal)
            _productPrice = value
            lblPrice.Text = $"₱{value:F2}"
        End Set
    End Property

    Private _productImage As Image
    Public Property ProductImage As Image
        Get
            Return _productImage
        End Get
        Set(value As Image)
            _productImage = value
            Guna2PictureBox1.Image = value
        End Set
    End Property

    Private Sub Guna2PictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox1.Click

    End Sub

    Private Sub lblPrice_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblName_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub UserControl1_Click(sender As Object, e As EventArgs) Handles MyBase.Click, lblName.Click, lblPrice.Click, Guna2PictureBox1.Click

        RaiseEvent ProductClicked()


    End Sub

    Private Sub Guna2Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub UserControl1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class


