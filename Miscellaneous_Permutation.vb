Module Miscellaneous_Permutation

    Sub Main()

        Dim goods
        goods = New List(Of String)(New String() {"Eno", "Chidi", "Olu", "Ahmed", "Osas", "Gbeda"})
        Dim perm As New Permutation
        Dim result As List(Of String()) = perm.possibleWordPermutations(goods, 3)
        ' print choices and operation
        Console.Write("[ ")
        For Each choice As String In perm.words
            Console.Write(choice & "; ")
        Next
        Console.WriteLine("] permutation " & perm.r & ":" & Environment.NewLine)
        ' print out permutations nicely
        For Each group As String() In result
            For Each member As String In group
                Console.Write(member & "; ")
            Next
            Console.WriteLine()
        Next
        Console.WriteLine(Environment.NewLine & "Number of ways is " & result.Count & ".")

    End Sub

End Module
