Public Class PeriodicFunction

    Private theta, a, y, half_vert_screen As Integer
    Private Const dotDIAMETER = 10

    Dim dot_colour As New System.Drawing.SolidBrush(System.Drawing.Color.Yellow)
    Dim bg_colour As New System.Drawing.SolidBrush(System.Drawing.Color.LightGray)

    ' draw first appearance of dot on the screen
    Public Sub prep(sender As Object, g As Graphics)
        theta = 0
        a = sender.Height / 3 ' constant
        ' half way down the vertical section of the screen
        half_vert_screen = sender.Height / 2
        y = Math.Round(a * Math.Sin(theta * Math.PI / 180)) + half_vert_screen

        ' clear entire used canvas area
        g.FillRectangle(bg_colour, 0, 60, sender.Width, sender.Height)
        ' draw x-axis line
        g.DrawLine(Pens.Black, 0, half_vert_screen + 5, sender.Width, half_vert_screen + 5)
        ' draw dot
        g.FillEllipse(dot_colour, theta, y, dotDIAMETER, dotDIAMETER)
    End Sub

    ' repetitively clear and draw dot on the screen - Simulate motion
    Public Sub play(sender As Object, g As Graphics)
        ' condition for continuing motion
        Do While theta < sender.Width - dotDIAMETER
            y = Math.Round(a * Math.Sin(theta * Math.PI / 180)) + half_vert_screen

            ' redraw dot
            g.FillEllipse(dot_colour, theta, y, dotDIAMETER, dotDIAMETER)

            theta += 15
            ' take a time pause
            Threading.Thread.Sleep(50)
        Loop
    End Sub
End Class
