Module Algebra_improper2mixed

    Sub Main()

        ''
        ' Convert fractions from Improper To Mixed
        ''
        Dim fraction As New Dictionary(Of String, Integer)
        fraction.Add("numerator", 10)
        fraction.Add("denominator", 3)

        Console.WriteLine("    Converting from Improper to Mixed the fraction:")
        ' Print as fraction
        Console.WriteLine(String.Format("{0,55}", fraction.Item("numerator")))
        Console.WriteLine(String.Format("{0,55}", "-"))
        Console.WriteLine(String.Format("{0,55}", fraction.Item("denominator")))

        ' use the ImproperToMixed Class
        Dim imp2mix As New ImproperToMixed
        imp2mix._init_(fraction)
        fraction = imp2mix.doConvert()

        Console.WriteLine(Environment.NewLine)

        Console.WriteLine(String.Format("{0,52}", fraction.Item("numerator")))
        Console.WriteLine(String.Format("{0,48} {1} {2}", "Answer =   ", fraction.Item("whole_number"), "-"))
        Console.WriteLine(String.Format("{0,52}", fraction.Item("denominator")))

    End Sub

End Module
