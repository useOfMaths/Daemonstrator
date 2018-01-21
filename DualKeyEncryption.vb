Imports System.Numerics
Imports System.Globalization

Public Class DualKeyEncryption
    ''
    ' STEP VI:
    ''
    Public Function encodeWord(msg As Char(), key As BigInteger, semi_prime As BigInteger) As String()
        Dim encryption(msg.Length - 1) As String
        Dim x As Integer
        For i As Integer = 0 To msg.Length - 1
            ' get unicode of this character as x
            x = AscW(msg(i))
            ' use RSA to encrypt & save in base 16
            encryption(i) = BigInteger.ModPow(x, key, semi_prime).ToString("X")
        Next i

        Return encryption
    End Function

    ''
    ' STEP VII:
    ''
    Public Function decodeWord(code As String(), key As BigInteger, semi_prime As BigInteger) As String
        Dim decryption As String = ""
        Dim c As BigInteger
        For i As Integer = 0 To code.Length - 1
            ' use RSA to decrypt
            c = BigInteger.ModPow(BigInteger.Parse(code(i), NumberStyles.HexNumber), key, semi_prime)
            decryption &= ChrW(c)
        Next i

        Return decryption
    End Function

End Class
