Public Class SortFraction
    Inherits AddFraction

    Dim final_numerators() As Integer
    Dim final_denominators() As Integer
    Dim copy_numerators() As Integer
    Dim send_back As New Dictionary(Of String, Integer())

    Private Sub takeOff()
        ReDim final_numerators(numerators.Count - 1)
        ReDim final_denominators(denominators.Count - 1)
        ReDim copy_numerators(numerators.Count - 1)

        ' STEPS 1, 2:
        canonizeFraction()

        For index = 0 To new_numerators.Count - 1
            copy_numerators(index) = new_numerators(index)
        Next
    End Sub


    Private Sub Land()
        ' map sorted (transformed) fractions To the original ones
        Dim position As Integer
        For index = 0 To copy_numerators.Count - 1
            ' get index using list value
            position = Array.IndexOf(new_numerators, copy_numerators(index))
            final_numerators(index) = numerators(position)
            final_denominators(index) = denominators(position)
        Next index

        send_back.Add("numerators", final_numerators)
        send_back.Add("denominators", final_denominators)
    End Sub


    ' Returns a dictionary Of the New fraction
    Public Function sortAscending() As Dictionary(Of String, Integer())
        takeOff()

        ' STEP 3:
        ' sort ascending
        Array.Sort(copy_numerators)

        Land()
        Return send_back
    End Function


    ' Returns a dictionary Of the New fraction
    Public Function sortDescending() As Dictionary(Of String, Integer())
        takeOff()

        ' STEP 3:
        ' sort descending
        Array.Sort(copy_numerators)
        Array.Reverse(copy_numerators)

        Land()
        Return send_back
    End Function

End Class
