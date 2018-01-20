Public Class ListFactors

    Dim find_my_factors As Integer
    Dim found_factors As New List(Of Integer)
    Dim sqrt_range As Integer

    ' Simulate a constructor
    Public Sub _init_(candidate As Integer)
        find_my_factors = candidate
        found_factors.Add(1)
        found_factors.Add(find_my_factors) ' 1 and itself are automatic factors
        sqrt_range = Math.Ceiling(Math.Sqrt(find_my_factors))
    End Sub

    ' Returns an array reference Of the desired factors
    Public Function findFactors() As List(Of Integer)
        ' Loop through 1 To 'find_my_factors' and test for divisibility.
        For count = 2 To sqrt_range
            If find_my_factors Mod count = 0 Then
                found_factors.Add(count)
                ' Get the complementing factor by dividing 'find_my_factor' by variable count.
                found_factors.Add(find_my_factors / count)
            End If
        Next count

        ' Sort the array in ascending order Not entirely necessary.
        found_factors.Sort()

        Return found_factors

    End Function

End Class
