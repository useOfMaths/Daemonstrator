Public Class PrimeNumbers

    Dim first As Integer
    Dim last As Integer
    Dim progress As Integer
    Dim list_of_primes As New List(Of Integer)(New Integer() {2, 3, 5, 7})
    Dim index As Integer
    Dim square_root As Integer
    Dim do_next_iteration As Boolean
    Dim result As New List(Of Integer)

    ' Simulate a constructor
    Public Sub _init_(alpha As Integer, omega As Integer)
        first = alpha
        last = omega
        ' STEP 1:
        progress = 9

        square_root = 0
    End Sub

    ' Returns a list Of the desired Set Of prime numbers
    Public Function getPrimes() As List(Of Integer)

        ' STEP 2:
        For progress = progress To last Step 2

            do_next_iteration = False ' a flag

            ' STEPS 3, 4:
            ' Check through already accumulated prime numbers
            ' to see if any Is a factor of "progress".
            square_root = Val(Math.Ceiling(Math.Sqrt(progress)))

            index = 0
            Do While list_of_primes.Item(index) <= square_root
                If progress Mod list_of_primes.Item(index) = 0 Then
                    do_next_iteration = True
                    Exit Do
                End If

                index += 1
            Loop

            If do_next_iteration = True Then
                Continue For
            End If

            ' if all checks are scaled,then "progress" Is our guy.
            list_of_primes.Add(progress)

        Next progress

        Return list_of_primes

    End Function

End Class
