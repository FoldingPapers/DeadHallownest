using System.Linq;
using System.Reflection;
using UnityEngine;
using Modding;
using UnityEngine.SceneManagement;
using UObject = UnityEngine.Object;

// ReSharper disable once CheckNamespace
namespace ExampleMod1
{
    // ReSharper disable once UnusedMember.Global
    public class DeadHallownest : Mod
    {
        // ReSharper disable once NotAccessedField.Global
        // ReSharper disable once MemberCanBePrivate.Global
        internal static DeadHallownest Instance;

        public override string GetVersion() => "0.0.3";

        public override void Initialize()
        {
            // Instance = this;

            // Log("Initializing");

            UnityEngine.SceneManagement.SceneManager.activeSceneChanged += NewRoom;
            ModHooks.Instance.NewGameHook += NewGame;
            ModHooks.Instance.LanguageGetHook += Description;

            Log("Initialized");
        }


        private static readonly string[] TO_DESTROY =
        {
            "Battle Gate",
            "Bone Gate",
            "Plant Trap",
            "Worm",
            "Zap Cloud",
            "Big Centipede",
            "Mage Door",
            "Pigeon",
            "Hornet",
            "Quirrel",
            "Geo Rock",
            "Toll Gate",
            "Heart Piece",
            "Vessel Fragment",
            "Banker Spa",
            "Moss Cultist",
            "Miner",
            "Myla",
        };

        private static string Description(string key, string sheet)
        {
            if (sheet != "Cornifer") return Language.Language.GetInternal(key, sheet);
            switch (key)
            {
                case "CARD":
                    return
                        @"I'm leaving this note, hoping someone will come across it. This place is emtpy, and has been such for a long time.



I suggest you turn back and go, for there is nothing for you down here. But if you truly wish to, continue exploring deeper. 







...Perhaps you will find something I've missed...";
                default:
                    return Language.Language.GetInternal(key, sheet);
            }
        }

        private void NewGame()
        {
            Log("why?");
            foreach (FieldInfo fi in typeof(PlayerData).GetFields(BindingFlags.Instance | BindingFlags.Public))
            {
                // cache tolower
                string name = fi.Name.ToLower();

                if (name.Contains("defeated"))
                {
                    if (fi.FieldType == typeof(bool))
                    {
                        fi.SetValue(PlayerData.instance, true);
                        continue;
                    }

                    if (fi.FieldType == typeof(int))
                    {
                        fi.SetValue(PlayerData.instance, 2);
                        continue;
                    }

                    Log($"This shouldn't be happening. {fi.Name}");
                }

                if (fi.FieldType == typeof(bool) &&
                    (
                        name.Contains("killed") ||
                        name.Contains("cloth") ||
                        name.Contains("collected") ||
                        name.Contains("dreamreward") ||
                        name.Contains("corn_"))
                )
                {
                    fi.SetValue(PlayerData.instance, true);
                }
            }

            // cg2
            PlayerData.instance.killsMegaBeamMiner = 2;

            //other things - setting Zote, the Nailsmith and Quirrel to dead, getting rid of any appearance of the Dreamers and removing Cornifer
            PlayerData.instance.dreamerScene1 = true;
            PlayerData.instance.fountainGeo = 3000;

            #region NPCs
            PlayerData.instance.zoteRescuedBuzzer = false;
            PlayerData.instance.zoteDead = true;
            PlayerData.instance.zoteDeathPos = 1;
            PlayerData.instance.quirrelEpilogueCompleted = true;
            PlayerData.instance.dungDefenderSleeping = true;
            PlayerData.instance.legEaterLeft = true;
            PlayerData.instance.bankerTheft = 2;
            PlayerData.instance.bankerTheftCheck = true;
            PlayerData.instance.tisoDead = true;
            PlayerData.instance.mossCultist = 2;
            PlayerData.instance.cultistTransformed = true;
            PlayerData.instance.metCharmSlug = true;
            PlayerData.instance.slugEncounterComplete = true;
            PlayerData.instance.xunRewardGiven = true;
            #endregion
            
            #region NailsmithDed
            PlayerData.instance.metNailsmith = true;
            PlayerData.instance.nailsmithCliff = true;
            PlayerData.instance.nailsmithKilled = true;
            PlayerData.instance.nailsmithSpared = false;
            PlayerData.instance.nailsmithKillSpeech = true;
            PlayerData.instance.honedNail = true;
            #endregion

            #region Go Away Seer
            PlayerData.instance.mothDeparted = true;
            PlayerData.instance.dreamNailConvo = true;
            PlayerData.instance.dreamNailUpgraded = true;
            PlayerData.instance.dreamMothConvo1 = true;
            #endregion
        }

        private static void NewRoom(Scene arg0, Scene arg1)
        {
            Modding.Logger.Log("H");
            foreach (GameObject go in UObject.FindObjectsOfType<GameObject>())
            {
                //enemies
                if (go.layer == 11 ||
                    go.name.Contains("Audio") && go.name.Contains("Centipede") ||
                    TO_DESTROY.Any(s => go.name.Contains(s)))
                {
                    Modding.Logger.Log("REEEE " + go.name);
                    UObject.Destroy(go);
                    continue;
                }

                if (!go.name.Contains("centipede_pit")) continue;
                Animator anim = go.GetComponent<Animator>();

                Modding.Logger.Log("HHEEE" + go.name);
                UObject.Destroy(anim);
            }
        }
    }
}