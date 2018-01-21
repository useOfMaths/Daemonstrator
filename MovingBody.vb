Public Class MovingBody
    Private x, y As Integer
    Private previous_x As Integer = 0
    Private previous_y As Integer = 0
    Private Const ballDIAMETER = 80

    Dim ball_colour As New System.Drawing.SolidBrush(System.Drawing.Color.Yellow)
    Dim bg_colour As New System.Drawing.SolidBrush(System.Drawing.Color.LightGray)

    ' draw first appearance of ball on the screen
    Public Sub prep(sender As Object, g As Graphics)
        x = 10
        y = Math.Round(sender.Height / 2)
        If previous_x > 0 Then
            ' clear previous ball using background colour
            g.FillEllipse(bg_colour, previous_x, previous_y, ballDIAMETER, ballDIAMETER)
        End If
        ' draw ball
        g.FillEllipse(ball_colour, x, y, ballDIAMETER, ballDIAMETER)
        previous_x = x
        previous_y = y
    End Sub

    ' repetitively clear and draw ball on the screen - Simulate motion
    Public Sub play(sender As Object, g As Graphics)
        ' condition for continuing motion
        Do While x < sender.Width - ballDIAMETER
            ' clear previous ball using background colour
            g.FillEllipse(bg_colour, previous_x, previous_y, ballDIAMETER, ballDIAMETER)
            ' redraw ball
            g.FillEllipse(ball_colour, x, y, ballDIAMETER, ballDIAMETER)

            previous_x = x
            x += 10
            ' take a time pause
            Threading.Thread.Sleep(50)
        Loop
    End Sub
End Class
