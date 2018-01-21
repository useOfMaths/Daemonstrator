Imports System.Numerics
Imports System.Globalization

Public Class SoleKeyEncryption

    Public Function encodeWord(msg As Char(), key As Char()) As String()
        ' encoding eqn { Tn = 3^n-1(2t1 + 1) - 1 } - please use your own eqn
        '                        2
        Dim encryption(msg.Length - 1) As String
        Dim n As Integer
        Dim t1 As Integer
        Dim Tn As BigInteger
        For i As Integer = 0 To msg.Length - 1
            ' get unicode of this character as t1
            t1 = AscW(msg(i))
            ' get next key digit as n
            n = Convert.ToInt32(key(i Mod (key.Length - 1)).ToString(), 16)
            ' use recurrence series equation to encrypt & save in base 16
            Tn = BigInteger.Divide(BigInteger.Subtract(BigInteger.Multiply(BigInteger.Pow(3, n - 1), 2 * t1 + 1), 1), 2)
            encryption(i) = Tn.ToString("X")
        Next i

        Return encryption
    End Function


    Public Function decodeWord(code As String(), key As Char()) As String
        ' decoding eqn { t1 = 3^1-n(2Tn + 1) - 1 }
        '                        2
        Dim decryption As String = ""
        Dim n As Integer
        Dim t1 As BigInteger
        Dim Tn As BigInteger
        For i As Integer = 0 To code.Length - 1
            Tn = BigInteger.Parse(code(i), NumberStyles.HexNumber)
            ' get next key digit as n
            n = Convert.ToInt32(key(i Mod (key.Length - 1)).ToString(), 16)
            ' use recurrence series equation to decrypt
            t1 = BigInteger.Divide(BigInteger.Subtract(BigInteger.Divide(2 * Tn + 1, BigInteger.Pow(3, n - 1)), 1), 2)
            decryption &= ChrW(t1)
        Next i

        Return decryption
    End Function


End Class
