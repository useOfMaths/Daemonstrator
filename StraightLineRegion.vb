Public Class StraightLineRegion

    ' ball coordinates
    Private x_ball, y_ball As Integer
    Private previous_x As Integer = 0
    Private previous_y As Integer = 0
    Private Const ballDIAMETER = 80
    ' line variables
    Private x1, y1, x2, y2 As Integer
    Private m, c As Double
    Private x_line As Double

    Dim ball_colour = New System.Drawing.SolidBrush(System.Drawing.Color.Yellow)
    Dim bg_colour As New System.Drawing.SolidBrush(System.Drawing.Color.LightGray)

    ' draw first appearance of ball on the screen
    Public Sub prep(sender As Object, g As Graphics)
        x_ball = 10
        y_ball = Math.Round(sender.Height / 2)
        ball_colour = New System.Drawing.SolidBrush(System.Drawing.Color.Yellow)

        x1 = Math.Round(sender.Width / 2) - 100
        y1 = 70
        x2 = Math.Round(sender.Width / 2) + 100
        y2 = sender.Height - 50

        m = (y2 - y1) / (x2 - x1) ' slope
        c = (x2 * y1 - x1 * y2) / (x2 - x1) ' y-intercept

        ' Point where ball will cross line
        x_line = (y_ball - c) / m

        ' draw line
        g.DrawLine(Pens.Black, x1, y1, x2, y2)

        If previous_x > 0 Then
            ' clear previous ball using background colour
            g.FillEllipse(bg_colour, previous_x, previous_y, ballDIAMETER, ballDIAMETER)
        End If
        ' draw ball
        g.FillEllipse(ball_colour, x_ball, y_ball, ballDIAMETER, ballDIAMETER)
        previous_x = x_ball
        previous_y = y_ball
    End Sub

    ' repetitively clear and draw ball on the screen - Simulate motion
    Public Sub play(sender As Object, g As Graphics)
        ' condition for continuing motion
        Do While x_ball < sender.Width - ballDIAMETER
            If x_ball >= x_line Then
                ' change colour as ball crosses line
                ball_colour = New System.Drawing.SolidBrush(System.Drawing.Color.Green)
            End If

            ' clear previous ball using background colour
            g.FillEllipse(bg_colour, previous_x, previous_y, ballDIAMETER, ballDIAMETER)
            ' redraw ball
            g.FillEllipse(ball_colour, x_ball, y_ball, ballDIAMETER, ballDIAMETER)

            previous_x = x_ball
            x_ball += 10
            ' take a time pause
            Threading.Thread.Sleep(50)
        Loop
    End Sub
End Class
