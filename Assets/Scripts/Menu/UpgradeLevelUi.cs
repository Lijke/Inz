using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeLevelUi : MonoBehaviour{
    public ItemSO item;
    public GoldContainer goldContainer;
    public TextMeshProUGUI buttonText;
    public void Init(ItemSO itemSo){
        item = itemSo;
        buttonText.text = GetNextLevelCost().ToString();
    }

    public float GetNextLevelCost(){
        return (item.currentLevel+1) * item.baseCost;
    }

    float GetCurrentLevelCost(){
        return item.currentLevel * item.baseCost;
    }
    
    public void LevelUp(){
        if (goldContainer.GetCurrentGold() > GetNextLevelCost()){
            item.LevelUp();
            UpdateButtonText();
            goldContainer.SubstractGold(GetCurrentLevelCost());
        }
    }

    public void UpdateButtonText(){
        buttonText.text = GetNextLevelCost().ToString();
    }
}
