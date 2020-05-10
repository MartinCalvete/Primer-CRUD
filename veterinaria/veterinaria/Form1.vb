Imports MySql.Data.MySqlClient
'Martin Calvete 3BF
Public Class Veterinaria
    Dim conexion As MySqlConnection = New MySqlConnection
    Dim cmd As New MySqlCommand
    Sub ActualizarSelect()
        Dim ds As DataSet = New DataSet
        Dim adaptador As MySqlDataAdapter = New MySqlDataAdapter

        conexion.ConnectionString = "server=localhost; database=veterinaria;Uid=root;Pwd=;"

        Try
            conexion.Open()
            cmd.Connection = conexion

            cmd.CommandText = "SELECT * FROM perros ORDER BY nombre ASC"
            adaptador.SelectCommand = cmd
            adaptador.Fill(ds, "Tabla")
            grdPerros.DataSource = ds
            grdPerros.DataMember = "Tabla"

            conexion.Close()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click

        conexion.ConnectionString = "server=localhost; database=veterinaria;Uid=root;Pwd=;"

        Try
            conexion.Open()
            cmd.Connection = conexion

            cmd.CommandText = "INSERT INTO perros(nombre, raza, color) VALUES(@nombre, @raza, @color)"
            cmd.Prepare()

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text)
            cmd.Parameters.AddWithValue("@raza", txtRaza.Text)
            cmd.Parameters.AddWithValue("@color", txtColor.Text)
            cmd.ExecuteNonQuery()
            txtNombre.Clear()
            txtRaza.Clear()
            txtColor.Clear()

            conexion.Close()

            ActualizarSelect()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub Veteriaria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizarSelect()
    End Sub

    Private Sub grdPerros_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdPerros.CellContentClick

    End Sub

    Private Sub grdPerros_SelectionChanged(sender As Object, e As EventArgs) Handles grdPerros.SelectionChanged
        If (grdPerros.SelectedRows.Count > 0) Then
            txtNombre.Text = grdPerros.Item("nombre", grdPerros.SelectedRows(0).Index).Value
            txtRaza.Text = grdPerros.Item("raza", grdPerros.SelectedRows(0).Index).Value
            txtColor.Text = grdPerros.Item("color", grdPerros.SelectedRows(0).Index).Value
            txtID.Text = grdPerros.Item("id", grdPerros.SelectedRows(0).Index).Value
        End If

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click

        conexion.ConnectionString = "server=localhost; database=veterinaria;Uid=root;Pwd=;"

        Try
            conexion.Open()
            cmd.Connection = conexion

            cmd.CommandText = "UPDATE perros SET nombre=@nombre, raza=@raza, color=@color WHERE id=@id"
            cmd.Prepare()

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text)
            cmd.Parameters.AddWithValue("@raza", txtRaza.Text)
            cmd.Parameters.AddWithValue("@color", txtColor.Text)
            cmd.Parameters.AddWithValue("@id", txtID.Text)
            cmd.ExecuteNonQuery()
            txtNombre.Clear()
            txtRaza.Clear()
            txtColor.Clear()
            txtID.Clear()

            conexion.Close()
            ActualizarSelect()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        conexion.ConnectionString = "server=localhost; database=veterinaria;Uid=root;Pwd=;"

        Try
            conexion.Open()
            cmd.Connection = conexion

            cmd.CommandText = "DELETE FROM perros WHERE id=@id"
            cmd.Prepare()

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text)
            cmd.Parameters.AddWithValue("@raza", txtRaza.Text)
            cmd.Parameters.AddWithValue("@color", txtColor.Text)
            cmd.Parameters.AddWithValue("@id", txtID.Text)
            cmd.ExecuteNonQuery()
            txtNombre.Clear()
            txtRaza.Clear()
            txtColor.Clear()
            txtID.Clear()

            conexion.Close()
            ActualizarSelect()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class
