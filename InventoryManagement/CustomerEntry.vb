Imports System.Data.SqlClient

Public Class CustomerEntry
    Public con As New SqlConnection("Data Source=EDITH;Initial Catalog=Inventory;Persist Security Info=True;User ID=haritha;Password=123;TrustServerCertificate=True")
    Public cmd As New SqlCommand
    Public da As New SqlDataAdapter
    Public ds As New DataSet
    Public dt As New DataTable
    Public qr As String
    Dim dr As SqlDataReader

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        txtCName.Text = ""
        txtAddress.Text = ""
        txtPhNo.Text = ""
        txtRmrks.Text = ""
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If String.IsNullOrWhiteSpace(txtCName.Text) Then
                MsgBox("Please enter Customer Name")
                txtCName.Focus()
                Exit Sub
            End If
            If String.IsNullOrWhiteSpace(txtPhNo.Text) Then
                MsgBox("Please enter Phone Number")
                txtPhNo.Focus()
                Exit Sub
            End If
            If String.IsNullOrWhiteSpace(txtAddress.Text) Then
                MsgBox("Please enter Address")
                txtAddress.Focus()
                Exit Sub
            End If

            qr = "INSERT INTO Customer_table (c_name, phone, address, remarks) VALUES (@c_name, @phone, @address, @remarks)"
            Using cmd As New SqlCommand(qr, con)
                cmd.Parameters.AddWithValue("@c_name", txtCName.Text)
                cmd.Parameters.AddWithValue("@phone", txtPhNo.Text)
                cmd.Parameters.AddWithValue("@address", txtAddress.Text)
                cmd.Parameters.AddWithValue("@remarks", txtRmrks.Text)

                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                cmd.ExecuteNonQuery()
            End Using

            MsgBox("Customer record saved successfully!", MsgBoxStyle.Information)
            LoadData() 
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

    Private Sub CustomerEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'InventoryDataSet.Customer_table' table. You can move, or remove it, as needed.
        'Me.Customer_tableTableAdapter.Fill(Me.InventoryDataSet.Customer_table)
        SetupDataGridView()
        LoadData()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If txtSearchCName.Text = "" Then
            MsgBox("Please enter Customer Name to Delete")
            txtSearchCName.Focus()
            Exit Sub
        End If

        qr = "Delete Customer_table where c_name = '" & txtSearchCName.Text & "'"
        cmd = New SqlCommand(qr, con)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub LoadData(Optional filter As String = "")
        DataGridView1.Rows.Clear()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Dim query As String
            If String.IsNullOrWhiteSpace(filter) Then
                query = "SELECT * FROM Customer_table"
            Else
                query = "SELECT * FROM Customer_table WHERE c_name LIKE @filter"
            End If

            Using cmd As New SqlCommand(query, con)
                If Not String.IsNullOrWhiteSpace(filter) Then
                    cmd.Parameters.AddWithValue("@filter", "%" & filter & "%")
                End If

                Using dr As SqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        DataGridView1.Rows.Add(dr("c_name").ToString(), dr("phone").ToString(), dr("address").ToString(), dr("remarks").ToString())
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
            DataGridView1.Columns.Add("c_name", "Customer Name")
            DataGridView1.Columns.Add("phone", "Phone Number")
            DataGridView1.Columns.Add("address", "Address")
            DataGridView1.Columns.Add("remarks", "Remarks")
        End If
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        Me.Dispose()
    End Sub

    Private Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        Try
            If String.IsNullOrWhiteSpace(txtSearchCName.Text) Then
                MsgBox("Please enter Customer Name to Search", MsgBoxStyle.Exclamation)
                txtSearchCName.Focus()
                Exit Sub
            End If

            qr = "UPDATE Customer_table SET phone = @phone, address = @address, remarks = @remarks WHERE c_name = @c_name"
            Using cmd As New SqlCommand(qr, con)
                cmd.Parameters.AddWithValue("@phone", txtPhNo.Text)
                cmd.Parameters.AddWithValue("@address", txtAddress.Text)
                cmd.Parameters.AddWithValue("@remarks", txtRmrks.Text)
                cmd.Parameters.AddWithValue("@c_name", txtSearchCName.Text)

                con.Open()
                If cmd.ExecuteNonQuery() > 0 Then
                    MsgBox("Customer record updated successfully!", MsgBoxStyle.Information)
                Else
                    MsgBox("Customer not found!", MsgBoxStyle.Exclamation)
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
            txtCName.Text = row.Cells(0).Value.ToString()
            txtPhNo.Text = row.Cells(1).Value.ToString()
            txtAddress.Text = row.Cells(2).Value.ToString()
            txtRmrks.Text = row.Cells(3).Value.ToString()
        End If
    End Sub

    Private Sub txtSearchCName_TextChanged(sender As Object, e As EventArgs) Handles txtSearchCName.TextChanged
        LoadData(txtSearchCName.Text)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Dispose()
        Form1.Show()
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class

