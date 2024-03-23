Friend Class Location(Of TDirection)
    Inherits LocationDataClient
    Implements ILocation(Of TDirection)

    Public Sub New(worldData As Data.WorldData, locationId As Integer)
        MyBase.New(worldData, locationId)
    End Sub

    Public ReadOnly Property Column As Integer Implements ILocation(Of TDirection).Column
        Get
            Return LocationData.Column
        End Get
    End Property

    Public ReadOnly Property Row As Integer Implements ILocation(Of TDirection).Row
        Get
            Return LocationData.Row
        End Get
    End Property

    Public Sub SetNeighbor(direction As TDirection, nextLocation As ILocation(Of TDirection)) Implements ILocation(Of TDirection).SetNeighbor
        Throw New NotImplementedException()
    End Sub
End Class
