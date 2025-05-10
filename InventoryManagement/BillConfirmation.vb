Imports System.Data.SqlClient

Public Class BillConfirmation
    Public con As New SqlConnection("Data Source=EDITH;Initial Catalog=Inventory;Persist Security Info=True;User ID=haritha;Password=123;TrustServerCertificate=True")
    Public cmd As New SqlCommand
    Public qr As String

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Me.Dispose()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtTax_TextChanged(sender As Object, e As EventArgs) Handles txtTax.TextChanged
        If String.IsNullOrWhiteSpace(txtBillNo.Text) Then
            MsgBox("Please enter Bill Number Again")
            txtBillNo.Focus()
            Exit Sub
        End If

        CalculateTotal()
    End Sub

    Private Sub txtDiscount_TextChanged(sender As Object, e As EventArgs) Handles txtDiscount.TextChanged
        If String.IsNullOrWhiteSpace(txtBillNo.Text) Then
            MsgBox("Please enter Bill Number Again")
            txtBillNo.Focus()
            Exit Sub
        End If

        CalculateTotal()
    End Sub

    Private Sub CalculateTotal()
        Try
            Dim billNo As String = txtBillNo.Text
            Dim subtotal As Decimal = GetSubtotalFromDatabase(billNo)

            Dim tax As Decimal = If(Decimal.TryParse(txtTax.Text, tax), tax, 0)
            Dim discount As Decimal = If(Decimal.TryParse(txtDiscount.Text, discount), discount, 0)

            Dim total As Decimal = subtotal + (subtotal * tax / 100) - (subtotal * discount / 100)

            txtTotal.Text = total.ToString("F2")
        Catch ex As Exception
            MsgBox("Error calculating total: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Function GetSubtotalFromDatabase(billNo As String) As Decimal
        Dim subtotal As Decimal = 0

        Dim connString As String = "Data Source=EDITH;Initial Catalog=Inventory;Persist Security Info=True;User ID=haritha;Password=123;TrustServerCertificate=True"
        Using conn As New SqlConnection(connString)
            conn.Open()
            Dim query As String = "SELECT subtotal FROM Billing_table WHERE bill_no = @BillNumber"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@BillNumber", billNo)

                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing Then
                    subtotal = Convert.ToDecimal(result)
                Else
                    MsgBox("Bill Number not found.", MsgBoxStyle.Exclamation)
                End If
            End Using
        End Using

        Return subtotal
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            qr = "UPDATE Billing_table SET subtotal = subtotal, tax = tax, discount = discount WHERE bill_no = @billno"
            Using cmd As New SqlCommand(qr, con)
                cmd.Parameters.AddWithValue("@subtotal", txtTotal.Text)
                cmd.Parameters.AddWithValue("@tax", txtTax.Text)
                cmd.Parameters.AddWithValue("@discount", txtDiscount.Text)
                cmd.Parameters.AddWithValue("@billno", txtBillNo.Text)

                con.Open()
                If cmd.ExecuteNonQuery() > 0 Then
                    MsgBox("Billing record updated successfully!", MsgBoxStyle.Information)
                Else
                    MsgBox("Entry not found!", MsgBoxStyle.Exclamation)
                End If
            End Using

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            con.Close()
        End Try
    End Sub
End Class