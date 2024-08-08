using BepInEx;
using HarmonyLib;

namespace KeepMyCharacter
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
        public const string pluginGuid      = "ninjacookie.brc.keepmycharacter";
        public const string pluginName      = "KeepMyCharacter";
        public const string pluginVersion   = "1.0.1";

        public void Awake()
        {
            var harmony = new Harmony(pluginGuid);
            harmony.PatchAll();
        }
    }
}
