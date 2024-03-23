Friend Class Location
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

    Public Sub SetNeighbor(direction As String, nextLocation As ILocation) Implements ILocation.SetNeighbor
        Throw New NotImplementedException()
    End Sub
End Class
