Friend Module WorldInitializer
    Const MazeColumns = 7
    Const MazeRows = 7
    Const MaximumSanity = 99
    Private ReadOnly directions As IReadOnlyDictionary(Of String, MazeDirection(Of String)) =
        Direction.All.ToDictionary(
            Function(x) x,
            Function(x) Direction.ToMazeDirection(x))
    Friend Sub Initialize(world As IWorld)
        Dim maze As New Maze(Of String)(MazeColumns, MazeRows, directions)
        maze.Generate()
        For Each column In Enumerable.Range(0, MazeColumns)
            For Each row In Enumerable.Range(0, MazeRows)
                world.CreateLocation(column, row)
            Next
        Next
        For Each location In world.Locations
            Dim mazeCell = maze.GetCell(location.Column, location.Row)
            For Each direction In mazeCell.Directions
                If mazeCell.GetDoor(direction).Open Then
                    Dim nextColumn = location.Column + directions(direction).DeltaX
                    Dim nextRow = location.Row + directions(direction).DeltaY
                    Dim nextLocation = world.Locations.Single(Function(x) x.Column = nextColumn AndAlso x.Row = nextRow)
                    location.SetNeighbor(direction, nextLocation)
                    location.SetDoor(direction, Door.Open)
                End If
            Next
        Next
        Dim character = world.CreateCharacter(
                RNG.FromEnumerable(world.Locations),
                RNG.FromEnumerable(Direction.All),
                MaximumSanity)
        world.SetAvatar(
            character)
        For Each trauma In Traumas.All
            Dim location = RNG.FromEnumerable(world.Locations.Where(Function(x) Not x.HasCharacter AndAlso Not x.HasTrauma))
            location.Trauma = trauma
            character.SetTriggerLevel(trauma, RNG.RollDice("4d6"))
            character.SetAwarenessLevel(trauma, 0)
            character.SetEscalation(trauma, 0)
        Next
        For Each location In world.Locations.Where(Function(x) Not x.HasCharacter AndAlso Not x.HasTrauma)
            location.Trauma = RNG.FromEnumerable(Traumas.All)
        Next
    End Sub
End Module
