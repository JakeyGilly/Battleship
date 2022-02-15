Module Program
    Sub Main()
        Dim grid(8, 8) As Integer
        Dim ships() As String = {"#####", "####", "###", "##", "#"}
        Dim coords, direction As String
        Dim sucess As Integer
        For i = 0 To ships.Length - 1
            Do
                Console.Clear()
                If sucess = -1 Then
                    Console.WriteLine("Invalid Move")
                End If
                PrintGrid(grid)
                Console.WriteLine("Place this ship: " & ships(i))
                Console.Write("Enter Coordinates: ")
                coords = Console.ReadLine()
                If (Len(ships(i)) = 1) Then
                    direction = "DOWN"
                Else
                    Console.Write("Enter Direction (DOWN, UP, LEFT, RIGHT): ")
                    direction = Console.ReadLine()
                End If
                sucess = PlaceShip(ships(i), coords, direction, grid)
            Loop Until sucess = 0
        Next
        Console.Clear()
        PrintGrid(grid)
        Console.ReadLine()
    End Sub
    Function PlaceShip(ship As String, coords As String, direction As String, grid As Array)
        Dim Placed = False
        Select Case direction
            Case "DOWN"
                Dim x = Integer.Parse(coords.Split(",")(0)) - 1
                Dim y = Integer.Parse(coords.Split(",")(1)) - 1
                If ship.Length - 1 <= grid.GetLength(1) And ship.Length - 1 < grid.GetLength(1) - y Then
                    For i = 0 To ship.Length - 1
                        If grid(x, i + y) = 1 Then
                            Exit Select
                        End If
                    Next
                    For i = 0 To ship.Length - 1
                        grid(x, i + y) = 1
                    Next
                    Placed = True
                End If
            Case "UP"
                Dim x = Integer.Parse(coords.Split(",")(0)) - 1
                Dim y = Integer.Parse(coords.Split(",")(1)) - 1
                If ship.Length - 1 <= grid.GetLength(1) And y - ship.Length - 1 >= 0 Then
                    For i = ship.Length - 1 To 0 Step -1
                        If grid(x, y - i) = 1 Then
                            Exit Select
                        End If
                    Next
                    For i = ship.Length - 1 To 0 Step -1
                        grid(x, y - i) = 1
                    Next
                    Placed = True
                End If
            Case "LEFT"
                Dim x = Integer.Parse(coords.Split(",")(0)) - 1
                Dim y = Integer.Parse(coords.Split(",")(1)) - 1
                If ship.Length - 1 < grid.GetLength(0) And x - ship.Length - 1 >= 0 Then
                    For i = ship.Length - 1 To 0 Step -1
                        If grid(x - i, y) = 1 Then
                            Exit Select
                        End If
                    Next
                    For i = ship.Length - 1 To 0 Step -1
                        grid(x - i, y) = 1
                    Next
                    Placed = True
                End If
            Case "RIGHT"
                Dim x = Integer.Parse(coords.Split(",")(0)) - 1
                Dim y = Integer.Parse(coords.Split(",")(1)) - 1
                If ship.Length - 1 <= grid.GetLength(0) And ship.Length - 1 < grid.GetLength(0) - x Then
                    For i = 0 To ship.Length - 1
                        If grid(i + x, y) = 1 Then
                            Exit Select
                        End If
                    Next
                    For i = 0 To ship.Length - 1
                        grid(i + x, y) = 1
                    Next
                    Placed = True
                End If
        End Select
        If Placed Then
            Return 0
        Else
            Return -1
        End If
    End Function
    Function PrintGrid(grid)
        Console.Write(Space(3))
        For i = 0 To grid.GetLength(0) - 1
            Console.Write(i + 1 & Space(2))
        Next
        Console.WriteLine()
        For i = 0 To grid.GetLength(0) - 1
            Console.Write(i + 1 & Space(2))
            For j = 0 To grid.GetLength(1) - 1
                Console.Write(grid(j, i) & Space(2))
            Next
            Console.WriteLine()
        Next
        Return 0
    End Function
End Module
