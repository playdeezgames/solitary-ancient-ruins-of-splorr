﻿Friend Class Location
    Inherits LocationDataClient
    Implements ILocation

    Public Sub New(worldData As Data.WorldData, locationId As Integer)
        MyBase.New(worldData, locationId)
    End Sub

    Public ReadOnly Property Column As Integer Implements ILocation.Column
        Get
            Return LocationData.Column
        End Get
    End Property

    Public ReadOnly Property Row As Integer Implements ILocation.Row
        Get
            Return LocationData.Row
        End Get
    End Property

    Public ReadOnly Property Id As Integer Implements ILocation.Id
        Get
            Return LocationId
        End Get
    End Property

    Public Sub SetNeighbor(direction As String, nextLocation As ILocation) Implements ILocation.SetNeighbor
        LocationData.Neighbors(direction) = nextLocation.Id
    End Sub

    Public Sub SetDoor(direction As String, door As String) Implements ILocation.SetDoor
        LocationData.Doors(direction) = door
    End Sub

    Public Sub AddCharacter(character As ICharacter) Implements ILocation.AddCharacter
        LocationData.Characters.Add(character.Id)
    End Sub

    Public Sub RemoveCharacter(character As ICharacter) Implements ILocation.RemoveCharacter
        LocationData.Characters.Remove(character.Id)
    End Sub

    Public Function HasDoor(direction As String) As Boolean Implements ILocation.HasDoor
        Return LocationData.Doors.ContainsKey(direction)
    End Function
End Class
