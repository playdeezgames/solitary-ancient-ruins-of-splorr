Public Interface ILocation
    ReadOnly Property Column As Integer
    ReadOnly Property Row As Integer
    Sub SetNeighbor(direction As String, nextLocation As ILocation)
End Interface
