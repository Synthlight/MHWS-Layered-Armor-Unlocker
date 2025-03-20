-- Layered Armor Unlocker (REF)
-- By LordGregory

local version = "1.0"
log.info("Initializing `Layered Armor Unlocker (REF)` v"..version)

-- sdk.get_managed_singleton("app.SaveDataManager"):call("getCurrentUserSaveData")

local function unlockLayeredArmor()
    local saveDataManager = sdk.get_managed_singleton("app.SaveDataManager") -- app.SaveDataManager
    local userSaveParam   = saveDataManager:call("getCurrentUserSaveData") -- app.savedata.cUserSaveParam
    local equipParam      = userSaveParam._Equip -- app.savedata.cEquipParam

    -- Need to loop through the enum values and call this with 'true'.
    -- equipParam:call("setOuterArmorFlag(app.ArmorDef.ARMOR_PARTS, app.ArmorDef.SERIES, app.CharacterDef.GENDER, System.Boolean)", args)
end

re.on_draw_ui(function()
    if imgui.tree_node("Layered Armor Unlocker") then
        if imgui.button("Add Layered Armor to Current Save", LARGE_BTN) then
            unlockLayeredArmor()
        end
    end
end)