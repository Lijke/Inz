using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BuildingLogicManagerV2 : MonoBehaviour{
    public List<BuildingLogic> activeItemsPrefabs;
    public List<BuildingLogic> spawnedItems;
    
    public Transform buildingTransform;
    public static BuildingLogicManagerV2 Instace;
    public void Start(){
        Instace = this;
        SpawnAllUnlockedItems();
    }

    private void SpawnAllUnlockedItems(){
        int maxLevelBuildingId = 0;
        for (var index = 0; index < activeItemsPrefabs.Count; index++){
            var item = activeItemsPrefabs[index];
            if (item.buildingUnlocked){
               var obj = Instantiate(item, buildingTransform);
               var objLogic = obj.GetComponent<BuildingLogic>();
               spawnedItems.Add(objLogic);
               if (objLogic != null){
                   objLogic.SetupBuildingUi(item.buildingUnlocked);
               }
            }

            maxLevelBuildingId = index+1;
            break;
        }

        SpawnNextUnlockedBuilding(maxLevelBuildingId);
    }

    private void SpawnNextUnlockedBuilding(int nextBuildingId){
        var obj = Instantiate(activeItemsPrefabs[nextBuildingId], buildingTransform);
        var objScript = obj.GetComponent<BuildingLogic>();
        objScript.SetupBuildingUi(activeItemsPrefabs[nextBuildingId].buildingUnlocked);
    }


    public void SpawnNextItem(ItemSO item){
        for (int i = 0; i < activeItemsPrefabs.Count; i++){
            if (item == activeItemsPrefabs[i].item){
                activeItemsPrefabs[i+1].SetupBuildingUi(false);
                return;
            }
        }
    }
}
