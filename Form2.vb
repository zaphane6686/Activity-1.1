Imports MySql.Data.MySqlClient
Imports Mysqlx.Cursor
Imports System.Data
Imports System.Diagnostics.Eventing.Reader
Imports System.Windows.Forms

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

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CurrentType = "fruit"
        AddHandler btn_fruit.Click, AddressOf OnTypeButtonClick
        AddHandler btn_vegetable.Click, AddressOf OnTypeButtonClick
        AddHandler btn_meat.Click, AddressOf OnTypeButtonClick
        AddHandler btn_dairy.Click, AddressOf OnTypeButtonClick
        AddHandler btn_bread.Click, AddressOf OnTypeButtonClick
        AddHandler btn_beverage.Click, AddressOf OnTypeButtonClick

        LoadDataIntoGrid()
    End Sub

    Private Sub LoadDataIntoGrid(Optional customQuery As String = Nothing)
        Dim baseQuery As String = "SELECT `name`, `ammount` FROM Items WHERE `type` = @type"
        If AccountId >= 0 Then
            baseQuery &= " AND account_id = @accountId"
        End If
        baseQuery &= " ORDER BY `name`"

        Dim query As String = If(String.IsNullOrWhiteSpace(customQuery), baseQuery, customQuery)

        Try
            Using cn As New MySqlConnection(connString)
                cn.Open()
                Using da As New MySqlDataAdapter(query, cn)
                    da.SelectCommand.Parameters.Clear()
                    da.SelectCommand.Parameters.AddWithValue("@type", CurrentType)
                    If AccountId >= 0 Then
                        da.SelectCommand.Parameters.AddWithValue("@accountId", AccountId)
                    End If

                    Dim dt As New DataTable()
                    da.Fill(dt)
                    dgv_inventory.DataSource = dt
                    If dgv_inventory.Columns.Contains("name") Then
                        dgv_inventory.Columns("name").HeaderText = "Name"
                        dgv_inventory.Columns("name").DisplayIndex = 0
                    End If
                    If dgv_inventory.Columns.Contains("ammount") Then
                        dgv_inventory.Columns("ammount").HeaderText = "Amount"
                        dgv_inventory.Columns("ammount").DisplayIndex = 1
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error loading data: " & ex.Message)
        End Try
    End Sub

    Private Sub OnTypeButtonClick(sender As Object, e As EventArgs)
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

        LoadDataIntoGrid()
    End Sub

    Private Sub btn_back_form1_Click(sender As Object, e As EventArgs) Handles btn_back_form1.Click
        Form2.ActiveForm.Close()
        Form1.Show()
    End Sub
End Class