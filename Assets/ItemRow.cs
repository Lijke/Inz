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
            SetText(GamePrefs.GetInstance().goldCount.ToString());
            break;
         case CategoryType.AdsPopout:
            SetText(GamePrefs.GetInstance().adsPopout.ToString());
            break;
         case CategoryType.BuildingUpgrade:
            SetText(GamePrefs.GetInstance().buildingUpgradeCount.ToString());
            break;
         case CategoryType.BuildingDelayUpgrade:
            SetText(GamePrefs.GetInstance().buildingDelayUpgradeCount.ToString());
            break;
         case CategoryType.TotalTimeInGame:
            SetText(Mathf.Round(GamePrefs.GetInstance().totalTimeInGame).ToString());
            break;
      }
   }

   private void SetText(string val){
      value.text = val;
   }
}
