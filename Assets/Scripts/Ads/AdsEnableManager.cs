using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;
using UnityEngine.UI;


public class AdsEnableManager : MonoBehaviour{
  [Header("Min and max time to show ads image")]
  public Vector2 animShowTime;
  [FormerlySerializedAs("anieDelayTime")] [Header("Delay between each ads ")]
  public Vector2 animDelayTime;
  
  public float timer;
  public float adsEnableTime;
  public List<Sprite> adsSprite;
  public Image currentSprite;

  public AdsManager_UIImage adsManagerUIImage;
  private AdsPaymanceType m_currentAdPaymanceType;
  public AdsRewardHandler adsRewardHandler;
  private void Awake(){
    adsManagerUIImage.Disable();
    PickAnimDurationTime();
    GameEvents.onAdsEarnedReward += ResetAds;
  }


  private void ResetAds(){
    timer = -1;
    adsManagerUIImage.Disable();
    PickAnimDurationTime();
  }


  private void PickTypeOfAd(){
    var adsEnumCount = Enum.GetValues(typeof(AdsPaymanceType)).Length-1;
    var adsInt = Random.Range(0, adsEnumCount+1);
    switch (adsInt){
      case 0:
        m_currentAdPaymanceType = AdsPaymanceType.Gold;
        break;
      case 1:
        m_currentAdPaymanceType = AdsPaymanceType.PremiumCurrency;
        break;
    }

    currentSprite.sprite = adsSprite[(int)m_currentAdPaymanceType-1];
    adsRewardHandler.currentAdsPaymanceType = m_currentAdPaymanceType;
  }


  private void PickAnimDurationTime(){
    adsEnableTime = Random.Range(animDelayTime.x, animDelayTime.y);
    WaitForAnimTime();
  }


  private async UniTask WaitForAnimTime(){
    while (adsEnableTime > 0){
      adsEnableTime -= Time.deltaTime;
      await UniTask.NextFrame();
    }

    ShowAdImage();
  }


  private async UniTask ShowAdImage(){
    adsManagerUIImage.Enable();
    PickTypeOfAd();
    timer = PickAnimShowTime();
    while (timer > 0){
      timer -= Time.deltaTime;
      await UniTask.NextFrame();
    }
    adsManagerUIImage.Disable();
    PickAnimDurationTime();
  }


  private float PickAnimShowTime(){
    return Random.Range(animShowTime.x, animShowTime.y);
  }
}
