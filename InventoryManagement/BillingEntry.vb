Imports System.Data.SqlClient

Public Class BillingEntry
    Public con As New SqlConnection("Data Source=EDITH;Initial Catalog=Inventory;Persist Security Info=True;User ID=haritha;Password=123;TrustServerCertificate=True")
    Public cmd As New SqlCommand
    Dim Read As SqlDataReader
    Public _ICode As String
    Public _Category As String
    Public _Invo As String
    Public da As New SqlDataAdapter
    Public ds As New DataSet
    Public dt As New DataTable
    Public qr As String
    Dim dr As SqlDataReader
    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        Me.Dispose()
    End Sub

    Private Sub txtSearchIName_TextChanged(sender As Object, e As EventArgs) Handles txtSearchIName.TextChanged
        Try
            If txtSearchIName.TextLength > 0 Then
                With BillList
                    .ListView1.Items.Clear()
                    con.Open()
                    cmd = New SqlCommand("select * from Stock_table where item_name like @searchText", con)
                    cmd.Parameters.AddWithValue("@searchText", "%" & txtSearchIName.Text.Trim & "%")
                    Read = cmd.ExecuteReader()
                    While Read.Read()
                        Dim view As New ListViewItem(Read.Item("item_code").ToString())
                        view.SubItems.Add(Read.Item("item_name").ToString())
                        view.SubItems.Add(Read.Item("category_name").ToString())
                        view.SubItems.Add(Read.Item("purchase_price").ToString())
                        .ListView1.Items.Add(view)
                    End While
                    .ShowDialog()
                End With
            End If
        Catch ex As Exception
            ' Log or handle the exception if needed
        Finally
            Read.Close()
            con.Close()
        End Try
    End Sub

    Private Sub txtQuanity_TextChanged(sender As Object, e As EventArgs) Handles txtQuantity.TextChanged
        Dim Total As Double
        Total = Val(txtQuantity.Text) * Val(txtPrice.Text)
        txtAmount.Text = Total
    End Sub

    Private Sub txtQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuantity.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 8
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtDate_ValueChanged(sender As Object, e As EventArgs) Handles txtDate.ValueChanged
        txtDate.Text = Format(Me.txtDate.Value, "yyyy-MM-dd")
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        comboCName.Text = ""
        txtBillNo.Text = ""
        txtDate.Text = ""
        txtIName.Text = ""
        txtPrice.Text = ""
        txtQuantity.Text = ""
        txtAmount.Text = ""
        txtTotal.Text = ""
        txtSearchIName.Text = ""
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If String.IsNullOrWhiteSpace(comboCName.Text) Then
                MsgBox("Please enter Cutomer Name")
                comboCName.Focus()
                Exit Sub
            End If
            If txtBillNo.Text = "" Then
                MsgBox("Please enter Bill number")
                txtBillNo.Focus()
                Exit Sub
            End If
            If txtIName.Text = "" Then
                MsgBox("Please enter item Name")
                txtIName.Focus()
                Exit Sub
            End If

            qr = "INSERT INTO BillingEntry_table(c_name, bill_no, item_name, quantity, price, amount) VALUES (@cname, @billno, @iname, @qty, @price, @amt)"
            Using cmd As New SqlCommand(qr, con)
                cmd.Parameters.AddWithValue("@cname", comboCName.Text)
                cmd.Parameters.AddWithValue("@billno", txtBillNo.Text)
                cmd.Parameters.AddWithValue("@iname", txtIName.Text)
                cmd.Parameters.AddWithValue("@qty", txtQuantity.Text)
                cmd.Parameters.AddWithValue("@price", txtPrice.Text)
                cmd.Parameters.AddWithValue("@amt", txtAmount.Text)
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                cmd.ExecuteNonQuery()
            End Using

            LoadData()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub LoadData(Optional filter As String = "")
        DataGridView1.Rows.Clear()

        If String.IsNullOrWhiteSpace(filter) AndAlso String.IsNullOrWhiteSpace(txtBillNo.Text) Then
            Exit Sub
        End If
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim query As String
            Using cmd As New SqlCommand()
                cmd.Connection = con
                If String.IsNullOrWhiteSpace(filter) Then
                    query = "SELECT item_name, quantity, price, amount FROM BillingEntry_table WHERE bill_no LIKE @billtext"
                    cmd.CommandText = query
                    cmd.Parameters.AddWithValue("@billtext", "%" & txtBillNo.Text.Trim() & "%")
                Else
                    query = "SELECT item_name, quantity, price, amount FROM BillingEntry_table WHERE c_name LIKE @filter"
                    cmd.CommandText = query
                    cmd.Parameters.AddWithValue("@filter", "%" & filter.Trim() & "%")
                End If
                Using dr As SqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        DataGridView1.Rows.Add(
                        dr("item_name").ToString(),
                        dr("quantity").ToString(),
                        dr("price").ToString(),
                        dr("amount").ToString()
                    )
                    End While
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error loading data: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

    Private Sub SetupDataGridView()
        If DataGridView1.Columns.Count = 0 Then
            DataGridView1.Columns.Add("item_name", "Item Name")
            DataGridView1.Columns.Add("quantity", "Quantity")
            DataGridView1.Columns.Add("price", "Price")
            DataGridView1.Columns.Add("amount", "Amount")
        End If
    End Sub
    Private Sub txtTotal_Enter(sender As Object, e As EventArgs) Handles txtTotal.Enter
        Dim Total As Double
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Using cmd As New SqlCommand("SELECT SUM(CAST(REPLACE(amount, '₹', '') AS FLOAT)) FROM BillingEntry_table WHERE ISNUMERIC(REPLACE(amount, '₹', '')) = 1 AND bill_no LIKE @billtext", con)
                cmd.Parameters.AddWithValue("@billtext", "%" & txtBillNo.Text.Trim() & "%")
                Dim result = cmd.ExecuteScalar()
                If Not IsDBNull(result) Then
                    Total = Convert.ToDouble(result)
                Else
                    Total = 0
                End If
            End Using

            txtTotal.Text = Total
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

    Private Sub txtTotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTotal.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 8
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub btnSve_Click(sender As Object, e As EventArgs) Handles btnSve.Click
        Try
            If String.IsNullOrWhiteSpace(comboCName.Text) Then
                MsgBox("Please enter Supplier Name")
                comboCName.Focus()
                Exit Sub
            End If
            If String.IsNullOrWhiteSpace(txtBillNo.Text) Then
                MsgBox("Please enter invoice Number")
                txtBillNo.Focus()
                Exit Sub
            End If
            If String.IsNullOrWhiteSpace(txtTotal.Text) Then
                MsgBox("Please add Items")
                txtTotal.Focus()
                Exit Sub
            End If

            Dim checkQuery As String = "SELECT COUNT(*) FROM Billing_table WHERE bill_no = @billNo"
            Using checkCmd As New SqlCommand(checkQuery, con)
                checkCmd.Parameters.AddWithValue("@billNo", txtBillNo.Text)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                Dim exists As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                If exists > 0 Then
                    qr = "UPDATE Billing_table SET c_name = @cname, bill_date = @bdate, subtotal = @total WHERE bill_no = @bill"
                    Using cmd As New SqlCommand(qr, con)
                        cmd.Parameters.AddWithValue("@cname", comboCName.Text)
                        cmd.Parameters.AddWithValue("@bill", txtBillNo.Text)
                        cmd.Parameters.AddWithValue("@bdate", txtDate.Text)
                        cmd.Parameters.AddWithValue("@total", txtTotal.Text)

                        cmd.ExecuteNonQuery()
                    End Using
                    MsgBox("Bill record updated successfully!", MsgBoxStyle.Information)
                Else
                    qr = "INSERT INTO Billing_table (c_name, bill_no, bill_date, subtotal) VALUES (@cname, @bill, @bdate, @total)"
                    Using cmd As New SqlCommand(qr, con)
                        cmd.Parameters.AddWithValue("@cname", comboCName.Text)
                        cmd.Parameters.AddWithValue("@bill", txtBillNo.Text)
                        cmd.Parameters.AddWithValue("@bdate", txtDate.Text)
                        cmd.Parameters.AddWithValue("@total", txtTotal.Text)

                        cmd.ExecuteNonQuery()
                    End Using
                    MsgBox("Bill record saved successfully!", MsgBoxStyle.Information)
                End If
            End Using
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
        Me.Dispose()
        BillConfirmation.Show()
    End Sub

    Private Sub btnBill_Click(sender As Object, e As EventArgs) Handles btnBill.Click
        Try
            With BillEntries
                .ListView1.Items.Clear()
                Using con As New SqlConnection("Data Source=EDITH;Initial Catalog=Inventory;Persist Security Info=True;User ID=haritha;Password=123;TrustServerCertificate=True")
                    con.Open()
                    Using cmd As New SqlCommand("SELECT * FROM Billing_table WHERE bill_no LIKE @searchText", con)
                        cmd.Parameters.AddWithValue("@searchText", "%" & .txtSearchBill.Text.Trim & "%")
                        Using Read As SqlDataReader = cmd.ExecuteReader()
                            While Read.Read()
                                Dim view As New ListViewItem(Read.Item("bill_no").ToString())
                                view.SubItems.Add(If(IsDBNull(Read.Item("c_name")), "N/A", Read.Item("c_name").ToString()))
                                view.SubItems.Add(If(IsDBNull(Read.Item("bill_date")), "N/A", Read.Item("bill_date").ToString()))
                                view.SubItems.Add(If(IsDBNull(Read.Item("subtotal")), "0", Read.Item("subtotal").ToString()))
                                .ListView1.Items.Add(view)
                            End While
                        End Using
                    End Using
                End Using
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If DataGridView1.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
                Dim itemName As String = selectedRow.Cells("item_name").Value.ToString()
                MessageBox.Show("Item Name: " & itemName, "Debug")

                Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If result = DialogResult.Yes Then
                    Using cmd As New SqlCommand("DELETE FROM BillingEntry_table WHERE item_name = @iname", con)
                        cmd.Parameters.AddWithValue("@iname", itemName)
                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If
                        cmd.ExecuteNonQuery()
                    End Using

                    LoadData()
                    MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Please select a record to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

    Private Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        Try
            qr = "UPDATE BillingEntry_table SET quantity = @qty, price = @price, amount = @amt WHERE item_name = @iname"
            Using cmd As New SqlCommand(qr, con)
                cmd.Parameters.AddWithValue("@qty", txtQuantity.Text)
                cmd.Parameters.AddWithValue("@price", txtPrice.Text)
                cmd.Parameters.AddWithValue("@amt", txtAmount.Text)
                cmd.Parameters.AddWithValue("@iname", txtIName.Text)

                con.Open()
                If cmd.ExecuteNonQuery() > 0 Then
                    MsgBox("Purchase Entry record updated successfully!", MsgBoxStyle.Information)
                Else
                    MsgBox("Entry not found!", MsgBoxStyle.Exclamation)
                End If
            End Using

            LoadData()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            txtIName.Text = If(row.Cells(0).Value IsNot Nothing, row.Cells(0).Value.ToString(), "")
            txtQuantity.Text = If(row.Cells(1).Value IsNot Nothing, row.Cells(1).Value.ToString(), "")
            txtPrice.Text = If(row.Cells(2).Value IsNot Nothing, row.Cells(2).Value.ToString(), "")
        End If
    End Sub

    Private Sub BillingEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDataGridView()
        LoadData()
        Me.Supplier_tableTableAdapter.Fill(Me.InventoryDataSet.Supplier_table)
        txtDate.Text = Now.ToString("yyyy-MM-dd")
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Dispose()
        Form1.Show()
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class