Public Class AddFraction

    Protected numerators() As Integer
    Protected denominators() As Integer
    Protected new_numerators() As Integer

    Protected lcm As Integer
    Protected answer As Integer

    ' Simulate a constructor
    Public Sub _init_(fractions As Dictionary(Of String, Integer()))
        numerators = fractions.Item("numerators")
        denominators = fractions.Item("denominators")
        ReDim new_numerators(numerators.Count - 1)
        answer = 0
    End Sub

    ' transforms fractions so they all have same denominator
    ' takes a dictionary Of a list Of numerators And denominators
    '
    ' returns a dictionary Of the New numerators And New denominator(LCM)
    Protected Sub canonizeFraction()
        ' STEP 1:
        Dim l_c_m As New LCM
        l_c_m._init_(denominators)
        lcm = l_c_m.getLCM()

        ' STEP 2:
        ' make numerators vary(ratio) With lcm
        For index = 0 To denominators.Count - 1
            new_numerators(index) = lcm / denominators(index) * numerators(index)
        Next index

    End Sub

    ' returns a dictionary Of the
    ' New numerator And New denominator(LCM)
    Public Function doAdd() As Dictionary(Of String, Integer)
        canonizeFraction()

        ' STEP 3:
        ' add all transformed numerators
        For Each num In new_numerators
            answer += num
        Next

        Dim send_back As New Dictionary(Of String, Integer)
        send_back.Add("numerator", answer)
        send_back.Add("denominator", LCM)
        Return send_back

    End Function

End Class
