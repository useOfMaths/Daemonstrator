Public Class Permutation
    Inherits Combination

    Private local_store
    Protected perm_store
    Private index As Integer

    ' till the ground for shuffle to grind on
    Public Function possibleWordPermutations(candidates As List(Of String), size As Integer) As List(Of String())
        perm_store = New List(Of String())
        possibleWordCombinations(candidates, size)
        ' illegal 'r' value
        If comb_store.Count = 0 Or r = 1 Then
            perm_store = comb_store
        Else
            Dim last_two
            last_two = New List(Of String())({New String() {"", ""}, New String() {"", ""}})
            For i As Integer = 0 To comb_store.Count - 1
                index = r - 1
                ' copy up last two elements of 'comb_store(i)'
                last_two(0)(0) = comb_store(i)(index)
                last_two(1)(1) = last_two(0)(0)
                index -= 1
                last_two(0)(1) = comb_store(i)(index)
                last_two(1)(0) = last_two(0)(1)
                index -= 1

                local_store = New List(Of String())
                local_store.Add(last_two(0))
                local_store.Add(last_two(1))
                If r > 2 Then
                    shuffleWord(local_store, i)
                End If
                perm_store.AddRange(local_store)
            Next i
        End If
        Return perm_store
    End Function

    Private Sub shuffleWord(arg_store As List(Of String()), i As Integer)
        local_store = New List(Of String())
        Dim members
        For j As Integer = 0 To arg_store.Count - 1
            members = New List(Of String)
            members.AddRange(arg_store(j))
            ' add 'index' 'comb_store(i)' element to this list of members
            members.Add(comb_store(i)(index))

            Dim temp_char As String
            Dim shift_index As Integer = members.Count
            ' shuffle this pack of words
            Do While shift_index > 0
                ' skip if already in store
                If local_store.Contains(members.ToArray()) = False Then
                    local_store.Add(members.ToArray())
                End If
                ' interchange these two neighbours
                shift_index -= 1
                If shift_index > 0 Then
                    temp_char = members(shift_index)
                    members(shift_index) = members(shift_index - 1)
                    members(shift_index - 1) = temp_char
                End If
            Loop
        Next j
        ' Are there any elements left? repeat if yes
        If index > 0 Then
            index -= 1
            shuffleWord(local_store, i)
        End If
    End Sub

End Class
