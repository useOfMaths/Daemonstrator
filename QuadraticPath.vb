Public Class QuadraticPath

    Private x_start, y_start, x_max, y_max, x, y As Integer
    Private a, b, c As Double
    Private Const dotDIAMETER = 10

    Dim dot_colour As New System.Drawing.SolidBrush(System.Drawing.Color.Yellow)
    Dim bg_colour As New System.Drawing.SolidBrush(System.Drawing.Color.LightGray)

    ' draw first appearance of dot on the screen
    Public Sub prep(sender As Object, g As Graphics)
        x_start = 10
        y_start = sender.Height - 70
        x_max = Math.Round(sender.Width / 2) - 5
        y_max = 70
        x = x_start
        y = y_start

        ' constants
        a = (y_start - y_max) / Math.Pow((x_start - x_max), 2)
        b = -2 * a * x_max
        c = y_max + a * Math.Pow(x_max, 2)

        ' clear entire used canvas area
        g.FillRectangle(bg_colour, 0, 60, sender.Width, sender.Height)
        ' draw dot
        g.FillEllipse(dot_colour, x, y, dotDIAMETER, dotDIAMETER)
    End Sub

    ' repetitively clear and draw dot on the screen - Simulate motion
    Public Sub play(sender As Object, g As Graphics)
        ' condition for continuing motion
        Do While x < sender.Width - dotDIAMETER And y <= y_start
            ' redraw dot
            g.FillEllipse(dot_colour, x, y, dotDIAMETER, dotDIAMETER)

            x += 10
            y = Math.Round(a * x * x + b * x + c)
            ' take a time pause
            Threading.Thread.Sleep(50)
        Loop
    End Sub
End Class
