using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeDurationUi : MonoBehaviour{
   public TextMeshProUGUI header;
   public TextMeshProUGUI description; 
   public Image upgradeItem;
   public TextMeshProUGUI buttonText;
   private ItemSO item;
   private GoldContainer goldContainer;
   private float baseCost;
   public void Init(ItemSO item, GoldContainer goldContainer, float baseCost){
      this.item = item;
      this.goldContainer = goldContainer;
      this.baseCost = baseCost;
   }



   public void SetUpgrade(){
      header.text = item.upgradeDurationSO.upgradeHeader;
      description.text = item.upgradeDurationSO.upgradeDescription;
      upgradeItem.sprite = item.upgradeDurationSO.upgradeImage;
      buttonText.text = item.upgradeDurationSO.GetNextDurationCost(baseCost).ToString();
   }

   public void Upgrade(){
      if (item.upgradeDurationSO.GetNextDurationCost(item.baseCost) == 0){
         item.MaxLevelReached();
         buttonText.text = "Max level";
         return;
      }
      if (goldContainer.GetCurrentGold() > item.upgradeDurationSO.GetNextDurationCost(item.baseCost) ){
         GamePrefs.statisticInfo.buildingDelayUpgradeCount++;
         var cost = item.upgradeDurationSO.GetNextDurationCost(item.baseCost);
         goldContainer.SubstractGold(cost);
         //koszt ulepszenie zwiększany
         item.upgradeDurationSO.Upgrade();
         item.SetCurrentDuration();
         buttonText.text = item.upgradeDurationSO.GetNextDurationCost(baseCost).ToString();
         GameEvents.DurationLevelUp(item);

      }
   }
}
