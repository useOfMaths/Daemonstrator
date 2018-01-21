Module Miscellaneous_SoleKeyEncryption

    Sub Main()

        Dim message = "merry xmas".ToCharArray()
        Dim key = "A5FB17C4D8".ToCharArray() ' you might want To avoid zeroes
        Dim go_secure = New SoleKeyEncryption()

        Dim encrypted = go_secure.encodeWord(message, key)
        Console.WriteLine("Message is '" & String.Join("", message) & "';" &
                          Environment.NewLine & "Encrypted version is " & String.Join(", ", encrypted))

        Dim decrypted = go_secure.decodeWord(encrypted, key)
        Console.WriteLine(Environment.NewLine & "Decrypted version is '" & decrypted & "'.")

    End Sub

End Module
