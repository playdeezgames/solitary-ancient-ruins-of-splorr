Friend Class CombatState
    Inherits BaseGameState(Of IWorldModel)

    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean), context As IUIContext(Of IWorldModel))
        MyBase.New(parent, setState, context)
    End Sub

    Public Overrides Sub HandleCommand(cmd As String)
    End Sub

    Public Overrides Sub Render(displayBuffer As IPixelSink)
        displayBuffer.Fill(0)
        Dim uifont = Context.Font(UIFontName)
        For Each row In Enumerable.Range(0, WorldModel.BoardRows)
            Dim y = row * uifont.Height
            For Each column In Enumerable.Range(0, WorldModel.BoardColumns)
                Dim x = column * uifont.TextWidth(" ")
                If Context.Model.GetBoardCell(column, row) Then
                    uifont.WriteText(displayBuffer, (x, y), "X", 4)
                Else
                    uifont.WriteText(displayBuffer, (x, y), " ", 2)
                End If
            Next
        Next
    End Sub

    Public Overrides Sub OnStart()
        Context.Model.CreateBoard(Context.Model.Trauma)
        MyBase.OnStart()
    End Sub
End Class
