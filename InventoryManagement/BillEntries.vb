Imports System.Data.SqlClient

Public Class BillEntries
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Me.Dispose()
        With BillingEntry
            .txtIName.Clear()
            .txtBillNo.Clear()
            .txtPrice.Clear()
            .txtSearchIName.Clear()
        End With
    End Sub

    Private Sub txtSearchBill_TextChanged(sender As Object, e As EventArgs) Handles txtSearchBill.TextChanged
        Try
            ListView1.Items.Clear()
            Using con As New SqlConnection("Data Source=EDITH;Initial Catalog=Inventory;Persist Security Info=True;User ID=haritha;Password=123;TrustServerCertificate=True")
                con.Open()
                Using cmd As New SqlCommand("SELECT * FROM Billing_table WHERE bill_no LIKE @searchText", con)
                    cmd.Parameters.AddWithValue("@searchText", "%" & txtSearchBill.Text.Trim & "%")
                    Using Read As SqlDataReader = cmd.ExecuteReader()
                        While Read.Read()
                            Dim view As New ListViewItem(Read.Item("bill_no").ToString())
                            view.SubItems.Add(Read.Item("c_name").ToString())
                            view.SubItems.Add(If(IsDBNull(Read.Item("bill_date")), "N/A", Read.Item("bill_date").ToString()))
                            view.SubItems.Add(If(IsDBNull(Read.Item("subtotal")), "0", Read.Item("subtotal").ToString()))
                            ListView1.Items.Add(view)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            With BillingEntry
                .txtBillNo.Text = Me.ListView1.SelectedItems(0).SubItems(0).Text
                .comboCName.Text = Me.ListView1.SelectedItems(0).SubItems(1).Text
                .txtDate.Text = Me.ListView1.SelectedItems(0).SubItems(2).Text
                .txtTotal.Text = Me.ListView1.SelectedItems(0).SubItems(3).Text
            End With

            Dim selectedInvoiceNo As String = ListView1.SelectedItems(0).SubItems(0).Text
            LoadBillingEntryData(selectedInvoiceNo)

            Me.Dispose()
        End If
    End Sub

    Private Sub LoadBillingEntryData(BillNo As String)
        Try
            Using con As New SqlConnection("Data Source=EDITH;Initial Catalog=Inventory;Persist Security Info=True;User ID=haritha;Password=123;TrustServerCertificate=True")
                con.Open()
                Using cmd As New SqlCommand("SELECT item_name, quantity, price, amount FROM BillingEntry_table WHERE bill_no = @billNo", con)
                    cmd.Parameters.AddWithValue("@billNo", BillNo)
                    Using Read As SqlDataReader = cmd.ExecuteReader()
                        BillingEntry.DataGridView1.Rows.Clear()
                        While Read.Read()
                            BillingEntry.DataGridView1.Rows.Add(
                                Read.Item("item_name").ToString(),
                                Read.Item("quantity").ToString(),
                                Read.Item("price").ToString(),
                                Read.Item("amount").ToString()
                            )
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading purchase entry data: " & ex.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If ListView1.SelectedItems.Count > 0 Then
                Dim selectedBillNo As String = ListView1.SelectedItems(1).SubItems(1).Text

                Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this record?",
                                                              "Delete Confirmation",
                                                              MessageBoxButtons.YesNo,
                                                              MessageBoxIcon.Warning)

                If result = DialogResult.Yes Then
                    Using con As New SqlConnection("Data Source=EDITH;Initial Catalog=Inventory;Persist Security Info=True;User ID=haritha;Password=123;TrustServerCertificate=True")
                        con.Open()
                        Using cmd As New SqlCommand("DELETE FROM Billing_table WHERE bill_no = @billNo", con)
                            cmd.Parameters.AddWithValue("@billNo", selectedBillNo)
                            cmd.ExecuteNonQuery()
                        End Using
                    End Using

                    ListView1.Items.Remove(ListView1.SelectedItems(0))
                    MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Please select a record to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class