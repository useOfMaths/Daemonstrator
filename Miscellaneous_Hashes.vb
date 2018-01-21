Module Miscellaneous_Hashes

    Sub Main()

        Dim message = "merry xmas".ToCharArray()

        Dim one_way = New Hashes()
        Dim hashed = one_way.hashWord(message)

        Console.WriteLine("Message is '" & String.Join("", message) & "';" &
                          Environment.NewLine & "Message hash is " + hashed)
    End Sub

End Module
