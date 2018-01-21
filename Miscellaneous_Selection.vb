Module Miscellaneous_Selection

    Sub Main()

        Dim goods As String() = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"}
        Dim pick As New Selection
        Dim result As List(Of String()) = pick.groupSelection(goods, 2)

        ' print choices and operation
        Console.Write("[ ")
        For Each choice As String In pick.words
            Console.Write(choice & "; ")
        Next
        Console.WriteLine("] selection " & pick.r & ":" & Environment.NewLine)

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
