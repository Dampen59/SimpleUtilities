Imports Microsoft.Win32

Public Class SimpleUtilitiesMenu

    Dim key As Microsoft.Win32.RegistryKey

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Enabled = False
        AjouterProgrammeDemarrage.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Enabled = False
        EnregistrerDllOcx.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Enabled = False
        GestionnaireDeTaches.Show()
    End Sub
End Class
