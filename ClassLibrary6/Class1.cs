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

        public override string GetVersion() => "0.0.1";

        public override void Initialize()
        {

            Instance = this;

            Log("Initializing");

            UnityEngine.SceneManagement.SceneManager.activeSceneChanged += NewRoom;

            ModHooks.Instance.NewGameHook += NewGame;
            Log("Initialized");
        }

        private void NewGame()
        {
            //bosses
            PlayerData.instance.collectorDefeated = true;
            PlayerData.instance.defeatedDungDefender = true;
            PlayerData.instance.defeatedMantisLords = true;
            PlayerData.instance.defeatedMegaBeamMiner = true;
            PlayerData.instance.defeatedMegaBeamMiner2 = true;
            PlayerData.instance.defeatedMegaJelly = true;
            PlayerData.instance.defeatedNightmareGrimm = true;
            PlayerData.instance.falseKnightDefeated = true;
            PlayerData.instance.falseKnightDreamDefeated = true;
            PlayerData.instance.flukeMotherDefeated = true;
            PlayerData.instance.giantBuzzerDefeated = true;
            PlayerData.instance.giantFlyDefeated = true;
            PlayerData.instance.hornet1Defeated = true;
            PlayerData.instance.hornetOutskirtsDefeated = true;
            PlayerData.instance.infectedKnightDreamDefeated = true;
            PlayerData.instance.mageLordDefeated = true;
            PlayerData.instance.mageLordDreamDefeated = true;
            PlayerData.instance.mawlekDefeated = true;
            PlayerData.instance.megaMossChargerDefeated = true;
            PlayerData.instance.zoteDefeated = true;
            PlayerData.instance.duskKnightDefeated = true;
            PlayerData.instance.greyPrinceDefeated = true;
            PlayerData.instance.whiteDefenderDefeated = true;
            //ghosts
            PlayerData.instance.galienDefeated = 2;
            PlayerData.instance.markothDefeated = 2;
            PlayerData.instance.noEyesDefeated = 2;
            PlayerData.instance.xeroDefeated = 2;
            PlayerData.instance.aladarSlugDefeated = 2;
            PlayerData.instance.mumCaterpillarDefeated = 2;
            PlayerData.instance.guardiansDefeated = 2;
            //the remaining ones
            PlayerData.instance.blocker1Defeated = true;
            PlayerData.instance.blocker2Defeated = true;
            PlayerData.instance.defeatedDoubleBlockers = true;
            PlayerData.instance.duskKnightDefeated = true;

            //other things - setting Zote, the Nailsmith and Quirrel to dead, getting rid of any appearance of the Dreamers and removing Cornifer
            PlayerData.instance.quirrelEpilogueCompleted = true;
            PlayerData.instance.nailsmithKilled = true;
            PlayerData.instance.dreamerScene1 = true;
            PlayerData.instance.zoteDead = true;
            PlayerData.instance.clothLeftTown = true;
            #region gettingridofPeskyCornifer
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
                    

                }
  

        }
    }

}