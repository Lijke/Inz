using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "ItemSO")]
public class ItemSO : ScriptableObject{
    public float currentPrice;
    public float currentDuration;
    public float currentLevel;
    public string itemName;
    [TextArea(5, 20)] 
    public string description;

    public float baseCost;
    public float index;

    public UpgradeDurationSO upgradeDurationSO;

    public bool maxLevelReached;


    public void LevelUp(){
        currentLevel += 1;
        GamePrefs.statisticInfo.buildingUpgradeCount++;
        UpgradeGoldPerDuration();
        GameEvents.LevelUp(this);
    }
    [Button()]
    public void UpgradeGoldPerDuration(){
        currentPrice = baseCost * currentLevel;
    }

    public void SetCurrentDuration(){
        currentDuration = upgradeDurationSO.GetCurrentDurationTimer();
        GameEvents.DurationLevelUp(this);
    }
    public void MaxLevelReached(){
        GameEvents.LevelUp(this);
        maxLevelReached = true;
    }

    public float GetUnlockedGoldValue(){
        return currentPrice;
    }


   
}


