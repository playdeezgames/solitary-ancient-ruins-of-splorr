Friend Module WorldInitializer
    Const MazeColumns = 7
    Const MazeRows = 7
    Private ReadOnly directions As IReadOnlyDictionary(Of Direction, MazeDirection(Of Direction)) =
        New Dictionary(Of Direction, MazeDirection(Of Direction)) From
        {
            {Direction.North, New MazeDirection(Of Direction)(Direction.South, 0, -1)},
            {Direction.East, New MazeDirection(Of Direction)(Direction.West, 1, 0)},
            {Direction.South, New MazeDirection(Of Direction)(Direction.North, 0, 1)},
            {Direction.West, New MazeDirection(Of Direction)(Direction.East, -1, 0)}
        }
    Friend Sub Initialize(world As IWorld(Of Direction))
        Dim maze As New Maze(Of Direction)(MazeColumns, MazeRows, directions)
        maze.Generate()
        For Each column In Enumerable.Range(0, MazeColumns)
            For Each row In Enumerable.Range(0, MazeRows)
                world.CreateLocation(column, row)
            Next
        Next
        For Each location In world.Locations
            Dim mazeCell = maze.GetCell(location.Column, location.Row)
            For Each direction In mazeCell.Directions
                Dim nextColumn = location.Column + directions(direction).DeltaX
                Dim nextRow = location.Row + directions(direction).DeltaY
                Dim nextLocation = world.Locations.Single(Function(x) x.Column = nextColumn AndAlso x.Row = nextRow)
                location.SetNeighbor(direction, nextLocation)
            Next
        Next
        'TODO: create PC
    End Sub
End Module
