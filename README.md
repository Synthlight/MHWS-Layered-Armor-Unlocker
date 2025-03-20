# MHWS Layered Armor Unlocker (For Player & Palico)

Adds a window, when ref is open, with the options:
- Unlock all Player Layered Armor in Current Save
- Unlock all Palico Layered Armor in Current Save

(Palico == Otomo)

# Requirements/Installation

Required REFrameworks's C# API/build to work.
- Login to GitHub. (You can't even see the DL links in Action until you do.)
- Go [here](https://github.com/praydog/REFramework/actions?query=branch%3Acsharp-api+event%3Apush).
- Go to the latest action, and DL:
  - The REF version for MHWilds.
  - And `csharp-api`.
  - (The REF version from here is kinda optional, but it will suspend the game on startup whilst C# API compilation occurs, so it's recommended.)
 - Install both. Extract the API archive so the `plugins` folder winds up in the `reframework` folder.
 - Place the DLL from this mod inside the `reframework\plugins\managed` folder.
 - If at any point you don't have X folder, just make it. (I wish I didn't have to say this.)

Run the game, load your save, open REF's UI, and click whichever button you want!