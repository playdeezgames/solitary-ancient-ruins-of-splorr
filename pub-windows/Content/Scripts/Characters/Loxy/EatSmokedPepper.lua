        
local item = CharacterExtensions.ConsumedItem(character, effect)
local msg = character.World:CreateMessage():AddLine(7, CharacterExtensions.Name(character) .. " eats the smoked pepper.")
CharacterExtensions.DetermineSpiciness(character, msg)