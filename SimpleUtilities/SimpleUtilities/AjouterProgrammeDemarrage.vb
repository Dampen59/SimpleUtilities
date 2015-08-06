Imports Microsoft.Win32

Public Class AjouterProgrammeDemarrage

    Private Sub AjouterProgrammeDemarrage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.ShowDialog()
        txt_path.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If txt_path.Text = "" Then
            MsgBox("Vous n'avez pas sélectionné de fichier !", MsgBoxStyle.Exclamation, "Erreur")
            Return
        End If

        txt_valeur.Text.Replace(" ", "")

        If txt_valeur.Text = "" Then
            MsgBox("Veuillez entrer un nom de valeur !", MsgBoxStyle.Exclamation, "Erreur")
            Return
        End If

        Dim reponse
        reponse = MsgBox("Etes-vous sur de vouloir ajouter : " & vbCrLf & OpenFileDialog1.FileName & vbCrLf & "Au démarrage de Windows ?", vbYesNo + vbInformation, "Confirmation")

        If reponse = vbYes Then
            Dim rk As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
            rk.SetValue(txt_valeur.Text, txt_path.Text, RegistryValueKind.String)
            rk.Flush()
            rk.Close()
            MsgBox("Clé de démarrage ajoutée avec succès !" & vbCrLf & "Vous devez redémarrer votre ordinateur pour que les changements prennent effet !")
        Else
        End If
    End Sub

    Private Sub txt_valeur_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_valeur.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsControl(e.KeyChar) Then

            e.Handled = False

        Else

            e.Handled = True

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        SimpleUtilitiesMenu.Enabled = True
    End Sub

    Private Sub AjouterProgrammeDemarrage_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        SimpleUtilitiesMenu.Enabled = True
    End Sub
End Class