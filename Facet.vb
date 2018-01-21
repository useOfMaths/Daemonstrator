Public Class Facet

    Dim screen_rect As Rectangle
    Public CLICK_OCCURRED As Boolean = False

    Public Sub formFeatures(sender As Object)
        'Set window position, width and height
        screen_rect = Screen.PrimaryScreen.Bounds
        sender.SetDesktopBounds(0, 0, screen_rect.Width, screen_rect.Height)

        ' Set a display text
        sender.Text = "useOfMaths.com"

        ' Set a background colour
        sender.BackColor = System.Drawing.Color.LightGray

        ' Set an icon image
        Dim path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
        path = New Uri(path).LocalPath
        Try
            sender.Icon = New Icon(path & "\useOfMaths.ico")
        Catch ex As System.IO.FileNotFoundException
            ' Well, just go on and use default pic
        End Try

        '
        'create a button - response_btn
        '
        Dim response_btn As New Button()
        response_btn.BackColor = System.Drawing.Color.Magenta
        response_btn.ForeColor = System.Drawing.Color.Blue
        response_btn.Name = "response_btn"
        response_btn.SetBounds(Math.Round(screen_rect.Width / 2) - 50, 5, 100, 40)
        response_btn.Text = "Move"
        sender.Controls.Add(response_btn)
        AddHandler response_btn.Click, AddressOf response_btn_Click
    End Sub

    Public Sub decorateButtonArea(sender As Object, e As PaintEventArgs)
        ' Draw a dotted line
        Dim pencil As New System.Drawing.Pen(System.Drawing.Color.Black)
        pencil.DashStyle = Drawing2D.DashStyle.DashDot
        pencil.Width = 5
        e.Graphics.DrawLine(pencil, 0, 50, sender.Width, 50)
        pencil.Dispose()

        ' Colour region
        Dim paint_brush As New System.Drawing.SolidBrush(System.Drawing.Color.Pink)
        e.Graphics.FillRectangle(paint_brush, 0, 0, sender.Width, 50)
        paint_brush.Dispose()
    End Sub

    Public Sub response_btn_Click(sender As Object, e As EventArgs)
        ' turn this on on every button click
        CLICK_OCCURRED = True
        sender.Refresh()
    End Sub
End Class
