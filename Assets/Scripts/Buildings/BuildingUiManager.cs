using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class BuildingUiManager : MonoBehaviour{
   public static BuildingUiManager Instance;

   public List<BuildingUiItem> spawnedBuildingsUI = new List<BuildingUiItem>();
   //Spwaning
   public GameObject buildingPrefab;
   public Transform spawnTransform;
   
   
   private void Awake(){
      if (Instance ==  null){
         Instance = this;
      }
   }
   
   public void SetupNextItem(ItemSO item, bool unlocked , BuildingLogic buildingLogic){
      var obj = Instantiate(buildingPrefab, spawnTransform);
      var objScript = obj.GetComponent<BuildingUiItem>();
      spawnedBuildingsUI.Add(objScript);
      objScript.item = item;
      BuildingStatus status = unlocked ? BuildingStatus.Unlocked : BuildingStatus.Lock;
      objScript.SetupStatus(status, item.currentDuration);
      objScript.InitLogic(buildingLogic);
   }

   public void SetUnlockedUI(ItemSO item){
      foreach (var building in spawnedBuildingsUI){
         if (building.item == item){
            building.SetupStatus(BuildingStatus.Unlocked, item.currentDuration);
         }
      }
   }


   public void SpeedUpAllBuildings(){
      foreach (var buildingUiItem in spawnedBuildingsUI){
         buildingUiItem.SpeedUp();
      }
   }


   public void BackToNormalAllBuildings(){
      foreach (var buildingUiItem in spawnedBuildingsUI){
         buildingUiItem.BackToNormal();
      }
   }
}
