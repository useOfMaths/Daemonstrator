Public Class ImproperToMixed

    Dim whole_number As Integer
    Dim numerator As Integer
    Dim denominator As Integer
    Dim new_numerator As Integer

    ' A constructor
    Public Sub _init_(fraction As Dictionary(Of String, Integer))
        numerator = fraction.Item("numerator")
        denominator = fraction.Item("denominator")
    End Sub

    ' Returns a dictionary Of the New fraction
    Public Function doConvert() As Dictionary(Of String, Integer)
        ' STEP 1:
        For dividend = numerator To 0 Step -1
            If dividend Mod denominator = 0 Then
                ' STEP 2:
                new_numerator = numerator - dividend
                ' STEP 3:
                whole_number = Int(dividend / denominator)
                Exit For
            End If
        Next dividend

        Dim send_back As New Dictionary(Of String, Integer)
        send_back.Add("whole_number", whole_number)
        send_back.Add("numerator", new_numerator)
        send_back.Add("denominator", denominator)
        Return send_back
    End Function

End Class
