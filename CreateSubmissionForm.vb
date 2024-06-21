Imports System.Diagnostics

Public Class CreateSubmissionForm
    Private stopwatch As Stopwatch = New Stopwatch()

    ' Constructor
    Public Sub New()
        InitializeComponent()
        ' Any initialization code here
    End Sub

    ' Event handler for the stopwatch button
    Private Sub btnStopwatch_Click(sender As Object, e As EventArgs) Handles btnStopwatch.Click
        ToggleStopwatch()
    End Sub

    ' Method to toggle the stopwatch
    Private Sub ToggleStopwatch()
        If stopwatch.IsRunning Then
            stopwatch.Stop()
            btnStopwatch.Text = "Resume Stopwatch"
        Else
            stopwatch.Start()
            btnStopwatch.Text = "Pause Stopwatch"
        End If
    End Sub

    ' Handle the Ctrl+T shortcut
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = (Keys.Control Or Keys.T) Then
            ToggleStopwatch()
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    ' Event handler for the submit button
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim name As String = txtName.Text
        Dim email As String = txtEmail.Text
        Dim phoneNumber As String = txtPhoneNumber.Text
        Dim gitHubRepoLink As String = txtGitHubRepoLink.Text

        ' Here, add your logic to save the submission to the backend or list.
        MessageBox.Show("Submission Saved!")
    End Sub
End Class
