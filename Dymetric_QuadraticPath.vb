Public Class Dymetric
    Private quad_curve As New QuadraticPath
    Private do_simulation = False

    ' decide what course of action to take
    Public Sub decideAction(sender As Object, g As Graphics, click_check As Boolean)
        If do_simulation And click_check Then
            ' do animation
            quad_curve.play(sender, g)
            do_simulation = False
        Else
            ' Put ball on screen
            quad_curve.prep(sender, g)
            do_simulation = True
        End If
    End Sub
End Class
