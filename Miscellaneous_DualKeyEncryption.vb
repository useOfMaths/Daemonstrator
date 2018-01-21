Imports System.Numerics

Module Miscellaneous_DualKeyEncryption

    Sub Main()

        ''
        ' STEP I:
        ''
        Dim p1 = 101 ' 1st prime
        Dim p2 = 401 ' 2nd prime
        ''
        ' STEP II:
        ''
        Dim semi_prime As BigInteger = p1 * p2

        ''
        ' STEP III:
        ''
        Dim l_c_m As New LCM
        l_c_m._init_({p1 - 1, p2 - 1})
        Dim lcm = l_c_m.getLCM()

        ''
        ' STEP IV:
        ''
        ' pick a random prime (public_key) that lies
        ' between 1 And LCM but Not a factor of LCM
        Dim public_key As BigInteger = 313

        ' find "public_key" complement - private_key - such that
        ' (public_key * private_key) % LCM = 1
        ' this involves some measure of trial And error
        Dim i = 1
        Do While (lcm * i + 1) Mod public_key <> 0
            i += 1
        Loop
        ''
        ' STEP V:
        ''
        Dim private_key As BigInteger = BigInteger.Divide(i * lcm + 1, public_key)

        Dim message = "merry xmas".ToCharArray()
        Dim go_secure = New DualKeyEncryption()

        Dim encrypted = go_secure.encodeWord(message, public_key, semi_prime)
        Console.WriteLine("Message is '" & String.Join("", message) & "';" &
                          Environment.NewLine & "Encrypted version is " & String.Join(", ", encrypted))

        Dim decrypted = go_secure.decodeWord(encrypted, private_key, semi_prime)
        Console.WriteLine(Environment.NewLine & "Decrypted version is '" & decrypted & "'.")

    End Sub

End Module
