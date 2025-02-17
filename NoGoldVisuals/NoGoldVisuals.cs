using BepInEx;
using R2API;
using RoR2;

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
        public const string PluginVersion = "1.0.4";

        public void Awake()
        {
            On.RoR2.DeathRewards.OnKilledServer += DisableGoldEffect;
        }

        private void DisableGoldEffect(On.RoR2.DeathRewards.orig_OnKilledServer orig, DeathRewards self, DamageReport damageReport)
        {

            if (self.goldReward != 0)
            {
                TeamManager.instance.GiveTeamMoney(damageReport.attackerTeamIndex, self.goldReward);
                TeamManager.instance.GiveTeamExperience(damageReport.attackerTeamIndex, (ulong)self.expReward);
            }
            else
            {
                orig.Invoke(self, damageReport);
            }
        }
    }
}
