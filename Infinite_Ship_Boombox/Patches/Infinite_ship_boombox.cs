using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameNetcodeStuff;
using HarmonyLib;

namespace Infinite_Ship_Boombox.Patches
{
    [HarmonyPatch(typeof(BoomboxItem))]
    internal class Infinite_ship_boombox
    {
        [HarmonyPatch("Update")]
        [HarmonyPrefix]
        static void patch_func(ref bool ___isInShipRoom, ref Item ___itemProperties, ref PlayerControllerB ___playerHeldBy)
        {
            if (___isInShipRoom || (___playerHeldBy != null && ___playerHeldBy.isInHangarShipRoom))
            {
                ___itemProperties.requiresBattery = false;
            }
            else
            {
                ___itemProperties.requiresBattery = true;
            }
        }

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void patch_func(ref Item ___itemProperties)
        {
            ___itemProperties.requiresBattery = true;
        }
    }
}
 