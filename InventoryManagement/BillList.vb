Imports System.Data.SqlClient

Public Class BillList
    Public con As New SqlConnection("Data Source=EDITH;Initial Catalog=Inventory;Persist Security Info=True;User ID=haritha;Password=123;TrustServerCertificate=True")
    Public cmd As New SqlCommand
    Dim Read As SqlDataReader
    Public _ICode As String
    Public _Category As String
    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        Me.Dispose()
        With BillingEntry
            .txtIName.Clear()
            .txtPrice.Clear()
            .txtSearchIName.Clear()
            .txtSearchIName.Focus()
        End With
    End Sub

    Private Sub txtSearchIName_TextChanged(sender As Object, e As EventArgs) Handles txtSearchIName.TextChanged
        Try
            ListView1.Items.Clear()
            con.Open()
            cmd = New SqlCommand("select * from Stock_table where item_name like @searchText", con)
            cmd.Parameters.AddWithValue("@searchText", "%" & txtSearchIName.Text.Trim & "%")
            Read = cmd.ExecuteReader()
            While Read.Read()
                Dim view As New ListViewItem(Read.Item("item_code").ToString())
                view.SubItems.Add(Read.Item("item_name").ToString())
                view.SubItems.Add(Read.Item("category_name").ToString())
                view.SubItems.Add(Read.Item("purchase_price").ToString())
                ListView1.Items.Add(view)
            End While
        Catch ex As Exception
            ' Log or handle the exception if needed
        Finally
            Read.Close()
            con.Close()
        End Try
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            MessageBox.Show("Item selected: " & ListView1.SelectedItems(0).SubItems(1).Text)
            With BillingEntry
                ._ICode = Me.ListView1.SelectedItems(0).SubItems(0).Text
                .txtIName.Text = Me.ListView1.SelectedItems(0).SubItems(1).Text
                ._Category = Me.ListView1.SelectedItems(0).SubItems(2).Text
                .txtPrice.Text = Me.ListView1.SelectedItems(0).SubItems(3).Text
            End With
            Me.Dispose()
        End If
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class