Public Class ProductsManage

    Public Class Product
        Public Property ID As String
        Public Property Name As String
        Public Property Price As Decimal
        Public Property Image As Image

    End Class

    Private products As New List(Of Product)

    Private Sub RefreshList()
        dgvProducts.Rows.Clear()
        For Each prod In products
            dgvProducts.Rows.Add(prod.ID, prod.Name, prod.Price)
        Next
    End Sub

    Private Sub ClearFields()
        txtID.Clear()
        txtName.Clear()
        txtPrice.Clear()
        pictureBox1.Image = Nothing
    End Sub

    Private Sub ProductsManage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With dgvProducts
            .ColumnCount = 3
            .Columns(0).Name = "Product ID"
            .Columns(1).Name = "Product Name"
            .Columns(2).Name = "Price"
            .Rows.Clear()
            .ReadOnly = True
            .AllowUserToAddRows = False
        End With
    End Sub

    Private Sub Guna2GradientTileButton1_Click(sender As Object, e As EventArgs) Handles Guna2GradientTileButton1.Click
        Me.Hide()
        Main.Show()

    End Sub

    Private Sub picProductsImg_Click(sender As Object, e As EventArgs) Handles pictureBox1.Click
        Using ofd As New OpenFileDialog
            ofd.Filter = "Image Files|*.jpg;*.png;*.bmp"
            If ofd.ShowDialog() = DialogResult.OK Then
                pictureBox1.Image = Image.FromFile(ofd.FileName)
            End If
        End Using
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim priceValue As Decimal
        If Not Decimal.TryParse(txtPrice.Text, priceValue) Then
            MessageBox.Show("Please enter a valid price.", "Invalid Input")
            Exit Sub
        End If

        Dim prod As New Product With {
        .ID = txtID.Text,
        .Name = txtName.Text,
        .Price = priceValue,
        .Image = pictureBox1.Image
    }

        ' Save to global product list
        ModuleProducts.ProductList.Add(prod)
        products.Add(prod)

        MessageBox.Show("Product saved successfully.", "Saved")


        Main.LoadProducts()

        RefreshList()
        ClearFields()
    End Sub


    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Dim prod = products.FirstOrDefault(Function(p) p.ID = txtID.Text)
        If prod IsNot Nothing Then
            prod.Name = txtName.Text
            prod.Price = txtPrice.Text
            prod.Image = pictureBox1.Image
            MessageBox.Show("Product updated.", "Edited")
        Else
            MessageBox.Show("Product ID not found.", "Error")
        End If
        RefreshList()
        ClearFields()

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim prod = products.FirstOrDefault(Function(p) p.ID = txtID.Text)
        If prod IsNot Nothing Then
            products.Remove(prod)
            MessageBox.Show("Product deleted.", "Deleted")
        Else
            MessageBox.Show("Product ID not found.", "Error")
        End If
        RefreshList()
        ClearFields()

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim prod = products.FirstOrDefault(Function(p) p.ID = txtSearch.Text)
        If prod IsNot Nothing Then
            txtID.Text = prod.ID
            txtName.Text = prod.Name
            txtPrice.Text = prod.Price
            pictureBox1.Image = prod.Image
        End If
    End Sub

    Private Sub dgvProducts_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProducts.CellContentClick

    End Sub

    Private Sub Guna2GradientTileButton4_Click(sender As Object, e As EventArgs) Handles Guna2GradientTileButton4.Click
        Me.Hide()
        LoginForm.Show()

    End Sub

    Private Sub Guna2GradientTileButton2_Click(sender As Object, e As EventArgs) Handles Guna2GradientTileButton2.Click

    End Sub

    Private Sub aboutUs_Click(sender As Object, e As EventArgs) Handles aboutUs.Click
        Me.Hide()
        Form1.Show()

    End Sub
End Class