Public Class EllipticalRegion

    ' square coordinates
    Private x_square, y_square As Integer
    Private previous_x As Integer = 0
    Private previous_y As Integer = 0
    Private Const squareLENGTH = 100
    Dim square_pen = New System.Drawing.Pen(System.Drawing.Color.Yellow)

    ' circle variables
    Private h, k, a, b As Integer
    Private Const dotDIAMETER = 10

    Dim bg_colour As New System.Drawing.SolidBrush(System.Drawing.Color.LightGray)

    ' draw first appearance of square on the screen
    Public Sub prep(sender As Object, g As Graphics)
        x_square = 10
        y_square = Math.Round(sender.Height / 2)
        square_pen.Width = 5

        ' ellipse centre coordinates
        h = Math.Round(sender.Width / 2)
        k = Math.Round(sender.Height / 2)
        ' ellipse major and minor semi-axes
        a = sender.Width / 3
        b = sender.Height / 3

        ' draw an ellipse
        g.DrawEllipse(Pens.Black, h - a, k - b, 2 * a, 2 * b)

        If previous_x > 0 Then
            ' clear previous square using background colour
            g.FillRectangle(bg_colour, previous_x - 5, previous_y - 5, squareLENGTH + 10, squareLENGTH + 10)
        End If
        ' draw square
        g.DrawRectangle(square_pen, x_square, y_square, squareLENGTH, squareLENGTH)
        previous_x = x_square
        previous_y = y_square
    End Sub

    ' repetitively clear and draw square on the screen - Simulate motion
    Public Sub play(sender As Object, g As Graphics)
        ' condition for continuing motion
        Do While x_square < sender.Width - squareLENGTH

            Dim square_left = x_square
            Dim square_right = x_square + squareLENGTH
            Dim square_top = y_square
            Dim square_bottom = y_square + squareLENGTH
            ' determinants for each side of the square
            Dim x_left_det = Math.Round((b / a) * Math.Sqrt(Math.Pow(a, 2) - Math.Pow((square_left - h), 2)))
            Dim x_right_det = Math.Round((b / a) * Math.Sqrt(Math.Pow(a, 2) - Math.Pow((square_right - h), 2)))
            Dim y_up_det = Math.Round((a / b) * Math.Sqrt(Math.Pow(b, 2) - Math.Pow((square_top - k), 2)))
            Dim y_down_det = Math.Round((a / b) * Math.Sqrt(Math.Pow(b, 2) - Math.Pow((square_bottom - k), 2)))

            ' check the bounds of the circle
            ' yellow outside the circle
            square_pen = New System.Drawing.Pen(System.Drawing.Color.Yellow)
            If square_top > k - x_left_det And square_bottom < k + x_left_det _
            And square_top > k - x_right_det And square_bottom < k + x_right_det _
            And square_left > h - y_up_det And square_right < h + y_up_det _
            And square_left > h - y_down_det And square_right < h + y_down_det Then
                ' green inside the circle
                square_pen = New System.Drawing.Pen(System.Drawing.Color.Green)
            End If
            square_pen.Width = 5

            ' clear previous square using background colour
            g.FillRectangle(bg_colour, previous_x - 5, previous_y - 5, squareLENGTH + 10, squareLENGTH + 10)
            ' redraw square
            g.DrawRectangle(square_pen, x_square, y_square, squareLENGTH, squareLENGTH)

            previous_x = x_square
            x_square += 10
            ' take a time pause
            Threading.Thread.Sleep(50)
        Loop
    End Sub
End Class
