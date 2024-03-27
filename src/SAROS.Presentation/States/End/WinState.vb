﻿Friend Class WinState
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
        uifont.WriteText(displayBuffer, (0, 0), "You win!", 15)
        uifont.WriteText(displayBuffer, (0, 8), "You are the epitome of mental health!", 15)
    End Sub

    Public Overrides Sub OnStart()
        PlayMux("VictoryTheme")
        MyBase.OnStart()
    End Sub
End Class
