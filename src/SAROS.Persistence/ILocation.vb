Public Interface ILocation(Of TDirection)
    ReadOnly Property Column As Integer
    ReadOnly Property Row As Integer
    Sub SetNeighbor(direction As TDirection, nextLocation As ILocation(Of TDirection))
End Interface
