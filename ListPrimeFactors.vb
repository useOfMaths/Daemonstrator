Public Class ListPrimeFactors

    Dim find_my_factors As Integer
    Dim found_prime_factors As New List(Of Integer)
    Dim sqrt_range As Integer

    Public Sub _init_(value As Integer)
        find_my_factors = value
    End Sub


    ' takes one argument, the candidate For factorisation
    ' returns an array reference Of the prime factors
    Public Function onlyPrimeFactors() As List(Of Integer)
        Dim temp_limit = Math.Ceiling(Math.Sqrt(find_my_factors))

        ' STEP 1:
        Dim i = 2
        Do While i <= temp_limit
            ' STEP 4:
            ' avoid an infinite Loop With the i != 1 check.
            If i <> 1 And find_my_factors Mod i = 0 Then
                found_prime_factors.Add(i)
                ' STEP 2:
                find_my_factors = find_my_factors / i
                ' STEP 3:
                Return onlyPrimeFactors()
            End If

            i += 1
        Loop

        found_prime_factors.Add(find_my_factors)
        Return found_prime_factors

    End Function

End Class
