Public Class FastHCF

    Dim set_of_numbers As New List(Of Integer) ' will hold the the values to be sent in
    Dim arg_copy As New List(Of Integer)
    Dim common_factors As New List(Of Integer) ' for housing all common factors
    Dim minimal_prime_factors As New List(Of Integer)
    Dim all_round_factor As Boolean
    Dim calc_result As Integer
    Dim index As Integer


    ' Simulate a constructor
    Public Sub _init_(group)
        For Each value In group
            set_of_numbers.Add(value)
            arg_copy.Add(value)
        Next
        ' STEP 1:
        set_of_numbers.Sort()
        arg_copy.Sort()

        index = 2
        all_round_factor = False ' state flag
        calc_result = 1
    End Sub

    ' STEP 2:
    ' does the grunt work
    ' takes no arguments but requires 'set_of_numbers' to be set
    Private Function findHCFFactors() As List(Of Integer)
        Do While index < minimal_prime_factors.Count
            all_round_factor = True
            ' STEP 3:
            For count = 0 To set_of_numbers.Count - 1
                If all_round_factor And arg_copy.Item(count) Mod minimal_prime_factors.Item(index) <> 0 Then
                    all_round_factor = False
                End If
            Next count

            ' STEP 4:
            If all_round_factor Then
                For count_off = 0 To set_of_numbers.Count - 1
                    arg_copy.Item(count_off) /= minimal_prime_factors.Item(index)
                Next count_off

                common_factors.Add(minimal_prime_factors.Item(index))
            End If

            index += 1

        Loop
        Return Nothing

    End Function


    ' Returns a scalar value Of the HCF
    Public Function getHCF() As Integer

        ' use only direct factors Of the smallest member
        Dim aux As New listPrimeFactors
        aux._init_(set_of_numbers.Item(0))
        minimal_prime_factors = aux.onlyPrimeFactors()


        ' go ahead And see which of the above factors are mutual
        index = 0
        findHCFFactors()

        'iterate through And retrieve members
        For Each factor In common_factors
            calc_result *= factor
        Next

        Return calc_result

    End Function


End Class
