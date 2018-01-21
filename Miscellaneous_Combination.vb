Module Miscellaneous_Combination

    Sub Main()

        Dim goods As List(Of String)
        goods = New List(Of String)(New String() {"Eno", "Chidi", "Olu", "Ahmed", "Osas", "Gbeda"})
        Dim combo As New Combination
        Dim result As List(Of String()) = combo.possibleWordCombinations(goods, 3)
        ' print choices and operation
        Console.Write("[ ")
        For Each choice As String In combo.words
            Console.Write(choice & "; ")
        Next
        Console.WriteLine("] combination " & combo.r & ":" & Environment.NewLine)
        ' print out combinations nicely
        For Each group As String() In result
            For Each member As String In group
                Console.Write(member & "; ")
            Next
            Console.WriteLine()
        Next
        Console.WriteLine(Environment.NewLine & "Number of ways is " & result.Count & ".")

    End Sub

End Module
