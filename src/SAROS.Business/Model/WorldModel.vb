﻿Public Class WorldModel
    Implements IWorldModel

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
        If location.HasDoor(character.AheadDirection) Then
            Dim nextColumn = location.Column
            Dim nextRow = location.Row
            Select Case character.AheadDirection
                Case Direction.North
                    nextRow -= 1
                Case Direction.East
                    nextColumn += 1
                Case Direction.South
                    nextRow += 1
                Case Direction.West
                    nextColumn -= 1
                Case Else
                    Throw New NotImplementedException
            End Select
            Dim nextLocation = World.Locations.Single(Function(l) l.Column = nextColumn AndAlso l.Row = nextRow)
            character.Location = nextLocation
        End If
    End Sub
End Class
