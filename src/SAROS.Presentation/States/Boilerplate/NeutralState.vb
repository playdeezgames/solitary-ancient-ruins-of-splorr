﻿Friend Class NeutralState
    Inherits BaseGameState(Of IWorldModel)

    Public Sub New(parent As IGameController, setState As Action(Of String, Boolean), context As IUIContext(Of IWorldModel))
        MyBase.New(parent, setState, context)
    End Sub

    Public Overrides Sub HandleCommand(cmd As String)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Sub Render(displayBuffer As IPixelSink)
        Throw New NotImplementedException()
    End Sub

    Private ReadOnly stateTable As IReadOnlyList(Of (state As String, condition As Func(Of IWorldModel, Boolean))) =
        New List(Of (String, Func(Of IWorldModel, Boolean))) From
        {
            (GameState.Lose, Function(m) m.IsInsane),
            (GameState.Navigation, Function(m) True)
        }

    Public Overrides Sub OnStart()
        MyBase.OnStart()
        SetState(stateTable.First(Function(item) item.condition(Model)).state)
    End Sub
End Class
