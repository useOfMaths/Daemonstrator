Module Algebra_low_term

    Sub Main()

        ''
        ' Reduce fractions To Lowest Term
        ''
        Dim fraction As New Dictionary(Of String, Integer)
        fraction.Add("numerator", 16)
        fraction.Add("denominator", 640)

        Console.WriteLine("    To reduce to lowest term, simplifying:")
        ' Print as fraction
        Console.WriteLine(String.Format("{0,45}", fraction.Item("numerator")))
        Console.WriteLine(String.Format("{0,45}", "-"))
        Console.WriteLine(String.Format("{0,45}", fraction.Item("denominator")))

        ' use the LowestTerm Class
        Dim low_term As New LowestTerm
        low_term._init_(fraction)
        fraction = low_term.reduceFraction()

        Console.WriteLine(Environment.NewLine)

        Console.WriteLine(String.Format("{0,46}", fraction.Item("numerator")))
        Console.WriteLine(String.Format("{0,46}", "Answer =    -"))
        Console.WriteLine(String.Format("{0,46}", fraction.Item("denominator")))

    End Sub

End Module
