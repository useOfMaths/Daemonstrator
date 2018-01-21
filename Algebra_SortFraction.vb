Module Algebra_sort_fraction

    Sub Main()
        ''
        ' Sorting fractions
        ''
        Dim numerators = {9, 3, 5, 7}
        Dim denominators = {2, 4, 12, 18}
        Dim fractions As New Dictionary(Of String, Integer())
        fractions.Add("numerators", numerators)
        fractions.Add("denominators", denominators)

        Console.WriteLine("    Sorting in ascending order the fractions:" & vbCrLf)
        ' Print as fraction
        For Each numerator In fractions.Item("numerators")
            Console.Write(String.Format("{0,13}", numerator))
        Next
        Console.Write(Environment.NewLine & String.Format("{0,12}", " "))
        For wasted = 0 To numerators.Count - 2
            Console.Write(String.Format("{0}", "-   ,        "))
        Next
        Console.WriteLine(String.Format("{0,1}", "-"))
        For Each denominator In fractions.Item("denominators")
            Console.Write(String.Format("{0,13}", denominator))
        Next
        Console.WriteLine("")

        ' use the SortFraction Class
        Dim sort_fract As New SortFraction
        sort_fract._init_(fractions)
        fractions = sort_fract.sortAscending()

        Console.WriteLine(Environment.NewLine)

        ' Print as fraction
        For Each numerator In fractions.Item("numerators")
            Console.Write(String.Format("{0,13}", numerator))
        Next
        Console.Write(Environment.NewLine & String.Format("{0,12}", "Answer  =   "))
        For wasted = 0 To numerators.Count - 2
            Console.Write(String.Format("{0}", "-   ,        "))
        Next
        Console.WriteLine(String.Format("{0,1}", "-"))
        For Each denominator In fractions.Item("denominators")
            Console.Write(String.Format("{0,13}", denominator))
        Next

    End Sub

End Module
