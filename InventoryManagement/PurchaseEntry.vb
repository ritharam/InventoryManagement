Imports System.Data.SqlClient

Public Class PurchaseEntry
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
                With ProductList
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

    Private Sub txtQuanity_TextChanged(sender As Object, e As EventArgs) Handles txtQuanity.TextChanged
        Dim Total As Double
        Total = Val(txtQuanity.Text) * Val(txtPrice.Text)
        txtAmount.Text = Total
    End Sub
    Private Sub txtQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuanity.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 8
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub PurchaseEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'InventoryDataSet.Supplier_table' table. You can move, or remove it, as needed.
        SetupDataGridView()
        LoadData()
        Me.Supplier_tableTableAdapter.Fill(Me.InventoryDataSet.Supplier_table)
        txtDate.Text = Now.ToString("yyyy-MM-dd")
    End Sub

    Private Sub txtDate_ValueChanged(sender As Object, e As EventArgs) Handles txtDate.ValueChanged
        txtDate.Text = Format(Me.txtDate.Value, "yyyy-MM-dd")
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        comboSName.Text = ""
        txtInvoiceNo.Text = ""
        txtDate.Text = ""
        txtIName.Text = ""
        txtPrice.Text = ""
        txtQuanity.Text = ""
        txtAmount.Text = ""
        txtTotal.Text = ""
        txtSearchIName.Text = ""
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If String.IsNullOrWhiteSpace(comboSName.Text) Then
                MsgBox("Please enter Supplier Name")
                comboSName.Focus()
                Exit Sub
            End If
            If txtInvoiceNo.Text = "" Then
                MsgBox("Please enter Invoice Number")
                txtInvoiceNo.Focus()
                Exit Sub
            End If
            If txtIName.Text = "" Then
                MsgBox("Please enter item Name")
                txtIName.Focus()
                Exit Sub
            End If

            qr = "INSERT INTO PurchaseEntry_table(s_name, Inv_no, item_name, quantity, price, amount) VALUES (@sname, @invono, @iname, @qty, @price, @amt)"
            Using cmd As New SqlCommand(qr, con)
                cmd.Parameters.AddWithValue("@sname", comboSName.Text)
                cmd.Parameters.AddWithValue("@invono", txtInvoiceNo.Text)
                cmd.Parameters.AddWithValue("@iname", txtIName.Text)
                cmd.Parameters.AddWithValue("@qty", txtQuanity.Text)
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

    'Sub LoadSupplierName()
    '    Try
    '        con.Open()
    '        cmd = New SqlCommand("select * from Supplier_table", con)
    '        Read = cmd.ExecuteReader
    '        While Read.Read
    '            comboSName.Items.Add(Read.Item("s_name").ToString)
    '        End While
    '        Read.Close()
    '        con.Close()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        con.Close()
    '    End Try
    'End Sub

    Private Sub LoadData(Optional filter As String = "")
        DataGridView1.Rows.Clear()

        If String.IsNullOrWhiteSpace(filter) AndAlso String.IsNullOrWhiteSpace(txtInvoiceNo.Text) Then
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
                    query = "SELECT item_name, quantity, price, amount FROM PurchaseEntry_table WHERE Inv_no LIKE @invoicetext"
                    cmd.CommandText = query
                    cmd.Parameters.AddWithValue("@invoicetext", "%" & txtInvoiceNo.Text.Trim() & "%")
                Else
                    query = "SELECT item_name, quantity, price, amount FROM PurchaseEntry_table WHERE c_name LIKE @filter"
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

    Private Sub txtTotal_TextChanged(sender As Object, e As EventArgs) Handles txtTotal.TextChanged

    End Sub

    Private Sub txtTotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTotal.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 8
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtTotal_Enter(sender As Object, e As EventArgs) Handles txtTotal.Enter
        Dim Total As Double
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Using cmd As New SqlCommand("SELECT SUM(CAST(REPLACE(amount, '₹', '') AS FLOAT)) FROM PurchaseEntry_table WHERE ISNUMERIC(REPLACE(amount, '₹', '')) = 1 AND Inv_no LIKE @invoicetext", con)
                cmd.Parameters.AddWithValue("@invoicetext", "%" & txtInvoiceNo.Text.Trim() & "%")
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

    Private Sub btnSve_Click(sender As Object, e As EventArgs) Handles btnSve.Click
        Try
            If String.IsNullOrWhiteSpace(comboSName.Text) Then
                MsgBox("Please enter Supplier Name")
                comboSName.Focus()
                Exit Sub
            End If
            If String.IsNullOrWhiteSpace(txtInvoiceNo.Text) Then
                MsgBox("Please enter invoice Number")
                txtInvoiceNo.Focus()
                Exit Sub
            End If
            If String.IsNullOrWhiteSpace(txtTotal.Text) Then
                MsgBox("Please add Items")
                txtTotal.Focus()
                Exit Sub
            End If

            Dim checkQuery As String = "SELECT COUNT(*) FROM Purchase_table WHERE invo_no = @invoNo"
            Using checkCmd As New SqlCommand(checkQuery, con)
                checkCmd.Parameters.AddWithValue("@invoNo", txtInvoiceNo.Text)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                Dim exists As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                If exists > 0 Then
                    qr = "UPDATE Purchase_table SET s_name = @sname, pur_date = @pdate, total = @total WHERE invo_no = @invo"
                    Using cmd As New SqlCommand(qr, con)
                        cmd.Parameters.AddWithValue("@sname", comboSName.Text)
                        cmd.Parameters.AddWithValue("@invo", txtInvoiceNo.Text)
                        cmd.Parameters.AddWithValue("@pdate", txtDate.Text)
                        cmd.Parameters.AddWithValue("@total", txtTotal.Text)

                        cmd.ExecuteNonQuery()
                    End Using
                    MsgBox("Purchase record updated successfully!", MsgBoxStyle.Information)
                Else
                    qr = "INSERT INTO Purchase_table (s_name, invo_no, pur_date, total) VALUES (@sname, @invo, @pdate, @total)"
                    Using cmd As New SqlCommand(qr, con)
                        cmd.Parameters.AddWithValue("@sname", comboSName.Text)
                        cmd.Parameters.AddWithValue("@invo", txtInvoiceNo.Text)
                        cmd.Parameters.AddWithValue("@pdate", txtDate.Text)
                        cmd.Parameters.AddWithValue("@total", txtTotal.Text)

                        cmd.ExecuteNonQuery()
                    End Using
                    MsgBox("Purchase record saved successfully!", MsgBoxStyle.Information)
                End If
            End Using
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub


    Private Sub btnInvoice_Click(sender As Object, e As EventArgs) Handles btnInvoice.Click
        Try
            With IvoiceEntries
                .ListView1.Items.Clear()
                Using con As New SqlConnection("Data Source=EDITH;Initial Catalog=Inventory;Persist Security Info=True;User ID=haritha;Password=123;TrustServerCertificate=True")
                    con.Open()
                    Using cmd As New SqlCommand("SELECT * FROM Purchase_table WHERE invo_no LIKE @searchText", con)
                        cmd.Parameters.AddWithValue("@searchText", "%" & .txtSearchInvo.Text.Trim & "%")
                        Using Read As SqlDataReader = cmd.ExecuteReader()
                            While Read.Read()
                                Dim view As New ListViewItem(Read.Item("invo_no").ToString())
                                view.SubItems.Add(If(IsDBNull(Read.Item("s_name")), "N/A", Read.Item("s_name").ToString()))
                                view.SubItems.Add(If(IsDBNull(Read.Item("pur_date")), "N/A", Read.Item("pur_date").ToString()))
                                view.SubItems.Add(If(IsDBNull(Read.Item("total")), "0", Read.Item("total").ToString()))
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
                    Using cmd As New SqlCommand("DELETE FROM PurchaseEntry_table WHERE item_name = @iname", con)
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
            qr = "UPDATE PurchaseEntry_table SET quantity = @qty, price = @price, amount = @amt WHERE item_name = @iname"
            Using cmd As New SqlCommand(qr, con)
                cmd.Parameters.AddWithValue("@qty", txtQuanity.Text)
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

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            txtIName.Text = If(row.Cells(0).Value IsNot Nothing, row.Cells(0).Value.ToString(), "")
            txtQuanity.Text = If(row.Cells(1).Value IsNot Nothing, row.Cells(1).Value.ToString(), "")
            txtPrice.Text = If(row.Cells(2).Value IsNot Nothing, row.Cells(2).Value.ToString(), "")
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Dispose()
        Form1.Show()
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class
