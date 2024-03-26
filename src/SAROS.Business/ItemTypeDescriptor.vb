Public Class ItemTypeDescriptor
    Sub New(displayName As String, Optional spawnCount As Integer = 1)
        Me.SpawnCount = spawnCount
        Me.DisplayName = displayName
    End Sub
    ReadOnly Property DisplayName As String
    ReadOnly Property SpawnCount As Integer
End Class
