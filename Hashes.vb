Imports System.Numerics
Imports System.Globalization

Public Class Hashes

    Public Function hashWord(msg As Char()) As String
        ' encoding eqn { Tn = (n-2)t1 + 2^n } - please use your own eqn
        Dim hash = ""
        Dim big_hash As BigInteger = 0
        Dim n As Integer
        Dim t1 As Integer
        Dim x As BigInteger
        For i As Integer = 0 To msg.Length - 1
            ' get unicode of this character as n
            n = AscW(msg(i))
            t1 = i + 1
            ' use recurrence series equation to hash
            x = BigInteger.Add(BigInteger.Multiply(n - 2, t1), BigInteger.Pow(2, n))
            If i = 0 Then
                hash = x.ToString()
                big_hash = x
                Continue For
            End If

            ' convert number from base 10 to base 2
            Dim binary = ""
            Dim remainder As BigInteger = 0
            Do
                big_hash = BigInteger.DivRem(big_hash, 2, remainder)
                binary = remainder.ToString() + binary
            Loop While big_hash.Equals(BigInteger.Zero) = False

            ' bitwise rotate left with the modulo of x
            x = BigInteger.Remainder(x, binary.Length)

            Dim slice_1 = binary.Substring(x).ToCharArray()
            ' keep as '1' to preserve hash size
            slice_1(0) = "1"

            Dim slice_2 As String = binary.Substring(0, x)

            hash = String.Join("", slice_1) + slice_2

            ' convert number from base 2 to base 10
            big_hash = 0 ' Not necessary; just stating the obvious
            Dim j = 0
            Do While j < hash.Length
                big_hash = BigInteger.Add(BigInteger.Multiply(Integer.Parse(hash(j).ToString()), BigInteger.Pow(2, hash.Length - 1 - j)), big_hash)
                j += 1
            Loop
        Next i
        hash = big_hash.ToString("X")
        hash = hash.ToUpper()

        Return hash
    End Function

End Class
