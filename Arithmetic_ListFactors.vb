Module Arithmetic_list_factors

    Sub Main()

        ' Use the list factors Class
        Dim test_guy = 48
        Dim factor_list As New ListFactors
        factor_list._init_(test_guy)
        Dim answer = factor_list.findFactors()

        Console.WriteLine("Factors of " & test_guy & " include:")
        Console.WriteLine(String.Join(", ", answer))

    End Sub

End Module
