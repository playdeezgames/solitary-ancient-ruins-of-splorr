Public Interface ICharacter
    ReadOnly Property Id As Integer
    Property Location As ILocation
    Property Facing As String
    Property Sanity As Integer
    ReadOnly Property MaximumSanity As Integer
    Sub SetTriggerLevel(trauma As String, triggerLevel As Integer)
    Function GetTriggerLevel(trauma As String) As Integer
End Interface
