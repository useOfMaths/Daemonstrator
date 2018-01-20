Module Arithmetic_prime_numbers

    Sub Main()

        ' Use the even number Class
        Dim lower_boundary = 1
        Dim upper_boundary = 100
        Dim prime_list As New PrimeNumbers
        prime_list._init_(lower_boundary, upper_boundary)
        Dim answer = prime_list.getPrimes()

        Console.WriteLine("Prime numbers between " & lower_boundary & " and " & upper_boundary & " are:")
        Console.WriteLine(String.Join(", ", answer))

    End Sub

End Module
