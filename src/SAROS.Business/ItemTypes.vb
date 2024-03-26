Friend Module ItemTypes
    Friend Const SanityPotion = "SanityPotion"
    Private ReadOnly descriptors As IReadOnlyDictionary(Of String, ItemTypeDescriptor) =
        New Dictionary(Of String, ItemTypeDescriptor) From
        {
            {SanityPotion, New ItemTypeDescriptor("Red Pill", AddressOf OnUseRedPill, spawnCount:=10)}
        }

    Private Sub OnUseRedPill(character As ICharacter)
        character.Sanity += 25
        'TODO: side effect
    End Sub

    Friend ReadOnly Property All As IEnumerable(Of String)
        Get
            Return descriptors.Keys
        End Get
    End Property
    Friend Function GetDescriptor(itemType As String) As ItemTypeDescriptor
        Return descriptors(itemType)
    End Function
End Module
