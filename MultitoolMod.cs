using MelonLoader;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using Multitool;
using UnityEngine;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

[assembly: MelonInfo(typeof(MultitoolMod), Multitool.ModHelperData.Name, Multitool.ModHelperData.Version, Multitool.ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace Multitool;

class MultitoolMod : BloonsTD6Mod
{
    public override void OnUpdate()
    {
        base.OnUpdate();
        bool inActiveGame = InGame.instance != null && InGame.instance.bridge != null;
        if (inActiveGame)
        {
            if (Input.GetKeyDown(KeyCode.F6))
            {
                Il2CppSystem.Action<int> wantedRound = (Il2CppSystem.Action<int>)delegate (int newRound)
                { if (newRound > 0) { InGame.instance.bridge.SetRound(newRound - 1); } };

                PopupScreen.instance.ShowSetValuePopup("Round",
                    "What would you like to set the round to?", wantedRound, 3);
            }

            if (Input.GetKeyDown(KeyCode.F7))
            {
                Il2CppSystem.Action<int> wantedMoney = (Il2CppSystem.Action<int>)delegate (int newMoney)
                { InGame.instance.bridge.SetCash(newMoney); };

                PopupScreen.instance.ShowSetValuePopup("Cash",
                    "What would you like to set your cash to?", wantedMoney, 650);
            }

            if (Input.GetKeyDown(KeyCode.F8))
            {
                Il2CppSystem.Action<int> wantedHealth = (Il2CppSystem.Action<int>)delegate (int newHealth)
                { InGame.instance.bridge.SetSandboxHealth(newHealth); };

                PopupScreen.instance.ShowSetValuePopup("Lives",
                    "What would you like to set your health to?", wantedHealth, 100);
            }
        }
    }
} 