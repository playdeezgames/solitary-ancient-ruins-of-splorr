Public Interface IWorldModel
    Sub Embark()
    Sub Abandon()
    Sub Load(filename As String)
    Sub Save(filename As String)
    Sub TurnLeft()
    Sub TurnRight()
    Sub MoveAhead()
    Sub CreateBoard(trauma As String)
    Function GetBoardCell(column As Integer, row As Integer) As Boolean
    ReadOnly Property Facing As String
    ReadOnly Property RoomString As String
    ReadOnly Property Column As Integer
    ReadOnly Property Row As Integer
    ReadOnly Property Sanity As Integer
    ReadOnly Property MaximumSanity As Integer
    ReadOnly Property IsInsane As Boolean
    ReadOnly Property Trauma As String
    ReadOnly Property TriggerLevel As Integer
End Interface
