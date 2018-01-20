Module Arithmetic_fast_HCF

    Sub Main()

        ' Use the fast HCF Class
        Dim group As New List(Of Integer)({20, 30, 40})
        Dim h_c_f As New FastHCF
        h_c_f._init_(group)
        Dim answer = h_c_f.getHCF()

        Console.Write("The H.C.F. of " & String.Join(", ", group) & " is " & answer)

    End Sub

End Module
