Imports System.Data.Common

Friend Class CombatResultState
    Inherits BaseGameState(Of IWorldModel)

    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean), context As IUIContext(Of IWorldModel))
        MyBase.New(parent, setState, context)
    End Sub

    Public Overrides Sub HandleCommand(cmd As String)
        Select Case cmd
            Case Command.A
                Context.Model.CompleteCombat()
                If Context.Model.IsInsane Then
                    SetState(GameState.Lose)
                ElseIf Context.Model.Win Then
                    SetState(GameState.Win)
                Else
                    SetState(GameState.Navigation)
                End If
        End Select
    End Sub

    Public Overrides Sub Render(displayBuffer As IPixelSink)
        displayBuffer.Fill(0)
        Dim uifont = Context.Font(UIFontName)
        Dim cellWidth = uifont.TextWidth(" ")
        Dim cellHeight = uifont.Height
        Dim offsetX = (ViewWidth - cellWidth * WorldModel.BoardColumns) \ 2
        Dim offsetY = (ViewHeight - cellHeight * WorldModel.BoardRows) \ 2
        Dim descriptor = Grimoire.TraumaDescriptors(Context.Model.Trauma)
        Dim text = $"You faced a painful memory about {descriptor.Description}!"
        Dim hue = 15
        CenterText(displayBuffer, 0, uifont, text, hue)
        If Context.Model.IsBoardCellTrigger(Context.Model.BoardColumn, Context.Model.BoardRow) Then
            displayBuffer.Fill((offsetX + 0, offsetY + cellHeight * Context.Model.BoardRow), (cellWidth * WorldModel.BoardColumns, cellHeight), 10)
            displayBuffer.Fill((offsetX + cellWidth * Context.Model.BoardColumn, offsetY), (cellWidth, cellHeight * WorldModel.BoardRows), 12)
            CenterText(displayBuffer, 8, uifont, "You are triggered!", 4)
            CenterText(displayBuffer, 16, uifont, $"You lose {Context.Model.EnemyCombatDamage} sanity!", 4)
            CenterText(displayBuffer, 24, uifont, $"You have {Context.Model.PostCombatSanity}/{Context.Model.MaximumSanity} sanity!", 4)
        Else
            displayBuffer.Fill((offsetX + cellWidth * Context.Model.BoardColumn, offsetY), (cellWidth, cellHeight * WorldModel.BoardRows), 12)
            displayBuffer.Fill((offsetX + 0, offsetY + cellHeight * Context.Model.BoardRow), (cellWidth * WorldModel.BoardColumns, cellHeight), 10)
            CenterText(displayBuffer, 8, uifont, "You process it in a healthy way!", 2)
            CenterText(displayBuffer, 16, uifont, $"Triggers decrease by {Context.Model.PlayerCombatDamage}!", 2)
            CenterText(displayBuffer, 24, uifont, $"Trigger level now is {Context.Model.PostCombatTriggerLevel}!", 2)
        End If
        For Each row In Enumerable.Range(0, WorldModel.BoardRows)
            Dim y = row * cellHeight + offsetY
            For Each column In Enumerable.Range(0, WorldModel.BoardColumns)
                Dim x = column * cellWidth + offsetX
                If Context.Model.IsBoardCellTrigger(column, row) Then
                    uifont.WriteText(displayBuffer, (x, y), "X", 4)
                Else
                    uifont.WriteText(displayBuffer, (x, y), " ", 2)
                End If
            Next
        Next


        Context.ShowStatusBar(displayBuffer, uifont, Context.ControlsText("Continue", Nothing), 0, 7)
    End Sub

    Private Shared Sub CenterText(displayBuffer As IPixelSink, y As Integer, uifont As Font, text As String, hue As Integer)
        uifont.WriteText(displayBuffer, ((ViewWidth - uifont.TextWidth(text)) \ 2, y), text, hue)
    End Sub
End Class
