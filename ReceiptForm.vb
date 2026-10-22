Imports System.Drawing.Printing
Public Class ReceiptForm
    Private receiptText As String = ""

    Public Sub LoadReceipt(receipt As String)
        receiptText = receipt
        rtbReceipt.Text = receipt
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim font As New Font("Consolas", 10)
        e.Graphics.DrawString(receiptText, font, Brushes.Black, 50, 50)
    End Sub
    Private Sub ReceiptForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles bntPrint.Click
        PrintDocument1.Print()
    End Sub
End Class