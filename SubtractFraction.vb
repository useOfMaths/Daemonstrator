Public Class SubtractFraction
    Inherits AddFraction

    ' Returns a dictionary Of the New fraction
    Public Function doSubtract() As Dictionary(Of String, Integer)
        ' STEPS 1, 2:
        canonizeFraction()

        ' STEP 3:
        ' subtract all transformed numerators
        answer = new_numerators(0)
        For count_off = 1 To new_numerators.Count - 1
            answer -= new_numerators(count_off)
        Next count_off

        Dim send_back As New Dictionary(Of String, Integer)
        send_back.Add("numerator", answer)
        send_back.Add("denominator", lcm)
        Return send_back

    End Function

End Class
