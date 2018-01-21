Public Class Dymetric
    Private line_region As New StraightLineRegion
    Private do_simulation = False

    ' decide what course of action to take
    Public Sub decideAction(sender As Object, g As Graphics, click_check As Boolean)
        If do_simulation And click_check Then
            ' do animation
            line_region.play(sender, g)
            do_simulation = False
        Else
            ' Put ball on screen
            line_region.prep(sender, g)
            do_simulation = True
        End If
    End Sub
End Class
