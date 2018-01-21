Public Class LowestTerm

    Dim numerator As Integer
    Dim denominator As Integer
    Dim trial_factor As Integer

    ' A constructor
    Public Sub _init_(fraction As Dictionary(Of String, Integer))
        numerator = fraction.Item("numerator")
        denominator = fraction.Item("denominator")

        ' Set trial_factor To the smaller value between numerator And denominator
        If numerator < denominator Then
            trial_factor = numerator
        Else
            trial_factor = denominator
        End If
    End Sub

    ' Returns a dictionary Of the New numerator And denominator
    Public Function reduceFraction() As Dictionary(Of String, Integer)
        ' We are counting down To test For mutual factors 
        Do While trial_factor > 1
            ' Do we have a factor
            If numerator Mod trial_factor = 0 Then
                ' Is this factor mutual?
                If denominator Mod trial_factor = 0 Then
                    ' where we have a mutual factor
                    numerator /= trial_factor
                    denominator /= trial_factor
                    Continue Do
                End If
            End If

            trial_factor -= 1
        Loop

        Dim send_back As New Dictionary(Of String, Integer)
        send_back.Add("numerator", numerator)
        send_back.Add("denominator", denominator)
        Return send_back

    End Function

End Class
