<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        dgv_inventory = New DataGridView()
        Button1 = New Button()
        lbl_item_name = New Label()
        lbl_desc = New Label()
        lbl_amount = New Label()
        btn_fruit = New Button()
        btn_vegetable = New Button()
        btn_meat = New Button()
        btn_dairy = New Button()
        btn_bread = New Button()
        btn_beverage = New Button()
        lbl_item = New Label()
        lbl_vegetable = New Label()
        lbl_meat = New Label()
        lbl_dairy = New Label()
        lbl_bread = New Label()
        lbl_beverage = New Label()
        CType(dgv_inventory, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgv_inventory
        ' 
        dgv_inventory.BackgroundColor = SystemColors.GradientActiveCaption
        dgv_inventory.BorderStyle = BorderStyle.None
        dgv_inventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgv_inventory.GridColor = SystemColors.GradientActiveCaption
        dgv_inventory.Location = New Point(338, 94)
        dgv_inventory.Name = "dgv_inventory"
        dgv_inventory.RowHeadersWidth = 51
        dgv_inventory.Size = New Size(1057, 534)
        dgv_inventory.TabIndex = 0
        ' 
        ' Button1
        ' 
        Button1.BackColor = SystemColors.GradientActiveCaption
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = SystemColors.GradientActiveCaption
        Button1.Image = CType(resources.GetObject("Button1.Image"), Image)
        Button1.ImageAlign = ContentAlignment.TopCenter
        Button1.Location = New Point(12, 12)
        Button1.Name = "Button1"
        Button1.Size = New Size(66, 51)
        Button1.TabIndex = 1
        Button1.TextAlign = ContentAlignment.MiddleRight
        Button1.UseVisualStyleBackColor = False
        ' 
        ' lbl_item_name
        ' 
        lbl_item_name.AutoSize = True
        lbl_item_name.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lbl_item_name.Location = New Point(351, 631)
        lbl_item_name.Name = "lbl_item_name"
        lbl_item_name.Size = New Size(50, 25)
        lbl_item_name.TabIndex = 5
        lbl_item_name.Text = "Item"
        ' 
        ' lbl_desc
        ' 
        lbl_desc.AutoSize = True
        lbl_desc.Location = New Point(351, 671)
        lbl_desc.Name = "lbl_desc"
        lbl_desc.Size = New Size(119, 20)
        lbl_desc.TabIndex = 6
        lbl_desc.Text = "Item Description"
        ' 
        ' lbl_amount
        ' 
        lbl_amount.AutoSize = True
        lbl_amount.Location = New Point(351, 651)
        lbl_amount.Name = "lbl_amount"
        lbl_amount.Size = New Size(94, 20)
        lbl_amount.TabIndex = 7
        lbl_amount.Text = "Item amount"
        ' 
        ' btn_fruit
        ' 
        btn_fruit.BackColor = SystemColors.GradientActiveCaption
        btn_fruit.FlatStyle = FlatStyle.Flat
        btn_fruit.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_fruit.ForeColor = SystemColors.GradientActiveCaption
        btn_fruit.Location = New Point(43, 132)
        btn_fruit.Name = "btn_fruit"
        btn_fruit.Size = New Size(207, 55)
        btn_fruit.TabIndex = 8
        btn_fruit.Text = "Fruits"
        btn_fruit.UseVisualStyleBackColor = False
        ' 
        ' btn_vegetable
        ' 
        btn_vegetable.FlatStyle = FlatStyle.Flat
        btn_vegetable.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_vegetable.ForeColor = SystemColors.GradientActiveCaption
        btn_vegetable.Location = New Point(43, 193)
        btn_vegetable.Name = "btn_vegetable"
        btn_vegetable.Size = New Size(207, 55)
        btn_vegetable.TabIndex = 9
        btn_vegetable.UseVisualStyleBackColor = True
        ' 
        ' btn_meat
        ' 
        btn_meat.FlatStyle = FlatStyle.Flat
        btn_meat.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_meat.ForeColor = SystemColors.GradientActiveCaption
        btn_meat.Location = New Point(43, 254)
        btn_meat.Name = "btn_meat"
        btn_meat.Size = New Size(207, 55)
        btn_meat.TabIndex = 10
        btn_meat.UseVisualStyleBackColor = True
        ' 
        ' btn_dairy
        ' 
        btn_dairy.FlatStyle = FlatStyle.Flat
        btn_dairy.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_dairy.ForeColor = SystemColors.GradientActiveCaption
        btn_dairy.Location = New Point(43, 315)
        btn_dairy.Name = "btn_dairy"
        btn_dairy.Size = New Size(207, 55)
        btn_dairy.TabIndex = 11
        btn_dairy.UseVisualStyleBackColor = True
        ' 
        ' btn_bread
        ' 
        btn_bread.FlatStyle = FlatStyle.Flat
        btn_bread.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_bread.ForeColor = SystemColors.GradientActiveCaption
        btn_bread.Location = New Point(43, 376)
        btn_bread.Name = "btn_bread"
        btn_bread.Size = New Size(207, 55)
        btn_bread.TabIndex = 12
        btn_bread.UseVisualStyleBackColor = True
        ' 
        ' btn_beverage
        ' 
        btn_beverage.BackColor = Color.Transparent
        btn_beverage.FlatStyle = FlatStyle.Flat
        btn_beverage.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_beverage.ForeColor = SystemColors.GradientActiveCaption
        btn_beverage.Location = New Point(43, 437)
        btn_beverage.Name = "btn_beverage"
        btn_beverage.Size = New Size(207, 55)
        btn_beverage.TabIndex = 13
        btn_beverage.Text = "sdfgh"
        btn_beverage.UseVisualStyleBackColor = False
        ' 
        ' lbl_item
        ' 
        lbl_item.AutoSize = True
        lbl_item.Font = New Font("Segoe UI Symbol", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lbl_item.ForeColor = Color.White
        lbl_item.Location = New Point(108, 137)
        lbl_item.Name = "lbl_item"
        lbl_item.Size = New Size(76, 38)
        lbl_item.TabIndex = 14
        lbl_item.Text = "Item"
        ' 
        ' lbl_vegetable
        ' 
        lbl_vegetable.AutoSize = True
        lbl_vegetable.Font = New Font("Segoe UI Symbol", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lbl_vegetable.ForeColor = Color.White
        lbl_vegetable.Location = New Point(67, 198)
        lbl_vegetable.Name = "lbl_vegetable"
        lbl_vegetable.Size = New Size(163, 38)
        lbl_vegetable.TabIndex = 15
        lbl_vegetable.Text = "Vegetables"
        ' 
        ' lbl_meat
        ' 
        lbl_meat.AutoSize = True
        lbl_meat.Font = New Font("Segoe UI Symbol", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lbl_meat.ForeColor = Color.White
        lbl_meat.Location = New Point(100, 259)
        lbl_meat.Name = "lbl_meat"
        lbl_meat.Size = New Size(84, 38)
        lbl_meat.TabIndex = 16
        lbl_meat.Text = "Meat"
        ' 
        ' lbl_dairy
        ' 
        lbl_dairy.AutoSize = True
        lbl_dairy.Font = New Font("Segoe UI Symbol", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lbl_dairy.ForeColor = Color.White
        lbl_dairy.Location = New Point(108, 320)
        lbl_dairy.Name = "lbl_dairy"
        lbl_dairy.Size = New Size(87, 38)
        lbl_dairy.TabIndex = 17
        lbl_dairy.Text = "Dairy"
        ' 
        ' lbl_bread
        ' 
        lbl_bread.AutoSize = True
        lbl_bread.Font = New Font("Segoe UI Symbol", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lbl_bread.ForeColor = Color.White
        lbl_bread.Location = New Point(108, 381)
        lbl_bread.Name = "lbl_bread"
        lbl_bread.Size = New Size(93, 38)
        lbl_bread.TabIndex = 18
        lbl_bread.Text = "Bread"
        ' 
        ' lbl_beverage
        ' 
        lbl_beverage.AutoSize = True
        lbl_beverage.Font = New Font("Segoe UI Symbol", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lbl_beverage.ForeColor = Color.White
        lbl_beverage.Location = New Point(80, 442)
        lbl_beverage.Name = "lbl_beverage"
        lbl_beverage.Size = New Size(139, 38)
        lbl_beverage.TabIndex = 19
        lbl_beverage.Text = "Beverage"
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.GradientActiveCaption
        ClientSize = New Size(1393, 738)
        Controls.Add(lbl_beverage)
        Controls.Add(lbl_bread)
        Controls.Add(lbl_dairy)
        Controls.Add(lbl_meat)
        Controls.Add(lbl_vegetable)
        Controls.Add(lbl_item)
        Controls.Add(btn_beverage)
        Controls.Add(btn_bread)
        Controls.Add(btn_dairy)
        Controls.Add(btn_meat)
        Controls.Add(btn_vegetable)
        Controls.Add(btn_fruit)
        Controls.Add(lbl_amount)
        Controls.Add(lbl_desc)
        Controls.Add(lbl_item_name)
        Controls.Add(Button1)
        Controls.Add(dgv_inventory)
        Name = "Form2"
        Text = "Form2"
        CType(dgv_inventory, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dgv_inventory As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents lbl_item_name As Label
    Friend WithEvents lbl_desc As Label
    Friend WithEvents lbl_amount As Label
    Friend WithEvents btn_fruit As Button
    Friend WithEvents btn_vegetable As Button
    Friend WithEvents btn_meat As Button
    Friend WithEvents btn_dairy As Button
    Friend WithEvents btn_bread As Button
    Friend WithEvents btn_beverage As Button
    Friend WithEvents lbl_item As Label
    Friend WithEvents lbl_vegetable As Label
    Friend WithEvents lbl_meat As Label
    Friend WithEvents lbl_dairy As Label
    Friend WithEvents lbl_bread As Label
    Friend WithEvents lbl_beverage As Label
End Class
