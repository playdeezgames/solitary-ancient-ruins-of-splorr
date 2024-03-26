
Friend Class Item
    Inherits ItemDataClient
    Implements IItem

    Public Sub New(worldData As Data.WorldData, itemId As Integer)
        MyBase.New(worldData, itemId)
    End Sub

    Public ReadOnly Property Id As Integer Implements IItem.Id
        Get
            Return ItemId
        End Get
    End Property
End Class
