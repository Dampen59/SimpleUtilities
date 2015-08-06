Public Class EnregistrerDllOcx

    Friend Sub Wait(ByVal ms_to_wait As Long)
        Dim endwait As Double
        endwait = Environment.TickCount + ms_to_wait
        While Environment.TickCount < endwait
            System.Threading.Thread.Sleep(1)
            Application.DoEvents()
        End While
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "Fichier DLL (*.dll)|*.dll|Fichier OCX (*.ocx)|*.ocx"

        OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
        OpenFileDialog1.ShowDialog()
        ListBox1.Items.Add(OpenFileDialog1.FileName)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ListBox1.Items.Remove(ListBox1.SelectedItem)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If ListBox1.Items.Count < 1 Then
            MsgBox("Il n'y a aucun DLL / OCX a enregistrer !", MsgBoxStyle.Exclamation, "Liste vide !")
            Return
        End If

        For Each item In ListBox1.Items
            Shell("Regsvr32 " & item)
            ListBox1.Items.Remove(item)
            Wait(500)
        Next

        MsgBox("Toutes les DLL et OCX ont été enregistrés !" & vbCrLf & "Veillez à ne pas avoir d'erreur dans votre barre de taches !", MsgBoxStyle.Information, "Information")

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        SimpleUtilitiesMenu.Enabled = True
    End Sub

    Private Sub EnregistrerDllOcx_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        SimpleUtilitiesMenu.Enabled = True
    End Sub
End Class