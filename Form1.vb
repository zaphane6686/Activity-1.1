Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing.Text

Public Class Form1
    Private ReadOnly connString As String =
                            "Server=mysql-2bcvngvt87654-developer242005-158b.j.aivencloud.com;" &
                            "Port=12587;" &
                            "Database=cpe221;" &
                            "Uid=avnadmin;" &
                            "Pwd=AVNS_zqTo32pnIgcTnqiHRHQ;" &
                            "SslMode=Required;"
    Private Property mode As String
    Private Property userName As String
    Private Property firstName As String
    Private Property lastName As String

    Private Sub User_Login_Design_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chk_show_pass.Visible = False
        txtbx_input.Text = "Enter Username"
        mode = "readerUserName"
        btn_create_acc.Text = "Create Account"
        txtbx_input.PasswordChar = ControlChars.NullChar
    End Sub

    Private Sub btn_1_Click(sender As Object, e As EventArgs) Handles btn_next.Click
        Select Case mode
            Case "sqlFirstName"
                Try
                    txtbx_input.PasswordChar = ControlChars.NullChar
                    firstName = txtbx_input.Text.Trim()
                    If firstName.Length = 0 Then
                        MsgBox("Please enter a first name.")
                        txtbx_input.Focus()
                        Return
                    End If
                    txtbx_input.Text = "Enter Last Name"
                    mode = "sqlLastName"
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            Case "sqlLastName"
                Try
                    lastName = txtbx_input.Text.Trim()
                    If lastName.Length = 0 Then
                        MsgBox("Please enter a last name.")
                        txtbx_input.Focus()
                        Return
                    End If
                    txtbx_input.Text = "Enter Your Username"
                    mode = "sqlUserName"
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            Case "sqlUserName"
                Dim qry As String = "SELECT userName FROM Accounts WHERE userName = @username LIMIT 1;"
                Try
                    Dim tempUser = txtbx_input.Text.Trim()
                    If tempUser.Length = 0 Then
                        MsgBox("Please enter a username.")
                        txtbx_input.Focus()
                        Return
                    End If

                    Using cn As New MySqlConnection(connString)
                        cn.Open()
                        Using cmd As New MySqlCommand(qry, cn)
                            cmd.Parameters.AddWithValue("@username", tempUser)
                            Using reader As MySqlDataReader = cmd.ExecuteReader()
                                If reader.Read() Then
                                    MsgBox("Username is already taken. Try another.")
                                    txtbx_input.Text = ""
                                    txtbx_input.Focus()
                                    Return
                                Else
                                    userName = tempUser
                                    txtbx_input.Text = "Enter Your Password"
                                    chk_show_pass.Visible = True
                                    mode = "sqlPassWord"
                                End If
                            End Using
                        End Using
                    End Using
                Catch ex As Exception
                    MsgBox("Read error: " & ex.Message)
                End Try

            Case "sqlPassWord"
                Try
                    If String.IsNullOrWhiteSpace(firstName) OrElse String.IsNullOrWhiteSpace(lastName) OrElse String.IsNullOrWhiteSpace(userName) Then
                        MsgBox("Missing data: ensure First Name, Last Name and Username are provided.")
                        txtbx_input.Text = "Enter First Name"
                        mode = "sqlFirstName"
                        txtbx_input.PasswordChar = ControlChars.NullChar
                    Else
                        Dim password As String = txtbx_input.Text
                        Dim query As String = "INSERT INTO Accounts (firstName, lastName, userName, password) VALUES (@firstname, @lastname, @username, @password);"
                        Using con As New MySqlConnection(connString)
                            con.Open()
                            Using comd As New MySqlCommand(query, con)
                                comd.Parameters.AddWithValue("@username", userName)
                                comd.Parameters.AddWithValue("@password", password)
                                comd.Parameters.AddWithValue("@firstname", firstName)
                                comd.Parameters.AddWithValue("@lastname", lastName)
                                Try
                                    Dim affected As Integer = comd.ExecuteNonQuery()
                                    If affected > 0 Then
                                        MsgBox("Record saved.")
                                    Else
                                        MsgBox("No rows were inserted.")
                                    End If
                                Catch mex As MySqlException
                                    If mex.Number = 1062 Then
                                        MsgBox("Username already exists. Please choose a different username.")
                                    Else
                                        MsgBox("Database error while inserting record: " & mex.Message)
                                    End If
                                End Try
                            End Using
                        End Using
                        txtbx_input.Text = "Enter Username"
                        chk_show_pass.Visible = False
                        mode = "readerUserName"
                        btn_create_acc.Text = "Create Account"
                        txtbx_input.PasswordChar = ControlChars.NullChar
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            Case "readerUserName"
                Dim query As String = "SELECT firstname,lastname,userName FROM Accounts WHERE userName = @username LIMIT 1;"
                Try
                    Using cn As New MySqlConnection(connString)
                        cn.Open()
                        Using cmd As New MySqlCommand(query, cn)
                            cmd.Parameters.AddWithValue("@username", txtbx_input.Text.Trim())
                            Using reader As MySqlDataReader = cmd.ExecuteReader()
                                If reader.Read() Then
                                    userName = reader("userName").ToString()
                                    txtbx_input.Text = "Enter Password"
                                    chk_show_pass.Visible = True
                                    mode = "readerPassword"
                                    btn_create_acc.Text = "Back"
                                Else
                                    MsgBox("Username not found. Please try again.")
                                End If
                            End Using
                        End Using
                    End Using
                Catch ex As Exception
                    MsgBox("Server down, please try again later while we fix the issue.")
                End Try

            Case "readerPassword"
                Dim query As String = "SELECT password, account_id FROM Accounts WHERE userName = @username LIMIT 1;"
                Try
                    If String.IsNullOrWhiteSpace(userName) Then
                        MsgBox("No username selected. Enter username first.")
                    Else
                        Using cn As New MySqlConnection(connString)
                            cn.Open()
                            Using cmd As New MySqlCommand(query, cn)
                                cmd.Parameters.AddWithValue("@username", userName)
                                Using rdr As MySqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleRow)
                                    If rdr.Read() Then
                                        Dim storedPassword As String = String.Empty
                                        Dim idx As Integer = rdr.GetOrdinal("password")
                                        If Not rdr.IsDBNull(idx) Then
                                            storedPassword = rdr.GetString(idx)
                                        End If

                                        Dim accountId As Integer = -1
                                        If rdr.GetSchemaTable() IsNot Nothing Then
                                            Try
                                                Dim accIdx As Integer = rdr.GetOrdinal("account_id")
                                                If Not rdr.IsDBNull(accIdx) Then
                                                    accountId = rdr.GetInt32(accIdx)
                                                End If
                                            Catch ex As Exception
                                                Debug.WriteLine("Error reading account_id: " & ex.Message)
                                            End Try
                                        End If

                                        If String.Equals(txtbx_input.Text.Trim(), storedPassword.Trim(), StringComparison.Ordinal) Then
                                            Try
                                                Form2.AccountId = accountId
                                            Catch ex As Exception
                                                Debug.WriteLine("Failed to set Form2.AccountId: " & ex.Message)
                                            End Try

                                            Try
                                                RemoveHandler Form2.FormClosed, AddressOf Form2_FormClosed
                                            Catch ex As Exception
                                                Debug.WriteLine("Failed to remove Form2.FormClosed handler: " & ex.Message)
                                            End Try
                                            AddHandler Form2.FormClosed, AddressOf Form2_FormClosed
                                            Me.Hide()
                                            Form2.Show()
                                            txtbx_input.Text = "Enter Username"
                                            chk_show_pass.Visible = False
                                            mode = "readerUserName"
                                            userName = String.Empty
                                            txtbx_input.PasswordChar = ControlChars.NullChar
                                            btn_create_acc.Text = "Create Account"
                                        Else
                                            MsgBox("Incorrect password. Please try again.")
                                            txtbx_input.Text = ""
                                            txtbx_input.Focus()
                                        End If
                                    Else
                                        MsgBox("Error retrieving password.")
                                    End If
                                End Using
                            End Using
                        End Using
                    End If
                Catch ex As Exception
                    MsgBox("Read error: " & ex.Message)
                End Try

            Case Else

        End Select
    End Sub

    Private Sub chk_show_pass_CheckedChanged(sender As Object, e As EventArgs) Handles chk_show_pass.CheckedChanged
        If chk_show_pass.Checked = True Then
            txtbx_input.PasswordChar = ControlChars.NullChar
        Else
            txtbx_input.PasswordChar = "*"c
        End If
    End Sub

    Private Sub btn_create_acc_Click(sender As Object, e As EventArgs) Handles btn_create_acc.Click
        Select Case mode
            Case "sqlFirstName"
                mode = "readerUserName"
                txtbx_input.Text = "Enter Username"
                chk_show_pass.Visible = False
                txtbx_input.PasswordChar = ControlChars.NullChar
                btn_create_acc.Text = "Create Account"
                firstName = String.Empty

            Case "sqlLastName"
                mode = "sqlFirstName"
                txtbx_input.Text = "Enter First Name"
                chk_show_pass.Visible = False
                txtbx_input.PasswordChar = ControlChars.NullChar
                lastName = String.Empty

            Case "sqlUserName"
                mode = "sqlLastName"
                txtbx_input.Text = "Enter Last Name"
                chk_show_pass.Visible = False
                txtbx_input.PasswordChar = ControlChars.NullChar
                userName = String.Empty

            Case "sqlPassWord"
                mode = "sqlUserName"
                txtbx_input.Text = "Enter Your Username"
                chk_show_pass.Visible = False
                txtbx_input.PasswordChar = ControlChars.NullChar

            Case "readerPassword"
                mode = "readerUserName"
                txtbx_input.Text = "Enter Username"
                chk_show_pass.Visible = False
                txtbx_input.PasswordChar = ControlChars.NullChar
                userName = String.Empty
                btn_create_acc.Text = "Create Account"

            Case "readerUserName"
                mode = "sqlFirstName"
                txtbx_input.Text = "Enter First Name"
                chk_show_pass.Visible = False
                txtbx_input.PasswordChar = ControlChars.NullChar
                btn_create_acc.Text = "Back"
                firstName = String.Empty
                lastName = String.Empty
                userName = String.Empty

            Case Else
                mode = "readerUserName"
                txtbx_input.Text = "Enter Username"
                chk_show_pass.Visible = False
                txtbx_input.PasswordChar = ControlChars.NullChar
                btn_create_acc.Text = "Create Account"
                firstName = String.Empty
                lastName = String.Empty
                userName = String.Empty
        End Select
    End Sub

    Private Sub txtbx_input_Click(sender As Object, e As EventArgs) Handles txtbx_input.Click
        If txtbx_input.Text.StartsWith("Enter", StringComparison.OrdinalIgnoreCase) Then
            txtbx_input.Text = ""
        End If
        If mode = "readerPassword" OrElse mode = "sqlPassWord" Then
            txtbx_input.PasswordChar = "*"c
        Else
            txtbx_input.PasswordChar = ControlChars.NullChar
        End If
    End Sub

    Private Sub txtbx_input_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbx_input.KeyPress
        If txtbx_input.Text.StartsWith("Enter", StringComparison.OrdinalIgnoreCase) AndAlso Not Char.IsControl(e.KeyChar) Then
            txtbx_input.Text = ""
            txtbx_input.SelectionStart = 0
            If mode = "readerPassword" OrElse mode = "sqlPassWord" Then
                txtbx_input.PasswordChar = "*"c
            Else
                txtbx_input.PasswordChar = ControlChars.NullChar
            End If
        End If
    End Sub

    Private Sub txtbx_input_KeyDown(sender As Object, e As KeyEventArgs) Handles txtbx_input.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True

            Dim txt As String = txtbx_input.Text.Trim()
            If txt.Length = 0 Then
                Return
            End If

            If txt.StartsWith("Enter", StringComparison.OrdinalIgnoreCase) Then
                Return
            End If

            btn_next.PerformClick()
        End If
    End Sub

    Private Sub Form2_FormClosed(sender As Object, e As FormClosedEventArgs)
        Try
            RemoveHandler Form2.FormClosed, AddressOf Form2_FormClosed
        Catch ex As Exception
            Debug.WriteLine("Failed to remove Form2.FormClosed handler in Form2_FormClosed: " & ex.Message)
        End Try
        Me.Show()
    End Sub
End Class
