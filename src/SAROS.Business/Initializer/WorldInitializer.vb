Friend Module WorldInitializer
    Const MazeColumns = 7
    Const MazeRows = 7
    Private ReadOnly directions As IReadOnlyDictionary(Of String, MazeDirection(Of String)) =
        New Dictionary(Of String, MazeDirection(Of String)) From
        {
            {Direction.North, New MazeDirection(Of String)(Direction.South, 0, -1)},
            {Direction.East, New MazeDirection(Of String)(Direction.West, 1, 0)},
            {Direction.South, New MazeDirection(Of String)(Direction.North, 0, 1)},
            {Direction.West, New MazeDirection(Of String)(Direction.East, -1, 0)}
        }
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
        world.SetAvatar(world.CreateCharacter(world.Locations.First, Direction.North))
    End Sub
End Module
