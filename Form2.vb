Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Windows.Forms 'test

Public Class Form2

    Private ReadOnly connString As String =
                            "Server=mysql-2bcvngvt87654-developer242005-158b.j.aivencloud.com;" &
                            "Port=12587;" &
                            "Database=cpe221;" &
                            "Uid=avnadmin;" &
                            "Pwd=AVNS_zqTo32pnIgcTnqiHRHQ;" &
                            "SslMode=Required;"

    <System.ComponentModel.Browsable(False)>
    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Public Property AccountId As Integer = -1
    Private Property CurrentType As String = "fruit"

    Private Async Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CurrentType = "fruit"
        AddHandler btn_fruit.Click, AddressOf OnTypeButtonClick
        AddHandler btn_vegetable.Click, AddressOf OnTypeButtonClick
        AddHandler btn_meat.Click, AddressOf OnTypeButtonClick
        AddHandler btn_dairy.Click, AddressOf OnTypeButtonClick
        AddHandler btn_bread.Click, AddressOf OnTypeButtonClick
        AddHandler btn_beverage.Click, AddressOf OnTypeButtonClick
        Await LoadDataIntoGrid()
    End Sub

    Private Async Function LoadDataIntoGrid(Optional customQuery As String = Nothing) As Threading.Tasks.Task
        Dim baseQuery As String = "SELECT `name`, `amount` FROM Items WHERE `type` = @type"
        If AccountId >= 0 Then
            baseQuery &= " AND account_id = @accountId"
        End If
        baseQuery &= " ORDER BY `name`"
        Dim query As String = If(String.IsNullOrWhiteSpace(customQuery), baseQuery, customQuery)

        Try
            Using cn As New MySqlConnection(connString)
                Await cn.OpenAsync()
                Using cmd As New MySqlCommand(query, cn)
                    cmd.Parameters.Clear()
                    If query.Contains("@type") Then
                        cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = CurrentType
                    End If
                    If AccountId >= 0 AndAlso query.Contains("@accountId") Then
                        cmd.Parameters.Add("@accountId", MySqlDbType.Int32).Value = AccountId
                    End If
                    Dim dt As New DataTable()
                    Using reader = Await cmd.ExecuteReaderAsync()
                        dt.Load(reader)
                    End Using
                    dgv_inventory.DataSource = dt
                    If dgv_inventory.Columns.Contains("name") Then
                        dgv_inventory.Columns("name").HeaderText = "Name"
                        dgv_inventory.Columns("name").DisplayIndex = 0
                    End If
                    If dgv_inventory.Columns.Contains("amount") Then
                        dgv_inventory.Columns("amount").HeaderText = "Amount"
                        dgv_inventory.Columns("amount").DisplayIndex = 1
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error loading data: " & ex.Message)
        End Try
    End Function

    Private Async Sub OnTypeButtonClick(sender As Object, e As EventArgs)
        If sender Is btn_fruit Then
            CurrentType = "fruit"
        ElseIf sender Is btn_vegetable Then
            CurrentType = "vegetable"
        ElseIf sender Is btn_meat Then
            CurrentType = "meat"
        ElseIf sender Is btn_dairy Then
            CurrentType = "dairy"
        ElseIf sender Is btn_bread Then
            CurrentType = "bread"
        ElseIf sender Is btn_beverage Then
            CurrentType = "beverage"
        End If
        Await LoadDataIntoGrid()
    End Sub

    Private Sub btn_back_form1_Click(sender As Object, e As EventArgs) Handles btn_back_form1.Click
        Me.Close()
        Form1.Show()
    End Sub

    Private Async Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        If String.IsNullOrWhiteSpace(CurrentType) Then
            MsgBox("Please select a category first.")
            Exit Sub
        End If

        Dim itemName As String = InputBox("Enter item name:")
        If String.IsNullOrWhiteSpace(itemName) Then Exit Sub

        Dim amountInput As String = InputBox("Enter amount:")
        Dim amount As Integer
        If Not Integer.TryParse(amountInput, amount) Then
            MsgBox("Invalid amount.")
            Exit Sub
        End If

        Try
            Using cn As New MySqlConnection(connString)
                Await cn.OpenAsync()
                Dim query As String = "INSERT INTO Items (`name`, `type`, `amount`, `account_id`) 
                                       VALUES (@name, @type, @amount, @accountId)"
                Using cmd As New MySqlCommand(query, cn)
                    cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = itemName
                    cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = CurrentType
                    cmd.Parameters.Add("@amount", MySqlDbType.Int32).Value = amount
                    cmd.Parameters.Add("@accountId", MySqlDbType.Int32).Value = AccountId
                    Await cmd.ExecuteNonQueryAsync()
                End Using
            End Using
            MsgBox("Item added successfully!")
            Await LoadDataIntoGrid()
        Catch ex As Exception
            MsgBox("Error adding item: " & ex.Message)
        End Try
    End Sub

    Private Async Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        If dgv_inventory.CurrentRow Is Nothing Then
            MsgBox("Please select an item to delete.")
            Exit Sub
        End If

        Dim itemName As String = dgv_inventory.CurrentRow.Cells("name").Value.ToString()
        Dim confirm = MessageBox.Show("Delete " & itemName & " ?", "Confirm Delete", MessageBoxButtons.YesNo)
        If confirm <> DialogResult.Yes Then Exit Sub

        Try
            Using cn As New MySqlConnection(connString)
                Await cn.OpenAsync()
                Dim query As String = "DELETE FROM Items 
                                       WHERE `name` = @name 
                                       AND `type` = @type"
                If AccountId >= 0 Then
                    query &= " AND account_id = @accountId"
                End If
                Using cmd As New MySqlCommand(query, cn)
                    cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = itemName
                    cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = CurrentType
                    If AccountId >= 0 Then
                        cmd.Parameters.Add("@accountId", MySqlDbType.Int32).Value = AccountId
                    End If
                    Await cmd.ExecuteNonQueryAsync()
                End Using
            End Using
            Await LoadDataIntoGrid()
        Catch ex As Exception
            MsgBox("Error deleting item: " & ex.Message)
        End Try
    End Sub

End Class