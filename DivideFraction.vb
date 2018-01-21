Public Class DivideFraction
    Inherits MultiplyFraction

    ' Returns a dictionary Of the New fraction
    Public Function doDivide() As Dictionary(Of String, Integer)
        ' Invert every other fraction but the first
        For index = 1 To numerators.Count - 1
            Dim temp = numerators(index)
            numerators(index) = denominators(index)
            denominators(index) = temp
        Next index

        Return doMultiply()
            End Function

End Class
