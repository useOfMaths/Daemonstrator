Public Class Form1

    Private form_details As New Facet

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Fill in Form - Put button on form
        form_details.formFeatures(sender)
    End Sub
End Class
