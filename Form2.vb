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

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataIntoGrid()
    End Sub

    Private Sub LoadDataIntoGrid(Optional customQuery As String = Nothing)
        Dim query As String = If(String.IsNullOrWhiteSpace(customQuery), "SELECT * FROM Items;", customQuery)

        Try
            Using cn As New MySqlConnection(connString)
                cn.Open()
                Using da As New MySqlDataAdapter(query, cn)
                    Dim dt As New DataTable()
                    da.Fill(dt)

                    ' find first DataGridView on the form
                    Dim targetDgv As DataGridView = Nothing
                    For Each ctl As Control In Me.Controls
                        If TypeOf ctl Is DataGridView Then
                            targetDgv = DirectCast(ctl, DataGridView)
                            Exit For
                        End If
                    Next

                    If targetDgv Is Nothing Then
                        MsgBox("No DataGridView found on the form to display data.")
                        Return
                    End If

                    targetDgv.DataSource = dt

                    FormatDataGridAsBox(targetDgv)
                    MakeCellsSquare(targetDgv)

                    AddHandler targetDgv.Resize, Sub(s, ev) MakeCellsSquare(targetDgv)
                    AddHandler targetDgv.ColumnWidthChanged, Sub(s, ev) MakeCellsSquare(targetDgv)
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error loading data: " & ex.Message)
        End Try
    End Sub

    Private Sub FormatDataGridAsBox(dgv As DataGridView)
        dgv.BorderStyle = BorderStyle.FixedSingle
        dgv.GridColor = Color.LightGray
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single
        dgv.EnableHeadersVisualStyles = False
        dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240)
        dgv.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        For Each col As DataGridViewColumn In dgv.Columns
            col.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
            col.DefaultCellStyle.Padding = New Padding(6)
        Next
        dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgv.RowTemplate.Height = 40
        dgv.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.MultiSelect = False
        dgv.ReadOnly = True

        dgv.Refresh()
    End Sub
    Private Sub MakeCellsSquare(dgv As DataGridView)
        If dgv.Columns.Count = 0 Then Return

        Dim availableWidth As Integer = dgv.ClientSize.Width - dgv.RowHeadersWidth
        Dim vsb As ScrollBar = Nothing
        For Each ctl As Control In dgv.Controls
            If TypeOf ctl Is VScrollBar Then
                vsb = DirectCast(ctl, VScrollBar)
                Exit For
            End If
        Next
        If vsb IsNot Nothing AndAlso vsb.Visible Then
            availableWidth -= SystemInformation.VerticalScrollBarWidth
        End If

        Dim colCount As Integer = dgv.Columns.Count
        Dim widthPerCol As Integer = Math.Max(60, Math.Floor(availableWidth / colCount))

        Dim maxCellSize As Integer = 300
        If widthPerCol > maxCellSize Then widthPerCol = maxCellSize

        For Each col As DataGridViewColumn In dgv.Columns
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            col.Width = widthPerCol
        Next

        For Each row As DataGridViewRow In dgv.Rows
            row.Height = widthPerCol
        Next

        dgv.Refresh()
    End Sub
End Class