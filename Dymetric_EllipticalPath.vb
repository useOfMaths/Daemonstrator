Public Class Dymetric
    Private ellipse_ride As New EllipticalPath
    Private do_simulation = False

    ' decide what course of action to take
    Public Sub decideAction(sender As Object, g As Graphics, click_check As Boolean)
        If do_simulation And click_check Then
            ' do animation
            ellipse_ride.play(sender, g)
            do_simulation = False
        Else
            ' Put ball on screen
            ellipse_ride.prep(sender, g)
            do_simulation = True
        End If
    End Sub
End Class
