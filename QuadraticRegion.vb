Public Class QuadraticRegion

    ' ball coordinates
    Private x_ball, y_ball As Integer
    Private previous_x As Integer = 0
    Private previous_y As Integer = 0
    Private Const ballDIAMETER = 80
    Dim ball_colour = New System.Drawing.SolidBrush(System.Drawing.Color.Yellow)

    ' quadratic variables
    Private xq_start, yq_start, xq_min, yq_min, xq_stop, x, y As Integer
    Private xq_lb, xq_ub As Double ' curve lower and upper boundary
    Private a, b, c, discriminant As Double
    Private Const dotDIAMETER = 5
    Dim dot_colour As New System.Drawing.SolidBrush(System.Drawing.Color.Black)

    Dim bg_colour As New System.Drawing.SolidBrush(System.Drawing.Color.LightGray)

    ' draw first appearance of ball on the screen
    Public Sub prep(sender As Object, g As Graphics)
        x_ball = 10
        y_ball = Math.Round(sender.Height / 2)
        ball_colour = New System.Drawing.SolidBrush(System.Drawing.Color.Yellow)

        xq_start = Math.Round(sender.Width / 2) - 200
        yq_start = 70
        xq_min = Math.Round(sender.Width / 2)
        yq_min = sender.Height - 70
        xq_stop = Math.Round(sender.Width / 2) + 200

        ' constants
        a = (yq_start - yq_min) / Math.Pow((xq_start - xq_min), 2)
        b = -2 * a * xq_min
        c = yq_min + a * Math.Pow(xq_min, 2)

        discriminant = Math.Sqrt(b * b - 4 * a * (c - (y_ball - ballDIAMETER / 2)))
        If a < 0 Then ' a is negative
            xq_lb = (-b + discriminant) / (2 * a) ' lower boundary
            xq_ub = (-b - discriminant) / (2 * a) ' upper boundary
        Else
            xq_lb = (-b - discriminant) / (2 * a) ' lower boundary
            xq_ub = (-b + discriminant) / (2 * a) ' upper boundary
        End If

        ' draw quadratic curve
        For x = xq_start To xq_stop
            y = Math.Round(a * x * x + b * x + c)
            ' redraw dot
            g.FillEllipse(dot_colour, x, y, dotDIAMETER, dotDIAMETER)
        Next x

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
            ' yellow outside the quadratic region
            ball_colour = New System.Drawing.SolidBrush(System.Drawing.Color.Yellow)
            If (x_ball <= xq_lb And x_ball + ballDIAMETER >= xq_lb) _
                Or (x_ball <= xq_ub And x_ball + ballDIAMETER >= xq_ub) Then
                ' red on the quadratic outline
                ball_colour = New System.Drawing.SolidBrush(System.Drawing.Color.Red)
            ElseIf x_ball >= xq_lb And x_ball + ballDIAMETER <= xq_ub Then
                ' green inside the quadratic region
                ball_colour = New System.Drawing.SolidBrush(System.Drawing.Color.Green)
            End If

            ' clear previous ball using background colour
            g.FillEllipse(bg_colour, previous_x, previous_y, ballDIAMETER, ballDIAMETER)
            ' redraw ball
            g.FillEllipse(ball_colour, x_ball, y_ball, ballDIAMETER, ballDIAMETER)

            previous_x = x_ball
            x_ball += 5
            ' take a time pause
            Threading.Thread.Sleep(50)
        Loop
    End Sub
End Class
