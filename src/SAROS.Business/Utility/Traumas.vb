Friend Module Traumas
    Friend Const Mother = "Mother"
    Friend Const Father = "Father"
    Friend Const Teacher = "Teacher"
    Friend Const School = "School"
    Friend Const BestFriend = "BestFriend"
    Friend Const FirstCrush = "FirstCrush"
    Friend Const BodyImage = "BodyImage"
    Friend ReadOnly All As IReadOnlyList(Of String) =
        New List(Of String) From
        {
            Mother,
            Father,
            Teacher,
            School,
            BestFriend,
            FirstCrush,
            BodyImage
        }
End Module
