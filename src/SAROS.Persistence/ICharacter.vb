﻿Public Interface ICharacter
    ReadOnly Property Id As Integer
    Property Location As ILocation
    Property Facing As String
    ReadOnly Property Sanity As Integer
    ReadOnly Property MaximumSanity As Integer
End Interface
