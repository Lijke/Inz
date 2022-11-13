using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "GoldContainerSo")]
public class GoldContainer : ScriptableObject{
    public float currentGold;
    public float currentPremiumCurrency;
    public static GoldContainer Instance;
    public float goldMultiplayer;
    
    
    public void AddGold(float gold){
        if (goldMultiplayer == 0){
            goldMultiplayer = 1;
        }
#if UNITY_EDITOR
        Debug.Log($"golda added : {gold} gold multiplayer {goldMultiplayer}");
#endif
        currentGold += gold*goldMultiplayer;
        GamePrefs.statisticInfo.goldCount += currentGold;
        GameEvents.AddGold();
        UiGoldManager.Instance.UpdateText(TypeOfGold.gold, currentGold.ToString());
    }

    public float GetCurrentGold(){
        return currentGold;
    }

    public void SubstractGold(float spentGold){
        currentGold -= spentGold;
        GameEvents.AddGold();
    }

    public bool CanBuyByGold(float cost){
        return currentGold >= cost;
    }

    public bool CanBuyByPremium(float cost){
        return currentPremiumCurrency >= cost;
    }


    public void Init(){
        Instance = this;
    }


    public void AddPremiumCurrency(int givenAmmount){
        currentPremiumCurrency += givenAmmount;
        UiGoldManager.Instance.UpdateText(TypeOfGold.premium, currentPremiumCurrency.ToString());
    }


    public void SubstractPremiumVal(float cost){
        currentPremiumCurrency -= cost;
    }
}
