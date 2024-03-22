Imports System.IO

Public Class WorldModel
    Implements IWorldModel

    Private _world As IWorld

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
    End Sub
    Public Sub Abandon() Implements IWorldModel.Abandon
        World = Nothing
    End Sub
    Public Sub Load(filename As String) Implements IWorldModel.Load
        Throw New NotImplementedException
    End Sub
    Public Sub Save(filename As String) Implements IWorldModel.Save
        Throw New NotImplementedException
    End Sub
End Class
