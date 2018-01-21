Module Algebra_2Unknown

    Sub Main()
        ''
        ' Simultaneous Equations With 2 unknowns
        ''
        Dim operators = {"+", "+"}
        Dim x_coefficients = {8.0, 2.0}
        Dim y_coefficients = {-5.0, 17.0}
        Dim equal = {89.0, 150.0}

        Dim equations As New Dictionary(Of String, Double())
        equations.Add("x", x_coefficients)
        equations.Add("y", y_coefficients)
        equations.Add("eq", equal)

        If y_coefficients(0) < 0 Then
            operators(0) = "-"
        End If
        If y_coefficients(1) < 0 Then
            operators(1) = "-"
        End If

        Console.WriteLine(vbCrLf, "    Solving simultaneously the equations:", vbCrLf)
        'Print As an equation
        Console.WriteLine(String.Format("{0,20}x  {1}  {2}y  =  {3}",
              x_coefficients(0), operators(0), Math.Abs(y_coefficients(0)), equal(0)
              )
        )
        Console.WriteLine(String.Format("{0,20}x  {1}  {2}y  =  {3}",
            x_coefficients(1), operators(1), Math.Abs(y_coefficients(1)), equal(1)
            )
        )
        Console.WriteLine(Environment.NewLine)
        Console.Write(String.Format("{0,15} {1}{2,20}", "Yields:", vbCrLf, "(x, y)  =  "))

        Try
            Dim sim2unk As New Simultaneous2Unknown
            sim2unk._init_(equations)
            Dim solution = sim2unk.solveSimultaneous()

            Console.Write(String.Format("({0:0.0000}, {1:0.0000})", solution(0), solution(1)))

        Catch ex As Exception
            Console.Write("(infinity,  infinity)")
        End Try

    End Sub

End Module
