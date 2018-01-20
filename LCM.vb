Public Class LCM

    Dim set_of_numbers As New List(Of Integer) ' will hold the the values to be sent in
    Dim all_factors As New List(Of Integer) ' for housing all common factors
    Dim state_check As Boolean
    Dim calc_result As Integer
    Dim index As Integer

    ' A constructor
    Public Sub _init_(group)
        For Each member In group
            set_of_numbers.Add(member)
        Next
        ' Sort array in descending order
        set_of_numbers.Sort()
        set_of_numbers.Reverse()

        index = 1
        state_check = False
        calc_result = 1
    End Sub

    Private Function findLCMFactors() As List(Of Integer)
        '  Copy 'set_of_numbers' into 'arg_copy'
        Dim arg_copy As New List(Of Integer)
        For Each number In set_of_numbers
            arg_copy.Add(number)
        Next
        ' STEP 1:
        ' sort in descending order
        arg_copy.Sort()
        arg_copy.Reverse()

        Do While index <= arg_copy.Item(0)
            state_check = False
            For count_off = 0 To set_of_numbers.Count - 1
                If set_of_numbers.Item(count_off) Mod index = 0 Then
                    ' STEP 3:
                    set_of_numbers.Item(count_off) /= index
                    If state_check = False Then
                        all_factors.Add(index)
                    End If

                    state_check = True ' do Not store the factor twice
                End If
            Next count_off

            ' STEP 4:
            If state_check Then
                Return findLCMFactors()
            End If

            index += 1
        Loop

        Return Nothing
    End Function


    ' Returns an array reference Of the desired Set Of even numbers
    Public Function getLCM() As Integer
        ' STEP 2:
        index = 2
        findLCMFactors()

        ' iterate through And retrieve members
        For Each factor In all_factors
            calc_result *= factor
        Next factor

        Return calc_result
    End Function

End Class
