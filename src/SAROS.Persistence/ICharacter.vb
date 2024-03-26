Public Interface ICharacter
    ReadOnly Property Id As Integer
    Property Location As ILocation
    Property Facing As String
    Property Sanity As Integer
    ReadOnly Property MaximumSanity As Integer
    ReadOnly Property HasItems As Boolean
    Sub SetTriggerLevel(trauma As String, triggerLevel As Integer)
    Sub SetAwarenessLevel(trauma As String, awarenessLevel As Integer)
    Sub SetEscalation(trauma As String, escalation As Integer)
    Sub AddItem(item As IItem)
    Function GetTriggerLevel(trauma As String) As Integer
    Function GetAwarenessLevel(trauma As String) As Integer
    Function GetEscalation(trauma As String) As Integer
    Sub RemoveItem(item As IItem)
    ReadOnly Property Items As IEnumerable(Of IItem)
End Interface
