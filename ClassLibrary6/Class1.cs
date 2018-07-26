using System;
using System.Collections.Generic;
using System.Reflection;
using System.Collections;
using UnityEngine;
using GlobalEnums;
using Modding;
using UnityEngine.SceneManagement;

namespace ExampleMod1
{

    public class DeadHallownest : Mod
    {
        internal static DeadHallownest Instance;

        public override string GetVersion() => "0.0.3";

        public override void Initialize()
        {

            Instance = this;

            Log("Initializing");

            UnityEngine.SceneManagement.SceneManager.activeSceneChanged += NewRoom;

            ModHooks.Instance.NewGameHook += NewGame;

            ModHooks.Instance.LanguageGetHook += Description;

            Log("Initialized");
        }

        private string Description(string key, string sheet)
        {
            string ret = Language.Language.GetInternal(key, sheet);
            if (sheet == "Cornifer")
            {
                switch (key)
                {
                     case "CARD":
                        ret = @"I'm leaving this note, hoping someone will come across it. This place is emtpy, and has been such for a long time.



I suggest you turn back and go, for there is nothing for you down here. But if you truly wish to, continue exploring deeper. 







...Perhaps you will find something I've missed...";
                        break;
                }
            }
            return ret;
        }
        private void NewGame()
        {
            //bosses
            PlayerData.instance.collectorDefeated = true;
            PlayerData.instance.defeatedDungDefender = true;
            PlayerData.instance.defeatedMantisLords = true;
            PlayerData.instance.defeatedMegaBeamMiner = true;
            PlayerData.instance.defeatedMegaBeamMiner2 = true;
            PlayerData.instance.killedMegaBeamMiner = true;
            PlayerData.instance.killsMegaBeamMiner = 2;
            PlayerData.instance.defeatedMegaJelly = true;
            PlayerData.instance.defeatedNightmareGrimm = true;
            PlayerData.instance.falseKnightDefeated = true;
            PlayerData.instance.falseKnightDreamDefeated = true;
            PlayerData.instance.flukeMotherDefeated = true;
            PlayerData.instance.giantBuzzerDefeated = true;
            PlayerData.instance.giantFlyDefeated = true;
            PlayerData.instance.hornet1Defeated = true;
            PlayerData.instance.hornetOutskirtsDefeated = true;
            PlayerData.instance.killedInfectedKnight = true;
            PlayerData.instance.infectedKnightDreamDefeated = true;
            PlayerData.instance.mageLordDefeated = true;
            PlayerData.instance.mageLordDreamDefeated = true;
            PlayerData.instance.mawlekDefeated = true;
            PlayerData.instance.megaMossChargerDefeated = true;
            PlayerData.instance.zoteDefeated = true;
            PlayerData.instance.duskKnightDefeated = true;
            PlayerData.instance.greyPrinceDefeated = true;
            PlayerData.instance.whiteDefenderDefeated = true;
            PlayerData.instance.killedBlackKnight = true;
            PlayerData.instance.killedMimicSpider = true;
            //ghosts
            PlayerData.instance.galienDefeated = 2;
            PlayerData.instance.markothDefeated = 2;
            PlayerData.instance.noEyesDefeated = 2;
            PlayerData.instance.xeroDefeated = 2;
            PlayerData.instance.aladarSlugDefeated = 2;
            PlayerData.instance.mumCaterpillarDefeated = 2;
            PlayerData.instance.guardiansDefeated = 2;
            //the remaining "defeated" ones
            PlayerData.instance.blocker1Defeated = true;
            PlayerData.instance.blocker2Defeated = true;
            PlayerData.instance.defeatedDoubleBlockers = true;
            PlayerData.instance.duskKnightDefeated = true;

            //other things - setting Zote, the Nailsmith and Quirrel to dead, getting rid of any appearance of the Dreamers and removing Cornifer
            PlayerData.instance.dreamerScene1 = true;
            PlayerData.instance.mageLordOrbsCollected = true;
            PlayerData.instance.falseKnightOrbsCollected = true;
            PlayerData.instance.greyPrinceOrbsCollected = true;
            PlayerData.instance.infectedKnightOrbsCollected = true;
            PlayerData.instance.whiteDefenderOrbsCollected = true;
            PlayerData.instance.fountainGeo = 3000;

            //NPCs
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

            #region Cloth
            PlayerData.instance.metCloth = true;
            PlayerData.instance.savedCloth = true;
            PlayerData.instance.clothEnteredTramRoom = true;
            PlayerData.instance.clothLeftTown = true;
            PlayerData.instance.clothInTown = true;
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
            PlayerData.instance.dreamReward1 = true;
            PlayerData.instance.dreamReward2 = true;
            PlayerData.instance.dreamReward3 = true;
            PlayerData.instance.dreamReward4 = true;
            PlayerData.instance.dreamReward5 = true;
            PlayerData.instance.dreamReward5b = true;
            PlayerData.instance.dreamReward6 = true;
            PlayerData.instance.dreamReward7 = true;
            PlayerData.instance.dreamReward8 = true;
            PlayerData.instance.dreamReward9 = true;
            PlayerData.instance.dreamMothConvo1 = true;
            #endregion

            #region GettingRidOfPeskyCornifer
            PlayerData.instance.corn_abyssEncountered = true;
            PlayerData.instance.corn_abyssLeft = true;
            PlayerData.instance.corn_cityEncountered = true;
            PlayerData.instance.corn_cityLeft = true;
            PlayerData.instance.corn_cliffsEncountered = true;
            PlayerData.instance.corn_cliffsLeft = true;
            PlayerData.instance.corn_crossroadsEncountered = true;
            PlayerData.instance.corn_crossroadsLeft = true;
            PlayerData.instance.corn_deepnestEncountered = true;
            PlayerData.instance.corn_deepnestMet1 = true;
            PlayerData.instance.corn_deepnestMet2 = true;
            PlayerData.instance.corn_deepnestLeft = true;
            PlayerData.instance.corn_fogCanyonEncountered = true;
            PlayerData.instance.corn_fogCanyonLeft = true;
            PlayerData.instance.corn_fungalWastesEncountered = true;
            PlayerData.instance.corn_fungalWastesLeft = true;
            PlayerData.instance.corn_greenpathEncountered = true;
            PlayerData.instance.corn_greenpathLeft = true;
            PlayerData.instance.corn_minesEncountered = true;
            PlayerData.instance.corn_minesLeft = true;
            PlayerData.instance.corn_outskirtsEncountered = true;
            PlayerData.instance.corn_outskirtsLeft = true;
            PlayerData.instance.corn_royalGardensEncountered = true;
            PlayerData.instance.corn_royalGardensLeft = true;
            PlayerData.instance.corn_waterwaysEncountered = true;
            PlayerData.instance.corn_waterwaysLeft = true;
            #endregion
        }

        private void NewRoom(Scene arg0, Scene arg1)
        {

            GameObject[] gos = GameObject.FindObjectsOfType<GameObject>();

            foreach (var go in gos)
            {
                //enemies
                if (go.layer == 11)
                {
                    UnityEngine.Object.Destroy(go);
                }
                //Those Challenge Doors you see most of the time
                if (go.name.Contains("Battle Gate"))
                {
                    UnityEngine.Object.Destroy(go);
                }
                //a Bunch more of the challenge doors, like the Ancestral Mound one and in Greenpath
                if (go.name.Contains("Bone Gate"))
                {
                    UnityEngine.Object.Destroy(go);
                }
                //Enemies that are on the Enviromental Hazards layer (layer 17)
                //Fool Eater
                if (go.name.Contains("Plant Trap"))
                {
                    UnityEngine.Object.Destroy(go);
                }
                //Goams
                if (go.name.Contains("Worm"))
                {
                    UnityEngine.Object.Destroy(go);
                }
                //Charged Lumaflies
                if (go.name.Contains("Zap Cloud"))
                {
                    UnityEngine.Object.Destroy(go);
                }
                //Garpedes
                if (go.name.Contains("Big Centipede"))
                {
                    UnityEngine.Object.Destroy(go);
                }
                //Well, because you usually get the Elegant Key from Sly, but Sly is getting removed, so is and the door that requires the Elegant key
                if (go.name.Contains("Mage Door"))
                {
                    UnityEngine.Object.Destroy(go);
                }
                //Because Those Pesky Maskfly Pidgeons aren't on layer 11 for some reason
                if (go.name.Contains("Pigeon"))
                {
                    UnityEngine.Object.Destroy(go);
                }
                //Because Hornet appears here and there and doesn't want to be removed (grrrmpf)
                if (go.name.Contains("Hornet"))
                {
                    UnityEngine.Object.Destroy(go);
                }
                //same for Quirrel
                if (go.name.Contains("Quirrel"))
                {
                    UnityEngine.Object.Destroy(go);
                }
                //Geo rocks because you don't need Geo
                if (go.name.Contains("Geo Rock"))
                {
                    UnityEngine.Object.Destroy(go);
                }
                //Toll Maschines because you DO need Geo but I already removed 99% of it 
                if (go.name.Contains("Toll Gate"))
                {
                    UnityEngine.Object.Destroy(go);
                }
                //You don't need more masks, do you?
                if (go.name.Contains("Heart Piece"))
                {
                    UnityEngine.Object.Destroy(go);
                }
                //Nor the Soul Vessels
                if (go.name.Contains("Vessel Fragment"))
                {
                    UnityEngine.Object.Destroy(go);
                }
                //Uhh
                if (go.name.Contains("centipede_pit"))
                {
                    Animator anim = go.GetComponent<Animator>();

                    UnityEngine.Object.Destroy(anim);
                }

                #region NPCs
                //I have no idea why she didn't want to die
                if (go.name.Contains("Banker Spa"))
                {
                    UnityEngine.Object.Destroy(go);
                }
                //Moss Prophet YEET
                if (go.name.Contains("Moss Cultist"))
                {
                    UnityEngine.Object.Destroy(go);
                }
                //Making Myla the big dead
                if (go.name.Contains("Miner"))
                {
                    UnityEngine.Object.Destroy(go);
                }
                if (go.name.Contains("Myla"))
                {
                    UnityEngine.Object.Destroy(go);
                }
                #endregion

                if (go.name.Contains("Audio") && go.name.Contains("Centipede"))
                {
                    UnityEngine.Object.Destroy(go);
                }
            }
        }



        }


    }
