Module Algebra_3Unknown

    Sub Main()
        ''
        ' Simultaneous Equations with 3 unknowns
        ''

        Dim x_coefficients = {2.0, 4.0, 2.0}
        Dim y_coefficients = {1.0, -1.0, 3.0}
        Dim z_coefficients = {1.0, -2.0, -8.0}
        Dim equal = {4.0, 1.0, -3.0}

        Dim equations As New Dictionary(Of String, Double())
        equations.Add("x", x_coefficients)
        equations.Add("y", y_coefficients)
        equations.Add("z", z_coefficients)
        equations.Add("eq", equal)

        Dim operators(2, 1) As String
        For i = 0 To 2
            operators(i, 0) = "+"
            If y_coefficients(i) < 0 Then
                operators(i, 0) = "-"
            End If
            operators(i, 1) = "+"
            If z_coefficients(i) < 0 Then
                operators(i, 1) = "-"
            End If
        Next i

        Console.WriteLine(vbCrLf, "    Solving simultaneously the equations:", vbCrLf)
        'Print as an equation
        Console.WriteLine(String.Format("{0,20}x  {1}  {2}y  {3}  {4}z  =  {5}",
                x_coefficients(0), operators(0, 0), Math.Abs(y_coefficients(0)),
                operators(0, 1), Math.Abs(z_coefficients(0)), equal(0)
            )
        )
        Console.WriteLine(String.Format("{0,20}x  {1}  {2}y  {3}  {4}z  =  {5}",
                x_coefficients(1), operators(1, 0), Math.Abs(y_coefficients(1)),
                operators(1, 1), Math.Abs(z_coefficients(1)), equal(1)
            )
        )
        Console.WriteLine(String.Format("{0,20}x  {1}  {2}y  {3}  {4}z  =  {5}",
                x_coefficients(2), operators(2, 0), Math.Abs(y_coefficients(2)),
                operators(2, 1), Math.Abs(z_coefficients(2)), equal(2)
            )
        )
        Console.WriteLine(Environment.NewLine)
        Console.Write(String.Format("{0,15} {1}{2,20}", "Yields:", vbCrLf, "(x, y, z)  =  "))

        Try
            Dim sim3unk As New Simultaneous3Unknown
            sim3unk._init_(equations)
            Dim solution = sim3unk.solveSimultaneous()

            Console.Write(String.Format("({0:0.0000}, {1:0.0000}, {2:0.0000})", solution(0), solution(1), solution(2)))

        Catch ex As Exception
            Console.Write("(infinity,  infinity, infinity)")
        End Try

    End Sub

End Module
