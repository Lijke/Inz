using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour{
    public delegate void OnAddGold();
    public static event OnAddGold onAddGold;

    public delegate void OnAddsReport(bool val);
    public static event OnAddsReport onAdvReport;

    public static void AdvReport(bool val){
        onAdvReport?.Invoke(val);
    }

    public static  void AddGold() {
        if (onAddGold != null) {
            onAddGold?.Invoke();
        }
    }
    
    public delegate void OnLevelUp(ItemSO item);

    public static event OnLevelUp onLevelUp;

    public static void LevelUp(ItemSO item){
        onLevelUp?.Invoke(item);
    }
    
    public delegate void OnDurationLevelUP(ItemSO item);

    public static event OnDurationLevelUP onDurationLevelUp;

    public static void DurationLevelUp(ItemSO item){
        onDurationLevelUp?.Invoke(item);
    }

    public delegate void OnAdsEarnedReward();

    public static event OnAdsEarnedReward onAdsEarnedReward;

    public static void AdsEarnedReward(){
        onAdsEarnedReward?.Invoke();
    }

    public delegate void OnDoubleGoldEvent(AdEventType adEventType, float boostTime);

    public static event OnDoubleGoldEvent onEventStarted;


    public static void EventStarted(AdEventType adEventType, float boostTime){
        onEventStarted?.Invoke(adEventType,boostTime);
    }
}
