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

    private void Awake(){
        goldMultiplayer = 1;
    }

    public void AddGold(float gold){
        if (goldMultiplayer == 0){
            goldMultiplayer = 1;
        }
        
        currentGold += gold*goldMultiplayer;
        #if UNITY_EDITOR    
        Debug.Log(currentGold);
        #endif
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
}
