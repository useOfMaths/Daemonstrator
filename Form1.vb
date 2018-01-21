Public Class Form1

    Private form_details As New Facet
    Private action_class As New Dymetric

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Fill in Form - Put button on form
        form_details.formFeatures(sender)
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        ' Colour button area
        form_details.decorateButtonArea(sender, e)

        ' Call MovingBody class into action
        action_class.decideAction(sender, Me.CreateGraphics(), form_details.CLICK_OCCURRED)

        ' Reset click variable
        form_details.CLICK_OCCURRED = False
    End Sub
End Class
