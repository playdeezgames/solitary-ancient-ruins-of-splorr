Public Class WorldModel
    Implements IWorldModel
    Public Const BoardColumns = 5
    Public Const BoardRows = 5
    Public Const FilledCellMaximum = BoardColumns * BoardRows - 1
    Private ReadOnly board(BoardColumns, BoardRows) As BoardCell

    Private _world As IWorld
    Sub New()
        BoardRow = BoardRows \ 2
        For Each y In Enumerable.Range(0, BoardRows)
            For Each x In Enumerable.Range(0, BoardColumns)
                board(x, y) = New BoardCell
            Next
        Next
    End Sub

    Public ReadOnly Property RoomString As String Implements IWorldModel.RoomString
        Get
            Dim character = World.Avatar
            Dim location = character.Location
            Dim frame As Integer = 0
            If location.HasDoor(character.LeftDirection) Then
                frame += 1
            End If
            If location.HasDoor(character.AheadDirection) Then
                frame += 2
            End If
            If location.HasDoor(character.RightDirection) Then
                frame += 4
            End If
            Return ChrW(frame)
        End Get
    End Property

    Public ReadOnly Property Column As Integer Implements IWorldModel.Column
        Get
            Return World.Avatar.Location.Column
        End Get
    End Property

    Public ReadOnly Property Row As Integer Implements IWorldModel.Row
        Get
            Return World.Avatar.Location.Row
        End Get
    End Property

    Public ReadOnly Property Facing As String Implements IWorldModel.Facing
        Get
            Return World.Avatar.Facing
        End Get
    End Property

    Public ReadOnly Property Sanity As Integer Implements IWorldModel.Sanity
        Get
            Return World.Avatar.Sanity
        End Get
    End Property

    Public ReadOnly Property MaximumSanity As Integer Implements IWorldModel.MaximumSanity
        Get
            Return World.Avatar.MaximumSanity
        End Get
    End Property

    Public ReadOnly Property IsInsane As Boolean Implements IWorldModel.IsInsane
        Get
            Return World.Avatar.Sanity <= 0
        End Get
    End Property

    Public ReadOnly Property Trauma As String Implements IWorldModel.Trauma
        Get
            Return World.Avatar.Location.Trauma
        End Get
    End Property

    Public ReadOnly Property TriggerLevel As Integer Implements IWorldModel.TriggerLevel
        Get
            If String.IsNullOrEmpty(Trauma) Then
                Return 0
            End If
            Return World.Avatar.GetTriggerLevel(Trauma)
        End Get
    End Property

    Public Property BoardRow As Integer Implements IWorldModel.BoardRow

    Public Property BoardColumn As Integer Implements IWorldModel.BoardColumn

    Private Property World As IWorld
        Get
            Return _world
        End Get
        Set(value As IWorld)
            _world = value
        End Set
    End Property
    Public Sub Embark() Implements IWorldModel.Embark
        World = New World(New WorldData)
        WorldInitializer.Initialize(World)
    End Sub
    Public Sub Abandon() Implements IWorldModel.Abandon
        World = Nothing
    End Sub
    Public Sub Load(filename As String) Implements IWorldModel.Load
        World = New World(JsonSerializer.Deserialize(Of WorldData)(File.ReadAllText(filename)))
    End Sub
    Public Sub Save(filename As String) Implements IWorldModel.Save
        File.WriteAllText(filename, JsonSerializer.Serialize(World.Serialized))
    End Sub

    Public Sub TurnLeft() Implements IWorldModel.TurnLeft
        World.Avatar.Facing = World.Avatar.LeftDirection
    End Sub

    Public Sub TurnRight() Implements IWorldModel.TurnRight
        World.Avatar.Facing = World.Avatar.RightDirection
    End Sub

    Public Sub MoveAhead() Implements IWorldModel.MoveAhead
        Dim character = World.Avatar
        Dim location = character.Location
        Dim facing = character.AheadDirection
        If location.HasDoor(facing) Then
            Dim nextColumn = location.Column + Direction.GetDeltaX(facing)
            Dim nextRow = location.Row + Direction.GetDeltaY(facing)
            Dim nextLocation = World.Locations.Single(Function(l) l.Column = nextColumn AndAlso l.Row = nextRow)
            character.Location = nextLocation
        End If
    End Sub

    Public Sub BeginCombat(trauma As String) Implements IWorldModel.BeginCombat
        BoardRow = BoardRows \ 2
        BoardColumn = BoardColumns
        For Each y In Enumerable.Range(0, BoardRows)
            For Each x In Enumerable.Range(0, BoardColumns)
                board(x, y).Trigger = False
                board(x, y).Visible = False
            Next
        Next
        For Each dummy In Enumerable.Range(0, World.Avatar.GetAwarenessLevel(trauma))
            Dim x As Integer
            Dim y As Integer
            Do
                x = RNG.FromRange(0, BoardColumns - 1)
                y = RNG.FromRange(0, BoardRows - 1)
            Loop Until Not board(x, y).Visible
            board(x, y).Visible = True
        Next
        For Each dummy In Enumerable.Range(0, Math.Min(World.Avatar.GetTriggerLevel(trauma), FilledCellMaximum))
                Dim x As Integer
                Dim y As Integer
                Do
                    x = RNG.FromRange(0, BoardColumns - 1)
                    y = RNG.FromRange(0, BoardRows - 1)
                Loop Until Not board(x, y).Trigger
                board(x, y).Trigger = True
            Next
    End Sub

    Public Sub PreviousBoardRow() Implements IWorldModel.PreviousBoardRow
        BoardRow = (BoardRow + BoardRows - 1) Mod BoardRows
    End Sub

    Public Sub NextBoardRow() Implements IWorldModel.NextBoardRow
        BoardRow = (BoardRow + 1) Mod BoardRows
    End Sub

    Public Sub EnemyMove() Implements IWorldModel.EnemyMove
        BoardColumn = RNG.FromRange(0, BoardColumns - 1)
    End Sub

    Private ReadOnly Property EnemyCombatDamage As Integer
        Get
            Return Enumerable.Range(0, BoardRows).Where(Function(r) board(BoardColumn, r).Trigger).Count
        End Get
    End Property

    Private ReadOnly Property PlayerCombatDamage As Integer
        Get
            Return Enumerable.Range(0, BoardColumns).Where(Function(c) board(c, BoardRow).Trigger).Count
        End Get
    End Property

    Public Sub CompleteCombat() Implements IWorldModel.CompleteCombat
        If Not IsBoardCellVisible(BoardColumn, BoardRow) Then
            World.Avatar.SetAwarenessLevel(Trauma, World.Avatar.GetAwarenessLevel(Trauma) + 1)
        End If
        If IsBoardCellTrigger(BoardColumn, BoardRow) Then
            World.Avatar.Sanity -= EnemyCombatDamage
        Else
            World.Avatar.SetTriggerLevel(Trauma, TriggerLevel - PlayerCombatDamage)
        End If
    End Sub

    Public Function IsBoardCellTrigger(column As Integer, row As Integer) As Boolean Implements IWorldModel.IsBoardCellTrigger
        Return board(column, row).Trigger
    End Function

    Public Function IsBoardCellVisible(column As Integer, row As Integer) As Boolean Implements IWorldModel.IsBoardCellVisible
        Return board(column, row).Visible
    End Function
End Class
