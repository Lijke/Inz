using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using UnityEngine;

public class BuildingLogic : MonoBehaviour{
  public ItemSO item;
  public float currentDuration;
  private float currentGoldPerDuration;
  public GoldContainer goldContainer;
  public bool buildingUnlocked;
  [SerializeField] private bool speedUp;
  CancellationTokenSource cts = new CancellationTokenSource();
  private void Start(){
    cts = new CancellationTokenSource();
    item.SetCurrentDuration();
    currentDuration = item.currentDuration;
    currentGoldPerDuration = item.currentPrice;

    GenerateGold(cts);
  }
  
  private void Awake(){
    GameEvents.onDurationLevelUp += UpdateDurationTime;
  }

  private void OnDestroy(){
    GameEvents.onDurationLevelUp -= UpdateDurationTime;
  }
  
  public void SetupBuildingUi(bool isUnlocked){
    buildingUnlocked = isUnlocked;
    BuildingUiManager.Instance.SetupNextItem(item, isUnlocked, currentDuration, this);
  }

  private void UpdateDurationTime(ItemSO itemSo){
    currentDuration = item.currentDuration;
  }


  
  public async UniTask GenerateGold(CancellationTokenSource cts){
    while (true && buildingUnlocked){

      await UniTask.Delay(TimeSpan.FromSeconds(currentDuration),cancellationToken: cts.Token);
     
      if (goldContainer != null){
        currentGoldPerDuration = item.currentPrice;
        goldContainer.AddGold(currentGoldPerDuration);
#if UNITY_EDITOR
        Debug.Log($"{currentGoldPerDuration} item: {GetType().Name}");
#endif
      }
      else{
#if UNITY_EDITOR
        Debug.LogError($"Gold container null in {GetType().Name}");
#endif
      }
      
    }
  }


  public void Unlock(ItemSO item){
    buildingUnlocked = true;
    BuildingUiManager.Instance.SetUnlockedUI(item);
    BuildingLogicManagerV2.Instace.SpawnNextItem(item);
    GenerateGold(cts);
  }


  public void SpeedUp(){
    if (cts != null){
      cts.Cancel();
      cts.Dispose();
      GiveGold();
    }
    currentDuration /= 2;
    speedUp = true;
    cts = new CancellationTokenSource();
    GenerateGold(cts);
  }


  private void GiveGold(){
    currentGoldPerDuration = item.currentPrice;
    goldContainer.AddGold(currentGoldPerDuration);
  }


  public void BackToNormal(){
    currentDuration *= 2;
    speedUp = false;
  }

  [Button()]
  public void test(){
    currentDuration /= 2;
  }


  public void BreakAsyncWhile(){
    cts.Cancel();
  }
}
