Module Arithmetic_even_numbers

    Sub Main()

        ' Use the even number Class
        Dim lower_boundary = 1
        Dim upper_boundary = 100
        Dim even_list As New EvenNumbers
        even_list._init_(lower_boundary, upper_boundary)
        Dim answer = even_list.prepResult()

        Console.WriteLine("Even numbers between " & lower_boundary & " and " & upper_boundary & " are:")
        Console.Write(String.Join(", ", answer))

    End Sub

End Module
