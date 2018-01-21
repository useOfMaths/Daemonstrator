Public Class Facet

    Dim screen_rect As Rectangle
    Dim response_btn As New Button()

    Public Sub formFeatures(control As Object)
        'Set window position, width and height
        screen_rect = Screen.PrimaryScreen.Bounds
        control.SetDesktopBounds(0, 0, screen_rect.Width, screen_rect.Height)

        ' Set a display text
        sender.Text = "useOfMaths.com"

        ' Set a background colour
        sender.BackColor = System.Drawing.Color.Orange

        ' Set an icon image
        Dim path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
        path = New Uri(path).LocalPath
        Try
            sender.Icon = New Icon(path & "\useOfMaths.ico")
        Catch ex As Exception
            ' Well, just go on and use default pic
        End Try
    End Sub

End Class
