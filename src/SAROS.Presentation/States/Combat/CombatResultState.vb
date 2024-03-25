Friend Class CombatResultState
    Inherits BaseGameState(Of IWorldModel)

    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean), context As IUIContext(Of IWorldModel))
        MyBase.New(parent, setState, context)
    End Sub

    Public Overrides Sub HandleCommand(cmd As String)
        Select Case cmd
            Case Command.A
                Context.Model.CompleteCombat()
                SetState(GameState.Navigation)
        End Select
    End Sub

    Public Overrides Sub Render(displayBuffer As IPixelSink)
        displayBuffer.Fill(0)
        Dim uifont = Context.Font(UIFontName)
        Dim cellWidth = uifont.TextWidth(" ")
        Dim cellHeight = uifont.Height
        displayBuffer.Fill((0, cellHeight * Context.Model.BoardRow), (cellWidth * WorldModel.BoardColumns, cellHeight), 1)
        displayBuffer.Fill((cellWidth * Context.Model.BoardColumn, 0), (cellWidth, cellHeight * WorldModel.BoardRows), 1)
        For Each row In Enumerable.Range(0, WorldModel.BoardRows)
            Dim y = row * cellHeight
            For Each column In Enumerable.Range(0, WorldModel.BoardColumns)
                Dim x = column * cellWidth
                If Context.Model.IsBoardCellTrigger(column, row) Then
                    uifont.WriteText(displayBuffer, (x, y), "X", 4)
                Else
                    uifont.WriteText(displayBuffer, (x, y), " ", 2)
                End If
            Next
        Next
    End Sub
End Class
