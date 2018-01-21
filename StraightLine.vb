Public Class StraightLine

    Private x1, y1, x2, y2, x, y As Integer
    Private m, c As Double
    Private Const dotDIAMETER = 10

    Dim dot_colour As New System.Drawing.SolidBrush(System.Drawing.Color.Yellow)
    Dim bg_colour As New System.Drawing.SolidBrush(System.Drawing.Color.LightGray)

    ' draw first appearance of dot on the screen
    Public Sub prep(sender As Object, g As Graphics)
        x1 = 10
        y1 = 70
        x2 = sender.Width - 50
        y2 = sender.Height - 50
        x = x1
        y = y1

        m = (y2 - y1) / (x2 - x1) ' slope
        c = (x2 * y1 - x1 * y2) / (x2 - x1) ' y-intercept

        ' clear entire used canvas area
        g.FillRectangle(bg_colour, 0, 60, sender.Width, sender.Height)
        ' draw dot
        g.FillEllipse(dot_colour, x, y, dotDIAMETER, dotDIAMETER)
    End Sub

    ' repetitively clear and draw dot on the screen - Simulate motion
    Public Sub play(sender As Object, g As Graphics)
        ' condition for continuing motion
        Do While x < sender.Width - dotDIAMETER
            y = Math.Ceiling(m * x + c)

            ' redraw dot
            g.FillEllipse(dot_colour, x, y, dotDIAMETER, dotDIAMETER)

            x += 20
            ' take a time pause
            Threading.Thread.Sleep(50)
        Loop
    End Sub
End Class
