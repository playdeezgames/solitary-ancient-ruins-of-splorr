Public Class ItemTypeDescriptor
    Sub New(Optional spawnCount As Integer = 1)
        Me.SpawnCount = spawnCount
    End Sub
    ReadOnly Property SpawnCount As Integer
End Class
