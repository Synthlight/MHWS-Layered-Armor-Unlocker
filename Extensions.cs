/*
 * Layered Armor Unlocker
 * By LordGregory
 */

namespace LordGregory.Mods.Layered_Armor_Unlocker;

// ReSharper disable once UnusedType.Global
// ReSharper disable once UnusedMember.Global
public static class Extensions {
    public static string StripGreek(this string name) {
        return name.Replace("α", "[Alpha]")
                   .Replace("β", "[Beta]")
                   .Replace("γ", "[Gamma]");
    }
}