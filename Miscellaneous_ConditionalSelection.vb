Module Miscellaneous_ConditionalSelection

    Sub Main()

        Dim goods As String() = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"}
        ' minimum number of occurrences
        Dim min As Integer() = {0, 0, 1, 0, 0, 1, 0, 0, 1, 0}
        ' maximum number of occurrences
        Dim max As Integer() = {4, 3, 2, 4, 3, 2, 4, 3, 2, 4}

        Dim choose As New ConditionalSelection
        Dim result As List(Of String()) = choose.limitedSelection(goods, 5, min, max)

        ' print choices and operation
        Console.Write("[ ")
        For Each choice As String In choose.words
            Console.Write(choice & "; ")
        Next
        Console.WriteLine("] conditioned selection " & choose.r & ":" & Environment.NewLine)

        ' print out selections nicely
        For Each group As String() In result
            For Each member As String In group
                Console.Write(member & "; ")
            Next
            Console.WriteLine()
        Next
        Console.WriteLine(Environment.NewLine & "Number of ways is " & result.Count & ".")
    End Sub

End Module
