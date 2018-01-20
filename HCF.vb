Public Class HCF

    Dim set_of_numbers As New List(Of Integer) ' will hold the the values to be sent in
    Dim common_factors As New List(Of Integer) ' for housing all common factors
    Dim all_round_factor As Boolean
    Dim calc_result As Integer
    Dim index As Integer

    ' A constructor
    Public Sub _init_(group As List(Of Integer))
        ' make copy Of argument
        For Each value In group
            set_of_numbers.Add(value)
        Next
        ' STEP 1:
        set_of_numbers.Sort() ' sort ascending

        all_round_factor = False ' boolean state flag
        calc_result = 1
    End Sub

    ' does the grunt work
    ' takes no arguments but requires 'set_of_numbers' to be set
    Private Function findHCFFactors() As List(Of Integer)
        ' use the smallest in the set for the range
        Do While index < set_of_numbers.Item(0)
            index += 1
            ' Check for factors common to every member of 'set_of_numbers'
            all_round_factor = True
            ' STEP 2:
            For count = 0 To set_of_numbers.Count - 1
                If all_round_factor And set_of_numbers.Item(count) Mod index <> 0 Then
                    all_round_factor = False
                End If
            Next count

            ' STEP 3:
            ' Divide every member Of 'set_of_numbers by each common factor
            If all_round_factor Then
                For count_off = 0 To set_of_numbers.Count - 1
                    set_of_numbers.Item(count_off) /= index
                Next count_off

                common_factors.Add(index)
                ' STEP 4:
                Return findHCFFactors()
            End If

        Loop
        Return Nothing

    End Function

    ' Returns a scalar value Of the HCF
    Public Function getHCF() As Integer
        index = 1
        findHCFFactors()

        'iterate through And retrieve members
        For Each factor In common_factors
            calc_result *= factor
        Next
        Return calc_result
    End Function

End Class
