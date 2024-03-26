﻿Public Interface ILocation
    ReadOnly Property Column As Integer
    ReadOnly Property Row As Integer
    Sub SetNeighbor(direction As String, nextLocation As ILocation)
    ReadOnly Property Id As Integer
    Sub SetDoor(direction As String, door As String)
    Sub AddCharacter(result As ICharacter)
    Function HasDoor(direction As String) As Boolean
    Sub RemoveCharacter(character As ICharacter)
    Sub AddItem(item As IItem)
    ReadOnly Property HasCharacter As Boolean
    ReadOnly Property HasTrauma As Boolean
    Property Trauma As String
End Interface
