Module Algebra_subtract_fraction

    Sub Main()
        ''
        ' Subtracting fractions
        ''
        Dim numerators = {9, 3, 5, 7}
        Dim denominators = {2, 4, 12, 18}
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
            Console.Write(String.Format("{0}", "-     -      "))
        Next
        Console.WriteLine(String.Format("{0,1}", "-"))
        For Each denominator In fractions.Item("denominators")
            Console.Write(String.Format("{0,13}", denominator))
        Next
        Console.WriteLine("")

        ' use the SubtractFraction Class
        Dim sub_fract As New SubtractFraction
        sub_fract._init_(fractions)
        Dim fraction = sub_fract.doSubtract()

        Console.WriteLine(Environment.NewLine)

        Console.WriteLine(String.Format("{0,25}", fraction.Item("numerator")))
        Console.WriteLine(String.Format("{0,25}", "Answer   =      -"))
        Console.WriteLine(String.Format("{0,25}", fraction.Item("denominator")))

    End Sub

End Module
