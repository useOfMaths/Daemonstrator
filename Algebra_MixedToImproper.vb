Module Algebra_mixed2improper

    Sub Main()

        ''
        ' Convert fractions from Mixed To Improper
        ''
        Dim fraction As New Dictionary(Of String, Integer)
        fraction.Add("whole_number", 3)
        fraction.Add("numerator", 1)
        fraction.Add("denominator", 3)

        Console.WriteLine("    Converting from Mixed to Improper the fraction:")
        ' Print As fraction
        Console.WriteLine(String.Format("{0,55}", fraction.Item("numerator")))
        Console.WriteLine(String.Format("{0,53} {1}", fraction.Item("whole_number"), "-"))
        Console.WriteLine(String.Format("{0,55}", fraction.Item("denominator")))

        ' use the MixedToImproper Class
        Dim mix2imp As New MixedToImproper
        mix2imp._init_(fraction)
        fraction.Item("numerator") = mix2imp.doConvert()

        Console.WriteLine(Environment.NewLine)

        Console.WriteLine(String.Format("{0,52}", fraction.Item("numerator")))
        Console.WriteLine(String.Format("{0,52}", "Answer =      -"))
        Console.WriteLine(String.Format("{0,52}", fraction.Item("denominator")))

    End Sub

End Module
