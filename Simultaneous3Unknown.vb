Public Class Simultaneous3Unknown

    Dim x_coefficients() As Double
    Dim y_coefficients() As Double
    Dim z_coefficients() As Double
    Dim equal() As Double
    Dim eliminator(2, 2) As Double
    Dim x_variable As Double
    Dim y_variable As Double
    Dim z_variable As Double

    Dim lcm As Double

    ' A constructor
    Public Sub _init_(equations As Dictionary(Of String, Double()))
        x_coefficients = equations("x")
        y_coefficients = equations("y")
        z_coefficients = equations("z")
        equal = equations("eq")
    End Sub

    ' Returns a list Of the result
    Public Function solveSimultaneous() As Double()
        Dim l_c_m As New LCM
        l_c_m._init_(z_coefficients)
        lcm = l_c_m.getLCM()

        ' STEP 1:
        ' eliminate z variable
        eliminator(0, 0) = (lcm * x_coefficients(0)) / z_coefficients(0)
        eliminator(0, 1) = (lcm * y_coefficients(0)) / z_coefficients(0)
        eliminator(0, 2) = (lcm * equal(0)) / z_coefficients(0)

        eliminator(1, 0) = (lcm * x_coefficients(1)) / z_coefficients(1)
        eliminator(1, 1) = (lcm * y_coefficients(1)) / z_coefficients(1)
        eliminator(1, 2) = (lcm * equal(1)) / z_coefficients(1)

        eliminator(2, 0) = (lcm * x_coefficients(2)) / z_coefficients(2)
        eliminator(2, 1) = (lcm * y_coefficients(2)) / z_coefficients(2)
        eliminator(2, 2) = (lcm * equal(2)) / z_coefficients(2)

        ' STEP 2:
        Dim new_x = {eliminator(0, 0) - eliminator(1, 0), eliminator(1, 0) - eliminator(2, 0)}
        Dim new_y = {eliminator(0, 1) - eliminator(1, 1), eliminator(1, 1) - eliminator(2, 1)}
        Dim new_eq = {eliminator(0, 2) - eliminator(1, 2), eliminator(1, 2) - eliminator(2, 2)}

        Try
            ' STEP 3
            Dim s2u As New Simultaneous2Unknown
            Dim aux As New Dictionary(Of String, Double())
            aux.Add("x", new_x)
            aux.Add("y", new_y)
            aux.Add("eq", new_eq)
            s2u._init_(aux)
            Dim partial_solution = s2u.solveSimultaneous()

            x_variable = partial_solution(0)
            y_variable = partial_solution(1)
            ' STEP 4:
            z_variable = (equal(0) - x_coefficients(0) * x_variable - y_coefficients(0) * y_variable) / z_coefficients(0)

            Return {x_variable, y_variable, z_variable}

        Catch ex As DivideByZeroException
            Throw ex
            Return Nothing
        End Try
    End Function

End Class
