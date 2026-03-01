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
        dgv_inventory = New DataGridView()
        btn_fruit = New Button()
        btn_vegetable = New Button()
        btn_meat = New Button()
        btn_dairy = New Button()
        btn_bread = New Button()
        btn_beverage = New Button()
        btn_back_form1 = New Button()
        btn_add = New Button()
        btn_delete = New Button()
        CType(dgv_inventory, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgv_inventory
        ' 
        dgv_inventory.BackgroundColor = SystemColors.Control
        dgv_inventory.BorderStyle = BorderStyle.None
        dgv_inventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgv_inventory.Location = New Point(337, 41)
        dgv_inventory.Name = "dgv_inventory"
        dgv_inventory.RowHeadersWidth = 51
        dgv_inventory.Size = New Size(978, 534)
        dgv_inventory.TabIndex = 0
        ' 
        ' btn_fruit
        ' 
        btn_fruit.FlatStyle = FlatStyle.Flat
        btn_fruit.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_fruit.Location = New Point(43, 132)
        btn_fruit.Name = "btn_fruit"
        btn_fruit.Size = New Size(207, 55)
        btn_fruit.TabIndex = 8
        btn_fruit.Text = "Fruit"
        btn_fruit.UseVisualStyleBackColor = False
        ' 
        ' btn_vegetable
        ' 
        btn_vegetable.FlatStyle = FlatStyle.Flat
        btn_vegetable.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_vegetable.Location = New Point(43, 193)
        btn_vegetable.Name = "btn_vegetable"
        btn_vegetable.Size = New Size(207, 55)
        btn_vegetable.TabIndex = 9
        btn_vegetable.Text = "Vegetable"
        btn_vegetable.UseVisualStyleBackColor = True
        ' 
        ' btn_meat
        ' 
        btn_meat.FlatStyle = FlatStyle.Flat
        btn_meat.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_meat.Location = New Point(43, 254)
        btn_meat.Name = "btn_meat"
        btn_meat.Size = New Size(207, 55)
        btn_meat.TabIndex = 10
        btn_meat.Text = "Meat"
        btn_meat.UseVisualStyleBackColor = True
        ' 
        ' btn_dairy
        ' 
        btn_dairy.FlatStyle = FlatStyle.Flat
        btn_dairy.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_dairy.Location = New Point(43, 315)
        btn_dairy.Name = "btn_dairy"
        btn_dairy.Size = New Size(207, 55)
        btn_dairy.TabIndex = 11
        btn_dairy.Text = "Dairy"
        btn_dairy.UseVisualStyleBackColor = True
        ' 
        ' btn_bread
        ' 
        btn_bread.FlatStyle = FlatStyle.Flat
        btn_bread.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_bread.Location = New Point(43, 376)
        btn_bread.Name = "btn_bread"
        btn_bread.Size = New Size(207, 55)
        btn_bread.TabIndex = 12
        btn_bread.Text = "Bread"
        btn_bread.UseVisualStyleBackColor = True
        ' 
        ' btn_beverage
        ' 
        btn_beverage.BackColor = Color.Transparent
        btn_beverage.FlatStyle = FlatStyle.Flat
        btn_beverage.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_beverage.Location = New Point(43, 437)
        btn_beverage.Name = "btn_beverage"
        btn_beverage.Size = New Size(207, 55)
        btn_beverage.TabIndex = 13
        btn_beverage.Text = "Beverage"
        btn_beverage.UseVisualStyleBackColor = False
        ' 
        ' btn_back_form1
        ' 
        btn_back_form1.FlatStyle = FlatStyle.Flat
        btn_back_form1.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_back_form1.Location = New Point(12, 12)
        btn_back_form1.Name = "btn_back_form1"
        btn_back_form1.Size = New Size(207, 55)
        btn_back_form1.TabIndex = 14
        btn_back_form1.Text = "Back"
        btn_back_form1.UseVisualStyleBackColor = False
        ' 
        ' btn_add
        ' 
        btn_add.BackColor = Color.Transparent
        btn_add.FlatStyle = FlatStyle.Flat
        btn_add.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_add.Location = New Point(555, 632)
        btn_add.Name = "btn_add"
        btn_add.Size = New Size(207, 55)
        btn_add.TabIndex = 15
        btn_add.Text = "Add Item"
        btn_add.UseVisualStyleBackColor = False
        ' 
        ' btn_delete
        ' 
        btn_delete.BackColor = Color.Transparent
        btn_delete.FlatStyle = FlatStyle.Flat
        btn_delete.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn_delete.Location = New Point(821, 632)
        btn_delete.Name = "btn_delete"
        btn_delete.Size = New Size(207, 55)
        btn_delete.TabIndex = 16
        btn_delete.Text = "Delete Item"
        btn_delete.UseVisualStyleBackColor = False
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1393, 738)
        Controls.Add(btn_delete)
        Controls.Add(btn_add)
        Controls.Add(btn_back_form1)
        Controls.Add(btn_beverage)
        Controls.Add(btn_bread)
        Controls.Add(btn_dairy)
        Controls.Add(btn_meat)
        Controls.Add(btn_vegetable)
        Controls.Add(btn_fruit)
        Controls.Add(dgv_inventory)
        Name = "Form2"
        Text = "Form2"
        CType(dgv_inventory, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents dgv_inventory As DataGridView
    Friend WithEvents btn_fruit As Button
    Friend WithEvents btn_vegetable As Button
    Friend WithEvents btn_meat As Button
    Friend WithEvents btn_dairy As Button
    Friend WithEvents btn_bread As Button
    Friend WithEvents btn_beverage As Button
    Friend WithEvents btn_back_form1 As Button
    Friend WithEvents btn_add As Button
    Friend WithEvents btn_delete As Button
End Class
