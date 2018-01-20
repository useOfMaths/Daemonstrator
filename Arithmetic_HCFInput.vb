Imports System.Text.RegularExpressions

Module Arithmetic_HCF_input
    Sub Main()

        ' Collect input
        Console.WriteLine("Welcome to our Find HCF program.")
        Console.WriteLine("Enter your series of numbers whose HCF you wish to find.")
        Console.WriteLine("Type 'done' when you are through with entering your numbers.")

        Dim group As New List(Of Integer)
        Dim collect_input_text = "Enter First Number:  "
        Dim user_input As String
        Dim user_num As Integer

        Try
            Do
                ' Get keyboard input
                Console.Write(collect_input_text)
                user_input = Console.ReadLine()
                ' Make sure input is a number
                Dim check As New Regex("^[0-9]+$")
                Dim mate As Match = check.Match(user_input)
                If mate.Success Then
                    user_num = Val(user_input)
                    If user_num <> 0 Then
                        group.Add(user_num)
                        collect_input_text = "Enter Next Number:  "
                    Else
                        Console.WriteLine("You cannot enter zero. Repeat that!Type 'done' when you're finished.")
                    End If

                Else
                    ' Convert 'user_input' to upper case.
                    user_input = user_input.ToUpper
                    If user_input <> "DONE" Then
                        Console.WriteLine("Wrong Input. Repeat that!Type 'done' when you're finished.")
                    End If
                End If
            Loop While user_input <> "DONE"
        Catch
            Console.WriteLine("Sorry, but something must have gone wrong!")
        End Try

        ' Use the fast HCF Class
        Dim h_c_f As New FastHCF
        h_c_f._init_(group)
        Dim answer = h_c_f.getHCF()

        Console.Write("The H.C.F. of " & String.Join(", ", group) & " is " & answer)

    End Sub

End Module
