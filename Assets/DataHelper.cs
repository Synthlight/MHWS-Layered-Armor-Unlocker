/*
 * Layered Armor Unlocker
 * By LordGregory
 */

using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using app;

namespace Layered_Armor_Unlocker.Assets;

public static class DataHelper {
    public static readonly Dictionary<ArmorDef.SERIES, List<ArmorDef.ARMOR_PARTS>>           VALID_PLAYER_ARMOR          = LoadDict<ArmorDef.SERIES, List<ArmorDef.ARMOR_PARTS>>(Assets.ValidPlayerArmor);
    public static readonly Dictionary<string, ArmorDef.SERIES>                               PLAYER_ARMOR_SERIES_BY_NAME = LoadDict<string, ArmorDef.SERIES>(Assets.PlayerArmorSeriesByName);
    public static readonly Dictionary<OtEquipDef.EQUIP_DATA_ID, List<OtEquipDef.EQUIP_TYPE>> VALID_OTOMO_ARMOR           = LoadDict<OtEquipDef.EQUIP_DATA_ID, List<OtEquipDef.EQUIP_TYPE>>(Assets.ValidOtomoArmor);
    public static readonly Dictionary<string, OtEquipDef.EQUIP_DATA_ID>                      OTOMO_ARMOR_SERIES_BY_NAME  = LoadDict<string, OtEquipDef.EQUIP_DATA_ID>(Assets.OtomoArmorSeriesByName);

    public static Dictionary<K, V> LoadDict<K, V>(byte[] data) where K : notnull {
        var json = Encoding.UTF8.GetString(data);
        return JsonSerializer.Deserialize<Dictionary<K, V>>(json)!;
    }
}