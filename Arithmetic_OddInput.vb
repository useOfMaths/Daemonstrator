Module Arithmetic_odd_input

    Sub Main()

        ' Collect Input
        Dim lower_boundary As Integer
        Dim upper_boundary As Integer

        Console.WriteLine("Enter the range for your odd numbers.")

        Console.Write("Enter Start Number: ")
        lower_boundary = Val(Console.ReadLine())
        Console.Write("Enter Stop Number: ")
        upper_boundary = Val(Console.ReadLine())

        ' Use the even number Class
        Dim odd_list As New OddNumbers
        odd_list._init_(lower_boundary, upper_boundary)
        Dim answer = odd_list.prepResult()

        Console.WriteLine("Odd numbers between " & lower_boundary & " and " & upper_boundary & " are:")
        Console.Write(String.Join(", ", answer))

    End Sub

End Module
