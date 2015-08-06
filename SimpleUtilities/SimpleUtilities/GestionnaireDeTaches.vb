Imports Microsoft.Win32

Public Class GestionnaireDeTaches

    Private Sub GestionnaireDeTaches_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim rk As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System\", True)
        Dim result As String
        result = rk.GetValue("DisableTaskMgr", "nope")

        If result = "0" Or result = "nope" Then
            Label2.Text = "Activé !"
            Label2.ForeColor = Color.Green
            Button1.Text = "Désactiver le gestionnaire de taches !"
        Else
            Label2.Text = "Désactivé !"
            Label2.ForeColor = Color.Red
            Button1.Text = "Activer le gestionnaire de taches !"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Désactiver le gestionnaire de taches !" Then
            Dim rk As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System\", True)
            rk.SetValue("DisableTaskMgr", "1", RegistryValueKind.DWord)
            rk.Flush()
            rk.Close()
            Label2.Text = "Désactivé !"
            Label2.ForeColor = Color.Red
            Button1.Text = "Activer le gestionnaire de taches !"
        Else
            Dim rk As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System\", True)
            rk.SetValue("DisableTaskMgr", "0", RegistryValueKind.DWord)
            rk.Flush()
            rk.Close()
            Button1.Text = "Désactiver le gestionnaire de taches !"
            Label2.Text = "Activé !"
            Label2.ForeColor = Color.Green
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        SimpleUtilitiesMenu.Enabled = True
    End Sub

    Private Sub GestionnaireDeTaches_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        SimpleUtilitiesMenu.Enabled = True
    End Sub
End Class