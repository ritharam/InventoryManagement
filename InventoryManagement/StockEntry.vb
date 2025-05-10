Imports System.Data.SqlClient

Public Class StockEntry
    Public con As New SqlConnection("Data Source=EDITH;Initial Catalog=Inventory;Persist Security Info=True;User ID=haritha;Password=123;TrustServerCertificate=True")
    Public cmd As New SqlCommand
    Public da As New SqlDataAdapter
    Public ds As New DataSet
    Public dt As New DataTable
    Public qr As String
    Dim dr As SqlDataReader

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        Me.Dispose()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        txtIName.Text = ""
        txtICode.Text = ""
        txtCtgName.Text = ""
        txtAvlStock.Text = ""
        txtPPrice.Text = ""
        txtMRP.Text = ""
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If txtIName.Text = "" Then
                MsgBox("Please enter Item Name")
                txtIName.Focus()
                Exit Sub
            End If
            If txtICode.Text = "" Then
                MsgBox("Please enter Item Code")
                txtICode.Focus()
                Exit Sub
            End If
            If txtCtgName.Text = "" Then
                MsgBox("Please enter Category Name")
                txtCtgName.Focus()
                Exit Sub
            End If
            If txtAvlStock.Text = "" Then
                MsgBox("Please enter Available Stock")
                txtAvlStock.Focus()
                Exit Sub
            End If
            If txtPPrice.Text = "" Then
                MsgBox("Please enter Purchase Price")
                txtPPrice.Focus()
                Exit Sub
            End If
            If txtMRP.Text = "" Then
                MsgBox("Please enter MRP")
                txtMRP.Focus()
                Exit Sub
            End If

            Dim curDate As DateTime = DateTime.Now
            qr = "INSERT INTO Stock_table (category_name, item_name, item_code, avl_unit, purchase_price, mrp, purchase_date) VALUES (@ctgname, @iname, @icode, @avl, @pprice, @mrp, @pdate)"
            Using cmd As New SqlCommand(qr, con)
                cmd.Parameters.AddWithValue("@ctgname", txtCtgName.Text)
                cmd.Parameters.AddWithValue("@iname", txtIName.Text)
                cmd.Parameters.AddWithValue("@icode", txtICode.Text)
                cmd.Parameters.AddWithValue("@avl", txtAvlStock.Text)
                cmd.Parameters.AddWithValue("@pprice", txtPPrice.Text)
                cmd.Parameters.AddWithValue("@mrp", txtMRP.Text)
                cmd.Parameters.AddWithValue("@pdate", curDate)
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                cmd.ExecuteNonQuery()
            End Using

            MsgBox("Stock record saved successfully!", MsgBoxStyle.Information)
            LoadData()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

    Private Sub StockEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDataGridView()
        LoadData()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If txtSearchIName.Text = "" Then
            MsgBox("Please enter Item Name to Delete")
            txtSearchIName.Focus()
            Exit Sub
        End If

        qr = "DELETE FROM Stock_table WHERE item_name = @iname"
        Using cmd As New SqlCommand(qr, con)
            cmd.Parameters.AddWithValue("@iname", txtSearchIName.Text)
            con.Open()
            cmd.ExecuteNonQuery()
        End Using
        MsgBox("Stock record deleted successfully!", MsgBoxStyle.Information)
        LoadData()
    End Sub

    Private Sub LoadData(Optional filter As String = "")
        DataGridView1.Rows.Clear()
        Try
            con.Open()
            Dim query As String
            If String.IsNullOrWhiteSpace(filter) Then
                query = "SELECT * FROM Stock_table"
            Else
                query = "SELECT * FROM Stock_table WHERE item_name LIKE @filter"
            End If

            Using cmd As New SqlCommand(query, con)
                If Not String.IsNullOrWhiteSpace(filter) Then
                    cmd.Parameters.AddWithValue("@filter", "%" & filter & "%")
                End If

                dr = cmd.ExecuteReader()
                While dr.Read()
                    DataGridView1.Rows.Add(dr.Item("item_name"), dr.Item("item_code"), dr.Item("category_name"), dr.Item("avl_unit"), dr.Item("purchase_price"), dr.Item("mrp"), dr.Item("purchase_date"))
                End While
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            dr?.Dispose()
            con.Close()
        End Try
    End Sub

    Private Sub SetupDataGridView()
        If DataGridView1.Columns.Count = 0 Then
            DataGridView1.Columns.Add("item_name", "Item Name")
            DataGridView1.Columns.Add("item_code", "Item Code")
            DataGridView1.Columns.Add("category_name", "Category Name")
            DataGridView1.Columns.Add("avl_unit", "Available Unit")
            DataGridView1.Columns.Add("purchase_price", "Purchase Price")
            DataGridView1.Columns.Add("mrp", "MRP")
            DataGridView1.Columns.Add("purchase_date", "Purchase Date")
        End If
    End Sub

    Private Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        Try
            If String.IsNullOrWhiteSpace(txtSearchIName.Text) Then
                MsgBox("Please enter Item Name to Search", MsgBoxStyle.Exclamation)
                txtSearchIName.Focus()
                Exit Sub
            End If

            qr = "UPDATE Stock_table SET category_name = @ctgname, item_name = @iname, item_code = @icode, avl_unit = @avl, purchase_price = @pprice, mrp = @mrp WHERE item_name = @searchname"
            Using cmd As New SqlCommand(qr, con)
                cmd.Parameters.AddWithValue("@ctgname", txtCtgName.Text)
                cmd.Parameters.AddWithValue("@iname", txtIName.Text)
                cmd.Parameters.AddWithValue("@icode", txtICode.Text)
                cmd.Parameters.AddWithValue("@avl", txtAvlStock.Text)
                cmd.Parameters.AddWithValue("@pprice", txtPPrice.Text)
                cmd.Parameters.AddWithValue("@mrp", txtMRP.Text)
                cmd.Parameters.AddWithValue("@searchname", txtSearchIName.Text)
                con.Open()
                If cmd.ExecuteNonQuery() > 0 Then
                    MsgBox("Stock record updated successfully!", MsgBoxStyle.Information)
                Else
                    MsgBox("Stock Detail not found!", MsgBoxStyle.Exclamation)
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
            txtIName.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
            txtICode.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString()
            txtCtgName.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString()
            txtAvlStock.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString()
            txtPPrice.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString()
            txtMRP.Text = DataGridView1.CurrentRow.Cells(5).Value.ToString()
        End If
    End Sub

    Private Sub txtSearchIName_TextChanged(sender As Object, e As EventArgs) Handles txtSearchIName.TextChanged
        LoadData(txtSearchIName.Text)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Dispose()
        Form1.Show()
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class
