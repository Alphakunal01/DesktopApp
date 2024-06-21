Public Class ViewSubmissionsForm
    Private submissions As List(Of Submission)
    Private currentIndex As Integer
    Private isEditing As Boolean = False

    Public Sub New()
        InitializeComponent()
        InitializeSubmissions()
        DisplayCurrentSubmission()
    End Sub

    Private Sub InitializeSubmissions()
        submissions = New List(Of Submission) From {
            New Submission("Alice Smith", "alice@example.com", "123-456-7890", "https://github.com/alice"),
            New Submission("Bob Jones", "bob@example.com", "234-567-8901", "https://github.com/bob"),
            New Submission("Carol White", "carol@example.com", "345-678-9012", "https://github.com/carol")
        }
        currentIndex = 0
    End Sub

    Private Sub DisplayCurrentSubmission()
        If submissions IsNot Nothing AndAlso submissions.Count > 0 Then
            Dim currentSubmission = submissions(currentIndex)
            txtName.Text = currentSubmission.Name
            txtEmail.Text = currentSubmission.Email
            txtPhoneNumber.Text = currentSubmission.PhoneNumber
            txtGitHubRepoLink.Text = currentSubmission.GitHubRepoLink
            SetTextFieldsEditable(False)
        Else
            txtName.Text = ""
            txtEmail.Text = ""
            txtPhoneNumber.Text = ""
            txtGitHubRepoLink.Text = ""
        End If
    End Sub

    Private Sub SetTextFieldsEditable(isEditable As Boolean)
        txtName.ReadOnly = Not isEditable
        txtEmail.ReadOnly = Not isEditable
        txtPhoneNumber.ReadOnly = Not isEditable
        txtGitHubRepoLink.ReadOnly = Not isEditable
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If submissions IsNot Nothing AndAlso submissions.Count > 0 Then
            currentIndex = (currentIndex - 1 + submissions.Count) Mod submissions.Count
            DisplayCurrentSubmission()
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If submissions IsNot Nothing AndAlso submissions.Count > 0 Then
            currentIndex = (currentIndex + 1) Mod submissions.Count
            DisplayCurrentSubmission()
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If submissions IsNot Nothing AndAlso submissions.Count > 0 Then
            submissions.RemoveAt(currentIndex)
            If currentIndex >= submissions.Count Then
                currentIndex = submissions.Count - 1
            End If
            DisplayCurrentSubmission()
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If submissions IsNot Nothing AndAlso submissions.Count > 0 Then
            If isEditing Then
                ' Save changes
                Dim currentSubmission = submissions(currentIndex)
                currentSubmission.Name = txtName.Text
                currentSubmission.Email = txtEmail.Text
                currentSubmission.PhoneNumber = txtPhoneNumber.Text
                currentSubmission.GitHubRepoLink = txtGitHubRepoLink.Text
                isEditing = False
                btnEdit.Text = "Edit"
                SetTextFieldsEditable(False)
            Else
                ' Enable editing
                isEditing = True
                btnEdit.Text = "Save"
                SetTextFieldsEditable(True)
            End If
        End If
    End Sub
End Class
