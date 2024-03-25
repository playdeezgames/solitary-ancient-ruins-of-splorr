﻿Imports System.Drawing

Friend Class NavigationState
    Inherits BaseGameState(Of IWorldModel)

    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean), context As IUIContext(Of IWorldModel))
        MyBase.New(parent, setState, context)
    End Sub

    Public Overrides Sub HandleCommand(cmd As String)
        Select Case cmd
            Case Command.A
                SetState(GameState.ActionMenu)
            Case Command.B
                SetState(BoilerplateState.GameMenu)
            Case Command.Left
                Context.Model.TurnLeft()
            Case Command.Right
                Context.Model.TurnRight()
            Case Command.Up
                Context.Model.MoveAhead()
                SetState(BoilerplateState.Neutral)
        End Select
    End Sub

    Public Overrides Sub Render(displayBuffer As IPixelSink)
        displayBuffer.Fill(0)
        Dim roomFont = Context.Font(roomFontname)
        roomFont.WriteText(displayBuffer, (0, 0), Context.Model.RoomString, 15)

        Dim uifont = Context.Font(UIFontName)
        uifont.WriteText(displayBuffer, (0, 192), $"({Context.Model.Column},{Context.Model.Row}) {Context.Model.Facing}", 7)
        uifont.WriteText(displayBuffer, (0, 200), $"{Context.Model.Trauma} {Context.Model.TriggerLevel} {Context.Model.Escalation}", 7)
        uifont.WriteText(displayBuffer, (0, 208), $"Sanity: {Context.Model.Sanity}/{Context.Model.MaximumSanity}", 7)
    End Sub
End Class