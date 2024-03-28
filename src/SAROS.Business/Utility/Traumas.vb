Public Module Traumas
    Public Const Mother = "Mother"
    Public Const Father = "Father"
    Public Const Teacher = "Teacher"
    Public Const School = "School"
    Public Const BestFriend = "BestFriend"
    Public Const FirstCrush = "FirstCrush"
    Public Const BodyImage = "BodyImage"
    Public Const BeingInPublic = "BeingInPublic"
    Friend ReadOnly All As IReadOnlyList(Of String) =
        New List(Of String) From
        {
            Mother,
            Father,
            Teacher,
            School,
            BestFriend,
            FirstCrush,
            BodyImage,
            BeingInPublic
        }
End Module
