Public Class Doom

    Private Sub Doom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(1)
        Label1.Text = ProgressBar1.Value & "% Installing Dark Chucky Virus...."
        If ProgressBar1.Value >= 100 Then
            ProgressBar1.Value = ProgressBar1.Value
            MsgBox("DARK CHUCKY VIRUS WILL DELETE SYSTEM FILES IN 24 HOURS")
            Timer1.Stop()
        End If
    End Sub
End Class