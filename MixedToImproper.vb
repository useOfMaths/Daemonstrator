Public Class MixedToImproper

    Dim whole_number As Integer
    Dim numerator As Integer
    Dim denominator As Integer

    ' A constructor
    Public Sub _init_(fraction As Dictionary(Of String, Integer))
        whole_number = fraction.Item("whole_number")
        numerator = fraction.Item("numerator")
        denominator = fraction.Item("denominator")
    End Sub


    ' Returns a scalar Of the New numerator
    Public Function doConvert() As Integer
        ' STEPS 1, 2:
        Return whole_number * denominator + numerator
    End Function

End Class
