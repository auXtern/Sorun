Imports System.IO
Imports System.Reflection

'Auxtern Projects 2021
Module Program

    Public app_location = AppDomain.CurrentDomain.BaseDirectory
    Public app_version = Assembly.GetExecutingAssembly().GetName().Version
    Public app_data = Path.Combine(app_location, "data")

    Sub Main(args As String())

        If Not Directory.Exists(app_data) Then
            Directory.CreateDirectory(app_data)
        End If

        If (args.Length >= 1) Then

            'open location program
            If (args(0).ToString().ToLower() = ":l" Or args(0).ToString().ToLower() = ":location") Then
                Process.Start("cmd", "/c explorer " & app_location)
                End

                'open location data
            ElseIf (args(0).ToString().ToLower() = ":d" Or args(0).ToString().ToLower() = ":data") Then
                Process.Start("cmd", "/c explorer " & app_data)
                End

                'get version program
            ElseIf (args(0).ToString().ToLower() = ":v" Or args(0).ToString().ToLower() = ":version") Then
                Console.WriteLine(app_version)
                End

                'help
            ElseIf (args(0).ToString().ToLower() = ":h" Or args(0).ToString().ToLower() = ":help") Then
                Dim target_url = "https://github.com/auXtern/Sorun"
                Process.Start("cmd", "/c start " & target_url)
                End

            Else

                'other
                If (args.Length >= 2) Then

                    If (args(0).ToString().ToLower() = ":o" Or args(0).ToString().ToLower() = ":open") Then
                        Dim source_file As String = Path.Combine(app_data, args(1) & ".sorun")
                        If Not File.Exists(source_file) Then
                            Console.WriteLine(-1)
                            End
                        End If

                        Console.WriteLine("-d : target is directory")
                        Console.WriteLine("-f : target is file")
                        Console.WriteLine("-p : target is program")
                        Console.WriteLine("-u : target is url")
                        Console.WriteLine("")
                        For Each line As String In File.ReadLines(source_file)
                            'read data in file sorun
                            Dim line_info = line.Split("||")
                            If line_info.Length < 3 Then
                                Continue For
                            ElseIf Not line_info(0) = "-d" And Not line_info(0) = "-f" And Not line_info(0) = "-u" And Not line_info(0) = "-p" And Not line_info(0) = "-s" Then
                                Continue For
                            End If
                            Console.WriteLine(line)
                        Next line
                        End


                        'add file sorun to data
                    ElseIf (args(0).ToString().ToLower() = ":a" Or args(0).ToString().ToLower() = ":append") Then
                        Dim source_path As String
                        Dim target_path As String
                        Dim source_extension As String

                        Dim total_file = args.Length - 1
                        Console.WriteLine(total_file)
                        For i = 1 To total_file
                            source_path = args(i).ToString
                            If Not File.Exists(source_path) Then
                                Console.WriteLine(-1)
                                Continue For
                            End If

                            source_extension = Path.GetExtension(source_path)
                            If Not source_extension = ".sorun" Then
                                Console.WriteLine(-2)
                                Continue For
                            End If

                            target_path = Path.Combine(app_data, Path.GetFileName(source_path))
                            FileCopy(source_path, target_path)
                            If Not File.Exists(target_path) Then
                                Console.WriteLine(-3)
                                Continue For
                            End If

                            Console.WriteLine(1)
                        Next
                        End

                    Else
                        Dim source_file As String = Path.Combine(app_data, args(0) & ".sorun")
                        Dim initial As String = args(1).ToString().ToLower()

                        If Not File.Exists(source_file) Then
                            Console.WriteLine(-1)
                            End
                        End If

                        For Each line As String In File.ReadLines(source_file)
                            'read data in file sorun
                            Dim line_info = line.Split("||")
                            If line_info.Length < 3 Then
                                Continue For
                            ElseIf Not line_info(0) = "-d" And Not line_info(0) = "-f" And Not line_info(0) = "-u" And Not line_info(0) = "-p" And Not line_info(0) = "-s" Then
                                Continue For
                            End If

                            If Not line_info(1) = initial Then
                                Continue For
                            End If

                            If line_info(0) = "-d" Then
                                If Directory.Exists(line_info(2)) Then
                                    Process.Start("cmd", "/c explorer " & line_info(2))
                                    End
                                Else
                                    Console.WriteLine(-2)
                                    End
                                End If

                            ElseIf line_info(0) = "-f" Or line_info(0) = "-p" Then
                                Dim file_path = line_info(2)
                                If File.Exists(file_path.ToString.Replace(Chr(34), "")) Then
                                    Process.Start("cmd", "/c " & file_path)
                                    End
                                Else
                                    Console.WriteLine(-2)
                                    End
                                End If

                            ElseIf line_info(0) = "-s" Then
                                Dim file_path = line_info(2)
                                If File.Exists(file_path.ToString.Replace(Chr(34), "")) Then
                                    Process.Start("explorer", "/select, " & file_path)
                                    End
                                Else
                                    Console.WriteLine(-2)
                                    End
                                End If

                            ElseIf line_info(0) = "-u" Then
                                Dim target_url = line_info(2).ToString.Replace(Chr(34), "")
                                Process.Start("cmd", "/c start " & target_url)
                                End

                            End If

                        Next line
                        Console.WriteLine(-3)
                        End

                    End If

                End If

            End If

        End If



    End Sub
End Module
