Public Class ConditionalSelection
    Inherits Selection

    Private final_elements

    ' pick only those groups that meet occurrence conditions
    Public Function limitedSelection(candidates As String(), size As Integer, minimum As Integer(), maximum As Integer()) As List(Of String())
        final_elements = New List(Of String())
        groupSelection(candidates, size)
        For i As Integer = 0 To complete_group.Count - 1
            Dim state As Boolean = False
            For j As Integer = 0 To words.Length - 1
                ' get 'word(j)' frequency/count in group
                Dim count As Integer = -1
                Dim k As Integer = -1
                Do
                    k += 1
                    count += 1
                    k = Array.IndexOf(complete_group(i), words(j), k)
                Loop While k > -1
                ' Productive boundary check
                If count >= minimum(j) And count <= maximum(j) Then
                    state = True
                Else
                    state = False
                    Exit For
                End If
            Next j
            ' skip if already in net
            If state Then
                final_elements.Add(complete_group(i))
            End If
        Next i
        Return final_elements
    End Function

End Class
