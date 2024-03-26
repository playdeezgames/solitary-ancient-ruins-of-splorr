Imports SAROS.Data

Friend MustInherit Class ItemDataClient
    Inherits WorldDataClient
    Protected ReadOnly Property ItemId As Integer
    Protected ReadOnly Property ItemData As ItemData
        Get
            Return WorldData.Items(ItemId)
        End Get
    End Property

    Protected Sub New(worldData As Data.WorldData, itemId As Integer)
        MyBase.New(worldData)
        Me.ItemId = itemId
    End Sub
End Class
