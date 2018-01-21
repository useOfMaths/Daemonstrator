Public Class CubicPath

    Private x_max, y_max, x_min, y_min, x, y As Integer
    Private a, b, c, d As Double
    Private Const dotDIAMETER = 10

    Dim dot_colour As New System.Drawing.SolidBrush(System.Drawing.Color.Yellow)
    Dim bg_colour As New System.Drawing.SolidBrush(System.Drawing.Color.LightGray)

    ' draw first appearance of dot on the screen
    Public Sub prep(sender As Object, g As Graphics)
        x = 20
        x_max = Math.Round(sender.Width / 4) + 10
        y_max = 70
        x_min = Math.Round(3 * sender.Width / 4) - 10
        y_min = sender.Height - 70

        ' constants
        a = (-2 * (y_max - y_min)) / Math.Pow((x_max - x_min), 3)
        b = -(3 / 2) * a * (x_max + x_min)
        c = 3 * a * x_max * x_min
        d = y_max + (a / 2) * (x_max - 3 * x_min) * Math.Pow(x_max, 2)

        y = Math.Round(a * Math.Pow(x, 3) + b * Math.Pow(x, 2) + c * x + d)

        ' clear entire used canvas area
        g.FillRectangle(bg_colour, 0, 60, sender.Width, sender.Height)
        ' draw dot
        g.FillEllipse(dot_colour, x, y, dotDIAMETER, dotDIAMETER)
    End Sub

    ' repetitively clear and draw dot on the screen - Simulate motion
    Public Sub play(sender As Object, g As Graphics)
        ' condition for continuing motion
        Do While x < sender.Width - dotDIAMETER And y >= y_max
            ' redraw dot
            g.FillEllipse(dot_colour, x, y, dotDIAMETER, dotDIAMETER)

            x += 20
            y = Math.Round(a * Math.Pow(x, 3) + b * Math.Pow(x, 2) + c * x + d)
            ' take a time pause
            Threading.Thread.Sleep(50)
        Loop
    End Sub
End Class
