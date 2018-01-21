Public Class Selection
    Public words As String()
    Public r As Integer ' min length Of word
    Protected complete_group
    Private i As Integer

    Public Function groupSelection(candidates As String(), size As Integer) As List(Of String())
        words = candidates
        r = size
        complete_group = New List(Of String())
        i = 0
        recursiveFillUp(New List(Of String))

        Return complete_group
    End Function

    ' pick elements recursively
    Protected Sub recursiveFillUp(temp As List(Of String))
        Dim picked_elements(words.Length) As List(Of String)
        Dim j As Integer = i
        Do While j < words.Length
            picked_elements(j) = New List(Of String)
            picked_elements(j).AddRange(temp)
            picked_elements(j).Add(words(j))
            ' recoil factor
            If i >= words.Length Then
                i = j
            End If
            ' satisfied yet?
            If picked_elements(j).Count = r Then
                complete_group.Add(picked_elements(j).ToArray())
            ElseIf picked_elements(j).Count < r Then
                recursiveFillUp(picked_elements(j))
            End If
            j += 1
        Loop
        j -= 1
        If picked_elements(j).Equals(Nothing) = False And picked_elements(j).Count = r Then
            i += 1 ' keep recoil factor straightened out
        End If
    End Sub

End Class
