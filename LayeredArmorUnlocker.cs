/*
 * Layered Armor Unlocker v1.0
 * By LordGregory
 */

using System;
using app;
using ImGuiNET;
using REFrameworkNET;
using REFrameworkNET.Attributes;
using REFrameworkNET.Callbacks;

// ReSharper disable once CheckNamespace
namespace LordGregory.Mods.Layered_Armor_Unlocker;

// ReSharper disable once UnusedType.Global
// ReSharper disable once UnusedMember.Global
public class LayeredArmorUnlocker {
    [Callback(typeof(ImGuiDrawUI), CallbackType.Pre)]
    public static void ImGuiCallback() {
        if (API.IsDrawingUI() && ImGui.TreeNode("Layered Armor Unlocker")) {
            UnlockPlayerLayeredArmor();
            UnlockPalicoLayeredArmor();
            ImGui.TreePop();
        }
    }

    private static void UnlockPlayerLayeredArmor() {
        if (ImGui.Button("Unlock all Player Layered Armor in Current Save")) {
            var saveDataManager   = API.GetManagedSingletonT<SaveDataManager>();
            var userSaveParam     = saveDataManager.getCurrentUserSaveData();
            var equipParam        = userSaveParam._Equip;
            var armorPartsValues  = Enum.GetValues<ArmorDef.ARMOR_PARTS>();
            var armorSeriesValues = Enum.GetValues<ArmorDef.SERIES>();
            var genderValues      = Enum.GetValues<CharacterDef.GENDER>();

            foreach (var series in armorSeriesValues) {
                if (series is ArmorDef.SERIES.NONE or ArmorDef.SERIES.MAX) continue;
                foreach (var part in armorPartsValues) {
                    if (part == ArmorDef.ARMOR_PARTS.MAX) continue;
                    foreach (var gender in genderValues) {
                        if (gender == CharacterDef.GENDER.NOTHING) continue;
                        equipParam.setOuterArmorFlag(part, series, gender, true);
                    }
                }
            }
        }
    }

    private static void UnlockPalicoLayeredArmor() {
        if (ImGui.Button("Unlock all Palico Layered Armor in Current Save")) {
            var saveDataManager = API.GetManagedSingletonT<SaveDataManager>();
            var userSaveParam   = saveDataManager.getCurrentUserSaveData();
            var equipParam      = userSaveParam._Equip;
            var equipTypeValues = Enum.GetValues<OtEquipDef.EQUIP_TYPE>();
            var equipIdValues   = Enum.GetValues<OtEquipDef.EQUIP_DATA_ID>();

            foreach (var equipId in equipIdValues) {
                if (equipId is OtEquipDef.EQUIP_DATA_ID.NONE or OtEquipDef.EQUIP_DATA_ID.MAX) continue;
                foreach (var type in equipTypeValues) {
                    if (type is OtEquipDef.EQUIP_TYPE.MAX or OtEquipDef.EQUIP_TYPE.WEAPON) continue;
                    equipParam.setOtomoOuterArmorFlag(type, equipId, true);
                }
            }
        }
    }
}