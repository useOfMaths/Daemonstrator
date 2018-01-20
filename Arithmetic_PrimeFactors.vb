Module Arithmetic_prime_factors

    Sub Main()

        ' Use the list factors Class
        Dim test_guy = 48
        Dim prime_factors As New ListPrimeFactors
        prime_factors._init_(test_guy)
        Dim answer = prime_factors.onlyPrimeFactors()

        Console.WriteLine("Prime factorising " & test_guy & " gives:")
        Console.WriteLine(String.Join(" X ", answer))

    End Sub

End Module
