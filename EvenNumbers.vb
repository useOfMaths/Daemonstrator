Public Class EvenNumbers

    Dim first As Integer
    Dim last As Integer
    Dim result As New List(Of Integer)

    ' Simulate a constructor
    Public Sub _init_(alpha As Integer, omega As Integer)
        first = alpha
        last = omega
    End Sub

    ' Returns an list Of the desired Set Of even numbers
    Public Function prepResult() As List(Of Integer)
        ' Loop from start to stop and rip out even numbers;

        Dim i = 0
        For i = first To last
            If i Mod 2 = 0 Then ' modulo(%) is explained later
                result.Add(i)
            End If
        Next i

        Return result
    End Function

End Class
