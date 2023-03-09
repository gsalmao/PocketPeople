# Pocket People

Pocket People is a top-down adventure game, where the player can walk around, buy/sell items, equip or use certain items, collect items in the map, talk with people and interact with world objects. It is separated in several assemblies.

https://user-images.githubusercontent.com/8738336/224033068-05896dca-c20e-4f40-8db5-b403b2cb85e7.mp4


## Interact with nearby objects to read / talk to them.
![gif1](https://user-images.githubusercontent.com/8738336/221646460-b7d01635-4539-4d56-9e3e-bf10d1dc0f79.gif)


## Buy consummables and use them
![gif2](https://user-images.githubusercontent.com/8738336/221646747-19f7b9aa-b2b2-428f-86e7-8f99514ab214.gif)


## Buy new clothes in the clothes shop
![gif3](https://user-images.githubusercontent.com/8738336/221646873-5212fd53-9ffd-4571-aaa1-879a5bac8b17.gif)


Here are some important assemblies:

## PocketPeople.Application
Responsible for main application classes.
- **GameManager : MonoBehaviour:** Since the game is simple, it just set the screen resolution. It also has a static debugging bool, which was used to debug scenes, preventing the SceneLoader's from auto-loading scenes.
- **SceneLoader : MonoBehaviour:** Used to switch between scene and fade between them.

## PocketPeople.CursorEntities
Classes that handles with the player's cursor.
- **CursorController : MonoBehaviour:** Main cursor class responsible for changing it.
- **CursorModifier : MonoBehaviour:** Monobehaviour class that controls the cursor's behaviour when interacting with an object.
- **ICursorCallbacks:** Interface with events used to expand the CursorModifier's functionality.

## PocketPeople.Dialogues
Responsible for storing the data of the dialogues and exhibiting them.

## PocketPeople.Interactables
Responsible for the interaction system. It has a basic Interactable class inheriting from CursorModifier and several Interactable derived classes, each one doing their own specific thing.

## PocketPeople.Interactables.Shopkeeper
Responsible for interacting with the shopkeeper and trading items.
- **Shopkeeper : Interactable:** Opens the ShopWindow.
- **ShopWindow : BasicWindow:** Responsible for the shop's items and the player's items, where both can be traded.

## PocketPeople.Items
The item system of the game.
- **Inventory:** Controls and manages the player's belongs.
- **Equipment:** Handles the player's equipped items.
- **RuntimeItem:** Instance of an item. Holds a reference to an ItemData.

## PocketPeople.Items.Data
Store the data of the items.
- **ItemData : ScriptableObject:** Basic item info.
- **EquipmentData : ItemData:** Equippable items.
- **ConsummableData : ItemData:** Consummable items.

## PocketPeople.Items.Effects
Store the data required for the effect of the items.
- **BaseEffect : ScriptableObject:** Basic item effect class. Invoke an Action whenever is activated.
- **SwapperEffect : BaseEffect:** Data for swapping the Player's sprites.

## PocketPeople.Items.UI
Responsible for drawing the item buttons on the screen and handling the Player's input once clicked on the buttons.

## NodeCanvasCustom.Actions
Holds every ActionTask created during this project, to be used inside NodeCanvas's Behaviour Trees and Finite State Machines.

## PocketPeople.Player
Controls the behaviour of the player.
- **PlayerController : MonoBehaviour:** Controls the Player's physics and behaviour
whenever he is interacting with something.
- **PlayerEffects:** Subscribe to the ItemEffect's Action and process them according to what
they are supposed to do.
