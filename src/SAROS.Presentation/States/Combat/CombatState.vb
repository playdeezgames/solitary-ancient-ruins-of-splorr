Friend Class CombatState
    Inherits BaseGameState(Of IWorldModel)

    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean), context As IUIContext(Of IWorldModel))
        MyBase.New(parent, setState, context)
    End Sub

    Public Overrides Sub HandleCommand(cmd As String)
        Select Case cmd
            Case Command.Up
                Context.Model.PreviousBoardRow()
            Case Command.Down
                Context.Model.NextBoardRow()
            Case Command.A
                Context.Model.EnemyMove()
                SetState(GameState.CombatResult)
        End Select
    End Sub

    Public Overrides Sub Render(displayBuffer As IPixelSink)
        displayBuffer.Fill(0)
        Dim uifont = Context.Font(UIFontName)
        Dim cellWidth = uifont.TextWidth(" ")
        Dim cellHeight = uifont.Height
        displayBuffer.Fill((0, cellHeight * Context.Model.BoardRow), (cellWidth * WorldModel.BoardColumns, cellHeight), 1)
        For Each row In Enumerable.Range(0, WorldModel.BoardRows)
            Dim y = row * cellHeight
            For Each column In Enumerable.Range(0, WorldModel.BoardColumns)
                Dim x = column * cellWidth
                If Not Context.Model.IsBoardCellVisible(column, row) Then
                    uifont.WriteText(displayBuffer, (x, y), "?", 7)
                ElseIf Context.Model.IsBoardCellTrigger(column, row) Then
                    uifont.WriteText(displayBuffer, (x, y), "X", 4)
                Else
                    uifont.WriteText(displayBuffer, (x, y), " ", 2)
                End If
            Next
        Next

        uifont.WriteText(displayBuffer, (0, 192), $"({Context.Model.Column},{Context.Model.Row}) {Context.Model.Facing}", 7)
        uifont.WriteText(displayBuffer, (0, 200), $"{Context.Model.Trauma} {Context.Model.TriggerLevel} {Context.Model.Escalation}", 7)
        uifont.WriteText(displayBuffer, (0, 208), $"Sanity: {Context.Model.Sanity}/{Context.Model.MaximumSanity}", 7)
    End Sub

    Public Overrides Sub OnStart()
        Context.Model.BeginCombat(Context.Model.Trauma)
        MyBase.OnStart()
    End Sub
End Class
