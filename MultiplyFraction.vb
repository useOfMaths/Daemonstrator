Public Class MultiplyFraction

    Protected numerators() As Integer
    Protected denominators() As Integer
    Protected trial_factor As Integer
    Protected n_index As Integer
    Protected d_index As Integer
    Protected answer(2) As Integer
    Protected mutual_factor As Boolean

    ' Simulate a constructor
    Public Sub _init_(fractions As Dictionary(Of String, Integer()))
        numerators = fractions.Item("numerators")
        denominators = fractions.Item("denominators")

        trial_factor = 0
        n_index = 0
        d_index = 0
        answer = {1, 1}

        ' Set trial_factor To the highest value amongst
        'both numerators And denominators
        For Each numerator In numerators
            If numerator > trial_factor Then
                trial_factor = numerator
            End If
        Next
        For Each denominator In denominators
            If denominator > trial_factor Then
                trial_factor = denominator
            End If
        Next
    End Sub

    ' Returns a dictionary Of the New numerator And denominator
    Public Function doMultiply() As Dictionary(Of String, Integer)
        ' STEP 3:
        ' We are counting down To test For mutual factors 
        Do While trial_factor > 1
            ' STEP 1:
            ' iterate through numerators And check For factors
            Do While n_index < numerators.Count
                mutual_factor = False
                If numerators(n_index) Mod trial_factor = 0 Then ' do we have a factor
                    ' iterate through denominators And check For factors
                    Do While d_index < denominators.Count
                        If denominators(d_index) Mod trial_factor = 0 Then  ' Is this factor mutual?
                            mutual_factor = True
                            Exit Do ' stop as soon as we find a mutual factor so preserve the corresponding index
                        End If
                        d_index += 1
                    Loop

                    Exit Do ' stop as soon as we find a mutual factor so as to preserve the corresponding index
                End If

                n_index += 1
            Loop

            ' STEP 2:
            ' where we have a mutual factor
            If mutual_factor Then
                numerators(n_index) /= trial_factor
                denominators(d_index) /= trial_factor
                Continue Do ' Continue With Next iteration repeating the current value Of trial_factor
            End If

            n_index = 0
            d_index = 0
            trial_factor -= 1
        Loop

        For Each numerator In numerators
            answer(0) *= numerator
        Next
        For Each denominator In denominators
            answer(1) *= denominator
        Next

        Dim send_back As New Dictionary(Of String, Integer)
        send_back.Add("numerator", answer(0))
        send_back.Add("denominator", answer(1))
        Return send_back

    End Function

End Class
