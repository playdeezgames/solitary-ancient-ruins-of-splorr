Imports System.IO
Imports System.Text.Json
Imports SAROS.Data

Public Class World
    Inherits WorldDataClient
    Implements IWorld
    Public Sub New(worldData As WorldData)
        MyBase.New(worldData)
    End Sub
End Class
