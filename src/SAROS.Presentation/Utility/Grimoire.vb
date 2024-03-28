Public Module Grimoire
    Public Const DefaultScreenWidth = ViewWidth * 3
    Public Const DefaultScreenHeight = ViewHeight * 3
    Public Const ViewHeight = 216
    Public Const ViewWidth = 384
    Public Const GameTitle = "Solitary Ancient Ruins of SPLORR!!"
    Public Const GameSubtitle = "The Cosmic Horror of Infinity"

    Friend Const ConfigFileName = "config.json"
    Friend Const ContinueText = "Continue"
    Friend Const UIFontName = "UIFont"
    Friend Const RoomFontName = "Room"
    Friend Const MapFontName = "Map"
    Friend Const ItemFontName = "Item"

    Friend ReadOnly TraumaDescriptors As IReadOnlyDictionary(Of String, TraumaDescriptor) =
        New Dictionary(Of String, TraumaDescriptor) From
        {
            {Traumas.Mother, New TraumaDescriptor("your mother")},
            {Traumas.Father, New TraumaDescriptor("your father")},
            {Traumas.FirstCrush, New TraumaDescriptor("your first crush")},
            {Traumas.Teacher, New TraumaDescriptor("a teacher")},
            {Traumas.School, New TraumaDescriptor("your school")},
            {Traumas.BestFriend, New TraumaDescriptor("your best friend")},
            {Traumas.BodyImage, New TraumaDescriptor("your body image")},
            {Traumas.BeingInPublic, New TraumaDescriptor("being in public")}
        }
End Module
