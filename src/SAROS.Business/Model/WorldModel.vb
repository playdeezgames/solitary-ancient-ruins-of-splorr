﻿Public Class WorldModel
    Implements IWorldModel
    Public Const BoardColumns = 5
    Public Const BoardRows = 5
    Public Const FilledCellMaximum = BoardColumns * BoardRows - 1
    Private ReadOnly board(BoardColumns, BoardRows) As Boolean

    Private _world As IWorld

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
            character.Sanity -= 1
        End If
    End Sub

    Public Sub CreateBoard(trauma As String) Implements IWorldModel.CreateBoard
        For Each y In Enumerable.Range(0, BoardRows)
            For Each x In Enumerable.Range(0, BoardColumns)
                board(x, y) = False
            Next
        Next
        For Each dummy In Enumerable.Range(0, Math.Min(World.Avatar.GetTriggerLevel(trauma), FilledCellMaximum))
            Dim x As Integer
            Dim y As Integer
            Do
                x = RNG.FromRange(0, BoardColumns - 1)
                y = RNG.FromRange(0, BoardRows - 1)
            Loop Until Not board(x, y)
            board(x, y) = True
        Next
    End Sub

    Public Function GetBoardCell(column As Integer, row As Integer) As Boolean Implements IWorldModel.GetBoardCell
        Return board(column, row)
    End Function
End Class
