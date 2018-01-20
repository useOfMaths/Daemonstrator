Module Arithmetic_odd_numbers

    Sub Main()
        ' Use the even number Class
        Dim lower_boundary = 1
        Dim upper_boundary = 100
        Dim odd_list As New OddNumbers
        odd_list._init_(lower_boundary, upper_boundary)
        Dim answer = odd_list.prepResult()

        Console.WriteLine("Odd numbers between " & lower_boundary & " and " & upper_boundary & " are:")
        Console.Write(String.Join(", ", answer))

    End Sub

End Module
