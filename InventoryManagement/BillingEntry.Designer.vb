<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BillingEntry
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BillingEntry))
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtIName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSearchIName = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Customer_tableTableAdapter = New InventoryManagement.InventoryDataSetTableAdapters.Customer_tableTableAdapter()
        Me.Supplier_tableTableAdapter = New InventoryManagement.InventoryDataSetTableAdapters.Supplier_tableTableAdapter()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnModify = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnBill = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.txtBillNo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CustomertableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.InventoryDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.InventoryDataSet = New InventoryManagement.InventoryDataSet()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.comboCName = New System.Windows.Forms.ComboBox()
        Me.CustomertableBindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CustomertableBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.SuppliertableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnSve = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel3.SuspendLayout()
        CType(Me.CustomertableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InventoryDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InventoryDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.CustomertableBindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomertableBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SuppliertableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Product Sans Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(1213, 29)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(25, 30)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "-"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Product Sans Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(1666, 25)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(25, 30)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "-"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Product Sans Medium", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.InactiveBorder
        Me.Label5.Location = New System.Drawing.Point(108, 20)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 51)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Billing"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Product Sans Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(1715, 23)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(26, 30)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "x"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Product Sans Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(2123, 56)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 30)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "-"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel3.Controls.Add(Me.txtAmount)
        Me.Panel3.Controls.Add(Me.txtPrice)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.btnAdd)
        Me.Panel3.Controls.Add(Me.txtQuantity)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.txtIName)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.txtSearchIName)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Location = New System.Drawing.Point(44, 266)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(5, 9, 5, 9)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1232, 136)
        Me.Panel3.TabIndex = 38
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(956, 71)
        Me.txtAmount.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(96, 37)
        Me.txtAmount.TabIndex = 33
        '
        'txtPrice
        '
        Me.txtPrice.Location = New System.Drawing.Point(811, 70)
        Me.txtPrice.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(96, 37)
        Me.txtPrice.TabIndex = 13
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(951, 29)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(95, 36)
        Me.Label15.TabIndex = 32
        Me.Label15.Text = "Amount"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(805, 31)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 36)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "Price"
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnAdd.Location = New System.Drawing.Point(1098, 69)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(111, 39)
        Me.btnAdd.TabIndex = 27
        Me.btnAdd.Text = "ADD"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(659, 71)
        Me.txtQuantity.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(96, 37)
        Me.txtQuantity.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(654, 29)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 36)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Quantity"
        '
        'txtIName
        '
        Me.txtIName.Location = New System.Drawing.Point(359, 71)
        Me.txtIName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtIName.Name = "txtIName"
        Me.txtIName.Size = New System.Drawing.Size(253, 37)
        Me.txtIName.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(354, 29)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(126, 36)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Item Name"
        '
        'txtSearchIName
        '
        Me.txtSearchIName.Location = New System.Drawing.Point(46, 71)
        Me.txtSearchIName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSearchIName.Name = "txtSearchIName"
        Me.txtSearchIName.Size = New System.Drawing.Size(270, 37)
        Me.txtSearchIName.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(41, 29)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(201, 36)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Search Item Name"
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(774, 741)
        Me.txtTotal.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(286, 37)
        Me.txtTotal.TabIndex = 45
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(679, 744)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 36)
        Me.Label16.TabIndex = 44
        Me.Label16.Text = "Total"
        '
        'Customer_tableTableAdapter
        '
        Me.Customer_tableTableAdapter.ClearBeforeFill = True
        '
        'Supplier_tableTableAdapter
        '
        Me.Supplier_tableTableAdapter.ClearBeforeFill = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Product Sans Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(1250, 28)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(26, 30)
        Me.Label13.TabIndex = 32
        Me.Label13.Text = "x"
        '
        'btnModify
        '
        Me.btnModify.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.btnModify.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnModify.Location = New System.Drawing.Point(1093, 590)
        Me.btnModify.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(179, 50)
        Me.btnModify.TabIndex = 47
        Me.btnModify.Text = "MODIFY"
        Me.btnModify.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Product Sans Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(2188, 52)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 30)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "x"
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnDelete.Location = New System.Drawing.Point(1093, 441)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(183, 48)
        Me.btnDelete.TabIndex = 42
        Me.btnDelete.Text = "DELETE"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnBill
        '
        Me.btnBill.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.btnBill.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnBill.Location = New System.Drawing.Point(359, 726)
        Me.btnBill.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnBill.Name = "btnBill"
        Me.btnBill.Size = New System.Drawing.Size(230, 52)
        Me.btnBill.TabIndex = 41
        Me.btnBill.Text = "Bill Entries"
        Me.btnBill.UseVisualStyleBackColor = False
        '
        'btnNew
        '
        Me.btnNew.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.btnNew.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnNew.Location = New System.Drawing.Point(44, 726)
        Me.btnNew.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(251, 52)
        Me.btnNew.TabIndex = 40
        Me.btnNew.Text = "NEW ENTRY"
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'txtBillNo
        '
        Me.txtBillNo.Location = New System.Drawing.Point(46, 64)
        Me.txtBillNo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtBillNo.Name = "txtBillNo"
        Me.txtBillNo.Size = New System.Drawing.Size(330, 37)
        Me.txtBillNo.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(52, 21)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 36)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Bill Number"
        '
        'CustomertableBindingSource
        '
        Me.CustomertableBindingSource.DataMember = "Customer_table"
        Me.CustomertableBindingSource.DataSource = Me.InventoryDataSetBindingSource
        '
        'InventoryDataSetBindingSource
        '
        Me.InventoryDataSetBindingSource.DataSource = Me.InventoryDataSet
        Me.InventoryDataSetBindingSource.Position = 0
        '
        'InventoryDataSet
        '
        Me.InventoryDataSet.DataSetName = "InventoryDataSet"
        Me.InventoryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Highlight
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(-1, -2)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(5, 9, 5, 9)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1428, 86)
        Me.Panel2.TabIndex = 36
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSave.Location = New System.Drawing.Point(1012, 1172)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(251, 68)
        Me.btnSave.TabIndex = 43
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel1.Controls.Add(Me.comboCName)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtDate)
        Me.Panel1.Controls.Add(Me.txtBillNo)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(44, 102)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(5, 9, 5, 9)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1232, 136)
        Me.Panel1.TabIndex = 37
        '
        'comboCName
        '
        Me.comboCName.DataSource = Me.CustomertableBindingSource2
        Me.comboCName.DisplayMember = "c_name"
        Me.comboCName.FormattingEnabled = True
        Me.comboCName.Location = New System.Drawing.Point(425, 64)
        Me.comboCName.Name = "comboCName"
        Me.comboCName.Size = New System.Drawing.Size(293, 44)
        Me.comboCName.TabIndex = 16
        Me.comboCName.ValueMember = "c_name"
        '
        'CustomertableBindingSource2
        '
        Me.CustomertableBindingSource2.DataMember = "Customer_table"
        Me.CustomertableBindingSource2.DataSource = Me.InventoryDataSetBindingSource
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(798, 29)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 36)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Date"
        '
        'txtDate
        '
        Me.txtDate.Location = New System.Drawing.Point(804, 72)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(277, 37)
        Me.txtDate.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(419, 28)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 36)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Customer Name"
        '
        'CustomertableBindingSource1
        '
        Me.CustomertableBindingSource1.DataMember = "Customer_table"
        Me.CustomertableBindingSource1.DataSource = Me.InventoryDataSetBindingSource
        '
        'SuppliertableBindingSource
        '
        Me.SuppliertableBindingSource.DataMember = "Supplier_table"
        Me.SuppliertableBindingSource.DataSource = Me.InventoryDataSetBindingSource
        '
        'btnSve
        '
        Me.btnSve.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.btnSve.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSve.Location = New System.Drawing.Point(1093, 514)
        Me.btnSve.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSve.Name = "btnSve"
        Me.btnSve.Size = New System.Drawing.Size(183, 48)
        Me.btnSve.TabIndex = 46
        Me.btnSve.Text = "SAVE"
        Me.btnSve.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(44, 430)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 62
        Me.DataGridView1.RowTemplate.Height = 28
        Me.DataGridView1.Size = New System.Drawing.Size(1016, 272)
        Me.DataGridView1.TabIndex = 39
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(47, 21)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 34
        Me.PictureBox1.TabStop = False
        '
        'BillingEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 36.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1323, 920)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.btnModify)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnBill)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSve)
        Me.Controls.Add(Me.DataGridView1)
        Me.Font = New System.Drawing.Font("Poppins", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "BillingEntry"
        Me.Text = "BillingEntry"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.CustomertableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InventoryDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InventoryDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.CustomertableBindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomertableBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SuppliertableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label12 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtAmount As TextBox
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtIName As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtSearchIName As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Customer_tableTableAdapter As InventoryDataSetTableAdapters.Customer_tableTableAdapter
    Friend WithEvents Supplier_tableTableAdapter As InventoryDataSetTableAdapters.Supplier_tableTableAdapter
    Friend WithEvents Label13 As Label
    Friend WithEvents btnModify As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnBill As Button
    Friend WithEvents btnNew As Button
    Friend WithEvents txtBillNo As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents CustomertableBindingSource As BindingSource
    Friend WithEvents InventoryDataSetBindingSource As BindingSource
    Friend WithEvents InventoryDataSet As InventoryDataSet
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnSave As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents comboCName As ComboBox
    Friend WithEvents SuppliertableBindingSource As BindingSource
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDate As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents btnSve As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents CustomertableBindingSource1 As BindingSource
    Friend WithEvents CustomertableBindingSource2 As BindingSource
    Friend WithEvents PictureBox1 As PictureBox
End Class
