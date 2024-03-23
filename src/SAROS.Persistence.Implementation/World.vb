Imports System.Text.Json
Imports SAROS.Data

Public Class World
    Inherits WorldDataClient
    Implements IWorld
    Public Sub New(worldData As WorldData)
        MyBase.New(worldData)
    End Sub

    Public ReadOnly Property Serialized As String Implements IWorld.Serialized
        Get
            Return JsonSerializer.Serialize(WorldData)
        End Get
    End Property

    Public ReadOnly Property Locations As IEnumerable(Of ILocation) Implements IWorld.Locations
        Get
            Return Enumerable.Range(0, WorldData.Locations.Count).Select(Function(x) New Location(WorldData, x))
        End Get
    End Property

    Public Function CreateLocation(column As Integer, row As Integer) As ILocation Implements IWorld.CreateLocation
        Dim locationId = WorldData.Locations.Count
        WorldData.Locations.Add(New LocationData With
                                {
                                    .Column = column,
                                    .Row = row
                                })
        Return New Location(WorldData, locationId)
    End Function
End Class
