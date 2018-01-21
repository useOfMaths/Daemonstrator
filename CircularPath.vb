Public Class CircularPath

    Private a, b, r, x, y As Integer
    Private Const dotDIAMETER = 10

    Dim dot_colour As New System.Drawing.SolidBrush(System.Drawing.Color.Yellow)
    Dim bg_colour As New System.Drawing.SolidBrush(System.Drawing.Color.LightGray)

    ' draw first appearance of dot on the screen
    Public Sub prep(sender As Object, g As Graphics)
        ' circle centre coordinates
        a = Math.Round(sender.Width / 2)
        b = Math.Round(sender.Height / 2)
        ' circle radius
        r = Math.Round(sender.Height / 3)
        x = a - r
        y = b

        ' clear entire used canvas area
        g.FillRectangle(bg_colour, 0, 60, sender.Width, sender.Height)
        ' draw dot
        g.FillEllipse(dot_colour, x, y, dotDIAMETER, dotDIAMETER)
    End Sub

    ' repetitively clear and draw dot on the screen - Simulate motion
    Public Sub play(sender As Object, g As Graphics)
        ' condition for continuing motion
        Do While x <= a + r
            y = b - Math.Round(Math.Sqrt(Math.Pow(r, 2) - Math.Pow((x - a), 2)))
            ' redraw dot
            g.FillEllipse(dot_colour, x, y, dotDIAMETER, dotDIAMETER)

            y = b + Math.Round(Math.Sqrt(Math.Pow(r, 2) - Math.Pow((x - a), 2)))
            ' redraw dot
            g.FillEllipse(dot_colour, x, y, dotDIAMETER, dotDIAMETER)

            x += 20
            ' take a time pause
            Threading.Thread.Sleep(50)
        Loop
    End Sub
End Class
