Friend Class WinState
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
        Dim text = "You win!"
        uifont.WriteText(displayBuffer, ((ViewWidth - uifont.TextWidth(text)) \ 2, ViewHeight \ 3 - uifont.HalfHeight), text, 2)
        text = "You are the epitome of mental health!"
        uifont.WriteText(displayBuffer, ((ViewWidth - uifont.TextWidth(text)) \ 2, 2 * ViewHeight \ 3 - uifont.HalfHeight), text, 2)
        Context.ShowStatusBar(displayBuffer, uifont, "(A)/Space: Continue", 0, 7)
    End Sub

    Public Overrides Sub OnStart()
        PlayMux("VictoryTheme")
        MyBase.OnStart()
    End Sub
End Class
