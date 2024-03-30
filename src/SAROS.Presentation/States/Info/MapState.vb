Imports System.Data

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
            Dim hue = 15
            If cell.TriggerLevel > 0 Then
                If cell.HasItems Then
                    hue = 14
                Else
                    hue = 4
                End If
            Else
                If cell.HasItems Then
                    hue = 2
                End If
            End If
            mapFont.WriteText(displayBuffer, (x, y), cell.Text, hue)
        Next
        Dim uifont = Context.Font(UIFontName)
        Context.ShowHeader(displayBuffer, uifont, "MAP", 6, 0)
        Context.ShowStatusBar(displayBuffer, uifont, Context.ControlsText(Nothing, "Close"), 0, 7)
    End Sub
End Class
