Module Arithmetic_check_prime

    Sub Main()
        ' Use the check prime Class
        Dim test_guy = 93
        Dim prime_check As New CheckPrime
        prime_check._init_(test_guy)

        Dim result = "Prime State:" & Environment.NewLine
        If prime_check.verifyPrime() Then
            result = test_guy & " is a prime number."
        Else
            result += test_guy & " is not a prime number." & Environment.NewLine
            result += "At least one factor of " & test_guy & " is " & prime_check.possible_factor
        End If

        Console.WriteLine(result)

    End Sub

End Module
