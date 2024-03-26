Public Class ItemTypeDescriptor
    Private ReadOnly onUse As Action(Of ICharacter)
    Sub New(displayName As String, onUse As Action(Of ICharacter), Optional spawnCount As Integer = 1, Optional isConsumed As Boolean = True)
        Me.SpawnCount = spawnCount
        Me.onUse = onUse
        Me.DisplayName = displayName
        Me.IsConsumed = isConsumed
    End Sub
    ReadOnly Property DisplayName As String
    ReadOnly Property SpawnCount As Integer
    ReadOnly Property IsConsumed As Boolean
    Friend Sub Use(character As ICharacter)
        onUse(character)
    End Sub
End Class
