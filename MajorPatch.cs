using HarmonyLib;
using Sannabi._03.Scripts.Jaeyun.Boss;
using UnityEngine;

namespace TooManyBosses.Patches
{
    public class MajorPatch
    {
        public static int majorNumber = 3;
        public static bool isInstitated = false;

        [HarmonyPatch(typeof(Major), "OnEnable")]
        [HarmonyPrefix]
        static void Major_Prefix()
        {
            GameObject originalMajor = GameObject.Find("Pref_Major_Bundle");
            if (originalMajor == null)
            {
                Plugin.Log.LogError("Error: No Major Song in scene.");
            }
            else if (!isInstitated)
            {
                isInstitated = true;
                GameObject bundle = new GameObject("Major_Bundle");
                for (int i = 2; i <= majorNumber; i++)
                {
                    GameObject gameobject = Object.Instantiate<GameObject>(originalMajor, originalMajor.transform.parent);
                    if (gameobject == null)
                    {
                        Plugin.Log.LogError("Failed to instiate Major number " + i);
                    }
                    else
                    {
                        Plugin.Log.LogInfo("Successfully instiated Major number " + i);
                        gameobject.name = "Cloned_Major(" + i + ")";
                        gameobject.transform.parent = bundle.transform;
                    }
                }
            }
        }
    }
}