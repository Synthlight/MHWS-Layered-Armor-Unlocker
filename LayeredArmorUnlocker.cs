/*
 * Layered Armor Unlocker
 * By LordGregory
 */

using System;
using app;
using app.savedata;
using ImGuiNET;
using Layered_Armor_Unlocker.Assets;
using REFrameworkNET;
using REFrameworkNET.Attributes;
using REFrameworkNET.Callbacks;

// ReSharper disable once CheckNamespace
namespace LordGregory.Mods.Layered_Armor_Unlocker;

// ReSharper disable once UnusedType.Global
public class LayeredArmorUnlocker {
    // ReSharper disable once UnusedType.Global
    // ReSharper disable once UnusedMember.Global
    [Callback(typeof(ImGuiDrawUI), CallbackType.Pre)]
    public static void ImGuiCallback() {
        if (API.IsDrawingUI() && ImGui.TreeNode("Layered Armor Unlocker")) {
            UnlockPlayerLayeredArmor();
            UnlockPlayerValidLayeredArmor();
            LockPlayerLayeredArmor();
            IndividualPlayerUnlocks();
            UnlockOtomoLayeredArmor();
            UnlockOtomoValidLayeredArmor();
            LockOtomoLayeredArmor();
            IndividualOtomoUnlocks();
            ImGui.TreePop();
        }
    }

    private static void UnlockPlayerLayeredArmor() {
        if (ImGui.Button("Unlock All Player Layered Armor in Current Save")) {
            var equipParam        = GetEquipParam();
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

    private static void UnlockPlayerValidLayeredArmor() {
        if (ImGui.Button("Unlock Valid Player Layered Armor in Current Save")) {
            var equipParam   = GetEquipParam();
            var genderValues = Enum.GetValues<CharacterDef.GENDER>();

            foreach (var (series, parts) in DataHelper.VALID_PLAYER_ARMOR) {
                foreach (var part in parts) {
                    foreach (var gender in genderValues) {
                        if (gender == CharacterDef.GENDER.NOTHING) continue;
                        equipParam.setOuterArmorFlag(part, series, gender, true);
                    }
                }
            }
        }
    }

    private static void LockPlayerLayeredArmor() {
        if (ImGui.Button("Lock All Player Layered Armor in Current Save")) {
            var equipParam        = GetEquipParam();
            var armorPartsValues  = Enum.GetValues<ArmorDef.ARMOR_PARTS>();
            var armorSeriesValues = Enum.GetValues<ArmorDef.SERIES>();
            var genderValues      = Enum.GetValues<CharacterDef.GENDER>();

            foreach (var series in armorSeriesValues) {
                if (series is ArmorDef.SERIES.NONE or ArmorDef.SERIES.MAX) continue;
                foreach (var part in armorPartsValues) {
                    if (part == ArmorDef.ARMOR_PARTS.MAX) continue;
                    foreach (var gender in genderValues) {
                        if (gender == CharacterDef.GENDER.NOTHING) continue;
                        equipParam.setOuterArmorFlag(part, series, gender, false);
                    }
                }
            }
        }
    }

    private static void IndividualPlayerUnlocks() {
        if (ImGui.TreeNode("Unlock Player Armor Individually by Name")) {
            foreach (var (name, series) in DataHelper.PLAYER_ARMOR_SERIES_BY_NAME) {
                if (!DataHelper.VALID_PLAYER_ARMOR.TryGetValue(series, out var parts)) continue;
                if (ImGui.Button($"Unlock {name.StripGreek()} in Current Save")) {
                    var equipParam   = GetEquipParam();
                    var genderValues = Enum.GetValues<CharacterDef.GENDER>();

                    foreach (var part in parts) {
                        foreach (var gender in genderValues) {
                            if (gender == CharacterDef.GENDER.NOTHING) continue;
                            equipParam.setOuterArmorFlag(part, series, gender, true);
                        }
                    }
                }
            }
            ImGui.TreePop();
        }
    }

    private static void UnlockOtomoLayeredArmor() {
        if (ImGui.Button("Unlock All Palico Layered Armor in Current Save")) {
            var equipParam      = GetEquipParam();
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

    private static void UnlockOtomoValidLayeredArmor() {
        if (ImGui.Button("Unlock Valid Palico Layered Armor in Current Save")) {
            var equipParam = GetEquipParam();

            foreach (var (series, parts) in DataHelper.VALID_OTOMO_ARMOR) {
                foreach (var part in parts) {
                    equipParam.setOtomoOuterArmorFlag(part, series, true);
                }
            }
        }
    }

    private static void LockOtomoLayeredArmor() {
        if (ImGui.Button("Lock All Palico Layered Armor in Current Save")) {
            var equipParam      = GetEquipParam();
            var equipTypeValues = Enum.GetValues<OtEquipDef.EQUIP_TYPE>();
            var equipIdValues   = Enum.GetValues<OtEquipDef.EQUIP_DATA_ID>();

            foreach (var equipId in equipIdValues) {
                if (equipId is OtEquipDef.EQUIP_DATA_ID.NONE or OtEquipDef.EQUIP_DATA_ID.MAX) continue;
                foreach (var type in equipTypeValues) {
                    if (type is OtEquipDef.EQUIP_TYPE.MAX or OtEquipDef.EQUIP_TYPE.WEAPON) continue;
                    equipParam.setOtomoOuterArmorFlag(type, equipId, false);
                }
            }
        }
    }

    private static void IndividualOtomoUnlocks() {
        if (ImGui.TreeNode("Unlock Palico Armor Individually by Name")) {
            foreach (var (name, series) in DataHelper.OTOMO_ARMOR_SERIES_BY_NAME) {
                if (!DataHelper.VALID_OTOMO_ARMOR.TryGetValue(series, out var parts)) continue;
                if (ImGui.Button($"Unlock {name.StripGreek()} in Current Save")) {
                    var equipParam = GetEquipParam();

                    foreach (var part in parts) {
                        equipParam.setOtomoOuterArmorFlag(part, series, true);
                    }
                }
            }
            ImGui.TreePop();
        }
    }

    private static cEquipParam GetEquipParam() {
        var saveDataManager = API.GetManagedSingletonT<SaveDataManager>();
        var userSaveParam   = saveDataManager.getCurrentUserSaveData();
        var equipParam      = userSaveParam._Equip;
        return equipParam;
    }
}