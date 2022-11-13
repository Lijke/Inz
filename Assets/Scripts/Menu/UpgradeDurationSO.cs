using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "UpgradeSO")]
public class UpgradeDurationSO : ScriptableObject{
    public string upgradeHeader;
    public string upgradeDescription;
    public Sprite upgradeImage;
    public List<int> expectedLevel; 
    public int currentExpectedLevel;
    public List<int> durationTime;
    public float GetNextDurationCost(float baseGold){
        if (currentExpectedLevel == expectedLevel.Count - 1){
            return 0;
        }
        return  expectedLevel[currentExpectedLevel] * baseGold / 5;
    }

    public void Upgrade(){
        if (currentExpectedLevel == expectedLevel.Count -1 ){
            return;
            
        }
        currentExpectedLevel++;
    }

    public float GetCurrentDurationTimer(){
        return durationTime[currentExpectedLevel];
    }
}


