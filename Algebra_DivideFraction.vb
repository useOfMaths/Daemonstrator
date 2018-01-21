Module Algebra_divide_fraction

    Sub Main()
        ''
        ' Dividing fractions
        ''
        Dim numerators = {16, 9, 640, 7}
        Dim denominators = {9, 20, 27, 20}
        Dim fractions As New Dictionary(Of String, Integer())
        fractions.Add("numerators", numerators)
        fractions.Add("denominators", denominators)

        Console.WriteLine("    Solving:")
        ' Print as fraction
        For Each numerator In fractions.Item("numerators")
            Console.Write(String.Format("{0,13}", numerator))
        Next
        Console.Write(Environment.NewLine & String.Format("{0,12}", " "))
        For wasted = 0 To numerators.Count - 2
            Console.Write(String.Format("{0}", "-     /      "))
        Next
        Console.WriteLine(String.Format("{0,1}", "-"))
        For Each denominator In fractions.Item("denominators")
            Console.Write(String.Format("{0,13}", denominator))
        Next
        Console.WriteLine("")

        ' use the DivideFraction Class
        Dim div_fract As New DivideFraction
        div_fract._init_(fractions)
        Dim fraction = div_fract.doDivide()

        Console.WriteLine(Environment.NewLine)

        Console.WriteLine(String.Format("{0,25}", fraction.Item("numerator")))
        Console.WriteLine(String.Format("{0,25}", "Answer   =   -"))
        Console.WriteLine(String.Format("{0,25}", fraction.Item("denominator")))

    End Sub

End Module
