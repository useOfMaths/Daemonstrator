Public Class Simultaneous2Unknown

    Dim x_coefficients() As Double
    Dim y_coefficients() As Double
    Dim equal() As Double
    Dim eliminator(1, 1) As Double
    Dim x_variable As Double
    Dim y_variable As Double

    ' A constructor
    Public Sub _init_(equations)
        x_coefficients = equations("x")
        y_coefficients = equations("y")
        equal = equations("eq")
    End Sub

    ' Returns a list Of the result
    Public Function solveSimultaneous() As Double()
        ' eliminate y
        ' STEP 2:
        eliminator(0, 0) = y_coefficients(1) * x_coefficients(0)
        eliminator(0, 1) = y_coefficients(1) * equal(0)
        ' STEP 3:
        eliminator(1, 0) = y_coefficients(0) * x_coefficients(1)
        eliminator(1, 1) = y_coefficients(0) * equal(1)

        Try
            ' STEPS 4, 5:
            x_variable = (eliminator(0, 1) - eliminator(1, 1)) / (eliminator(0, 0) - eliminator(1, 0))
            ' STEP 6:
            y_variable = (equal(0) - x_coefficients(0) * x_variable) / y_coefficients(0)

            Return {x_variable, y_variable}

        Catch ex As DivideByZeroException
            Throw ex
            Return Nothing
        End Try
    End Function

End Class
