Imports MySql.Data.MySqlClient
Imports Mysqlx.Cursor
Imports System.Data
Imports System.Diagnostics.Eventing.Reader

Public Class Form1
    Private ReadOnly connString As String = "Server=127.0.0.1;User ID=root;Password=Qqgj6686;Database=cpe_221;AllowPublicKeyRetrieval=True;"
    Dim mode As String
    Dim userName As String 'test
    Dim firstName As String
    Dim lastName As String

    Private Sub User_Login_Design_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chk_show_pass.Visible = False
        txtbx_input.Text = "Enter Username"
        mode = "readerUserName"
        btn_create_acc.Text = "Create Account"
        txtbx_input.PasswordChar = ControlChars.NullChar
    End Sub

    Private Sub btn_1_Click(sender As Object, e As EventArgs) Handles btn_next.Click
        
        'Label1.Text = "Mode: " & mode
        If mode = "sqlFirstName" Then
            Try
                txtbx_input.PasswordChar = ControlChars.NullChar
                firstName = txtbx_input.Text
                txtbx_input.Text = "Enter Last Name"
                mode = "sqlLastName"
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        ElseIf mode = "sqlLastName" Then
            Try
                lastName = txtbx_input.Text
                txtbx_input.Text = "Enter Your Username"
                mode = "sqlUserName"
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        ElseIf mode = "sqlUserName" Then
            Try
                userName = txtbx_input.Text.Trim()
                txtbx_input.Text = "Enter Your Password"
                chk_show_pass.Visible = True
                mode = "sqlPassWord"
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        ElseIf mode = "sqlPassWord" Then
            Try
                Dim password As String = txtbx_input.Text
                If String.IsNullOrWhiteSpace(firstName) OrElse String.IsNullOrWhiteSpace(lastName) OrElse String.IsNullOrWhiteSpace(userName) Then
                    MsgBox("Missing data: ensure First Name, Last Name and Username are provided.")
                    txtbx_input.Text = "Enter First Name"
                    mode = "sqlFirstName"
                    txtbx_input.PasswordChar = ControlChars.NullChar
                Else

                    Dim qry As String = "SELECT userName FROM tbl_ep1 WHERE userName = @username LIMIT 1;"
                    Try
                        Using cn As New MySqlConnection(connString)
                            cn.Open()
                            Using cmd As New MySqlCommand(qry, cn)
                                cmd.Parameters.AddWithValue("@username", txtbx_input.Text.Trim())
                                Using reader As MySqlDataReader = cmd.ExecuteReader()
                                    If reader.Read() Then
                                        MsgBox("Username is already taken")
                                    Else
                                        Dim query As String = "INSERT INTO tbl_ep1 (firstName, lastName, userName, password) VALUES (@firstname, @lastname, @username, @password);"
                                        Using con As New MySqlConnection(connString)
                                            con.Open()
                                            Using comd As New MySqlCommand(query, con)
                                                comd.Parameters.AddWithValue("@username", userName)
                                                comd.Parameters.AddWithValue("@password", password)
                                                comd.Parameters.AddWithValue("@firstname", firstName)
                                                comd.Parameters.AddWithValue("@lastname", lastName)
                                                Dim affected As Integer = comd.ExecuteNonQuery()
                                                If affected > 0 Then
                                                    MsgBox("Record saved.")
                                                Else
                                                    MsgBox("No rows were inserted.")
                                                End If
                                            End Using
                                        End Using

                                        txtbx_input.Text = "Enter Username"
                                        chk_show_pass.Visible = False
                                        mode = "readerUserName"
                                        btn_create_acc.Text = "Create Account"
                                        txtbx_input.PasswordChar = ControlChars.NullChar
                                    End If
                                End Using
                            End Using
                        End Using
                    Catch ex As Exception
                        MsgBox("Read error: " & ex.Message)
                    End Try

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        ElseIf mode = "readerUserName" Then
            Dim query As String = "SELECT userName FROM tbl_ep1 WHERE userName = @username LIMIT 1;"
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
                MsgBox("Read error: " & ex.Message)
            End Try

        ElseIf mode = "readerPassword" Then
            Dim query As String = "SELECT password FROM tbl_ep1 WHERE userName = @username LIMIT 1;"
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


                                    'MsgBox($"DB:'{storedPassword}' (len={storedPassword.Length}) | Input:'{txtbx_input.Text.Trim()}' (len={txtbx_input.Text.Trim().Length})")

                                    If String.Equals(txtbx_input.Text.Trim(), storedPassword.Trim(), StringComparison.Ordinal) Then
                                        MsgBox("Login successful! Welcome, " & userName & ".")
                                        txtbx_input.Text = "Enter Username"
                                        chk_show_pass.Visible = False
                                        mode = String.Empty
                                        userName = String.Empty
                                        txtbx_input.PasswordChar = ControlChars.NullChar
                                        btn_create_acc.Text = "Create Account"
                                        Form2.Show()
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
        End If
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

    Private Sub txtbx_input_MouseEnter(sender As Object, e As EventArgs) Handles txtbx_input.MouseEnter
        txtbx_input.Text = ""
        If mode = "readerPassword" OrElse mode = "sqlPassWord" Then
            txtbx_input.PasswordChar = "*"c
        Else
            txtbx_input.PasswordChar = ControlChars.NullChar
        End If
    End Sub
End Class
