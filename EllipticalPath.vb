Public Class EllipticalPath

    Private h, k, a, b, x, y As Integer
    Private Const dotDIAMETER = 10

    Dim dot_colour As New System.Drawing.SolidBrush(System.Drawing.Color.Yellow)
    Dim bg_colour As New System.Drawing.SolidBrush(System.Drawing.Color.LightGray)

    ' draw first appearance of dot on the screen
    Public Sub prep(sender As Object, g As Graphics)
        ' ellipse centre coordinates
        h = Math.Round(sender.Width / 2)
        k = Math.Round(sender.Height / 2)
        ' ellipse major and minor semi-axes
        a = Math.Round(sender.Width / 3)
        b = Math.Round(sender.Height / 3)
        x = h - a
        y = k

        ' clear entire used canvas area
        g.FillRectangle(bg_colour, 0, 60, sender.Width, sender.Height)
        ' draw dot
        g.FillEllipse(dot_colour, x, y, dotDIAMETER, dotDIAMETER)
    End Sub

    ' repetitively clear and draw dot on the screen - Simulate motion
    Public Sub play(sender As Object, g As Graphics)
        ' condition for continuing motion
        Do While x <= h + a
            y = Math.Round(k - (b / a) * Math.Sqrt(Math.Pow(a, 2) - Math.Pow((x - h), 2)))
            ' redraw dot
            g.FillEllipse(dot_colour, x, y, dotDIAMETER, dotDIAMETER)

            y = Math.Round(k + (b / a) * Math.Sqrt(Math.Pow(a, 2) - Math.Pow((x - h), 2)))
            ' redraw dot
            g.FillEllipse(dot_colour, x, y, dotDIAMETER, dotDIAMETER)

            x += 20
            ' take a time pause
            Threading.Thread.Sleep(50)
        Loop
    End Sub
End Class
