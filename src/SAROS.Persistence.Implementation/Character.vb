Friend Class Character
    Inherits CharacterDataClient
    Implements ICharacter

    Public Sub New(worldData As Data.WorldData, characterId As Integer)
        MyBase.New(worldData, characterId)
    End Sub

    Public ReadOnly Property Id As Integer Implements ICharacter.Id
        Get
            Return CharacterId
        End Get
    End Property

    Public ReadOnly Property Location As ILocation Implements ICharacter.Location
        Get
            Return New Location(WorldData, CharacterData.LocationId)
        End Get
    End Property

    Public Property Facing As String Implements ICharacter.Facing
        Get
            Return CharacterData.Facing
        End Get
        Set(value As String)
            CharacterData.Facing = value
        End Set
    End Property
End Class