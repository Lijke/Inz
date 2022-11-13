using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
public enum  AdEventType{
    SpeedUp =0,
    DoubleGold =1
}
public class DoubleGold : MonoBehaviour{
    [SerializeField] private float boostTime;
    [SerializeField] private float cost;
    public TextMeshProUGUI adCost_TMP;

    private void Awake(){
        adCost_TMP.text = cost.ToString();
    }

    public void StartDoubleGold(){
        if (GoldContainer.Instance.CanBuyByPremium(cost)){
            ChangeGoldMultiplayerValue();
                GameEvents.EventStarted(AdEventType.DoubleGold, boostTime);
        }
    }


    private void ChangeGoldMultiplayerValue(){
        GoldContainer.Instance.goldMultiplayer = 2;
        CalculateTime();
    }

    public void SetDefaultGoldMultiplayer(){
        GoldContainer.Instance.goldMultiplayer = 1;
    }

    private async UniTaskVoid CalculateTime(){
        float timer = boostTime;
        while (timer > 0){
           await UniTask.NextFrame();
            timer -= Time.deltaTime;
        }
        SetDefaultGoldMultiplayer();
    }
}
