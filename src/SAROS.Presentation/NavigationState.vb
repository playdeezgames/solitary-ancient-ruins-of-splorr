﻿Imports System.Drawing

Friend Class NavigationState
    Inherits BaseGameState(Of IWorldModel)

    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean), context As IUIContext(Of IWorldModel))
        MyBase.New(parent, setState, context)
    End Sub

    Public Overrides Sub HandleCommand(cmd As String)
        Select Case cmd
            Case Command.B
                SetState(BoilerplateState.GameMenu)
            Case Command.Left
                Context.Model.TurnLeft()
            Case Command.Right
                Context.Model.TurnRight()
        End Select
    End Sub

    Public Overrides Sub Render(displayBuffer As IPixelSink)
        displayBuffer.Fill(0)
        Dim roomFont = Context.Font("Room")
        roomFont.WriteText(displayBuffer, (0, 0), Context.Model.RoomString, 15)
    End Sub
End Class