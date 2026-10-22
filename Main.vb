Imports System.Text
Imports System.Linq
Public Class Main


    Private Sub AddToOrder(prod As ProductsManage.Product)
        ' Check if the product is already in the order list
        Dim existing = Orders.FirstOrDefault(Function(o) o.Product.ID = prod.ID)

        If existing IsNot Nothing Then
            existing.Quantity += 1
        Else
            Orders.Add(New OrderItem With {.Product = prod, .Quantity = 1})
        End If

        RefreshOrders()
    End Sub

    Private Sub Guna2GradientTileButton2_Click(sender As Object, e As EventArgs) Handles Guna2GradientTileButton2.Click
        Me.Hide()
        ProductsManage.Show()

    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProducts()
    End Sub

    Public Sub LoadProducts()
        flpProducts.Controls.Clear()

        For Each prod In ModuleProducts.ProductList
            Dim item As New UserControl1 With {
            .ProductName = prod.Name,
            .ProductPrice = prod.Price,
            .ProductImage = prod.Image
        }


            AddHandler item.ProductClicked, Sub()
                                                AddToOrder(prod)
                                            End Sub

            flpProducts.Controls.Add(item)
        Next
    End Sub

    Public Class OrderItem
        Public Property Product As ProductsManage.Product
        Public Property Quantity As Integer = 1
    End Class

    Private Orders As New List(Of OrderItem)

    Private Sub Product_Click(sender As Object, e As EventArgs)
        Dim prod As ProductsManage.Product = CType(CType(sender, Button).Tag, ProductsManage.Product)
        Dim existing = Orders.FirstOrDefault(Function(o) o.Product.ID = prod.ID)

        If existing IsNot Nothing Then
            existing.Quantity += 1
        Else
            Orders.Add(New OrderItem With {.Product = prod, .Quantity = 1})
        End If

        RefreshOrders()
    End Sub

    Private Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click

        Dim total = Orders.Sum(Function(o) o.Quantity * o.Product.Price)
        Dim cash As Decimal

        If Decimal.TryParse(txtCash.Text, cash) Then
            If cash >= total Then
                Dim change = cash - total
                lblChange.Text = $"Change: ₱{change:F2}"

                ' Show receipt
                ShowReceipt(cash, change)

                MessageBox.Show("Payment Successful!")
                Orders.Clear()
                RefreshOrders()
                txtCash.Clear()
            Else
                MessageBox.Show("Insufficient cash.")
            End If
        Else
            MessageBox.Show("Please enter a valid cash amount.")
        End If
    End Sub

    Private Sub PnlOrders_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub RefreshOrders()
        pnlOrders.Controls.Clear()
        Dim total As Decimal = 0

        For Each order In Orders
            ' Create a container panel
            Dim panel As New Panel With {
            .Height = 60,
            .Dock = DockStyle.Top,
            .BackColor = Color.WhiteSmoke,
            .Padding = New Padding(0),
            .Margin = New Padding(0),
            .BorderStyle = BorderStyle.FixedSingle
        }

            ' Create TableLayoutPanel for responsive layout
            Dim tbl As New TableLayoutPanel With {
            .Dock = DockStyle.Fill,
            .ColumnCount = 3,
            .RowCount = 1
        }

            tbl.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))         ' Quantity (circle)
            tbl.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))     ' Name + price (centered)
            tbl.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))         ' Remove button

            ' Quantity Circle
            Dim lblQty As New Label With {
            .Text = order.Quantity.ToString(),
            .Width = 30,
            .Height = 30,
            .TextAlign = ContentAlignment.MiddleCenter,
            .BackColor = Color.LightPink,
            .ForeColor = Color.White,
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .Margin = New Padding(10, 15, 5, 15)
        }

            ' Circle shape
            Dim gp As New Drawing.Drawing2D.GraphicsPath()
            gp.AddEllipse(0, 0, lblQty.Width, lblQty.Height)
            lblQty.Region = New Region(gp)

            ' Product name and price (centered)
            Dim lblInfo As New Label With {
            .Text = $"{order.Product.Name} = ₱{order.Quantity * order.Product.Price:F2}",
            .Dock = DockStyle.Fill,
            .Font = New Font("Segoe UI", 9, FontStyle.Regular),
            .ForeColor = Color.Black,
            .TextAlign = ContentAlignment.MiddleCenter,
            .AutoSize = False
        }

            ' Remove button
            Dim btnRemove As New Button With {
            .Text = "Remove",
            .Width = 70,
            .Height = 30,
            .Tag = order,
            .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.IndianRed,
            .ForeColor = Color.White,
            .Margin = New Padding(5, 15, 10, 15)
        }
            btnRemove.FlatAppearance.BorderSize = 0

            AddHandler btnRemove.Click, Sub()
                                            Orders.Remove(order)
                                            RefreshOrders()
                                        End Sub

            ' Add to TableLayout
            tbl.Controls.Add(lblQty, 0, 0)
            tbl.Controls.Add(lblInfo, 1, 0)
            tbl.Controls.Add(btnRemove, 2, 0)

            ' Add layout panel to container
            panel.Controls.Add(tbl)
            pnlOrders.Controls.Add(panel)

            ' Calculate total
            total += order.Quantity * order.Product.Price
        Next

        lblTotal.Text = $"Total: ₱{total:F2}"
    End Sub

    Private Sub ShowReceipt(cash As Decimal, change As Decimal)
        Dim receipt As New StringBuilder()
        receipt.AppendLine("            VJJK COFFEE SHOP        ")
        receipt.AppendLine("        Poblacion, Your City Here   ")
        receipt.AppendLine("==============================================")
        receipt.AppendLine("Items:")
        receipt.AppendLine("")

        For Each order In Orders
            Dim line As String = $"{order.Product.Name} x{order.Quantity}  ₱{order.Quantity * order.Product.Price:F2}"
            receipt.AppendLine(line)
        Next

        receipt.AppendLine("")
        receipt.AppendLine("==============================================")
        Dim total = Orders.Sum(Function(o) o.Quantity * o.Product.Price)
        receipt.AppendLine($"Total:      ₱{total:F2}")
        receipt.AppendLine($"Cash:       ₱{cash:F2}")
        receipt.AppendLine($"Change:     ₱{change:F2}")
        receipt.AppendLine("==============================================")
        receipt.AppendLine("        Thank you for ordering at   ")
        receipt.AppendLine("             VJJK COFFEE SHOP!      ")

        Dim form As New ReceiptForm()
        form.LoadReceipt(receipt.ToString())
        form.ShowDialog()

    End Sub

    Private Sub Guna2Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel2.Paint

    End Sub

    Private Sub Guna2GradientTileButton4_Click(sender As Object, e As EventArgs) Handles Guna2GradientTileButton4.Click
        Me.Hide()
        LoginForm.Show()

    End Sub

    Private Sub aboutUs_Click(sender As Object, e As EventArgs) Handles aboutUs.Click
        Me.Hide()
        Form1.Show()

    End Sub
End Class
