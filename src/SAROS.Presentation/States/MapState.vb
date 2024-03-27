Friend Class MapState
    Inherits BaseGameState(Of IWorldModel)

    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean), context As IUIContext(Of IWorldModel))
        MyBase.New(parent, setState, context)
    End Sub

    Public Overrides Sub HandleCommand(cmd As String)
        Select Case cmd
            Case Command.B
                SetState(GameState.Navigation)
        End Select
    End Sub

    Public Overrides Sub Render(displayBuffer As IPixelSink)
        displayBuffer.Fill(0)
        Dim mapFont = Context.Font(MapFontName)
        Const OffsetX = 192 - 7 * 25 \ 2
        Const OffsetY = 96 - 7 * 25 \ 2
        For Each cell In Context.Model.Map
            Dim x = cell.Column * mapFont.TextWidth(ChrW(0)) + OffsetX
            Dim y = cell.Row * mapFont.Height + OffsetY
            mapFont.WriteText(displayBuffer, (x, y), cell.Text, 15)
        Next
    End Sub
End Class
