Public Interface IWorld
    ReadOnly Property Serialized As String
    Function CreateLocation(column As Integer, row As Integer) As ILocation
    ReadOnly Property Locations As IEnumerable(Of ILocation)
End Interface
