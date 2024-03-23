Imports System.Text.Json
Imports SAROS.Data

Public Class World(Of TDirection)
    Inherits WorldDataClient
    Implements IWorld(Of TDirection)
    Public Sub New(worldData As WorldData)
        MyBase.New(worldData)
    End Sub

    Public ReadOnly Property Serialized As String Implements IWorld(Of TDirection).Serialized
        Get
            Return JsonSerializer.Serialize(WorldData)
        End Get
    End Property

    Public ReadOnly Property Locations As IEnumerable(Of ILocation(Of TDirection)) Implements IWorld(Of TDirection).Locations
        Get
            Return Enumerable.Range(0, WorldData.Locations.Count).Select(Function(x) New Location(Of TDirection)(WorldData, x))
        End Get
    End Property

    Public Function CreateLocation(column As Integer, row As Integer) As ILocation(Of TDirection) Implements IWorld(Of TDirection).CreateLocation
        Dim locationId = WorldData.Locations.Count
        WorldData.Locations.Add(New LocationData With
                                {
                                    .Column = column,
                                    .Row = row
                                })
        Return New Location(Of TDirection)(WorldData, locationId)
    End Function
End Class
