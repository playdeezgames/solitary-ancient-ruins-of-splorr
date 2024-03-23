Imports System.IO

Public Class WorldModel
    Implements IWorldModel

    Private _world As IWorld(Of Direction)

    Private Property World As IWorld(Of Direction)
        Get
            Return _world
        End Get
        Set(value As IWorld(Of Direction))
            _world = value
        End Set
    End Property
    Public Sub Embark() Implements IWorldModel.Embark
        World = New World(Of Direction)(New WorldData)
        WorldInitializer.Initialize(World)
    End Sub
    Public Sub Abandon() Implements IWorldModel.Abandon
        World = Nothing
    End Sub
    Public Sub Load(filename As String) Implements IWorldModel.Load
        World = New World(Of Direction)(JsonSerializer.Deserialize(Of WorldData)(File.ReadAllText(filename)))
    End Sub
    Public Sub Save(filename As String) Implements IWorldModel.Save
        File.WriteAllText(filename, JsonSerializer.Serialize(World.Serialized))
    End Sub
End Class
