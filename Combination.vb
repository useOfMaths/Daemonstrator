Public Class Combination
    Public words As New List(Of String)
    Public r As Integer ' min length Of word
    Protected comb_store
    Private i As Integer

    ' point of entry
    Public Function possibleWordCombinations(candidates As List(Of String), size As Integer) As List(Of String())
        words = candidates
        r = size
        comb_store = New List(Of String())
        i = 0
        ' check for conformity
        If r <= 0 Or r > words.Count Then
            comb_store = New List(Of String())
        ElseIf r = 1 Then
            For i = 0 To words.Count - 1
                comb_store.Add(New String() {words(i)})
            Next i
        Else
            progressiveCombination()
        End If
        Return comb_store
    End Function


    ' do combinations for all 'words' element
    Private Sub progressiveCombination()
        '                   single member list
        repetitivePairing(New List(Of String)({words(i)}), i + 1)
        If i + r <= words.Count Then
            ' move on to next degree
            i += 1
            progressiveCombination()
        End If
    End Sub

    ' do all possible combinations for 1st element of this array
    Private Sub repetitivePairing(prefix As List(Of String), position As Integer)
        Dim auxiliary_store(words.Count - position) As List(Of String)
        For j As Integer = 0 To words.Count - position - 1
            ' check if desired -- r -- size will be realised
            If j + i + r <= words.Count Then
                auxiliary_store(j) = New List(Of String)
                auxiliary_store(j).AddRange(prefix)
                auxiliary_store(j).Add(words(position))
                If auxiliary_store(j).Count < r Then
                    ' see to adding next word on
                    repetitivePairing(auxiliary_store(j), position + 1)
                Else
                    comb_store.Add(auxiliary_store(j).ToArray())
                End If
            End If
            position += 1
        Next j
    End Sub

End Class
