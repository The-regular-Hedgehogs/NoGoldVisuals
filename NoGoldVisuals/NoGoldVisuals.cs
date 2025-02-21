using BepInEx;
using R2API;
using RoR2;
using UnityEngine;

namespace NoGoldVisuals
{
    [BepInDependency(ItemAPI.PluginGUID)]
    [BepInDependency(LanguageAPI.PluginGUID)]
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]

    public class NoGoldVisuals : BaseUnityPlugin
    {
        public const string PluginGUID = PluginAuthor + "." + PluginName;
        public const string PluginAuthor = "The-regular-Hedgehogs";
        public const string PluginName = "NoGoldVisuals";
        public const string PluginVersion = "1.1.1";

        public void Awake()
        {
            On.RoR2.EffectManager.SpawnEffect_GameObject_EffectData_bool += DisableGoldEffect;
        }

        private void DisableGoldEffect(On.RoR2.EffectManager.orig_SpawnEffect_GameObject_EffectData_bool orig, GameObject effectPrefab, EffectData effectData, bool transmit)
        {

            if (effectPrefab == null)
            {
                orig(effectPrefab, effectData, transmit);
                return;
            }

            if (effectPrefab.name == "CoinEmitter")
            {
                return;
            }

            orig(effectPrefab, effectData, transmit);
        }
    }
}
