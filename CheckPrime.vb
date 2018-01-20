Public Class CheckPrime

    Dim prime_suspect As Integer
    Dim a_factor As Integer

    ' Simulate a constructor
    Public Sub _init_(suspect As Integer)
        prime_suspect = suspect
    End Sub

    ' returns True If $prime_suspect Is a prime False otherwise.
    Public Function verifyPrime() As Boolean
        ' prime_suspect Is a prime number until proven otherwise
        ' Loop through searching For factors.
        For count = 2 To prime_suspect - 1
            If prime_suspect Mod count = 0 Then
                a_factor = count
                Return False
            End If
        Next count

        ' if no then factor is found:
        Return True
    End Function

    Public Property possible_factor() As Integer
        Get
            Return a_factor
        End Get
        Set(value As Integer)

        End Set
    End Property

End Class
