using HarmonyLib;
using Reptile;

namespace KeepMyCharacter.Patches
{
    internal class Patch_KeepCharacter : HarmonyPatch
    {
        [HarmonyPatch(typeof(ProgressObject), "SetPlayerAsCharacter", typeof(Characters))]
        public static class ProgressObject_SetPlayerAsCharacter_Patch
        {
            public static void Prefix(ref Characters character)
            {
                character = GetCurrentCharacter();
            }
        }

        [HarmonyPatch(typeof(ProgressObject), "SetPlayerAsCharacter", typeof(string))]
        public static class ProgressObject_SetPlayerAsCharacter_String_Patch
        {
            public static void Prefix(ref string character)
            {
                character = GetCurrentCharacter().ToString();
            }
        }

        [HarmonyPatch(typeof(Encounter), "SetPlayerAsCharacter")]
        public static class Encounter_SetPlayerAsCharacter_Patch
        {
            public static void Prefix(ref Characters character)
            {
                character = GetCurrentCharacter();
            }
        }

        [HarmonyPatch(typeof(NPC), "SetPlayerAsHeadmanWithJetpack")]
        public static class NPC_SetPlayerAsHeadmanWithJetpack_Patch
        {
            public static bool Prefix()
            {
                return false;
            }
        }

        [HarmonyPatch(typeof(CharacterVisual), "Init")]
        public static class CharacterVisual_Init_Patch
        {
            public static void Prefix(ref Characters character)
            {
                character = GetCurrentCharacter();
            }
        }

        private static Characters GetCurrentCharacter()
        {
            Player player = WorldHandler.instance?.GetCurrentPlayer();

            if (player != null)
                return player.GetValue<Characters>("character");

            return default;
        }
    }
}
