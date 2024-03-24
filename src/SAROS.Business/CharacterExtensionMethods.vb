Friend Module CharacterExtensionMethods
    <Extension>
    Function AheadDirection(character As ICharacter) As String
        Return character.Facing
    End Function
    <Extension>
    Function LeftDirection(character As ICharacter) As String
        Select Case character.Facing
            Case Direction.North
                Return Direction.West
            Case Direction.East
                Return Direction.North
            Case Direction.South
                Return Direction.East
            Case Direction.West
                Return Direction.South
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
    <Extension>
    Function RightDirection(character As ICharacter) As String
        Select Case character.Facing
            Case Direction.North
                Return Direction.East
            Case Direction.East
                Return Direction.South
            Case Direction.South
                Return Direction.West
            Case Direction.West
                Return Direction.North
            Case Else
                Throw New NotImplementedException
        End Select
    End Function
End Module
