Friend Class LoseState
    Inherits BaseGameState(Of IWorldModel)

    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean), context As IUIContext(Of IWorldModel))
        MyBase.New(parent, setState, context)
    End Sub

    Public Overrides Sub HandleCommand(cmd As String)
        If cmd = Command.A Then
            SetState(BoilerplateState.MainMenu)
        End If
    End Sub

    Public Overrides Sub Render(displayBuffer As IPixelSink)
        displayBuffer.Fill(0)
        Dim uifont = Context.Font(UIFontName)
        Dim text = "You have gone mad!"
        uifont.WriteText(displayBuffer, ((ViewWidth - uifont.TextWidth(text)) \ 2, ViewHeight \ 3 - uifont.HalfHeight), text, 4)
        text = "Nothing matters."
        uifont.WriteText(displayBuffer, ((ViewWidth - uifont.TextWidth(text)) \ 2, 2 * ViewHeight \ 3 - uifont.HalfHeight), text, 4)
        Context.ShowStatusBar(displayBuffer, uifont, "(A)/Space: Continue", 0, 7)
    End Sub
End Class
