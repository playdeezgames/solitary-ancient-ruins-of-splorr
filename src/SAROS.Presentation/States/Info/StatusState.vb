Friend Class StatusState
    Inherits BaseGameState(Of IWorldModel)

    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean), context As IUIContext(Of IWorldModel))
        MyBase.New(parent, setState, context)
    End Sub

    Public Overrides Sub HandleCommand(cmd As String)
        If cmd = Command.B Then
            SetState(GameState.Navigation)
        End If
    End Sub

    Public Overrides Sub Render(displayBuffer As IPixelSink)
        displayBuffer.Fill(0)
        Dim uifont = Context.Font(UIFontName)
        Dim items = Context.Model.TraumaStates
        Dim y = ViewHeight \ 2 - uifont.HalfHeight * items.Count
        For Each item In items
            Dim text As String
            Dim hue As Integer = 14
            If item.Awareness > 0 Then
                If item.TriggerLevel > 0 Then
                    hue = 4
                Else
                    hue = 2
                End If
                text = $"{Grimoire.TraumaDescriptors(item.Trauma).Description} {item.TriggerLevel}"
            Else
                text = $"{Grimoire.TraumaDescriptors(item.Trauma).Description} ??"
            End If
            uifont.WriteText(displayBuffer, ((ViewWidth - uifont.TextWidth(text)) \ 2, y), text, hue)
            y += uifont.Height
        Next
        Context.ShowHeader(displayBuffer, uifont, "Trauma Trigger Statuses", 6, 0)
        Context.ShowStatusBar(displayBuffer, uifont, "Esc/(B): Close", 0, 7)
    End Sub
End Class
