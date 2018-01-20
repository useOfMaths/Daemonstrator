Module Arithmetic_HCF

    Sub Main()

        ' Use the HCF Class
        Dim group As New List(Of Integer)({20, 30, 40})
        Dim hcf As New HCF
        hcf._init_(group)
        Dim answer = hcf.getHCF()

        Console.Write("The H.C.F. of " & String.Join(", ", group) & " is " & answer)

    End Sub

End Module
