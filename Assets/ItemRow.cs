using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemRow : MonoBehaviour{
   public TextMeshProUGUI itemName;
   public TextMeshProUGUI value;

   public void LoadValue(CategoryType categoryType){
      switch (categoryType){
         case CategoryType.Gold:
            SetText(GamePrefs.statisticInfo.goldCount.ToString());
            break;
         case CategoryType.AdsPopout:
            SetText(GamePrefs.statisticInfo.adsPopout.ToString());
            break;
         case CategoryType.BuildingUpgrade:
            SetText(GamePrefs.statisticInfo.buildingUpgradeCount.ToString());
            break;
         case CategoryType.BuildingDelayUpgrade:
            SetText(GamePrefs.statisticInfo.buildingDelayUpgradeCount.ToString());
            break;
         case CategoryType.TotalTimeInGame:
            SetText(Mathf.Round(GamePrefs.statisticInfo.totalTimeInGame).ToString());
            break;
      }
   }

   private void SetText(string val){
      value.text = val;
   }
}
