Public Interface IWorld
    ReadOnly Property Serialized As String
    Function CreateLocation(column As Integer, row As Integer) As ILocation
    Function CreateCharacter(location As ILocation, facing As String, maximumSanity As Integer) As ICharacter
    Sub SetAvatar(character As ICharacter)
    Function CreateItem(itemType As String) As IItem
    ReadOnly Property Locations As IEnumerable(Of ILocation)
    ReadOnly Property Avatar As ICharacter
End Interface
