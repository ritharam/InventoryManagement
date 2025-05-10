Imports System.Data.SqlClient

Public Class SupplierEntry
    Public con As New SqlConnection("Data Source=EDITH;Initial Catalog=Inventory;Persist Security Info=True;User ID=haritha;Password=123;TrustServerCertificate=True")
    Public cmd As New SqlCommand
    Public da As New SqlDataAdapter
    Public ds As New DataSet
    Public dt As New DataTable
    Public qr As String
    Dim dr As SqlDataReader
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        txtSName.Text = ""
        txtAddress.Text = ""
        txtPhNo.Text = ""
        txtRmrks.Text = ""
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If txtSName.Text = "" Then
                MsgBox("Please enter Supplier Name")
                txtSName.Focus()
                Exit Sub
            End If
            If txtPhNo.Text = "" Then
                MsgBox("Please enter Address Details")
                txtPhNo.Focus()
                Exit Sub
            End If
            If txtAddress.Text = "" Then
                MsgBox("Please enter Phone Number")
                txtAddress.Focus()
                Exit Sub
            End If

            qr = "INSERT INTO Supplier_table (s_name, ph_no, address, remarks) VALUES (@s_name, @phone, @address, @remarks)"
            Using cmd As New SqlCommand(qr, con)
                cmd.Parameters.AddWithValue("@s_name", txtSName.Text)
                cmd.Parameters.AddWithValue("@phone", txtPhNo.Text)
                cmd.Parameters.AddWithValue("@address", txtAddress.Text)
                cmd.Parameters.AddWithValue("@remarks", txtRmrks.Text)

                con.Open()
                cmd.ExecuteNonQuery()
            End Using

            MsgBox("Customer record saved successfully!", MsgBoxStyle.Information)
            LoadData()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub SupplierEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDataGridView()
        LoadData()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If txtSearchSName.Text = "" Then
            MsgBox("Please enter Supplier Name to Delete")
            txtSearchSName.Focus()
            Exit Sub
        End If

        qr = "Delete Supplier_table where s_name = '" & txtSearchSName.Text & "'"
        cmd = New SqlCommand(qr, con)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub LoadData(Optional filter As String = "")

        DataGridView1.Rows.Clear()
        Try
            con.Open()
            Dim query As String
            If String.IsNullOrWhiteSpace(filter) Then
                query = "Select * from Supplier_table"
            Else
                query = "Select * from Supplier_table where s_name LIKE @filter"
            End If

            Dim cmd As New SqlCommand(query, con)
            If Not String.IsNullOrWhiteSpace(filter) Then
                cmd.Parameters.AddWithValue("@filter", "%" & filter & "%")
            End If

            dr = cmd.ExecuteReader
            While dr.Read
                DataGridView1.Rows.Add(dr.Item("s_name"), dr.Item("ph_no"), dr.Item("address"), dr.Item("remarks"))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            dr?.Dispose()
            con.Close()
        End Try
    End Sub
    Private Sub SetupDataGridView()
        If DataGridView1.Columns.Count = 0 Then
            DataGridView1.Columns.Add("s_name", "Supplier Name")
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
            If String.IsNullOrWhiteSpace(txtSearchSName.Text) Then
                MsgBox("Please enter Supplier Name to Search", MsgBoxStyle.Exclamation)
                txtSearchSName.Focus()
                Exit Sub
            End If

            qr = "UPDATE Supplier_table SET ph_no = @phone, address = @address, remarks = @remarks WHERE s_name = @s_name"
            Using cmd As New SqlCommand(qr, con)
                cmd.Parameters.AddWithValue("@phone", txtPhNo.Text)
                cmd.Parameters.AddWithValue("@address", txtAddress.Text)
                cmd.Parameters.AddWithValue("@remarks", txtRmrks.Text)
                cmd.Parameters.AddWithValue("@s_name", txtSearchSName.Text)

                con.Open()
                If cmd.ExecuteNonQuery() > 0 Then
                    MsgBox("Supplier record updated successfully!", MsgBoxStyle.Information)
                Else
                    MsgBox("Supplier not found!", MsgBoxStyle.Exclamation)
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
        If e.RowIndex Then
            txtSName.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
            txtPhNo.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString()
            txtAddress.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString()
            txtRmrks.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString()
        End If
    End Sub

    Private Sub txtSearchSName_TextChanged(sender As Object, e As EventArgs) Handles txtSearchSName.TextChanged
        LoadData(txtSearchSName.Text)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Dispose()
        Form1.Show()
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class