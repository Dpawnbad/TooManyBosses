using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.Logging;
using HarmonyLib;
using TooManyBosses.Patches;

namespace TooManyBosses
{
    [BepInPlugin("mod.sanabi.tomb", "TooManyBosses", "0.0.7")]
    public class Plugin : BasePlugin
    {
        internal static new ManualLogSource Log;
        public override void Load()
        {
            Harmony.CreateAndPatchAll(typeof(MajorPatch));
            Log = base.Log;
            Log.LogInfo($"Plugin TooManyBosses is loaded!");
        }
    }
}
