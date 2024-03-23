Public Interface IWorld(Of TDirection)
    ReadOnly Property Serialized As String
    Function CreateLocation(column As Integer, row As Integer) As ILocation(Of TDirection)
    ReadOnly Property Locations As IEnumerable(Of ILocation(Of TDirection))
End Interface
