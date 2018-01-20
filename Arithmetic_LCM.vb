Module Arithmetic_LCM

    Sub Main()

        ' Use the LCM Class
        Dim group As New List(Of Integer)({20, 30, 40})
        Dim lcm As New LCM
        lcm._init_(group)
        Dim answer = lcm.getLCM()

        Console.Write("The L.C.M. of " & String.Join(", ", group) & " is " & answer)

    End Sub

End Module
